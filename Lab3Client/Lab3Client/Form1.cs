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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddWorker_Click(object sender, EventArgs e)
        {

        }

        private void AddWorker_Click_1(object sender, EventArgs e)
        {
            Worker worker = new Worker(Name.Text, Position.Text, long.Parse(Salary.Text));
            string workerData = JsonSerializer.Serialize(worker);

            ServerRequest request = new ServerRequest
            {
                ActionType = 0,
                Payload = workerData
            };

            string data = JsonSerializer.Serialize(request);

            if (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();
                }
                catch (IOException)
                {

                }

            }

        }
    }

    class Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public long Salary { get; set; }

        public Worker(string name, string position, long salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
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
