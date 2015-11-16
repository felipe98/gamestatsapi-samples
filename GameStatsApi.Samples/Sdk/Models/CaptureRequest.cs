using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStatsApi.Sdk.Models
{
    public class CaptureRequest
    {
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
        /// Is the snapshot public or for internal use only.
        /// <remarks>Server Validation: [Required]</remarks>
        /// </summary>
        [JsonProperty("IsPublic")]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Not required by the service, or used by the post. Added for consistency.
        /// <remarks>Server Validation: [MaxLength(250)]</remarks>
        /// </summary>
        [JsonProperty("SnapshotPath")]
        public string SnapshotPath { get; set; }

        /// <summary>
        /// Image data as a Base64 string.
        /// <remarks>Server Validation: [Required]</remarks>
        /// </summary>
        [JsonProperty("Data")]
        public string Data { get; set; }
    }
}
