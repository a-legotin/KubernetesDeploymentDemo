using System;
using Bus.Abstractions;
using Common.Models;

namespace Bus.Events
{
    public class WebPostDownloadedEvent : IntegrationEvent
    {
        public WebPostDownloadedEvent(WebPost post)
        {
            Post = post;
            ReceivedTime = DateTimeOffset.Now;
        }

        public DateTimeOffset ReceivedTime { get; }

        public WebPost Post { get; }
    }
}