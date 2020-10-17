using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Collections.Generic;

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
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 5555);

                HandleCommunication();
            } catch (SocketException)
            {
                Console.WriteLine("Server is not found");
            }

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

        private void ShowAll_Click(object sender, EventArgs e)
        {
            ServerRequest request = new ServerRequest
            {
                ActionType = 1,
            };

            string data = JsonSerializer.Serialize(request);

            if (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();

                    string serverResponse = reader.ReadLine();
                    WorkersArray workers = JsonSerializer.Deserialize<WorkersArray>(serverResponse);

                    string output = "";

                    workers.Workers.ForEach(worker =>
                    {
                        output += worker.Name + " " + worker.Position + " " + worker.Salary + "\r\n";
                    });

                    SearchAllOutput.Text = output;
                }
                catch (IOException)
                {

                }

            }

        }

        private void SearchByName_Click(object sender, EventArgs e)
        {
            ServerRequest request = new ServerRequest
            {
                ActionType = 2,
                Payload = WorkerName.Text
            };

            string data = JsonSerializer.Serialize(request);

            if (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();

                    string serverResponse = reader.ReadLine();
                    WorkersArray workers = JsonSerializer.Deserialize<WorkersArray>(serverResponse);

                    string output = "";

                    workers.Workers.ForEach(worker =>
                    {
                        output += worker.Name + " " + worker.Position + " " + worker.Salary + "\r\n";
                    });

                    SearchAllOutput.Text = output;
                }
                catch (IOException)
                {

                }

            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            ServerRequest request = new ServerRequest
            {
                ActionType = 3,
                Payload = WorkerName.Text
            };

            string data = JsonSerializer.Serialize(request);

            if (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();

                    string serverResponse = reader.ReadLine();
                    WorkersArray workers = JsonSerializer.Deserialize<WorkersArray>(serverResponse);

                    string output = "";

                    workers.Workers.ForEach(worker =>
                    {
                        output += worker.Name + " " + worker.Position + " " + worker.Salary + "\r\n";
                    });

                    SearchAllOutput.Text = output;
                }
                catch (IOException)
                {

                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerRequest request = new ServerRequest
            {
                ActionType = 4,
            };

            string data = JsonSerializer.Serialize(request);

            if (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();

                    string serverResponse = reader.ReadLine();
                    WorkersArray workers = JsonSerializer.Deserialize<WorkersArray>(serverResponse);

                    string output = "";

                    workers.Workers.ForEach(worker =>
                    {
                        output += worker.Name + " " + worker.Position + " " + worker.Salary + "\r\n";
                    });

                    SearchAllOutput.Text = output;
                }
                catch (IOException)
                {

                }

            }

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Worker newWorker = new Worker(NewName.Text, NewPosition.Text, long.Parse(NewSalary.Text));
            EditWorkerRequest editWorkerRequest = new EditWorkerRequest
            {
                NewWorker = newWorker,
                OldName = OldName.Text
            };

            ServerRequest request = new ServerRequest
            {
                ActionType = 5,
                Payload = JsonSerializer.Serialize(editWorkerRequest)                
            };

            string data = JsonSerializer.Serialize(request);

            if (isConnected)
            {
                try
                {
                    writer.WriteLine(data);
                    writer.Flush();

                    string serverResponse = reader.ReadLine();
                    WorkersArray workers = JsonSerializer.Deserialize<WorkersArray>(serverResponse);

                    string output = "";

                    workers.Workers.ForEach(worker =>
                    {
                        output += worker.Name + " " + worker.Position + " " + worker.Salary + "\r\n";
                    });

                    SearchAllOutput.Text = output;
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

    class WorkersArray
    {
        public List<Worker> Workers { get; set; }
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

    class EditWorkerRequest
    {
        public string OldName { get; set; }
        public Worker NewWorker { get; set; }
    }

}
