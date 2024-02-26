using OOD.Deserializer;
using OOD.Objects;
using OOD.Serializers;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;
using System.Xml.Serialization;
namespace OOD
{
    public static class OODEntry
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("[74;104;111;297;315;310;314]".Substring(1, "[74;104;111;297;315;310;314]".Length - 2));
            string F = "example_data.ftr";
            var objs=ReadFile(F);
            SerializeObjects("data.json", objs);

        }
        public static void SerializationExample()
        {

            Crew c = new Crew(1, "Agata", 20, "609509939", "agata.steciuk.stud@pw.edu.pl", 12, "Studnetka");
            Crew Kawa = new Crew(2, "Kawa", 19, "530908935", "wiktoria.kawa.stud@pw.edu.pl", 18, "studentka");
            XmlSerializer ser = new XmlSerializer(typeof(Crew));
            using (StreamWriter sw = new StreamWriter("data.xml"))
            {

                ser.Serialize(sw, c);
            }
            using (StreamReader sr = new StreamReader("data.xml"))
            {
                Crew nc = (Crew)ser.Deserialize(sr);
                Console.WriteLine(nc.getid());
            }

        }
        public static List<object> ReadFile(string filename)
        {
            string path=Directory.GetCurrentDirectory();
            IDeserializer deserializer = new FTRDeserializer();
           return deserializer.deserialize(path + "\\" + filename);

        }
        public static void SerializeObjects(string file, ICollection<object> objects)
        {
            ISerializer serializer = new Serializers.JsonSerializer();
            serializer.serialize(file, objects);
        }
    }

}
