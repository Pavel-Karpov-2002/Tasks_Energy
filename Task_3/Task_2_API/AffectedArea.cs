using Newtonsoft.Json;

namespace Task_2_API
{
    public class AffectedArea
    {
        [JsonProperty("area_name")]
        public string Name { get; set; }

        [JsonProperty("affected_customers")]
        public int? AffectedCustomers { get; set; }

        [JsonProperty("estimated_recovery_time")]
        public System.DateTime? EstimatedRecoveryTime { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " | " + "Affected cusotmers: " + AffectedCustomers + " | " + "Estimated recovery time: " + EstimatedRecoveryTime + " | " + Reason;
        }
    }
}
