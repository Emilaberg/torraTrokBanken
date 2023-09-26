
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
            Random rng = new Random();
            decimal money = rng.Next(999,10000);
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

        public bool TransferOut(int amount)
        {
            money -= amount;
            return true;
        }
        public bool TransferIn(int amount)
        {
            money += amount;
            return true;
        }
    }
}
