using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace HomeWork6
{
    /// <summary>
    /// Simple client
    /// </summary>
    public class Client
    {
        private int port;
        private string host;

        /// <summary>
        /// Client constructor.
        /// </summary>
        /// <param name="host">Host name</param>
        /// <param name="port">Port name</param>
        public Client(string host, int port)
        {
            this.port = port;
            this.host = host;
        }

        /// <summary>
        /// Requests file downloading from the server.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public async Task GetAsync(string path, Stream fileStream)
        {
            var client = new TcpClient(host, port);
            using var stream = client.GetStream();

            var writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync($"2 {path}");
            var reader = new StreamReader(stream);
            var buffer = new char[long.MaxValue.ToString().Length + 1];
            var currentValue = '1';
            var currentIndex = 0;
            while (currentValue != ' ')
            {
                await reader.ReadAsync(buffer, currentIndex, 1);
                currentValue = buffer[currentIndex];
                if (currentValue == '-')
                {
                    await reader.ReadAsync(buffer, currentIndex, 1);
                    throw new ArgumentException("This file does not exist.");
                }
                currentIndex++;
            }
            await stream.CopyToAsync(fileStream);
            fileStream.Position = 0;
            writer.Dispose();
            reader.Dispose();
            stream.Dispose();
            client.Dispose();
        }

        /// <summary>
        /// Requests list of files in server's directory
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>(<name: String> <isDir: Boolean>)</returns>
        public async Task<List<(string, bool)>> ListAsync(string path)
        {
            var client = new TcpClient(host, port);
            using var stream = client.GetStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync($"1 {path}");
            var reader = new StreamReader(stream);
            var size = Convert.ToInt32(await reader.ReadLineAsync());

            if (size == -1)
            {
                return null;
            }

            var list = new List<(string, bool)>();

            for (int i = 0; i < size; i++)
            {
                var name = await reader.ReadLineAsync();
                var isDir = Convert.ToBoolean(await reader.ReadLineAsync());
                list.Add((name, isDir));
            }
            client.Dispose();
            stream.Dispose();
            writer.Dispose();
            reader.Dispose();
            return list;
        }
    }
}