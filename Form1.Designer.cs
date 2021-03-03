
namespace IotData
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
            this.components = new System.ComponentModel.Container();
            this.BtnInit = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnGoOff = new System.Windows.Forms.Button();
            this.BtnGoOnline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnInit
            // 
            this.BtnInit.Location = new System.Drawing.Point(39, 22);
            this.BtnInit.Name = "BtnInit";
            this.BtnInit.Size = new System.Drawing.Size(107, 52);
            this.BtnInit.TabIndex = 1;
            this.BtnInit.Text = "Generate Data (START)";
            this.BtnInit.UseVisualStyleBackColor = true;
            this.BtnInit.Click += new System.EventHandler(this.BtnInit_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(39, 80);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(107, 52);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnGoOff
            // 
            this.BtnGoOff.Location = new System.Drawing.Point(152, 22);
            this.BtnGoOff.Name = "BtnGoOff";
            this.BtnGoOff.Size = new System.Drawing.Size(107, 52);
            this.BtnGoOff.TabIndex = 6;
            this.BtnGoOff.Text = "Go Offline";
            this.BtnGoOff.UseVisualStyleBackColor = true;
            this.BtnGoOff.Click += new System.EventHandler(this.BtnGoOff_Click);
            // 
            // BtnGoOnline
            // 
            this.BtnGoOnline.Location = new System.Drawing.Point(152, 80);
            this.BtnGoOnline.Name = "BtnGoOnline";
            this.BtnGoOnline.Size = new System.Drawing.Size(107, 52);
            this.BtnGoOnline.TabIndex = 7;
            this.BtnGoOnline.Text = "Go Online";
            this.BtnGoOnline.UseVisualStyleBackColor = true;
            this.BtnGoOnline.Click += new System.EventHandler(this.BtnGoOnline_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 155);
            this.Controls.Add(this.BtnGoOnline);
            this.Controls.Add(this.BtnGoOff);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnInit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Generator";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnInit;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnGoOff;
        private System.Windows.Forms.Button BtnGoOnline;
    }
}

