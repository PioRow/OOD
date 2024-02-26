using OOD.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Deserializer
{
    public interface IDeserializer
    {
        public  List<object> deserialize(string filepath);
    }
    public class FTRDeserializer:IDeserializer
    {
        Dictionary<string, IFTRFactory> Factories;
        public FTRDeserializer()
        {
             Factories = new Dictionary<string, IFTRFactory>
            {
                { "AI", new FTRAirportFactory() },
                 {"P",new FTRPassengerFactory() },
                 {"C",new FTRCrewFactory() },
                 {"CA", new FTRCargoFactory() },
                 {"CP", new FTRCargoPlaneFactory() },
                 {"PP",new FTRPassengerPlaneFactory() },
                 {"FL", new FTRFlightFactory() }
            };
        }
        public List<object> deserialize(string filepath)
        {
            List<object> result = new List<object>();
            
            String line;
            using (StreamReader sr = new StreamReader(filepath))
            {
                line=sr.ReadLine();
                while (line != null) { 
                    string[] fields = line.Split(",");
                    object o = Factories[fields[0]].Produce(fields);
                    Console.WriteLine(o);
                    result.Add(o);
                    line = sr.ReadLine();
                }
            }
            return result;
        }
    }
}
