using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStatsApi.Sdk.Models
{
    /// <summary>
    /// Common response object from /events/{action} endpoint.
    /// </summary>
    public class GenericResponse
    {
        /// <summary>
        /// Success or failure message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Either request validation error, or action exception errors.
        /// </summary>
        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        /// <summary>
        /// Contains information for event specific action.
        /// <example>/capture will return a link to the image captured.</example>
        /// </summary>
        [JsonProperty("meta")]
        public string Meta { get; set; }
    }
}
