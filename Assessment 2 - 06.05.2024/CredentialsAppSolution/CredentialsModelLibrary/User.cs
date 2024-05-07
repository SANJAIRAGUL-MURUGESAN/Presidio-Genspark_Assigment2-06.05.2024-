namespace CredentialsModelLibrary
{
    public class User : IEquatable<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IncorrectAttempt { get; set; }
        public string Location { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            IncorrectAttempt = 0;
            Location = string.Empty;
        }

        public User(string username,string password,string email,int incorrectattempt,string location)
        {
            Username = username;
            Password = password;
            Email = email;
            IncorrectAttempt = incorrectattempt;
            Location = location;
        }
        public bool Equals(User? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
