using System.Net;

namespace WebToDoListKlassMatt.Models.Entities
{
    public class ValidationError
    {
        public string Title { get; set; }
        public IDictionary<string, IList<string>>? Detail { get; set; }
        public string Instance { get; set; }
        public int Status { get; set; }


        public ValidationError(Notification notification, HttpContext context)
        {
            Title = "Bad request";
            Detail = notification.GetErrorMessages();
            Instance = context.TraceIdentifier;
            Status = (int)HttpStatusCode.BadRequest;
        }
    }
}
