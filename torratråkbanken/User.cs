namespace torratråkbanken
{
    internal class User
    {
        string username;
        string password;
        int userId;
        public SavingsAccount savingsAccount;
        public SalaryAccount salaryAccount;
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

        public void CreateSavingsAccount()
        {
            savingsAccount = new(userId);
            savingsAccount.GenerateStartingSum();
        }

        public void CreateSalaryAccount()
        {
            salaryAccount = new(userId);
            
        }
    }
}
