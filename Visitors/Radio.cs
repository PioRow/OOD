using OOD.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Visitors
{
    public class Radio:IMediaVisitor
    {
        public string Name { get; }
        public Radio(string name)
        {
            Name = name;
        }

        public string visit(Airport airport)
        {
            return $"Reporting for {Name},\r\nLadies and gentelmen, we are\r\nat the {airport.Name}\r\nairport.";
        }

        public string visit(PassengerPlane passengerPlane)
        {
            return $"Reporting for {Name},\r\nLadies and gentelmen, we’ve\r\njust witnessed\r\n{passengerPlane.Serial} take";
        }

        public string visit(CargoPlane cargoPlane)
        {
            return $"Reporting for {Name},\r\nLadies and gentelmen, we are\r\nseeing the\r\n{cargoPlane.Serial}\r\naircraft fly above us.\r\n";
        }
    }
}
