#nullable enable

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaBrowser.Common.Extensions
{
    /// <summary>
    /// Class BaseExtensions.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads all lines in the <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to read from.</param>
        /// <returns>All lines in the stream.</returns>
        public static string[] ReadAllLines(this Stream stream)
            => ReadAllLines(stream, Encoding.UTF8);

        /// <summary>
        /// Reads all lines in the <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to read from.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>All lines in the stream.</returns>
        public static string[] ReadAllLines(this Stream stream, Encoding encoding)
        {
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                return ReadAllLines(reader).ToArray();
            }
        }

        /// <summary>
        /// Reads all lines in the <see cref="StreamReader" />.
        /// </summary>
        /// <param name="reader">The <see cref="StreamReader" /> to read from.</param>
        /// <returns>All lines in the stream.</returns>
        public static IEnumerable<string> ReadAllLines(this StreamReader reader)
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
