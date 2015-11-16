using GameStatsApi.Sdk.Models;
using System;

namespace GameStatsApi.Sdk
{
    /// <summary>
    /// Service wrapper contract.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGameStatsService  : IDisposable
    {
        string BaseEndpoint { get; }

        /// <summary>
        /// Build querystring for token auth.
        /// </summary>
        /// <returns>Querystring</returns>
        string BuildQuerystring();

        /// <summary>
        /// Record game area/stage details or meta information.
        /// </summary>
        /// <param name="request">AreaEventRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse AreaEvent(AreaEventRequest request);
        GenericResponse AreaEventBasicAuth(AreaEventRequest request);

        /// <summary>
        /// Record game downloaded event (since most stores keep track of purchases, this event
        /// can be raise upon first run)
        /// </summary>
        /// <param name="request">DownloadedRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse DownloadedEvent(DownloadedRequest request);
        GenericResponse DownloadedEventBasicAuth(DownloadedRequest request);

        /// <summary>
        /// Record a general game event.
        /// </summary>
        /// <param name="request">GeneralRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse GeneralEvent(GeneralRequest request);
        GenericResponse GeneralEventBasicAuth(GeneralRequest request);

        /// <summary>
        /// Capture screenshot as a 64base string.
        /// </summary>
        /// <param name="request">CaptureRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse CaptureEvent(CaptureRequest request);
        GenericResponse CaptureEventBasicAuth(CaptureRequest request);
    }
}
