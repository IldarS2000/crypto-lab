using System;
using System.Text;
using System.Security.Cryptography;

namespace crypto
{
    class Crypto
    {
        private RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
        private MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();

        public MD5CryptoServiceProvider MD5 { get => mD5; set => mD5 = value; }
        public RSACryptoServiceProvider RSA { get => rSA; set => rSA = value; }

        public byte[] RSAencryption(byte[] data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData = { 0 };
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public byte[] RSAdecryption(byte[] data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData = { 0 };
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public byte[] MD5encryption(byte[] data, char[] privateKey)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(privateKey));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        return transform.TransformFinalBlock(data, 0, data.Length);
                    }
                }
            }
        }

        public byte[] MD5decryption(byte[] data, char[] privateKey)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(privateKey));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        return transform.TransformFinalBlock(data, 0, data.Length);
                    }
                }
            }
        }
    }
}
