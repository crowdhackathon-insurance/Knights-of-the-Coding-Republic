using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class AccidentParticipant
    {
        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        public string IdCard { get; set; }

        public bool IsDriver { get; set; }

        public bool HasInjuries { get; set; }

        public string SignUrl { get; set; }

        public long AccidentId { get; set; }

        public virtual Accident Accident { get; set; }

        public virtual AccidentCar AccidentCar { get; set; }
    }
}