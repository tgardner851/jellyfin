#nullable disable
#pragma warning disable CS1591
#pragma warning disable SA1622 // GenericTypeParameterDocumentationMustHaveText

using System;
using System.IO;
using System.Threading.Tasks;

namespace MediaBrowser.Model.Serialization
{
    public interface IJsonSerializer
    {
        /// <summary>
        /// Serializes to stream.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="stream">The stream.</param>
        /// <exception cref="ArgumentNullException"><c>obj</c> is <c>null</c>.</exception>
        void SerializeToStream(object obj, Stream stream);

        /// <summary>
        /// Serializes to stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <param name="stream">The stream.</param>
        /// <exception cref="ArgumentNullException"><c>obj</c> is <c>null</c>.</exception>
        void SerializeToStream<T>(T obj, Stream stream);

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="file">The file.</param>
        /// <exception cref="ArgumentNullException"><c>obj</c> is <c>null</c>.</exception>
        void SerializeToFile(object obj, string file);

        /// <summary>
        /// Deserializes from file.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="file">The file.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="ArgumentNullException"><c>type</c> is <c>null</c>.</exception>
        object DeserializeFromFile(Type type, string file);

        /// <summary>
        /// Deserializes from file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file">The file.</param>
        /// <returns>``0.</returns>
        /// <exception cref="ArgumentNullException"><c>file</c> is <c>null</c>.</exception>
        T DeserializeFromFile<T>(string file)
            where T : class;

        /// <summary>
        /// Deserializes from stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns>``0.</returns>
        /// <exception cref="ArgumentNullException"><c>stream</c> is <c>null</c>.</exception>
        T DeserializeFromStream<T>(Stream stream);

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text">The text.</param>
        /// <returns>``0.</returns>
        /// <exception cref="ArgumentNullException"><c>text</c> is <c>null</c>.</exception>
        T DeserializeFromString<T>(string text);

        /// <summary>
        /// Deserializes from stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="ArgumentNullException"><c>stream</c> is <c>null</c>.</exception>
        object DeserializeFromStream(Stream stream, Type type);

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="ArgumentNullException"><c>json</c> is <c>null</c>.</exception>
        object DeserializeFromString(string json, Type type);

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException"><c>obj</c> is <c>null</c>.</exception>
        string SerializeToString(object obj);

        Task<object> DeserializeFromStreamAsync(Stream stream, Type type);

        Task<T> DeserializeFromStreamAsync<T>(Stream stream);
    }
}
