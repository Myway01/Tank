namespace TankWar
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.picture_me = new System.Windows.Forms.PictureBox();
            this.label_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_me)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_me
            // 
            this.picture_me.Image = ((System.Drawing.Image)(resources.GetObject("picture_me.Image")));
            this.picture_me.Location = new System.Drawing.Point(50, 50);
            this.picture_me.Name = "picture_me";
            this.picture_me.Size = new System.Drawing.Size(116, 160);
            this.picture_me.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_me.TabIndex = 0;
            this.picture_me.TabStop = false;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.Transparent;
            this.label_Name.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.Location = new System.Drawing.Point(228, 74);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(169, 114);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "姓名：许博\r\n学号：3015209230\r\n专业：电子商务\r\n班级：1班\r\nQQ:897090750\r\nTel:18322303006";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 273);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.picture_me);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            ((System.ComponentModel.ISupportInitialize)(this.picture_me)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_me;
        private System.Windows.Forms.Label label_Name;
    }
}