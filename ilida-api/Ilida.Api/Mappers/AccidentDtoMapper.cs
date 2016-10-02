using Ilida.Api.Dtos;
using Ilida.Api.Models;
using System;
using System.Linq;

namespace Ilida.Api.Mappers
{
    public class AccidentDtoMapper : BaseMapper<Accident, AccidentDto>
    {
        private readonly IMapper<AccidentAction, AccidentActionDto> _accidentActionDtoMapper;
        private readonly IMapper<AccidentCar, AccidentCarDto> _accidentCarDtoMapper;
        private readonly IMapper<AccidentParticipant, AccidentParticipantDto> _accidentParticipantDtoMapper;
        private readonly IMapper<AccidentPhoto, AccidentPhotoDto> _accidentPhotoDtoMapper;
        private readonly IMapper<AccidentWitness, AccidentWitnessDto> _accidentWitnessDtoMapper;

        public AccidentDtoMapper(
            IMapper<AccidentParticipant, AccidentParticipantDto> accidentParticipantDtoMapper,
            IMapper<AccidentCar, AccidentCarDto> accidentCarDtoMapper,
            IMapper<AccidentPhoto, AccidentPhotoDto> accidentPhotoDtoMapper,
            IMapper<AccidentWitness, AccidentWitnessDto> accidentWitnessDtoMapper,
            IMapper<AccidentAction, AccidentActionDto> accidentActionDtoMapper)
        {
            if (accidentParticipantDtoMapper == null) throw new ArgumentNullException("accidentParticipantDtoMapper");
            if (accidentCarDtoMapper == null) throw new ArgumentNullException("accidentCarDtoMapper");
            if (accidentPhotoDtoMapper == null) throw new ArgumentNullException("accidentPhotoDtoMapper");
            if (accidentWitnessDtoMapper == null) throw new ArgumentNullException("accidentWitnessDtoMapper");
            if (accidentActionDtoMapper == null) throw new ArgumentNullException("accidentActionDtoMapper");

            _accidentParticipantDtoMapper = accidentParticipantDtoMapper;
            _accidentCarDtoMapper = accidentCarDtoMapper;
            _accidentPhotoDtoMapper = accidentPhotoDtoMapper;
            _accidentWitnessDtoMapper = accidentWitnessDtoMapper;
            _accidentActionDtoMapper = accidentActionDtoMapper;

        }
        public override AccidentDto Map(Accident accident)
        {
            if (accident == null) return null;

            return new AccidentDto
            {
                Id = accident.Id,
                OccuredOn = accident.OccuredOn,
                HasInjuries = accident.HasInjuries,
                HasOtherVehicleDamages = accident.HasOtherVehicleDamages,
                HasOtherItemsDamages = accident.HasOtherItemsDamages,
                Latitude = accident.Latitude,
                Longitude = accident.Longitude,
                DiagramUrl = accident.DiagramUrl,
                WorkflowStatus = accident.WorkflowStatus,
                AccidentParticipants = _accidentParticipantDtoMapper.Map(accident.AccidentParticipants),
                AccidentCars = _accidentCarDtoMapper.Map(accident.AccidentCars),
                AccidentPhotos = _accidentPhotoDtoMapper.Map(accident.AccidentPhotos),
                AccidentCompanies = accident.AccidentCompanies.Select(x => x.Company),
                AccidentWitnesses = _accidentWitnessDtoMapper.Map(accident.AccidentWitnesses),
                AccidentActions = _accidentActionDtoMapper.Map(accident.AccidentActions)
            };
        }
    }
}