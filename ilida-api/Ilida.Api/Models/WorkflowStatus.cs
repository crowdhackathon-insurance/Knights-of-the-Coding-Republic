using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class WorkflowStatus
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}