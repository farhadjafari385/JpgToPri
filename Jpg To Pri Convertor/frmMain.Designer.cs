namespace Jpg_To_Pri_Convertor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSelect = new System.Windows.Forms.Button();
            this.ofg = new System.Windows.Forms.OpenFileDialog();
            this.imgPre = new System.Windows.Forms.PictureBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPre)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(156, 21);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(97, 27);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select Jpg File";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ofg
            // 
            this.ofg.DefaultExt = "jpg";
            this.ofg.Filter = "*.jpg|*.jpg|*.jpeg|*.jpeg";
            // 
            // imgPre
            // 
            this.imgPre.BackColor = System.Drawing.Color.White;
            this.imgPre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.imgPre.Location = new System.Drawing.Point(0, 79);
            this.imgPre.Name = "imgPre";
            this.imgPre.Size = new System.Drawing.Size(730, 376);
            this.imgPre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPre.TabIndex = 1;
            this.imgPre.TabStop = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(465, 21);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(97, 27);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 63);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 13);
            this.lbl.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(730, 455);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.imgPre);
            this.Controls.Add(this.btnSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jpg To Pri Convertor - Created By Doctor Drax";
            ((System.ComponentModel.ISupportInitialize)(this.imgPre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog ofg;
        private System.Windows.Forms.PictureBox imgPre;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lbl;
    }
}

