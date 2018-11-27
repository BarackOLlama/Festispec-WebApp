namespace Festispec_WebApp.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Username:{Username.ToString()} Password: {Password.ToString()}";
        }
    }
}