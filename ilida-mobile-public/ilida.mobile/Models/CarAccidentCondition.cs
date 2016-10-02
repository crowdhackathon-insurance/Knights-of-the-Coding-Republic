namespace Ilida.Api.Models
{
    public class CarAccidentCondition
    {
        public long Id { get; set; }

        public long AccidentId { get; set; }

        public virtual Accident Accident { get; set; }

        public long AccidentCarId { get; set; }

        public virtual AccidentCar AccidentCar { get; set; }

        public long AccidentConditionId { get; set; }

        public virtual AccidentCondition AccidentCondition { get; set; }
    }
}