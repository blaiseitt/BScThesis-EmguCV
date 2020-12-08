using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Terminal_3._4._3_noCuda
{
    enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        //ECHO = 1,
        SGA = 3         //supress go-ahead
    }

    class TelnetProtocol
    {
        TcpClient telnetSocket;
        NetworkStream serverStream;

        public TelnetProtocol(string Hostname, int Port)
        {
            telnetSocket = new TcpClient();
            telnetSocket.Connect(Hostname, Port);
        }

        public bool IsConnected
        {
            get { return telnetSocket.Connected; }
        }

        public string DisplayServerResponse()
        {
            string response = Read();

            return response;
        }

        public string Read()
        {
            if (!telnetSocket.Connected) return null;
            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
            } while (telnetSocket.Available > 0);


            return sb.ToString();
        }

        public void Write(string cmd)
        {
            if (!telnetSocket.Connected) return;
            byte[] buf = Encoding.ASCII.GetBytes(cmd);
            telnetSocket.GetStream().Write(buf, 0, buf.Length);

            //telnetSocket.GetStream().Flush();
        }

        public void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        public void MessageToServer(byte[] messageToSend)
        {
            serverStream = telnetSocket.GetStream();
            //var bufsize = telnetSocket.ReceiveBufferSize;
            serverStream.Write(messageToSend, 0, messageToSend.Length);
            byte[] sentMsg = new byte[messageToSend.Length];

            for (int i = 0; i < messageToSend.Length; i++)
            {
                sentMsg[i] = (byte)serverStream.ReadByte();
            }

            //serverStream.Read(sentMsg, 0, messageToSend.Length);

            serverStream.Flush();
        }

        public void Disconnect()
        {
            telnetSocket.Close();
        }

        void ParseTelnet(StringBuilder sb)
        {
            while (telnetSocket.Available > 0)
            {
                int input = telnetSocket.GetStream().ReadByte();
                switch (input)
                {
                    //jeżeli odczytane zostały już wszystkie bajty to ReadByte przekazuje wartość -1 do zmiennej input
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        //w przypadku gdy bajt ma wartość 255 oznacza to IAC(Interpret as Command)
                        //jest on częścią dwu lub 3 bajtowej sekwencji, w przypadku dwu bajtowej sekwencji mamy do czynienia 
                        // z komendą obsługującą pewne pojedyńcze polecenie, natomiast 3 bajtowa sekwencja służy obsłudze
                        //negocji dotyczących opcji, przy czym czwarty bajt odnosi się opcji którą obejmują negocjacje
                        int inputverb = telnetSocket.GetStream().ReadByte();
                        //zakładamy że użytkownik nie będzie wysyłał pojedyńczych komend, dlatego jedyna ewentualność na jaką
                        //musimy się przygotować to 3bajtowa sekwencja, w której drugi element stanowi czasownik(verb)
                        if (inputverb == -1) break;
                        //ponowne sprawdzenie czy strumień nie został już przez przypadek w całości wyeksploatowany
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //2*bajt 255 po sobie interpretowany jest jako przekazanie 255 do bufora wyjściowego
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                //pobranie kolejnego bajtu ze strumienia, bajt ten z kolei dotyczy opcji jaka ma zostać obsłużona, następnie klasyka gatunku - sprawdzenie czy strumień przez przypadek się nie skońćczył
                                int inputoption = telnetSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;

                                telnetSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                {
                                    if ((inputverb == (int)Verbs.DO) || (inputverb == (int)Verbs.DONT)) telnetSocket.GetStream().WriteByte((byte)Verbs.WILL);
                                    else telnetSocket.GetStream().WriteByte((byte)Verbs.DO);
                                }
                                else
                                {
                                    if ((inputverb == (int)Verbs.DO) || (inputverb == (int)Verbs.DONT)) telnetSocket.GetStream().WriteByte((byte)Verbs.WONT);
                                    else telnetSocket.GetStream().WriteByte((byte)Verbs.DONT);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}
