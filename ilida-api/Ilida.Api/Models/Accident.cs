using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class Accident
    {
        public Accident()
        {
            AccidentParticipants = new List<AccidentParticipant>();
            AccidentCars = new List<AccidentCar>();
            AccidentPhotos = new List<AccidentPhoto>();
            AccidentCompanies = new List<AccidentCompany>();
            AccidentWitnesses = new List<AccidentWitness>();
        }

        public long Id { get; set; }
        
        [Required]
        public DateTime OccuredOn { get; set; }

        public bool HasInjuries { get; set; }

        public bool HasOtherVehicleDamages { get; set; }

        public bool HasOtherItemsDamages { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public string DiagramUrl { get; set; }

        public long WorkflowStatusId { get; set; }

        public virtual WorkflowStatus WorkflowStatus { get; set; }

        public virtual ICollection<AccidentParticipant> AccidentParticipants { get; set; }

        public virtual ICollection<AccidentCar> AccidentCars { get; set; }

        public virtual ICollection<AccidentPhoto> AccidentPhotos { get; set; }

        public virtual ICollection<AccidentCompany> AccidentCompanies { get; set; }

        public virtual ICollection<AccidentWitness> AccidentWitnesses { get; set; }

        public virtual ICollection<AccidentAction> AccidentActions { get; set; }
    }
}