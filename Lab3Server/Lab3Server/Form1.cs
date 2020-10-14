using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;


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

                ServerRequest request = JsonSerializer.Deserialize<ServerRequest>(clientData);

                if (request.ActionType == 0)
                {
                    AddWorker(request.Payload);
                } else if (request.ActionType == 1)
                {
                    GetWorkers(streamWriter);
                } else if (request.ActionType == 2)
                {
                    SearchWorker(request.Payload, streamWriter);
                } else if (request.ActionType == 3)
                {
                    DeleteWorker(request.Payload, streamWriter);
                } else if (request.ActionType == 4)
                {
                    SortBySalary(streamWriter);
                }
            }
        }

        private void SortBySalary(StreamWriter streamWriter)
        {
            string line;
            StreamReader reader = new StreamReader(@"E:\Лабы\7 сем\рис\Lab3\Lab3Server\text.txt");
            List<Worker> workers = new List<Worker>();

            while ((line = reader.ReadLine()) != null)
            {
                workers.Add(JsonSerializer.Deserialize<Worker>(line));
            }

            reader.Close();

            IEnumerable<Worker> query = workers.OrderBy(worker => worker.Salary);
            workers = query.ToList();
            reader.Close();
            streamWriter.Write(JsonSerializer.Serialize(workers));
        }

        private void DeleteWorker(string name, StreamWriter streamWriter)
        {
            string line;

            StreamReader reader = new StreamReader(@"E:\Лабы\7 сем\рис\Lab3\Lab3Server\text.txt");
            List<Worker> workers = new List<Worker>();

            while ((line = reader.ReadLine()) != null)
            {
                workers.Add(JsonSerializer.Deserialize<Worker>(line));
            }

            reader.Close();

            workers = workers.FindAll(worker => !worker.Name.Equals(name));

            string workersStr = JsonSerializer.Serialize(workers);

            streamWriter.Write(workersStr);

            File.WriteAllText(@"E:\Лабы\7 сем\рис\Lab3\Lab3Server\text.txt", workersStr);
        }

        private void SearchWorker(string payload, StreamWriter writer)
        {
            string line;
            List<Worker> workers = new List<Worker>();

            StreamReader reader = new StreamReader(@"E:\Лабы\7 сем\рис\Lab3\Lab3Server\text.txt");

            while ((line = reader.ReadLine()) != null)
            {
                workers.Add(JsonSerializer.Deserialize<Worker>(line));
            }

            workers = workers.FindAll(worker => worker.Name.Equals(payload));

            writer.Write(JsonSerializer.Serialize(workers));

            reader.Close();
        }

        private void GetWorkers(StreamWriter writer)
        {
            string line;
            List<Worker> workers = new List<Worker>();

            StreamReader reader = new StreamReader(@"E:\Лабы\7 сем\рис\Lab3\Lab3Server\text.txt");

            while ((line = reader.ReadLine()) != null)
            {
                workers.Add(JsonSerializer.Deserialize<Worker>(line));
            }

            writer.Write(JsonSerializer.Serialize(workers));

            reader.Close();
        }

        private void AddWorker(string worker)
        {
            FileStream fileStream = new FileStream(@"E:\Лабы\7 сем\рис\Lab3\Lab3Server\text.txt", FileMode.OpenOrCreate, FileAccess.Write);

            fileStream.Seek(0, SeekOrigin.End);

            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine(worker);
            streamWriter.Close();
            fileStream.Close();
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
