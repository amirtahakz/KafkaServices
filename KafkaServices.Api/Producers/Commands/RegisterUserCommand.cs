namespace KafkaServices.Api.Producers.Commands
{
    public class RegisterUserCommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
