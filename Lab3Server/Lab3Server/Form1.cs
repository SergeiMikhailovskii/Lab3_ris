using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;



namespace Lab3Server
{
    public partial class Form1 : Form
    {

        private bool isRunning;
        private TcpListener tcpListener;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeTcp()
        {
            tcpListener = new TcpListener(IPAddress.Any, 5555);
            tcpListener.Start();
            isRunning = true;

            LoopClients();
        }

        private void LoopClients()
        {

            while (isRunning)
            {
                TcpClient newClient = tcpListener.AcceptTcpClient();
                Thread thread = new Thread(new ParameterizedThreadStart(HandleClient));
                thread.Start(newClient);
            }

        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            StreamWriter streamWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader streamReader = new StreamReader(client.GetStream(), Encoding.ASCII);

            bool isClientConnected = true;
            string clientData = null;

            while (isClientConnected)
            {
                clientData = streamReader.ReadLine();
                Console.WriteLine("Data: " + clientData);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeTcp();
        }
    }

    class Worker
    {
        private string name;
        private string position;
        private long salary;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetPosition()
        {
            return position;
        }

        public void SetPosition(string position)
        {
            this.position = position;
        }

        public long GetSalary()
        {
            return salary;
        }

        public void SetSalary(long salary)
        {
            this.salary = salary;
        }

        public Worker(string name, string position, long salary)
        {
            this.name = name;
            this.position = position;
            this.salary = salary;
        }
    }

    class ServerRequest
    {
        public int ActionType { get; set; }
        public string Payload { get; set; }
    }

    class ServerResponse
    {
        public string Response { get; set; }
    }

}
