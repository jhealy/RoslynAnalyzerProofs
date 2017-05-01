using System;
using System.IO;
using System.Runtime.Serialization;

namespace RoslynProofsConsole.animals
{
    public class Feline : ISerializable
    {
        // spot the problem
        public static string Serialize(object obj)
        {
#pragma warning disable CC0001 // You should use 'var' whenever possible.
            StringWriter writer = new StringWriter();
#pragma warning restore CC0001 // You should use 'var' whenever possible.
            new SpecialFormatter().Serialize(writer, obj);
            return writer.ToString();
        }

        // good
        public  string SerializeBetter(object obj)
        {
            using (StringWriter writer = new StringWriter())
            {
                new SpecialFormatter().SerializeBetter(writer, obj);
                return writer.ToString();
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

    internal class SpecialFormatter
    {
        public SpecialFormatter()
        {
            System.Diagnostics.Debug.WriteLine(@"nothing happening");
        }

        public void Serialize(StringWriter writer, object obj) => 
            System.Diagnostics.Debug.WriteLine(@"nothing happening");

        public void  SerializeBetter(StringWriter writer, object obj) =>
            System.Diagnostics.Debug.WriteLine(@"nothing happening");
    }
}
