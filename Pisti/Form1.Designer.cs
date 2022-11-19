namespace Pisti
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnstart = new System.Windows.Forms.Button();
            this.rd101 = new System.Windows.Forms.RadioButton();
            this.rd151 = new System.Windows.Forms.RadioButton();
            this.rd201 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.Red;
            this.btnstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnstart.ForeColor = System.Drawing.Color.Snow;
            this.btnstart.Location = new System.Drawing.Point(187, 222);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(127, 100);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Başla";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // rd101
            // 
            this.rd101.AutoSize = true;
            this.rd101.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rd101.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rd101.Location = new System.Drawing.Point(223, 140);
            this.rd101.Name = "rd101";
            this.rd101.Size = new System.Drawing.Size(56, 22);
            this.rd101.TabIndex = 1;
            this.rd101.TabStop = true;
            this.rd101.Text = "101";
            this.rd101.UseVisualStyleBackColor = false;
            // 
            // rd151
            // 
            this.rd151.AutoSize = true;
            this.rd151.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rd151.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rd151.Location = new System.Drawing.Point(223, 168);
            this.rd151.Name = "rd151";
            this.rd151.Size = new System.Drawing.Size(56, 22);
            this.rd151.TabIndex = 2;
            this.rd151.TabStop = true;
            this.rd151.Text = "151";
            this.rd151.UseVisualStyleBackColor = false;
            // 
            // rd201
            // 
            this.rd201.AutoSize = true;
            this.rd201.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rd201.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rd201.Location = new System.Drawing.Point(223, 196);
            this.rd201.Name = "rd201";
            this.rd201.Size = new System.Drawing.Size(56, 22);
            this.rd201.TabIndex = 3;
            this.rd201.TabStop = true;
            this.rd201.Text = "201";
            this.rd201.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(197, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kaçta Bitsin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(506, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rd201);
            this.Controls.Add(this.rd151);
            this.Controls.Add(this.rd101);
            this.Controls.Add(this.btnstart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.RadioButton rd101;
        private System.Windows.Forms.RadioButton rd151;
        private System.Windows.Forms.RadioButton rd201;
        private System.Windows.Forms.Label label1;
    }
}

