using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpClientExample
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Укажите необходимый формат: \n 1:«ДД.ММ.ГГГГ» \n 2:ЧЧ:ММ:СС.ЗЗЗ» \n 3:«ДД.ММ.ГГГГ ЧЧ:ММ:СС.ЗЗЗ»");
            int serverPort = 2023;
            string serverAddress = "127.0.0.1";

            UdpClient udpClient = new UdpClient();
            while (true)
            {
                int a = int.Parse(Console.ReadLine());
                if (a == 0) break;
                string request="";

                switch(a)
                {                                          
                    case 1:
                        request = "date";
                        break;

                    case 2:
                        request = "time";
                        break;
                    case 3:
                        request = "datetime";
                        break;

                }

                byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                await udpClient.SendAsync(requestBytes, requestBytes.Length, serverAddress, serverPort);

                UdpReceiveResult udpReceiveResult = await udpClient.ReceiveAsync();
                string response = Encoding.UTF8.GetString(udpReceiveResult.Buffer);

                Console.WriteLine($"Received response: {response}");
            }
            udpClient.Close();
        }
    }
}