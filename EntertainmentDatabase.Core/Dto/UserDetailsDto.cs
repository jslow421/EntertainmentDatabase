namespace EntertainmentDatabase.Core.Dto
{
    public class UserDetailsDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}