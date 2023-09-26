namespace torratråkbanken
{
    internal class User
    {
        string username;
        string password;
        int userId;
        public User(string username, string password, int userId)
        {
            this.username = username;
            this.password = password;
            this.userId = userId;
        }

        public string GetUsername()
        {
            return username;
        }
    }
}
