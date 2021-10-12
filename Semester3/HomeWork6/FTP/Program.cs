using System;

namespace FTP
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var server = new Server("127.0.0.1", 8888);
            await server.Start();
        }
    }
}
