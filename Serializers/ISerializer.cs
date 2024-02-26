using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Serializers
{
    public interface ISerializer
    {
        public void serialize(string file, ICollection<object> Objects);
    }
    public class JsonSerializer : ISerializer
    {
        public void serialize(string file, ICollection<object> Objects)
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
