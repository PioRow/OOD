using OOD.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Visitors
{
    public class Television : IMediaVisitor
    {
        public string visit(Airport airport)
        {
            return $"<An image of\r\n{airport.Name} airport>";
        }

        public string visit(PassengerPlane passengerPlane)
        {
            return $"<An image of\r\n{passengerPlane.Serial} cargo\r\nplane>\r\n";
        }

        public string visit(CargoPlane cargoPlane)
        {
            return $"<An image of\r\n{cargoPlane.Serial} cargo\r\nplane>\r\n";
        }
    }
}
