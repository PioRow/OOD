using OOD.Deserializer;
using OOD.Objects;
using OOD.Serializers;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;
using NetworkSourceSimulator;
using FlightTrackerGUI;
namespace OOD
{

    public static partial class OODEntry
    {
        public static void Main(string[] args)
        {
            Ex2();   
        }
        public static void Ex2()
        {
            CLI.Init("example_data.ftr");
            CLI.Run();
        }
        
        
        public static void zad1()
        {
            string srcfile = "example_data.ftr";
            var objs = ReadFile(srcfile);
            string destfile = "data.json";
            SerializeObjects(destfile, objs);
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
                Console.WriteLine(nc.Id);
            }

        }
        public static List<IMyObject> ReadFile(string filename)
        {
            string path=Directory.GetCurrentDirectory();
            IDeserializer deserializer = new FTRDeserializer();
           return deserializer.deserialize(path + "\\" + filename);

        }
        public static void SerializeObjects(string file, ICollection<IMyObject> objects)
        {
            ISerializer serializer = new Serializers.JsonSerializer();
            serializer.serialize(file, objects);
        }
    }

}
