namespace Ilida.Api.Dtos
{
    public class AccidentParticipantDto
    {
        public long Id { get; set; }

        public string IdCard { get; set; }

        public bool IsDriver { get; set; }

        public bool HasInjuries { get; set; }

        public string SignUrl { get; set; }

        public AccidentCarDto AccidentCar { get; set; }
    }
}