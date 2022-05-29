namespace CustomerApp.Contracts
{
    public class CustomerDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Username { get; init; } = default!;

        public string Fullname { get; init; } = default!;

        public string EmailAddress { get; init; } = default!;

        public DateTime DateOfBirth { get; set; }
    }
}