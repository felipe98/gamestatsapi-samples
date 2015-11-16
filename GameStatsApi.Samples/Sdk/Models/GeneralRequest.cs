using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStatsApi.Sdk.Models
{
    public class GeneralRequest
    {
        /// <summary>
        /// Area/Stage name.
        /// <remarks>Server Validation: [Required, MaxLength(75)]</remarks>
        /// </summary>
        [JsonProperty("AreaName")]
        public string AreaName { get; set; }

        /// <summary>
        /// Captured on the server if not supplied.
        /// <remarks>Server Validation: [MaxLength(50)]</remarks>
        /// </summary>
        [JsonProperty("ClientIP")]
        public string ClientIP { get; set; }

        /// <summary>
        /// Area/Stage current difficulty setting
        /// <remarks>Server Validation: [MaxLength(50)]</remarks>
        /// </summary>
        [JsonProperty("Difficulty")]
        public string Difficulty { get; set; }

        /// <summary>
        /// Meta field can be used to pass plaintext/xml/json
        /// <remarks>Server Validation: [MaxLength(250)]</remarks>
        /// <example>{ "DeathCount": 2, "Score": 3000 }</example>
        /// </summary>
        [JsonProperty("Meta")]
        public string Meta { get; set; }

        /// <summary>
        /// Optional field for area completion, or overall completion.
        /// </summary>
        [JsonProperty("PerctCompleted")]
        public Nullable<double> PerctCompleted { get; set; }

        /// <summary>
        /// Platform xbox/mobile/etc
        /// <remarks>Server Validation: [MaxLength(50)]</remarks>
        /// </summary>
        [JsonProperty("Platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Email or GUID for consistent player stats.
        /// <remarks>Server Validation: [MaxLength(350)]</remarks>
        /// </summary>
        [JsonProperty("PlayerId")]
        public string PlayerId { get; set; }

        /// <summary>
        /// Acquired on admin site. Or via GetProjectId call.
        /// <remarks>Server Validation: [Required]</remarks>
        /// </summary>
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Overall total hours of gametime.
        /// </summary>
        [JsonProperty("TotalHours")]
        public Nullable<int> TotalHours { get; set; }
    }
}
