using Ilida.Api.Dtos;
using Ilida.Api.Models;

namespace Ilida.Api.Mappers
{
    public class AccidentWitnessDtoMapper : BaseMapper<AccidentWitness, AccidentWitnessDto>
    {
        public override AccidentWitnessDto Map(AccidentWitness witness)
        {
            if (witness == null) return null;

            return new AccidentWitnessDto
            {
                Id = witness.Id,
                IdCard = witness.IdCard
            };
        }
    }
}