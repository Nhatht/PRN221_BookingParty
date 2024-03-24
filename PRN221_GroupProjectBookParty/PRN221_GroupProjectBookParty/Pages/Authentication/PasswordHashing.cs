using System;
using System.Security.Cryptography;
using System.Text;

namespace PRN221_GroupProjectBookParty.Pages.Authentication
{
    public class PasswordHashing
    {
        // Hàm để hash mật khẩu sử dụng thuật toán SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi mật khẩu từ kiểu string sang mảng byte
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array thành một chuỗi hex string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Hàm để kiểm tra mật khẩu đã hash có khớp với mật khẩu gốc không
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Hash mật khẩu và so sánh với mật khẩu đã hash
            string hashOfInput = HashPassword(password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hashedPassword) == 0;
        }
    }
}
