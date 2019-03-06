namespace TankWar
{
    partial class FormOperate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperate));
            this.labelW = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.labelJ = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelO = new System.Windows.Forms.Label();
            this.labelEsc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.BackColor = System.Drawing.Color.Transparent;
            this.labelW.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelW.Location = new System.Drawing.Point(40, 30);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(139, 19);
            this.labelW.TabIndex = 1;
            this.labelW.Text = "W键：坦克上移";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.BackColor = System.Drawing.Color.Transparent;
            this.labelA.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelA.Location = new System.Drawing.Point(40, 90);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(139, 19);
            this.labelA.TabIndex = 2;
            this.labelA.Text = "A键：坦克左移";
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.BackColor = System.Drawing.Color.Transparent;
            this.labelS.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelS.Location = new System.Drawing.Point(40, 60);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(139, 19);
            this.labelS.TabIndex = 3;
            this.labelS.Text = "S键：坦克下移";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.BackColor = System.Drawing.Color.Transparent;
            this.labelD.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelD.Location = new System.Drawing.Point(40, 120);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(139, 19);
            this.labelD.TabIndex = 2;
            this.labelD.Text = "D键：坦克右移";
            // 
            // labelJ
            // 
            this.labelJ.AutoSize = true;
            this.labelJ.BackColor = System.Drawing.Color.Transparent;
            this.labelJ.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelJ.Location = new System.Drawing.Point(40, 150);
            this.labelJ.Name = "labelJ";
            this.labelJ.Size = new System.Drawing.Size(139, 19);
            this.labelJ.TabIndex = 2;
            this.labelJ.Text = "J键：发射子弹";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.BackColor = System.Drawing.Color.Transparent;
            this.labelP.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelP.Location = new System.Drawing.Point(40, 180);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(99, 19);
            this.labelP.TabIndex = 2;
            this.labelP.Text = "P键：暂停";
            // 
            // labelO
            // 
            this.labelO.AutoSize = true;
            this.labelO.BackColor = System.Drawing.Color.Transparent;
            this.labelO.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelO.Location = new System.Drawing.Point(40, 210);
            this.labelO.Name = "labelO";
            this.labelO.Size = new System.Drawing.Size(239, 19);
            this.labelO.TabIndex = 2;
            this.labelO.Text = "O键：游戏结束后重新开始";
            // 
            // labelEsc
            // 
            this.labelEsc.AutoSize = true;
            this.labelEsc.BackColor = System.Drawing.Color.Transparent;
            this.labelEsc.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEsc.Location = new System.Drawing.Point(40, 240);
            this.labelEsc.Name = "labelEsc";
            this.labelEsc.Size = new System.Drawing.Size(159, 19);
            this.labelEsc.TabIndex = 2;
            this.labelEsc.Text = "Esc键：退出游戏";
            // 
            // FormOperate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(314, 309);
            this.Controls.Add(this.labelS);
            this.Controls.Add(this.labelEsc);
            this.Controls.Add(this.labelO);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelJ);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.labelW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormOperate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "操作说明";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelJ;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelO;
        private System.Windows.Forms.Label labelEsc;
    }
}