using System.Text;
using OOD.Objects;

namespace OOD.Factories
{
    public interface IBinaryFactory
    {
        public object Produce(MemoryStream stream);
    }
}