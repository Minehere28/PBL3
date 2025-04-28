using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public abstract class Account
    {
        //là account id
        private string _sdt;
        private string _hoten;

        private static PasswordHasher<Account> hasher = new PasswordHasher<Account>();

        [Key]
        public string Sdt { get => _sdt; set => _sdt = value; }
        [Required]
        public string Hoten { get => _hoten; set => _hoten = value; }
        [Required]
        public string PasswordHash { get; set; }  // Đổi tên để rõ ràng

        // Băm mật khẩu và lưu
        public void SetPassword(string rawPassword)
        {
            PasswordHash = hasher.HashPassword(this, rawPassword);
        }

        // Kiểm tra mật khẩu nhập vào
        public bool VerifyPassword(string inputPassword)
        {
            var result = hasher.VerifyHashedPassword(this, PasswordHash, inputPassword);
            return result == PasswordVerificationResult.Success;
        }

        //public abstract void DisplayInfo();
        //public abstract string GetData();

    }
}
