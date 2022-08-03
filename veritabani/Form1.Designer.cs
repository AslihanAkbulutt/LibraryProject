namespace veritabani
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btKisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btOdunc = new System.Windows.Forms.Button();
            this.btUrun = new System.Windows.Forms.Button();
            this.btDiger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btKisi
            // 
            this.btKisi.BackColor = System.Drawing.Color.Salmon;
            this.btKisi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btKisi.Location = new System.Drawing.Point(25, 341);
            this.btKisi.Name = "btKisi";
            this.btKisi.Size = new System.Drawing.Size(155, 72);
            this.btKisi.TabIndex = 8;
            this.btKisi.Text = "KİŞİ İŞLEMLERİ";
            this.btKisi.UseVisualStyleBackColor = false;
            this.btKisi.Click += new System.EventHandler(this.btKisi_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(201, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 167);
            this.label1.TabIndex = 7;
            this.label1.Text = "MENÜ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btOdunc
            // 
            this.btOdunc.BackColor = System.Drawing.Color.Salmon;
            this.btOdunc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btOdunc.Location = new System.Drawing.Point(220, 341);
            this.btOdunc.Name = "btOdunc";
            this.btOdunc.Size = new System.Drawing.Size(155, 72);
            this.btOdunc.TabIndex = 6;
            this.btOdunc.Text = "ÖDÜNÇ/İADE İŞLEMLERİ";
            this.btOdunc.UseVisualStyleBackColor = false;
            this.btOdunc.Click += new System.EventHandler(this.btOdunc_Click);
            // 
            // btUrun
            // 
            this.btUrun.BackColor = System.Drawing.Color.Salmon;
            this.btUrun.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btUrun.Location = new System.Drawing.Point(414, 341);
            this.btUrun.Name = "btUrun";
            this.btUrun.Size = new System.Drawing.Size(155, 72);
            this.btUrun.TabIndex = 5;
            this.btUrun.Text = "ÜRÜN İŞLEMLERİ";
            this.btUrun.UseVisualStyleBackColor = false;
            this.btUrun.Click += new System.EventHandler(this.btUrun_Click);
            // 
            // btDiger
            // 
            this.btDiger.BackColor = System.Drawing.Color.Salmon;
            this.btDiger.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btDiger.Location = new System.Drawing.Point(611, 341);
            this.btDiger.Name = "btDiger";
            this.btDiger.Size = new System.Drawing.Size(155, 72);
            this.btDiger.TabIndex = 9;
            this.btDiger.Text = "DİĞER İŞLEMLER";
            this.btDiger.UseVisualStyleBackColor = false;
            this.btDiger.Click += new System.EventHandler(this.btDiger_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btDiger);
            this.Controls.Add(this.btKisi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btOdunc);
            this.Controls.Add(this.btUrun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btKisi;
        private Label label1;
        private Button btOdunc;
        private Button btUrun;
        private Button btDiger;
    }
}