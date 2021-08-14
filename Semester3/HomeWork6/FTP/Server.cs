using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FTP
{
    /// <summary>
    /// Simple server
    /// </summary>
    public class Server
    {
        private int port;
        private TcpListener listener;
        private CancellationTokenSource cancellationTokenSource = new();
        private List<Task> tasks = new();

        /// <summary>
        /// Server constructor
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="port">port name</param>
        public Server(string host, int port)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(host), port);
        }

        /// <summary>
        /// Start the server.
        /// </summary>
        /// <returns><size: Int> (<name: String> <isDir: Boolean>)</returns>
        public async Task Start()
        {
            listener.Start();
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync();
                tasks.Add(Task.Run(() => Work(client)));
            }
            var task = Task.WhenAll(tasks);
            task.Wait();
            listener.Stop();
        }

        /// <summary>
        /// Stop the server.
        /// </summary>
        public void Stop() => cancellationTokenSource.Cancel();

        /// <summary>
        /// Server process
        /// </summary>
        /// <param name="client">Tcp client</param>
        private async Task Work(TcpClient client)
        {
            using var stream = client.GetStream();
            using var reader = new StreamReader(stream);
            using var writer = new StreamWriter(stream) { AutoFlush = true };
            var data = await reader.ReadLineAsync();
            var (command, path) = ParseData(data);

            switch (command)
            {
                case "1":
                    await List(path, writer);
                    break;

                case "2":
                    await Get(path, writer);
                    break;

                default:
                    throw new ArgumentException("Command error.");
            }
        }

        /// <summary>
        /// Data parsing.
        /// </summary>
        /// <param name="data">String with command and path</param>
        /// <returns>Command and path</returns>
        private (string, string) ParseData(string data) => (data.Split()[0], data.Split()[1]);

        /// <summary>
        /// Comand list.
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <param name="writer">Stream writer</param>
        /// <returns><size: Int> (<name: String> <isDir: Boolean>)</returns>
        private async Task List(string path, StreamWriter writer)
        {
            if (!Directory.Exists(path))
            {
                await writer.WriteLineAsync("-1");
                return;
            }

            var files = Directory.GetFiles(path);
            var directories = Directory.GetDirectories(path);
            await writer.WriteLineAsync(Convert.ToString(directories.Length + files.Length));

            foreach (var file in files)
            {
                await writer.WriteLineAsync(file);
                await writer.WriteLineAsync("false");
            }

            foreach (var directory in directories)
            {
                await writer.WriteLineAsync(directory);
                await writer.WriteLineAsync("true");
            }
        }

        /// <summary>
        /// Comand get.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="writer">Stream writer</param>
        /// <returns><size: Long> <content: Bytes></returns>
        private async Task Get(string path, StreamWriter writer)
        {
            if (!File.Exists(path))
            {
                await writer.WriteLineAsync("-1");
                return;
            }
            await writer.WriteAsync($"{new FileInfo(path).Length} ");
            using var fileStream = File.OpenRead(path);
            await fileStream.CopyToAsync(writer.BaseStream);
        }
    }
}