using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ilida.Api.Mappers
{
    public interface IMapper<From, To>
    {
        To Map(From from);
        IEnumerable<To> Map(IEnumerable<From> from);
    }
}