using Ilida.Api.Dtos;
using Ilida.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ilida.Api.Mappers
{
    public class AccidentFromCreateRequestMapper : BaseMapper<CreateAccidentRequest, Accident>
    {
        public override Accident Map(CreateAccidentRequest request)
        {
            return new Accident
            {
                OccuredOn = request.OccuredOn,
                HasInjuries = request.HasInjuries,
                HasOtherVehicleDamages = request.HasOtherVehicleDamages,
                HasOtherItemsDamages = request.HasOtherItemsDamages,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                UserId = request.UserId,
                AccidentPhotos = request.AccidentPhotos.Select(x => new AccidentPhoto { Url = x }).ToList(),
                AccidentParticipants = request.AccidentParticipants.Select(x => new AccidentParticipant
                {
                    IdCard = x.IdCard,
                    IsDriver = x.IsDriver,
                    HasInjuries = x.HasInjuries,
                    SignUrl = x.SignUrl,
                    AccidentCar = new AccidentCar
                    {
                        CarPlate = x.AccidentCar.CarPlate,
                        DamageText = x.AccidentCar.DamageText,
                        Remarks = x.AccidentCar.Remarks
                    }
                }).ToList()
            };
        }
    }
}