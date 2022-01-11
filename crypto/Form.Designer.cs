namespace crypto
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.txtForEncryption = new System.Windows.Forms.TextBox();
            this.rsaButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDecrypted = new System.Windows.Forms.TextBox();
            this.decryptButton = new System.Windows.Forms.Button();
            this.md5Button = new System.Windows.Forms.Button();
            this.currAlgorithmLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.encryptFileButton = new System.Windows.Forms.Button();
            this.decryptFileButton = new System.Windows.Forms.Button();
            this.openFileDialogEncrypt = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogDecrypt = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtForEncryption
            // 
            this.txtForEncryption.Location = new System.Drawing.Point(15, 106);
            this.txtForEncryption.Multiline = true;
            this.txtForEncryption.Name = "txtForEncryption";
            this.txtForEncryption.Size = new System.Drawing.Size(554, 65);
            this.txtForEncryption.TabIndex = 0;
            // 
            // rsaButton
            // 
            this.rsaButton.Location = new System.Drawing.Point(15, 12);
            this.rsaButton.Name = "rsaButton";
            this.rsaButton.Size = new System.Drawing.Size(80, 52);
            this.rsaButton.TabIndex = 3;
            this.rsaButton.Text = "RSA";
            this.rsaButton.UseVisualStyleBackColor = true;
            this.rsaButton.Click += new System.EventHandler(this.rsaButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptButton.Location = new System.Drawing.Point(590, 106);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(116, 65);
            this.encryptButton.TabIndex = 4;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Text for encryption";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Encrypted text";
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.Location = new System.Drawing.Point(15, 301);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.txtEncrypted.Size = new System.Drawing.Size(554, 65);
            this.txtEncrypted.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Text after decryption";
            // 
            // txtDecrypted
            // 
            this.txtDecrypted.Location = new System.Drawing.Point(15, 397);
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.Name = "txtDecrypted";
            this.txtDecrypted.Size = new System.Drawing.Size(554, 65);
            this.txtDecrypted.TabIndex = 10;
            // 
            // decryptButton
            // 
            this.decryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptButton.Location = new System.Drawing.Point(590, 301);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(116, 65);
            this.decryptButton.TabIndex = 12;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // md5Button
            // 
            this.md5Button.Location = new System.Drawing.Point(101, 12);
            this.md5Button.Name = "md5Button";
            this.md5Button.Size = new System.Drawing.Size(80, 52);
            this.md5Button.TabIndex = 13;
            this.md5Button.Text = "MD5";
            this.md5Button.UseVisualStyleBackColor = true;
            this.md5Button.Click += new System.EventHandler(this.md5Button_Click);
            // 
            // currAlgorithmLabel
            // 
            this.currAlgorithmLabel.AutoSize = true;
            this.currAlgorithmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currAlgorithmLabel.Location = new System.Drawing.Point(279, 39);
            this.currAlgorithmLabel.Name = "currAlgorithmLabel";
            this.currAlgorithmLabel.Size = new System.Drawing.Size(235, 25);
            this.currAlgorithmLabel.TabIndex = 14;
            this.currAlgorithmLabel.Text = "Current algorithm: RSA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Private key";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(15, 205);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(554, 65);
            this.txtPrivateKey.TabIndex = 15;
            // 
            // encryptFileButton
            // 
            this.encryptFileButton.AllowDrop = true;
            this.encryptFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptFileButton.Location = new System.Drawing.Point(712, 106);
            this.encryptFileButton.Name = "encryptFileButton";
            this.encryptFileButton.Size = new System.Drawing.Size(116, 65);
            this.encryptFileButton.TabIndex = 17;
            this.encryptFileButton.Text = "Encrypt File";
            this.encryptFileButton.UseVisualStyleBackColor = true;
            this.encryptFileButton.Click += new System.EventHandler(this.encryptFileButton_Click);
            // 
            // decryptFileButton
            // 
            this.decryptFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptFileButton.Location = new System.Drawing.Point(712, 301);
            this.decryptFileButton.Name = "decryptFileButton";
            this.decryptFileButton.Size = new System.Drawing.Size(116, 65);
            this.decryptFileButton.TabIndex = 18;
            this.decryptFileButton.Text = "Decrypt File";
            this.decryptFileButton.UseVisualStyleBackColor = true;
            this.decryptFileButton.Click += new System.EventHandler(this.decryptFileButton_Click);
            // 
            // openFileDialogEncrypt
            // 
            this.openFileDialogEncrypt.FileName = "openFileDialogEncrypt";
            // 
            // openFileDialogDecrypt
            // 
            this.openFileDialogDecrypt.FileName = "openFileDialogDecrypt";
            // 
            // Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 513);
            this.Controls.Add(this.decryptFileButton);
            this.Controls.Add(this.encryptFileButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.currAlgorithmLabel);
            this.Controls.Add(this.md5Button);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDecrypted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEncrypted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.rsaButton);
            this.Controls.Add(this.txtForEncryption);
            this.Name = "Form";
            this.Text = "Crypto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtForEncryption;
        private System.Windows.Forms.Button rsaButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button md5Button;
        private System.Windows.Forms.Label currAlgorithmLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button encryptFileButton;
        private System.Windows.Forms.Button decryptFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogEncrypt;
        private System.Windows.Forms.OpenFileDialog openFileDialogDecrypt;
    }
}

