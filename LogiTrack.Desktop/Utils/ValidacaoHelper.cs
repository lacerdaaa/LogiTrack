using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Desktop.Utils
{
    public static class ValidacaoHelper
    {
        public static (bool IsValid, List<string> Errors) ValidateObject(object obj)
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, results, true);

            var errors = results.Select(r => r.ErrorMessage ?? string.Empty).ToList();
            return (isValid, errors);
        }

        public static bool ValidateAndShowErrors(object obj)
        {
            var (isValid, errors) = ValidateObject(obj);

            if (!isValid)
            {
                var message = string.Join("\n", errors);
                MessageHelper.ShowError($"Erros de validação:\n\n{message}");
            }

            return isValid;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumeric(string value)
        {
            return decimal.TryParse(value, out _);
        }
    }
}