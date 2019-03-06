namespace TankWar
{
    partial class gameMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameMain));
            this.Time_Game = new System.Windows.Forms.Timer(this.components);
            this.Panel_Information = new DoubleBufferedPanel();//双缓冲控件
            this.button_information = new System.Windows.Forms.Button();
            this.button_about = new System.Windows.Forms.Button();
            this.button_operate = new System.Windows.Forms.Button();
            this.Panel_Information.SuspendLayout();
            this.SuspendLayout();
            // 
            // Time_Game
            // 
            this.Time_Game.Enabled = true;
            this.Time_Game.Interval = 10;
            this.Time_Game.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Panel_Information
            // 
            this.Panel_Information.BackColor = System.Drawing.Color.LightGray;
            this.Panel_Information.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Information.BackgroundImage")));
            this.Panel_Information.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_Information.Controls.Add(this.button_information);
            this.Panel_Information.Controls.Add(this.button_about);
            this.Panel_Information.Controls.Add(this.button_operate);
            this.Panel_Information.Location = new System.Drawing.Point(780, 0);
            this.Panel_Information.Name = "Panel_Information";
            this.Panel_Information.Size = new System.Drawing.Size(300, 690);
            this.Panel_Information.TabIndex = 0;
            this.Panel_Information.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Information_Paint);
            // 
            // button_information
            // 
            this.button_information.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_information.BackgroundImage")));
            this.button_information.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_information.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_information.FlatAppearance.BorderSize = 0;
            this.button_information.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_information.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_information.ForeColor = System.Drawing.Color.White;
            this.button_information.Location = new System.Drawing.Point(90, 520);
            this.button_information.Name = "button_information";
            this.button_information.Size = new System.Drawing.Size(120, 40);
            this.button_information.TabIndex = 1;
            this.button_information.Text = "游戏说明";
            this.button_information.UseVisualStyleBackColor = true;
            this.button_information.Click += new System.EventHandler(this.button_information_Click);
            // 
            // button_about
            // 
            this.button_about.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_about.BackgroundImage")));
            this.button_about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_about.FlatAppearance.BorderSize = 0;
            this.button_about.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_about.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_about.ForeColor = System.Drawing.Color.White;
            this.button_about.Location = new System.Drawing.Point(90, 590);
            this.button_about.Name = "button_about";
            this.button_about.Size = new System.Drawing.Size(120, 40);
            this.button_about.TabIndex = 1;
            this.button_about.Text = "关于";
            this.button_about.UseVisualStyleBackColor = true;
            this.button_about.Click += new System.EventHandler(this.button_about_Click);
            // 
            // button_operate
            // 
            this.button_operate.BackColor = System.Drawing.Color.LightGray;
            this.button_operate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_operate.BackgroundImage")));
            this.button_operate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_operate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_operate.FlatAppearance.BorderSize = 0;
            this.button_operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_operate.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_operate.ForeColor = System.Drawing.Color.White;
            this.button_operate.Location = new System.Drawing.Point(90, 450);
            this.button_operate.Name = "button_operate";
            this.button_operate.Size = new System.Drawing.Size(120, 40);
            this.button_operate.TabIndex = 0;
            this.button_operate.Text = "操作说明";
            this.button_operate.UseMnemonic = false;
            this.button_operate.UseVisualStyleBackColor = true;
            this.button_operate.Click += new System.EventHandler(this.button_operate_Click);
            // 
            // gameMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::TankWar.Properties.Resources.map;
            this.ClientSize = new System.Drawing.Size(1080, 690);
            this.Controls.Add(this.Panel_Information);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "gameMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TankWar";
            this.Panel_Information.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Time_Game;
        private gameMain.DoubleBufferedPanel Panel_Information;
        private System.Windows.Forms.Button button_about;
        private System.Windows.Forms.Button button_operate;
        private System.Windows.Forms.Button button_information;
        /// <summary>
        /// 利用双缓冲解决控件闪烁
        /// </summary>
        public class DoubleBufferedPanel : System.Windows.Forms.Panel
        {
            public DoubleBufferedPanel() : base()
            {
                base.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.ResizeRedraw, true);
            }
        }

    }
}

