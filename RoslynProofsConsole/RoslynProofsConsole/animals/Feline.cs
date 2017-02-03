using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public static string SerializeBetter(object obj)
        {
            using (StringWriter writer = new StringWriter())
            {
                SpecialFormatter.SerializeBetter(writer, obj);
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

        public static void SerializeBetter(StringWriter writer, object obj) =>
            System.Diagnostics.Debug.WriteLine(@"nothing happening");
    }
}
