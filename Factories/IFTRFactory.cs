using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD.Objects;
namespace OOD.Factories
{
    public interface IFTRFactory
    {
        public object Produce(string[] values); 
    }
    public class FTRAirportFactory : IFTRFactory
    {
        public object Produce(string[] values)
        {
            var format = new CultureInfo("en-EN").NumberFormat;
            return new Airport(long.Parse(values[1]), values[2], values[3], float.Parse(values[4],format)
                , float.Parse(values[5], format), float.Parse(values[6], format), values[7]);
        }
    }
    public class FTRCargoFactory : IFTRFactory
    {
        public object Produce(string[] values)
        {
            var format = new CultureInfo("en-EN").NumberFormat;
            return new Cargo(long.Parse(values[1]), float.Parse(values[2], format), values[3], values[4]);
        }
    }
    public class FTRCargoPlaneFactory:IFTRFactory
    {
        public object Produce(string[] values)
        {
            var format = new CultureInfo("en-EN").NumberFormat;
            return new CargoPlane(long.Parse(values[1]), values[2], values[3], values[4], float.Parse(values[5], format));
        }
    }
    public class FTRCrewFactory:IFTRFactory
    {
        public object Produce(string[] values)
        {
            return new Crew(long.Parse(values[1]), values[2], long.Parse(values[3]), values[4], values[5], short.Parse(values[6]),
                values[7]);
        }
    }
    public class FTRFlightFactory : IFTRFactory
    {
        public object Produce(string[] values)
        {
            List<long> crewIds= values[10].Substring(1, values[10].Length-2).Split(";").Select(long.Parse).ToList();
            List<long> loadIds = values[11].Substring(1, values[11].Length - 2).Split(";").Select(long.Parse).ToList();
            var format = new CultureInfo("en-EN").NumberFormat;
            return new Flight(long.Parse(values[1]), long.Parse(values[2]), long.Parse(values[3]), values[4], values[5],
                float.Parse(values[6], format), float.Parse(values[7], format), float.Parse(values[8], format), long.Parse(values[9])
                ,crewIds,loadIds);
        }
    }
    public class FTRPassengerFactory:IFTRFactory
    {
        public object Produce(string[] values)
        {
            return new Passenger(long.Parse(values[1]), values[2], long.Parse(values[3]), values[4], values[5],values[6], long.Parse(values[7]));
        }
    }
    public class FTRPassengerPlaneFactory:IFTRFactory
    {
        public object Produce(string[] values)
        {
            return new PassengerPlane(long.Parse(values[1]), values[2], values[3], values[4], short.Parse(values[5]),
                short.Parse(values[6]), short.Parse(values[7]));
        }
    }

}
