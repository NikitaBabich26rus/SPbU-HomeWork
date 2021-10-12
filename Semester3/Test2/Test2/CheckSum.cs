using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    /// <summary>
    /// Class for calculating check sum.
    /// </summary>
    public class CheckSum
    {
        /// <summary>
        /// Сalculate the sum in a single thread
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>Sum</returns>
        public byte[] SingleThreaded(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new InvalidDataException();
            }
            using (var md5 = MD5.Create())
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path, "*").OrderBy(x => x).ToArray();
                    var str = Path.GetFileName(Path.GetDirectoryName(path));
                    foreach (var file in files)
                    {
                        str += Encoding.ASCII.GetString(SingleThreaded(file));
                    }
                    return md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                }
                else
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return md5.ComputeHash(stream);
                    }
                }
            }
        }

        /// <summary>
        ///  Сalculate the sum in a multiple thread
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Sum</returns>
        public async Task<byte[]> MultipleThreaded(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new InvalidDataException();
            }
            using (var md5 = MD5.Create())
            {
                if (Directory.Exists(path))
                {
                    var filesArray = Directory.GetFiles(path, "*").OrderBy(x => x).ToArray();
                    var str = Path.GetFileName(Path.GetDirectoryName(path));
                    foreach (var file in filesArray)
                    {
                        str += await MultipleThreaded(file);
                    }
                    return md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                }
                else
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return md5.ComputeHash(stream);
                    }
                }
            }
        }
    }
}