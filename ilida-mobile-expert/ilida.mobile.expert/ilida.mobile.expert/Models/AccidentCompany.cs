namespace Ilida.Api.Models
{
    public class AccidentCompany
    {
        public long Id { get; set; }

        public long AccidentId { get; set; }
        public virtual Accident Accident { get; set; }

        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}