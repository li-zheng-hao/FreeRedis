using System;

namespace FreeRedis.Diagnostics
{

    public class BaseEventData
    {
        public DateTime OpTime { get; set; }
    }
    public class ConnectedEventData:BaseEventData
    {
        public string Host { get; set; }
    }
    public class DisConnectedEventData:BaseEventData
    {
        public string Host { get; set; }
    }
    public class UnavailableEventData:BaseEventData
    {
        public string Host { get; set; }
    }
    public class NoticeEventData:BaseEventData
    {
        public string Message { get; set; }
        public NoticeType NoticeType { get; set; }
        public Exception Exception { get; set; }
        public object Tag { get; set; }
    }
   
}