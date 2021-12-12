using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace crypto
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            MinimumSize = new Size(650, 450);
            MaximumSize = new Size(650, 450);
        }

        Crypto crypto = new Crypto();
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        byte[] encryptedText = { 0 };
        bool rsaActive = true;
        bool md5Active = false;

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
                encryptedText = crypto.RSAencryption(plainText, crypto.RSA.ExportParameters(false), false);
            }
            else if (md5Active)
            {
                char[] key = txtPrivateKey.Text.ToCharArray();
                encryptedText = crypto.MD5encryption(plainText, key);
            }
            txtEncrypted.Text = ByteConverter.GetString(encryptedText);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            byte[] decryptedText = { 0 };
            if (rsaActive) 
            {
                decryptedText = crypto.RSAdecryption(encryptedText, crypto.RSA.ExportParameters(true), false);
            }
            else if (md5Active)
            {
                char[] key = txtPrivateKey.Text.ToCharArray();
                decryptedText = crypto.MD5decryption(encryptedText, key);
            }
            txtDecrypted.Text = ByteConverter.GetString(decryptedText);
        }

        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialogEncrypt.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialogEncrypt.FileName;
            string fileText = System.IO.File.ReadAllText(filename);

            if (rsaActive)
            {
                crypto.RSAEncrypt(filename);
            } 
            else if (md5Active)
            {
                byte[] plainText = ByteConverter.GetBytes(fileText);
                char[] key = txtPrivateKey.Text.ToCharArray();
                byte[] encryptedFile = crypto.MD5encryption(plainText, key);
                File.WriteAllText("D:\\projects\\VS19 projects\\cryptography\\crypto\\crypto\\encrypted.txt", 
                    System.Text.Encoding.UTF8.GetString(encryptedFile));
            }
        }

        private void decryptFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialogEncrypt.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialogEncrypt.FileName;
            string fileText = System.IO.File.ReadAllText(filename);

            string decrypted = "";
            if (rsaActive)
            {
                decrypted = crypto.RSADecrypt(filename);
            }
            else if (md5Active)
            {
                byte[] plainText = ByteConverter.GetBytes(fileText);
                char[] key = txtPrivateKey.Text.ToCharArray();
                byte[] decryptedFile = crypto.MD5decryption(plainText, key);
                decrypted = System.Text.Encoding.UTF8.GetString(decryptedFile);
            }
            File.WriteAllText("D:\\projects\\VS19 projects\\cryptography\\crypto\\crypto\\decrypted.txt", decrypted);
        }
    }
}


