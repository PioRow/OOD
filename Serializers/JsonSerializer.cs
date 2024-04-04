using OOD.Objects;

namespace OOD.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public void serialize(string file, ICollection<IMyObject> Objects)
        {
            string cwd = Directory.GetCurrentDirectory();
            using (StreamWriter sw = File.AppendText(file))
            {
                foreach (object obj in Objects)
                {

                    string ObjJson = System.Text.Json.JsonSerializer.Serialize(obj);
                    sw.WriteLine(ObjJson);
                }
            }
        }
    }

}
