using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataFive.Models
{
    public class CalculationResponse
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "SolutionNumber")]
        public string Answer { get; set; }

        public CalculationResponse(Guid id, int answer)
        {
            Id = id;
            Answer = answer.ToString();
        }
    }
}
