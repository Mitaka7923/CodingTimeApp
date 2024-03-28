using Google.Apis.Calendar.v3.Data;

namespace CodingTimeService.Calendar
{
    internal class InsertRequest
    {
        internal static DateTime startOfEvent = new();
        private static string clientSecretJson = @""; // your client-secrets path
        private static string userEmail = ""; // Your email
        private static string[] scopes = { "https://www.googleapis.com/auth/calendar" };

        [Obsolete]
        internal static void ExecuteRequest(TimeSpan elapsedTime)
        {
            var service = CalendarHelper.GetCalendarService(clientSecretJson, userEmail, scopes);

            var newEvent = new Event()
            {
                Summary = "Coding Practice 💻",
                ColorId = "5",
                Start = new EventDateTime() { DateTime = startOfEvent },
                End = new EventDateTime() { DateTime = startOfEvent.Add(elapsedTime) }
            };

            var calendarId = "primary";
            var request = service.Events.Insert(newEvent, calendarId);

            request.Execute();
        }
    }
}
