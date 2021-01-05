namespace Yuzem_Optik
{
    partial class Form1
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
            this.fileDialogButton = new System.Windows.Forms.Button();
            this.folderStatus = new System.Windows.Forms.Label();
            this.starterButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // fileDialogButton
            // 
            this.fileDialogButton.Location = new System.Drawing.Point(632, 13);
            this.fileDialogButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileDialogButton.Name = "fileDialogButton";
            this.fileDialogButton.Size = new System.Drawing.Size(112, 40);
            this.fileDialogButton.TabIndex = 0;
            this.fileDialogButton.Text = "Dosya Seç";
            this.fileDialogButton.UseVisualStyleBackColor = true;
            this.fileDialogButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // folderStatus
            // 
            this.folderStatus.AutoSize = true;
            this.folderStatus.Location = new System.Drawing.Point(18, 23);
            this.folderStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.folderStatus.Name = "folderStatus";
            this.folderStatus.Size = new System.Drawing.Size(352, 20);
            this.folderStatus.TabIndex = 1;
            this.folderStatus.Text = "Lütfen optik resimlerinin bulunduğu dosyayı seçin";
            // 
            // starterButton
            // 
            this.starterButton.Enabled = false;
            this.starterButton.Location = new System.Drawing.Point(18, 111);
            this.starterButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.starterButton.Name = "starterButton";
            this.starterButton.Size = new System.Drawing.Size(726, 51);
            this.starterButton.TabIndex = 2;
            this.starterButton.Text = "Başla";
            this.starterButton.UseVisualStyleBackColor = true;
            this.starterButton.Click += new System.EventHandler(this.starterButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 117);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(726, 45);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(757, 181);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.starterButton);
            this.Controls.Add(this.folderStatus);
            this.Controls.Add(this.fileDialogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "YUZEM OPTİK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileDialogButton;
        private System.Windows.Forms.Label folderStatus;
        private System.Windows.Forms.Button starterButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

