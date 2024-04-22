namespace VapeShop.Domain.Identity

{
    public class User
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }

        public required UserRole Role { get; set; }


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
