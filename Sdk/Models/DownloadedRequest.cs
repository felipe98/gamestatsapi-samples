using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStatsApi.Sdk.Models
{
    public class DownloadedRequest
    {
        /// <summary>
        /// Meta field can be used to pass plaintext/xml/json
        /// <remarks>Server Validation: [MaxLength(250)]</remarks>
        /// <example>{ "DeathCount": 2, "Score": 3000 }</example>
        /// </summary>
        [JsonProperty("Meta")]
        public string Meta { get; set; }

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
        /// Captured on the server if not supplied.
        /// <remarks>Server Validation: [MaxLength(50)]</remarks>
        /// </summary>
        [JsonProperty("ClientIP")]
        public string ClientIP { get; set; }
    }
}
