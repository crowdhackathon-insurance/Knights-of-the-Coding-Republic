using System.Collections.Generic;
using System.Linq;

namespace Ilida.Api.Mappers
{
    public abstract class BaseMapper<From, To> : IMapper<From, To>
    {
        public IEnumerable<To> Map(IEnumerable<From> from)
        {
            return from
                .Select(x => Map(x))
                .Where(x => x != null);
        }

        public abstract To Map(From from);
    }
}