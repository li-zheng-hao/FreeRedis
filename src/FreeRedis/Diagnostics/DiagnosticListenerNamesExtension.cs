
using System;
using System.Diagnostics;
namespace FreeRedis.Diagnostics
{
    public static class DiagnosticListenerNamesExtension
    {
        private static readonly DiagnosticListener _diagnosticListener =
            new DiagnosticListener(DiagnosticListenerNames.DiagnosticListenerName);

        public static void UseDiagnosticListener(this RedisClient redisClient)
        {
            redisClient.Notice += (s, e) =>
            {
                if (_diagnosticListener.IsEnabled(DiagnosticListenerNames.Notice))
                    _diagnosticListener.Write(DiagnosticListenerNames.Notice, new NoticeEventData()
                    {
                        NoticeType = e.NoticeType,
                        Message = e.Log,
                        Exception=e.Exception,
                        Tag=e.Tag,
                        OpTime = DateTime.UtcNow
                    });
            };
            redisClient.Connected += (s, e) =>
            {
                if (_diagnosticListener.IsEnabled(DiagnosticListenerNames.Connected))
                    _diagnosticListener.Write(DiagnosticListenerNames.Connected, new ConnectedEventData()
                    {
                        Host=e.Host,
                        OpTime = DateTime.UtcNow,
                    });
            };
            redisClient.Unavailable += (s, e) =>
            {
                if (_diagnosticListener.IsEnabled(DiagnosticListenerNames.Unavailable))
                    _diagnosticListener.Write(DiagnosticListenerNames.Unavailable, new UnavailableEventData()
                    {
                        OpTime = DateTime.UtcNow,
                        Host=e.Host
                    });
            };
            redisClient.Disconnected += (s, e) =>
            {
                if (_diagnosticListener.IsEnabled(DiagnosticListenerNames.Disconnected))
                    _diagnosticListener.Write(DiagnosticListenerNames.Disconnected, new DisConnectedEventData()
                    {
                        OpTime = DateTime.UtcNow,
                        Host=e.Host
                    });
            };
        }
    }
  
}