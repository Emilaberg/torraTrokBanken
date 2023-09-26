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
        public string GetPassword()
        {
            return password;
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

        public int GetUserId()
        {
            return userId;
        }

        public bool TransferMoney(string from, int amount)
        {

            if(from.ToUpper() == "SAVINGS")
            {
                if(!savingsAccount.TransferOut(amount))
                {
                    return false;
                }

                if(!salaryAccount.TransferIn(amount))
                {
                    return false;
                }
            }
            if (from.ToUpper() == "SALARY")
            {
                if (!salaryAccount.TransferOut(amount))
                {
                    return false;
                }

                if (!savingsAccount.TransferIn(amount))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
