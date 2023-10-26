using Newtonsoft.Json;
using System.Collections.Generic;

namespace Task_2_API
{
    public class Breakage
    {
        [JsonProperty("outage_start")]
        public System.DateTime? OutageStart { get; set; }
        [JsonProperty("outage_end")]
        public System.DateTime? OutageEnd { get; set; }
        [JsonProperty("affected_areas")]
        public List<AffectedArea> AffectedAreas { get; set; }

        public override string ToString()
        {
            string areas = "";
            foreach (var area in AffectedAreas)
            {
                areas += area.ToString() + " \n";
            }
            return "Outage start: " + OutageStart + "\n" +
                    "Affected areas: " + areas;
        }
    }
}
