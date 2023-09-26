
namespace torratråkbanken
{
    
    internal class SavingsAccount
    {
        int userId;
        decimal money;
        public SavingsAccount(int userId)
        {
            this.userId = userId;

        }

        public void GenerateStartingSum()
        {
            decimal money = 10000;
            this.money = money;
        }

        public int SavingsAccountUserId()
        {
            return userId;
        }
        public decimal GetSum()
        {
            return money;
        }
    }
}
