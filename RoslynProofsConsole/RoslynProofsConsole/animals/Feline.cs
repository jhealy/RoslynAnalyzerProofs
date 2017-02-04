using System;
using System.IO;
using System.Runtime.Serialization;

namespace RoslynProofsConsole.animals
{
    public class Feline : ISerializable
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        // bad
        public static string Serialize(object obj)
        {
            StringWriter writer = new StringWriter();
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
