
namespace torratråkbanken
{
    
    internal class SalaryAccount
    {
        int userId;
        decimal money;
        public SalaryAccount(int userId)
        {
            this.userId = userId;
        }

        public int SalaryAccountUserId()
        {
            return userId;
        }
        public decimal GetSum()
        {
            return money;
        }
    }
}
