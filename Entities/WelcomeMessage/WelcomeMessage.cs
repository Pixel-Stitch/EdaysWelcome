using System;

namespace Entities.WelcomeMessage
{
    public class WelcomeMessage
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string MessageEN { get; set; }
        public string MessageFR { get; set; }
        public string MessageDE { get; set; }
        public string ImageBase64 { get; set; }

        public string Message(string languageCode = "en")
        {
            switch (languageCode.ToLower())
            {
                case "fr":
                    return MessageFR;
                case "de":
                    return MessageDE;
                default:
                    return MessageEN;
            }
        }
    }
}