using System.ComponentModel.DataAnnotations;

namespace RoomsReservation.Db.Models
{
    public class ManagerValidator : IValidatableObject
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Check if username is already in use
            var isUsernameInUse = IsUsernameInUse((string)Username, validationContext);
            if (isUsernameInUse)
            {
                results.Add(new ValidationResult("Username is already in use.", new[] { nameof(Username) }));
            }

            // Check if email is already in use
            var isEmailInUse = IsEmailInUse((string)Email, validationContext);
            if (isEmailInUse)
            {
                results.Add(new ValidationResult("Email is already in use.", new[] { nameof(Email) }));
            }

            return results;
        }

    }
}