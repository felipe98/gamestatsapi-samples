using System.Collections.Generic;
using System.Configuration;

namespace GameStatsApi.Sdk.Helpers
{
    /// <summary>
    /// AppSettings helper object.
    /// </summary>
    public static class ConfigHelper
    {
        public static Dictionary<string, string> ApiConfigurations { get; set; }

        static ConfigHelper()
        {
            ApiConfigurations = new Dictionary<string, string>()
            {
                { Constants.API_KEY,ConfigurationManager.AppSettings[Constants.API_KEY] },
                { Constants.API_TOKEN,ConfigurationManager.AppSettings[Constants.API_TOKEN] },
                { Constants.API_SIGNATURE,ConfigurationManager.AppSettings[Constants.API_SIGNATURE] },
                { Constants.API_USERNAME,ConfigurationManager.AppSettings[Constants.API_USERNAME] },
                { Constants.API_PASSWORD,ConfigurationManager.AppSettings[Constants.API_PASSWORD] },
                { Constants.API_BASEURL,ConfigurationManager.AppSettings[Constants.API_BASEURL] }
            };
        }
    }
}
