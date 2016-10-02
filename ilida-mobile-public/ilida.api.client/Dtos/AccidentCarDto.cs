using Ilida.Api.Models;
using System.Collections.Generic;

namespace Ilida.Api.Dtos
{
    public class AccidentCarDto
    {
        public long Id { get; set; }

        public string CarPlate { get; set; }

        public string DamageText { get; set; }

        public string Remarks { get; set; }

        public IEnumerable<AccidentCondition> AccidentConditions { get; set; }
    }
}