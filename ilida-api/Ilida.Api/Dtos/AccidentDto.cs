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

        public ICollection<AccidentParticipant> AccidentParticipants { get; set; }

        public ICollection<AccidentCarDto> AccidentCars { get; set; }

        public ICollection<AccidentPhotoDto> AccidentPhotos { get; set; }

        public ICollection<Company> AccidentCompanies { get; set; }

        public ICollection<AccidentWitnessDto> AccidentWitnesses { get; set; }

        public ICollection<AccidentActionDto> AccidentActions { get; set; }
    }
}