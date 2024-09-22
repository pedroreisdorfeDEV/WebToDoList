using FluentValidation.Results;

namespace WebToDoListKlassMatt.Models.Entities
{
    public class Notification
    {
        private readonly IDictionary<string, IList<string>> ErrorMessages = new Dictionary<string, IList<string>>();
        public bool IsInvalid => ErrorMessages.Any();

        public override string ToString() => string.Join(' ', ErrorMessages.SelectMany(x => x.Value));

        public IDictionary<string, IList<string>> GetErrorMessages() => ErrorMessages;

        public string GetFormattedErrorMessages()
        {
            var formattedMessages = ErrorMessages
                .SelectMany(error => error.Value.Select(msg => $"{error.Key}: {msg}"));

            return string.Join(Environment.NewLine, formattedMessages);
        }

        public void AddErrorMessages(string key, string message)
        {
            if (!ErrorMessages.ContainsKey(key))
            {
                ErrorMessages[key] = new List<string>();
            }
            ErrorMessages[key].Add(message);
        }

        public void AddErrorMessages(ValidationResult result)
        {
            if (result.IsValid)
                return;

            foreach (var error in result.Errors)
            {
                AddErrorMessages(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
