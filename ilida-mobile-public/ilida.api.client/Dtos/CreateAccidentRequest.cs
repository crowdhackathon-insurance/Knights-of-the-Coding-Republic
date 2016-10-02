using System;
using System.Collections.Generic;

namespace Ilida.Api.Dtos
{
    public class CreateAccidentRequest
    {
        public DateTime OccuredOn { get; set; }

        public bool HasInjuries { get; set; }

        public bool HasOtherVehicleDamages { get; set; }

        public bool HasOtherItemsDamages { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long UserId { get; set; }

        public IEnumerable<AccidentParticipantDto> AccidentParticipants { get; set; }

        public IEnumerable<string> AccidentPhotos { get; set; }
    }
}