using GameStatsApi.Sdk.Helpers;
using GameStatsApi.Sdk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GameStatsApi.Sdk.Concrete
{
    public class GameStatsSimple : IGameStatsService
    {
        #region Properties

        public string BaseEndpoint
        {
            get { return ConfigHelper.ApiConfigurations[Constants.API_BASEURL]; }
        }

        #endregion

        #region Token Validation Events

        /// <summary>
        /// Record game area/stage details or meta information.
        /// </summary>
        /// <param name="request">AreaEventRequest</param>
        /// <returns>GenericResponse</returns>
        public GenericResponse AreaEvent(AreaEventRequest request)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                var json = client.UploadString(string.Format("{0}/events/area{1}", BaseEndpoint, BuildQuerystring()), 
                    JsonConvert.SerializeObject(request));

                return JsonConvert.DeserializeObject<GenericResponse>(json);
            }
        }

        /// <summary>
        /// Record game downloaded event (since most stores keep track of purchases, this event
        /// can be raise upon first run)
        /// </summary>
        /// <param name="request">DownloadedRequest</param>
        /// <returns>GenericResponse</returns>
        public GenericResponse DownloadedEvent(DownloadedRequest request)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                var json = client.UploadString(string.Format("{0}/events/downloaded{1}", BaseEndpoint, BuildQuerystring()),
                    JsonConvert.SerializeObject(request));

                return JsonConvert.DeserializeObject<GenericResponse>(json);
            }
        }

        /// <summary>
        /// Record a general game event.
        /// </summary>
        /// <param name="request">GeneralRequest</param>
        /// <returns>GenericResponse</returns>
        public GenericResponse GeneralEvent(GeneralRequest request)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                var json = client.UploadString(string.Format("{0}/events/general{1}", BaseEndpoint, BuildQuerystring()),
                    JsonConvert.SerializeObject(request));

                return JsonConvert.DeserializeObject<GenericResponse>(json);
            }
        }

        /// <summary>
        /// Capture screenshot as a 64base string.
        /// </summary>
        /// <param name="request">CaptureRequest</param>
        /// <returns>GenericResponse</returns>
        public GenericResponse CaptureEvent(CaptureRequest request)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                var json = client.UploadString(string.Format("{0}/events/capture{1}", BaseEndpoint, BuildQuerystring()),
                    JsonConvert.SerializeObject(request));

                return JsonConvert.DeserializeObject<GenericResponse>(json);
            }
        }

        #endregion

        #region Basic Auth Examples

        public GenericResponse AreaEventBasicAuth(AreaEventRequest request)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", GetAuthHeader());

                var json = client.UploadString(string.Format("{0}/events/area", BaseEndpoint),
                    JsonConvert.SerializeObject(request));

                return JsonConvert.DeserializeObject<GenericResponse>(json);
            }
        }

        public GenericResponse DownloadedEventBasicAuth(DownloadedRequest request)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", GetAuthHeader());

                var json = client.UploadString(string.Format("{0}/events/downloaded", BaseEndpoint),
                    JsonConvert.SerializeObject(request));

                return JsonConvert.DeserializeObject<GenericResponse>(json);
            }
        }

        public GenericResponse GeneralEventBasicAuth(GeneralRequest request)
        {
            throw new NotImplementedException();
        }

        public GenericResponse CaptureEventBasicAuth(CaptureRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Build querystring for token auth.
        /// </summary>
        /// <returns>Querystring</returns>
        public string BuildQuerystring()
        {
            return string.Format("?apikey={0}&token={1}",
                ConfigHelper.ApiConfigurations[Constants.API_KEY],
                ConfigHelper.ApiConfigurations[Constants.API_TOKEN]);
        }

        /// <summary>
        /// Build basic auth string (recommend using apikey/signature instead of username/password)
        /// </summary>
        /// <returns></returns>
        private string GetAuthHeader()
        {
            string credentials = Convert.ToBase64String(
                Encoding.GetEncoding("iso-8859-1").GetBytes(string.Format("{0}:{1}",
                    ConfigHelper.ApiConfigurations[Constants.API_KEY],
                    ConfigHelper.ApiConfigurations[Constants.API_SIGNATURE])));

            return credentials; 
        }
        
        #endregion

        #region Cleanup

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (disposed)
                return;

            if (isDisposing)
            {

            }

            disposed = true;
        }

        #endregion

    }
}
