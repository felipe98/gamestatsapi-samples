using GameStatsApi.Sdk.Concrete;
using GameStatsApi.Sdk.Models;
using System;
using System.IO;

namespace GameStatsApi.Sdk.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceWrapper = new GameStatsSimple())
            {
                AreaEvent(serviceWrapper);
                AreaEventBasicAuth(serviceWrapper);

                DownloadedEvent(serviceWrapper);
                
                GeneralEvent(serviceWrapper);
                
                CaptureEvent(serviceWrapper);
            }

            Console.ReadKey();
        }

        #region API Calls

        private static void AreaEvent(IGameStatsService statsService)
        {
            var response = statsService.AreaEvent(new AreaEventRequest
            {
                ProjectId = 4,
                Area = "SDK Tester",
                ClientIP = string.Empty,
                Difficulty = "Normal",
                Meta = Guid.NewGuid().ToString(),
                PerctCompleted = 0,
                Platform = "Desktop",
                PlayerId = string.Empty
            });

            Console.WriteLine(string.Format("Area Event: {0}", response.Message));
            Console.WriteLine("**********************************************************");
        }

        private static void AreaEventBasicAuth(IGameStatsService statsService)
        {
            var response = statsService.AreaEventBasicAuth(new AreaEventRequest
            {
                ProjectId = 1,
                Area = "SDK Tester",
                ClientIP = string.Empty,
                Difficulty = "Normal",
                Meta = Guid.NewGuid().ToString(),
                PerctCompleted = 0,
                Platform = "Desktop",
                PlayerId = string.Empty
            });

            Console.WriteLine(string.Format("Area Event Basic Auth: {0}", response.Message));
            Console.WriteLine("**********************************************************");
        }

        private static void DownloadedEvent(IGameStatsService statsService)
        {
            var response = statsService.DownloadedEvent(new DownloadedRequest
            {
                ProjectId = 4,
                Meta = "First ran at " + DateTime.UtcNow.ToString(),
                Platform = "Android",
                PlayerId = string.Empty
            });

            Console.WriteLine(string.Format("Downloaded Event: {0}", response.Message));
            Console.WriteLine("**********************************************************");
        }

        private static void GeneralEvent(IGameStatsService statsService)
        {
            var response = statsService.GeneralEvent(new GeneralRequest
            {
                ProjectId = 4,
                ClientIP = string.Empty,
                Difficulty = "Normal",
                Meta = Guid.NewGuid().ToString(),
                PerctCompleted = 0,
                Platform = "Desktop",
                PlayerId = string.Empty,
                AreaName = "SDK Test General",
                TotalHours = 12
            });

            Console.WriteLine(string.Format("General Event: {0}", response.Message));
            Console.WriteLine("**********************************************************");
        }

        private static void CaptureEvent(IGameStatsService statsService)
        {
            
            var response = statsService.CaptureEvent(new CaptureRequest
            {
                ProjectId = 1,
                PlayerId = string.Empty,
                IsPublic = true,
                Data = Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\Felipe\Desktop\2fc15b0.jpg"))
            });

            Console.WriteLine(string.Format("Capture Event: {0}", response.Message));
            Console.WriteLine(string.Format("Capture Event Meta: {0}", response.Meta));
            Console.WriteLine("**********************************************************");
        }

        #endregion
    }
}
