using OOD.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Factories
{
    public interface IBinaryFactory
    {
        public IMyObject produce(byte[] data);
    }
    public class AirportBinaryFactory : IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NCR = Encoding.ASCII.GetString(data, 0, 3);
            uint FML = BitConverter.ToUInt32(data, 3);
            long id = (long)BitConverter.ToUInt64(data, 7);
            ushort NL = BitConverter.ToUInt16(data, 15);
            string name = Encoding.ASCII.GetString(data, 17, NL);
            string code = Encoding.ASCII.GetString(data, 17 + NL, 3);
            float logitude = BitConverter.ToSingle(data, 20 + NL);
            float latitude = BitConverter.ToSingle(data, 24 + NL);
            float amsl = BitConverter.ToSingle(data, 28 + NL);
            string country = Encoding.ASCII.GetString(data, 32 + NL, 3);
            return new Airport(id, name, code, logitude, latitude, amsl, country);
        }
    }
    public class CargoBinaryFactory:IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NCA = Encoding.ASCII.GetString(data, 0, 3);
            uint FML = BitConverter.ToUInt32(data, 3);
            long id = (long)BitConverter.ToUInt64(data, 7);
            float weight = BitConverter.ToSingle(data, 15);
            string code = Encoding.ASCII.GetString(data, 19, 6);
            ushort DL = BitConverter.ToUInt16(data, 25);
            string description = Encoding.ASCII.GetString(data, 27, DL);

            return new Cargo(id, weight, code, description);
        }
    }
    public class FlightBinaryFactory : IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NCA = Encoding.ASCII.GetString(data, 0, 3);
            uint FML = BitConverter.ToUInt32(data, 3);
            long id = (long)BitConverter.ToUInt64(data, 7);
            long orginId =(long)BitConverter.ToUInt64(data, 15);
            long targetId = (long)BitConverter.ToUInt64(data, 23);
            long takeOffTime = BitConverter.ToInt64(data, 31);
            long landingTime = BitConverter.ToInt64(data, 39);
            long planeId = (long)BitConverter.ToUInt64(data, 47);
            ushort CC = BitConverter.ToUInt16(data, 55);
            long[] crewIds = new long[CC];
            for (int i = 0; i < CC; i++)
            {
                crewIds[i] =(long) BitConverter.ToUInt64(data, 57 + i * 8);
            }
            ushort PCC = BitConverter.ToUInt16(data, 57 + 8 * CC);
            long[] loadIds = new long[PCC];
            for (int i = 0; i < PCC; i++)
            {
                loadIds[i] =(long) BitConverter.ToUInt64(data, 59 + i * 8);
            }

            return new Flight(id, orginId, targetId, takeOffTime.ToString(), landingTime.ToString(), float.MaxValue, float.MaxValue, float.MaxValue, planeId
                , crewIds.ToList(), loadIds.ToList());
        }
    }
    public class CargoPlaneBinaryFactory : IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NCP = Encoding.ASCII.GetString(data, 0, 3);
            uint FML = BitConverter.ToUInt32(data, 3);
            long id =(long) BitConverter.ToUInt64(data, 7);
            string serial = Encoding.ASCII.GetString(data, 15, 10).Trim('\0');
            string country = Encoding.ASCII.GetString(data, 25, 3);
            ushort ML = BitConverter.ToUInt16(data, 28);
            string model = Encoding.ASCII.GetString(data, 30, ML);
            float maxLoad = BitConverter.ToSingle(data, 30 + ML);

            return new CargoPlane(id, serial, country, model, maxLoad);
        }
    }
    public class PassengerPlaneBinaryFactory:IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NPP = Encoding.ASCII.GetString(data, 0, 3);
            int FML = BitConverter.ToInt32(data, 3);
            long id = BitConverter.ToInt64(data, 7);
            string serial = Encoding.ASCII.GetString(data, 15, 10).Trim('\0');
            string country = Encoding.ASCII.GetString(data, 25, 3);
            short ML = BitConverter.ToInt16(data, 28);
            string model = Encoding.ASCII.GetString(data, 30, ML);
            short firstClassSize = BitConverter.ToInt16(data, 30 + ML);
            short businessClassSize = BitConverter.ToInt16(data, 32 + ML);
            short economyClassSize = BitConverter.ToInt16(data, 34 + ML);

            return new PassengerPlane(id, serial, country, model, firstClassSize, businessClassSize, economyClassSize);
        }
    }
    public class CrewBinaryFactory : IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NCR = Encoding.ASCII.GetString(data, 0, 3);
            int FML = BitConverter.ToInt32(data, 3);
            long id = BitConverter.ToInt64(data, 7);
            ushort NL = BitConverter.ToUInt16(data, 15);
            string name = Encoding.ASCII.GetString(data, 17, NL);
            ushort age = BitConverter.ToUInt16(data, 17 + NL);
            string phone = Encoding.ASCII.GetString(data, 19 + NL, 12);
            short EL = BitConverter.ToInt16(data, 31 + NL);
            string email = Encoding.ASCII.GetString(data, 33 + NL, EL);
            short practice = BitConverter.ToInt16(data, 33 + NL + EL);
            char[] role = Encoding.ASCII.GetChars(data, 35 + NL + EL, 1);

            return new Crew(id, name, age, phone, email, practice, role[0].ToString());
        }
    }
    public class PassengerBinaryFactory : IBinaryFactory
    {
        public IMyObject produce(byte[] data)
        {
            string NPA = Encoding.ASCII.GetString(data, 0, 3);
            int FML = BitConverter.ToInt32(data, 3);
            long id = BitConverter.ToInt64(data, 7);
            ushort NL = BitConverter.ToUInt16(data, 15);
            string name = Encoding.ASCII.GetString(data, 17, NL);
            ushort age = BitConverter.ToUInt16(data, 17 + NL);
            string phone = Encoding.ASCII.GetString(data, 19 + NL, 12);
            short EL = BitConverter.ToInt16(data, 31 + NL);
            string email = Encoding.ASCII.GetString(data, 33 + NL, EL);
            string @class = Encoding.ASCII.GetString(data, 33 + NL + EL, 1);
            long miles = BitConverter.ToInt64(data, 34 + NL + EL);

            return new Passenger(id, name, age, phone, email, @class, miles);
        }
    }

}
