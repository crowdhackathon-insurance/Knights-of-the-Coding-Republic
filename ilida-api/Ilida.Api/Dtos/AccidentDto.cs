using Ilida.Api.Models;
using System;
using System.Collections.Generic;

namespace Ilida.Api.Dtos
{
    public class AccidentDto
    {
        public long Id { get; set; }

        public DateTime OccuredOn { get; set; }

        public bool HasInjuries { get; set; }

        public bool HasOtherVehicleDamages { get; set; }

        public bool HasOtherItemsDamages { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string DiagramUrl { get; set; }

        public WorkflowStatus WorkflowStatus { get; set; }

        public IEnumerable<AccidentParticipantDto> AccidentParticipants { get; set; }

        public IEnumerable<AccidentCarDto> AccidentCars { get; set; }

        public IEnumerable<AccidentPhotoDto> AccidentPhotos { get; set; }

        public IEnumerable<Company> AccidentCompanies { get; set; }

        public IEnumerable<AccidentWitnessDto> AccidentWitnesses { get; set; }

        public IEnumerable<AccidentActionDto> AccidentActions { get; set; }
    }
}