using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace crypto
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        byte[] encryptedText = { 0 };
        bool rsaActive = true;
        bool md5Active = true;

        static public byte[] RSAencryption(byte[] data, RSAParameters RSAKey, bool DoOAEPPadding)
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

        static public byte[] RSAdecryption(byte[] data, RSAParameters RSAKey, bool DoOAEPPadding)
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

        static public byte[] MD5encryption(byte[] data, char[] privateKey)
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

        static public byte[] MD5decryption(byte[] data, char[] privateKey)
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

        private void rsaButton_Click(object sender, EventArgs e)
        {
            rsaActive = true;
            md5Active = false;
            currAlgorithmLabel.Text = "Current algorithm: RSA";
        }

        private void md5Button_Click(object sender, EventArgs e)
        {
            md5Active = true;
            rsaActive = false;
            currAlgorithmLabel.Text = "Current algorithm: MD5";
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            byte[] plainText = ByteConverter.GetBytes(txtForEncryption.Text);
            if (rsaActive)
            {
                encryptedText = RSAencryption(plainText, RSA.ExportParameters(false), false);
            }
            else if (md5Active)
            {
                char[] key = txtPrivateKey.Text.ToCharArray();
                encryptedText = MD5encryption(plainText, key);
            }
            txtEncrypted.Text = ByteConverter.GetString(encryptedText);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            byte[] decryptedText = { 0 };
            if (rsaActive) 
            {
                decryptedText = RSAdecryption(encryptedText, RSA.ExportParameters(true), false);
            }
            else if (md5Active)
            {
                char[] key = txtPrivateKey.Text.ToCharArray();
                decryptedText = MD5decryption(encryptedText, key);
            }
            txtDecrypted.Text = ByteConverter.GetString(decryptedText);
        }
    }
}
