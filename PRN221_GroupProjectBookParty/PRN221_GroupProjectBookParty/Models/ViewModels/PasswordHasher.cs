using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PRN221_GroupProjectBookParty.Models.ViewModels
{
    public class PasswordHasher
    {
        private const int SaltSize = 16; // 128 bits
        private const int KeySize = 32; // 256 bits
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            // Tạo một salt ngẫu nhiên
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Tạo một hash từ mật khẩu và salt
            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: KeySize);

            // Kết hợp salt và hash thành một chuỗi
            byte[] hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            // Chuyển đổi chuỗi byte sang chuỗi hex để lưu trữ
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Chuyển đổi chuỗi hex sang chuỗi byte
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Tách salt từ chuỗi hash
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Tạo hash từ mật khẩu và salt
            byte[] hashToVerify = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: KeySize);

            // So sánh hash đã tạo ra với hash trong chuỗi hash
            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != hashToVerify[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
