using OOD.Objects;
using System.Text;

namespace OOD.Factories
{
    public class BinaryCrewFactory : IBinaryFactory
	    {
		    public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                ushort nameLength = reader.ReadUInt16();
                string name = Encoding.ASCII.GetString(reader.ReadBytes(nameLength));
                ushort age = reader.ReadUInt16();
                string phone = Encoding.ASCII.GetString(reader.ReadBytes(12));
                ushort emailLength = reader.ReadUInt16();
                string email = Encoding.ASCII.GetString(reader.ReadBytes(emailLength));
                ushort practice = reader.ReadUInt16();
                char role = reader.ReadChar();
                
                return new Crew((long)id, name, age, phone, email, (short)practice, role.ToString());
            }

        }

        public class BinaryPassengerFactory : IBinaryFactory
        {
            public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                ushort nameLength = reader.ReadUInt16();
                string name = Encoding.ASCII.GetString(reader.ReadBytes(nameLength));
                ushort age = reader.ReadUInt16();
                string phone = Encoding.ASCII.GetString(reader.ReadBytes(12));
                ushort emailLength = reader.ReadUInt16();
                string email = Encoding.ASCII.GetString(reader.ReadBytes(emailLength));
                char @class = reader.ReadChar();
                ulong miles = reader.ReadUInt64();
                
                return new Passenger((long)id, name, age, phone, email, @class.ToString(), (long)miles);
            }
        }

        public class BinaryCargoFactory : IBinaryFactory
        {
            public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                float weight = reader.ReadSingle();
                string code = Encoding.ASCII.GetString(reader.ReadBytes(6));
                ushort descriptionLength = reader.ReadUInt16();
                string description = Encoding.ASCII.GetString(reader.ReadBytes(descriptionLength));
                
                return new Cargo((long)id, weight, code, description);
            }
        }

        public class BinaryCargoPlaneFactory : IBinaryFactory
        {
            public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                // okazuje się, że serial nie ma 10 a 6 długości i ostatnie 4 to nulle
                string serial = Encoding.ASCII.GetString(reader.ReadBytes(6));
                reader.BaseStream.Position += 4;
                string country = Encoding.ASCII.GetString(reader.ReadBytes(3));
                ushort modelLength = reader.ReadUInt16();
                string model = Encoding.ASCII.GetString(reader.ReadBytes(modelLength));
                float maxLoad = reader.ReadSingle();
                
                return new CargoPlane((long)id, serial, country, model, maxLoad);
            }
        }

        public class BinaryPassengerPlaneFactory : IBinaryFactory
        {
            public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                string serial = Encoding.ASCII.GetString(reader.ReadBytes(6));
                reader.BaseStream.Position += 4;
                string country = Encoding.ASCII.GetString(reader.ReadBytes(3));
                ushort modelLength = reader.ReadUInt16();
                string model = Encoding.ASCII.GetString(reader.ReadBytes(modelLength));
                ushort firstClassSize = reader.ReadUInt16();
                ushort secondClassSize = reader.ReadUInt16();
                ushort economyClassSize = reader.ReadUInt16();
                
                return new PassengerPlane((long)id, serial, country, model, (short)firstClassSize, (short)secondClassSize, (short)economyClassSize);
            }
        }

        public class BinaryAirportFactory : IBinaryFactory
        {
            public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                ushort nameLength = reader.ReadUInt16();
                string name = Encoding.ASCII.GetString(reader.ReadBytes(nameLength));
                string code = Encoding.ASCII.GetString(reader.ReadBytes(3));
                float longitude = reader.ReadSingle();
                float latitude = reader.ReadSingle();
                float amsl = reader.ReadSingle();
                string country = Encoding.ASCII.GetString(reader.ReadBytes(3));
                
                return new Airport((long)id, name, code, longitude, latitude, amsl, country);
            }
        }

        public class BinaryFlightFactory : IBinaryFactory
        {
            public object Produce(MemoryStream stream)
            {
                using var reader = new BinaryReader(stream);
                reader.BaseStream.Position += 7;
                
                ulong id = reader.ReadUInt64();
                ulong originId = reader.ReadUInt64();
                ulong targetId = reader.ReadUInt64();
                ulong takeoffTimeMs = reader.ReadUInt64();
                DateTimeOffset baseTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
                DateTimeOffset takeoffTimeOffset = baseTime.AddMilliseconds(takeoffTimeMs);
                string takeoffTime = takeoffTimeOffset.ToString("HH:mm");
                ulong landingTimeMs = reader.ReadUInt64();
                DateTimeOffset landingTimeOffset = baseTime.AddMilliseconds(landingTimeMs);
                string landingTime = landingTimeOffset.ToString("HH:mm");
                ulong planeId = reader.ReadUInt64();
                ushort crewCount = reader.ReadUInt16();
                List<long> crewIds = [];
                for (var i = 0; i < crewCount; i++)
                {
                    crewIds.Add((long)reader.ReadUInt64());
                }
                ushort passengerCargoCount = reader.ReadUInt16();
                List<long> loadIds = [];
                for (var i = 0; i < passengerCargoCount; i++)
                { 
                    loadIds.Add((long)reader.ReadUInt64());
                }
                
                return new Flight((long)id, (long)originId, (long)targetId, takeoffTime, landingTime, float.MinValue, float.MinValue,
                    float.MinValue, (long)planeId, crewIds, loadIds);
            }
        }
}