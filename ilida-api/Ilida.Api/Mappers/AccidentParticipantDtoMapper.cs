using Ilida.Api.Dtos;
using Ilida.Api.Models;
using System;

namespace Ilida.Api.Mappers
{
    public class AccidentParticipantDtoMapper : BaseMapper<AccidentParticipant, AccidentParticipantDto>
    {
        private readonly IMapper<AccidentCar, AccidentCarDto> _accidentCarDtoMapper;

        public AccidentParticipantDtoMapper(
            IMapper<AccidentCar, AccidentCarDto> accidentCarDtoMapper)
        {
            if (accidentCarDtoMapper == null) throw new ArgumentNullException("accidentCarDtoMapper");

            _accidentCarDtoMapper = accidentCarDtoMapper;
        }

        public override AccidentParticipantDto Map(AccidentParticipant participant)
        {
            if (participant == null) return null;

            return new AccidentParticipantDto
            {
                Id = participant.Id,
                IdCard = participant.IdCard,
                IsDriver = participant.IsDriver,
                HasInjuries = participant.HasInjuries,
                SignUrl = participant.SignUrl,
                AccidentCar = _accidentCarDtoMapper.Map(participant.AccidentCar)
            };
        }
    }
}