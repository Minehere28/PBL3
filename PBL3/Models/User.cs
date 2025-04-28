using YourNamespace.Models;

namespace PBL3.Models
{
    public class User : Account
    {
        //danh sách các tài khoản ngân hàng
        public DateTime NS { get; set; }
        public bool Gender { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public User()
        {
            BankAccounts = new HashSet<BankAccount>();
        }   

    }
}
