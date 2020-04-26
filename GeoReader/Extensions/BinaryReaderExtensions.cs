using System;
using System.IO;

namespace GeoReader.Extensions
{
    public static class BinaryReaderExtensions
    {
        public static string ReadString(this BinaryReader reader, int charCount)
        {
            return new string(reader.ReadChars(charCount)).TrimEnd('\0');
        }        
        
        public static DateTime ReadDateTime(this BinaryReader reader)
        {
            return DateTime.FromBinary((long)reader.ReadUInt64());
        }
    }
}