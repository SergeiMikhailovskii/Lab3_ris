using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab3Client
{
    public partial class Form1 : Form
    {

        private TcpClient client;

        private StreamReader reader;
        private StreamWriter writer;

        private bool isConnected;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 5555);

            HandleCommunication();
        }

        private void HandleCommunication()
        {
            reader = new StreamReader(client.GetStream(), Encoding.ASCII);
            writer = new StreamWriter(client.GetStream(), Encoding.ASCII);

            isConnected = true;
            ServerRequest serverRequest = new ServerRequest();
            serverRequest.ActionType = 0;
            serverRequest.Payload = "Test";

            string data = JsonSerializer.Serialize(serverRequest);

            while (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();
                } catch (IOException)
                {
                    
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
