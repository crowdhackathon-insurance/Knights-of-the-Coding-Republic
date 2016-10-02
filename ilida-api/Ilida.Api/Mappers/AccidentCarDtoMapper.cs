using Ilida.Api.Dtos;
using Ilida.Api.Models;
using System.Linq;

namespace Ilida.Api.Mappers
{
    public class AccidentCarDtoMapper : BaseMapper<AccidentCar, AccidentCarDto>
    {
        public override AccidentCarDto Map(AccidentCar car)
        {
            if (car == null) return null;

            return new AccidentCarDto
            {
                Id = car.Id,
                CarPlate = car.CarPlate,
                DamageText = car.DamageText,
                Remarks = car.Remarks,
                AccidentConditions = car.CarAccidentConditions.Select(x => x.AccidentCondition)
            };
        }
    }
}