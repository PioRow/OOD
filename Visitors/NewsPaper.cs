using OOD.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Visitors
{
    public class NewsPaper : IMediaVisitor
    {
        public string visit(Airport airport)
        {
            return $"{Name} a report from {airport.Name} airport, {airport.Country}";
        }
        public string Name { get; }
        public NewsPaper(string name)
        {
            this.Name = name;
        }
        public string visit(PassengerPlane passengerPlane)
        {
            return $"{Name}-\r\nBreaking news! {passengerPlane.Model}\r\naircraft loses EAS" +
                $"A fails\r\ncertification after inspection of\r\n{passengerPlane.Serial}\r\n";
        }

        public string visit(CargoPlane cargoPlane)
        {
            return $"{Name} - An\r\ninterview with the crew of\r\n{cargoPlane.Serial}.";
        }
    }
}
