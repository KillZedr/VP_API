using VapeShop.Domain.ECommerce;

namespace VapeShop.Domain.Identity

{
    public class User : Entity<int>
    {
        public int? Id { get; set; } 
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }

        public required UserRole Role { get; set; }
        public required UserSettings UserSettings { get; set; }
        public virtual  IEnumerable<Purchase> Purchases { get; set; } = new List<Purchase>();
        public virtual required Basket Basket { get; set; } 
        public virtual  IEnumerable<Feedback> Feedbacks { get; set; } = new List<Feedback>();


        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    return FirstName;
                }
                return $"{FirstName} {LastName}";
            }
        }
    }
}
