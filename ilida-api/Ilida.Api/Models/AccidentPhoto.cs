using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class AccidentPhoto
    {
        public long Id { get; set; }

        [Required]
        public string Url { get; set; }

        public long AccidentId { get; set; }

        public virtual Accident Accident { get; set; }
    }
}