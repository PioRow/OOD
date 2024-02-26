using OOD.Deserializer;
using OOD.Objects;
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
            ReadFile(F);
        }
        public static void Test()
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
        public static void  ReadFile(string filename)
        {
            string path=Directory.GetCurrentDirectory();
            var deserializer = new FTRDeserializer();
            deserializer.deserialize(path + "\\" + filename);

        }
    }

}
