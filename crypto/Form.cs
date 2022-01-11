using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace crypto
{
    public partial class Form : System.Windows.Forms.Form
    {
        private void showDragDropEffect_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        void encryptFileBy_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; 
            if (files != null)
            {
                try
                {
                    string filename = files[0];
                    string fileText = System.IO.File.ReadAllText(filename);
                    byte[] plainText = ByteConverter.GetBytes(fileText);

                    if (rsaActive)
                    {
                        encryptedFileText = crypto.RSAencryption(plainText, crypto.RSA.ExportParameters(false), false);
                    }
                    else if (md5Active)
                    {
                        char[] key = txtPrivateKey.Text.ToCharArray();
                        encryptedFileText = crypto.MD5encryption(plainText, key);
                    }
                    FileStream fs = new FileStream(encryptedFilename, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(encryptedFileText, 0, encryptedFileText.Length);
                    fs.Flush();
                    fs.Close();
                }
                catch { }
            }
            MessageBox.Show("encrypted");
        }

        void decryptFileBy_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; 
            if (files != null)
            {
                try
                {
                    string filename = files[0];
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] encryptedFromFile = br.ReadBytes(Convert.ToInt32(fs.Length));
                    fs.Flush();
                    fs.Close();

                    if (rsaActive)
                    {
                       
                    byte[] decrypted = crypto.RSAdecryption(encryptedFromFile, crypto.RSA.ExportParameters(true), false);
                        File.WriteAllText(decryptedFilename, System.Text.Encoding.UTF8.GetString(decrypted));
                    }
                    else if (md5Active)
                    {
                        char[] key = txtPrivateKey.Text.ToCharArray();
                        byte[] decrypted = crypto.MD5decryption(encryptedFromFile, key);
                        File.WriteAllText(decryptedFilename, System.Text.Encoding.UTF8.GetString(decrypted));
                    }
                }
                catch { }
            }
            MessageBox.Show("decrypted");
        }

        public Form()
        {
            InitializeComponent();
            encryptFileButton.AllowDrop = true;
            encryptFileButton.DragEnter += new DragEventHandler(showDragDropEffect_DragEnter);
            encryptFileButton.DragDrop += new DragEventHandler(encryptFileBy_DragDrop);
            decryptFileButton.AllowDrop = true;
            decryptFileButton.DragEnter += new DragEventHandler(showDragDropEffect_DragEnter);
            decryptFileButton.DragDrop += new DragEventHandler(decryptFileBy_DragDrop);
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            MinimumSize = new Size(650, 450);
            MaximumSize = new Size(650, 450);
        }

        Crypto crypto = new Crypto();
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        byte[] encryptedText = { 0 };
        byte[] encryptedFileText = { 0 };
        bool rsaActive = true;
        bool md5Active = false;
        const string encryptedFilename = "D:\\projects\\VS19 projects\\cryptography\\crypto\\crypto\\encrypted.bin";
        const string decryptedFilename = "D:\\projects\\VS19 projects\\cryptography\\crypto\\crypto\\decrypted.txt";

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
            try
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
            catch { }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            try
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
            catch { }
        }

        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogEncrypt.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = openFileDialogEncrypt.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                byte[] plainText = ByteConverter.GetBytes(fileText);

                if (rsaActive)
                {
                    encryptedFileText = crypto.RSAencryption(plainText, crypto.RSA.ExportParameters(false), false);
                }
                else if (md5Active)
                {
                    char[] key = txtPrivateKey.Text.ToCharArray();
                    encryptedFileText = crypto.MD5encryption(plainText, key);
                }
                FileStream fs = new FileStream(encryptedFilename, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(encryptedFileText, 0, encryptedFileText.Length);
                fs.Flush();
                fs.Close();
            }
            catch { }
        }

        private void decryptFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogEncrypt.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = openFileDialogEncrypt.FileName;
                FileStream fs = new FileStream(filename, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                byte[] encryptedFromFile = br.ReadBytes(Convert.ToInt32(fs.Length));
                fs.Flush();
                fs.Close();

                if (rsaActive)
                {
                    byte[] decrypted = crypto.RSAdecryption(encryptedFromFile, crypto.RSA.ExportParameters(true), false);
                    File.WriteAllText(decryptedFilename, System.Text.Encoding.UTF8.GetString(decrypted));
                }
                else if (md5Active)
                {
                    char[] key = txtPrivateKey.Text.ToCharArray();
                    byte[] decrypted = crypto.MD5decryption(encryptedFromFile, key);
                    File.WriteAllText(decryptedFilename, System.Text.Encoding.UTF8.GetString(decrypted));
                }
            }
            catch { }
        }
    }
}


