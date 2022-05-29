namespace CustomerApp.Domain
{
    public class Customer
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Username { get; init; } = default!;

        public string Fullname { get; init; } = default!;

        public string Email { get; init; } = default!;

        public DateTime DateOfBirth { get; set; }
    }
}