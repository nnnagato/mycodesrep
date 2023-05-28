using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DateTimeServer
{
    public partial class MainWindow : Window
    {
        private UdpClient udpClient;
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public MainWindow()
        {
            InitializeComponent();
        }


        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int localPort;
            if (!int.TryParse(localPortTextBox.Text, out localPort))
            {
                MessageBox.Show("Invalid local port.");
                return;
            }

            int remotePort;
            if (!int.TryParse(remotePortTextBox.Text, out remotePort))
            {
                MessageBox.Show("Invalid remote port.");
                return;
            }

            IPAddress remoteAddress;
            if (!IPAddress.TryParse(remoteAddressTextBox.Text, out remoteAddress))
            {
                MessageBox.Show("Invalid remote address.");
                return;
            }

            try
            {
                udpClient = new UdpClient(localPort);
                tcpListener = new TcpListener(IPAddress.Any, localPort);
                tcpListener.Start();

                chatTextBox.AppendText($"Listening on port {localPort}...\n");

                while (true)
                {
                    UdpReceiveResult udpReceiveResult = await udpClient.ReceiveAsync();
                    string request = Encoding.UTF8.GetString(udpReceiveResult.Buffer);

                    chatTextBox.AppendText($"Received UDP request: {request}\n");

                    string response = GetResponse(request);

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    await udpClient.SendAsync(responseBytes, responseBytes.Length, udpReceiveResult.RemoteEndPoint);

                    chatTextBox.AppendText($"Sent UDP response: {response}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetResponse(string request)
        {
            switch (request)
            {
                case "date":
                    return DateTime.Now.ToString("dd.MM.yyyy");
                case "time":
                    return DateTime.Now.ToString("HH:mm:ss.fff");
                case "datetime":
                    return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
                default:
                    return "Specified command is not supported";
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (tcpClient == null)
            {
                try
                {
                    tcpClient = new TcpClient(remoteAddressTextBox.Text, int.Parse(remotePortTextBox.Text));
                    networkStream = tcpClient.GetStream();

                    chatTextBox.AppendText("Connected to server.\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            string message = messageTextBox.Text;
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            await networkStream.WriteAsync(messageBytes, 0, messageBytes.Length);

            chatTextBox.AppendText($"Sent message: {message}\n");

            byte[] buffer = new byte[1024];
            int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            chatTextBox.AppendText($"Received response: {response}\n");
        }
    }
}