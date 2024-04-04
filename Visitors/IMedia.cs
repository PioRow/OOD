using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD.Objects;

namespace OOD.Visitors
{
    public interface IMediaVisitor
    {
        public string visit(Airport airport);
        public string visit(PassengerPlane passengerPlane);
        public string visit(CargoPlane cargoPlane);
    }
}
