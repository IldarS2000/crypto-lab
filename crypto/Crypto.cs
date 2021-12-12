using System;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace crypto
{
    class Crypto
    {
        private RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
        private MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();

        public MD5CryptoServiceProvider MD5 { get => mD5; set => mD5 = value; }
        public RSACryptoServiceProvider RSA { get => rSA; set => rSA = value; }

        Random rnd = new Random();
        List<int> primes = GeneratePrimesNaive(20);

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

        readonly char[] characters = new char[] {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
            ' ', '\n', '\t' };
        long d;
        long n;

        public void RSAEncrypt(string filename)
        {
            long p = primes[rnd.Next(0, primes.Count - 1)];
            long q = primes[rnd.Next(0, primes.Count - 1)];

            string s = "";
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                s += sr.ReadLine();
            }
            sr.Close();

            n = p * q;
            long m = (p - 1) * (q - 1);
            d = Calculate_d(m);
            long e_ = Calculate_e(d, m);

            List<string> result = RSA_Encode(s, e_, n);
            File.WriteAllLines("D:\\projects\\VS19 projects\\cryptography\\crypto\\crypto\\encrypted.txt", result);
        }

        public string RSADecrypt(string filename)
        {
            List<string> input = new List<string>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }
            sr.Close();

            return RSA_Decode(input, d, n);
        }

        private List<string> RSA_Encode(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi %= n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        private string RSA_Decode(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi %= n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }

        private long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
            {
                if ((m % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }
            }

            return d;
        }

        private long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                {
                    break;
                }
                else
                {
                    e++;
                }
            }

            return e;
        }

        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }
    }
}
