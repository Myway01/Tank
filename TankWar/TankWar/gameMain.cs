using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankWar
{

    public partial class gameMain : Form
    {
        public static int elapsedFrames;//过去的帧数
        public Timer Time_Run;//总进程
        public static ProductTank gameProductTank;//坦克生成
        public static Map gameMap;//地图
        public static CheckHit gameCheckHit;//碰撞判定
        public static p1Tank gamep1Tank;//玩家坦克
        public static List<eTank> ListeTank;//敌方坦克
        public static List<Bullet> ListBullet;//炮弹
        public static List<Animation> ListAnimation;//动画效果
        public static List<Property> ListProperty;//游戏道具
        public static gameMain gameForm;//游戏窗口
        public static TankWar gameTankWar;//胜负判定
        public static PanelDraw gamePanelDraw;//右侧区域绘制
        /// <summary>
        /// 游戏初始化
        /// </summary>
        public gameMain()
        {
            InitializeComponent();
            Time_Run = Time_Game;
            gameForm = this;
            ListAnimation = new List<Animation>();
            gameProductTank = new ProductTank();
            gameMap = new Map();
            gamep1Tank = new p1Tank();
            gameCheckHit = new CheckHit();
            ListBullet = new List<Bullet>();
            ListeTank = new List<eTank>();
            ListProperty = new List<Property>();
            gameTankWar = new TankWar();
            gamePanelDraw = new PanelDraw();
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.start);
            sp.Play();//游戏开始音效
        }
        /// <summary>
        /// 主窗口屏幕绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            gameMap.Draw(g);//地图
            if (gamep1Tank.IsBorn)
                gamep1Tank.Draw(g);//玩家坦克
            foreach (eTank etank in ListeTank)
            {
                if(etank.ETankFrames>30)
                    etank.Draw(g);//敌方坦克
            }
            foreach (Bullet bullet in ListBullet)
            {
                bullet.Draw(g);//炮弹
            }
            for (int i = 0; i < 13; i++)
            {
                g.DrawImage(Properties.Resources.grasses, i * 60, 450);//树林
            }
            for (int i = 0; i < ListProperty.Count; i++)
            {
                ListProperty[i].Draw(g);//道具
            }
            if (gameCheckHit.IsBaseDestyoyed)
            {
                g.FillRectangle(Brushes.Black, 360, 630, 60, 60);
                g.DrawImage(Properties.Resources.destory, 360, 630);//被摧毁的己方基地
            }
            for (int i = 0; i < ListAnimation.Count; i++)
            {
                ListAnimation[i].Draw(g);//动画效果
            }
            if (gameTankWar.IsStop)
            {
                g.DrawImage(Properties.Resources.pause, 326, 276);//暂停后的继续图标
            }
        }
        /// <summary>
        /// 游戏相关数据更新
        /// </summary>
        private void Update()
        {
            gameProductTank.Update();//生成坦克数据
            gameTankWar.Update();//胜负数据
            if (gamep1Tank.IsBorn)
                gamep1Tank.Update();//玩家坦克数据
            gameCheckHit.Update();//碰撞数据
            for (int i = ListeTank.Count - 1; i >= 0; i--)
            {
                ListeTank[i].ETankFrames++;
                if(ListeTank[i].ETankFrames>30)//坦克在生成动画结束方可出现
                    ListeTank[i].Update();//敌方坦克数据
            }
            for (int i = ListBullet.Count - 1; i >= 0; i--)
            {
                ListBullet[i].Update();//炮弹数据
            }
        }
        /// <summary>
        /// Timer控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //未暂停、未失败、未胜利状态下帧数增加、数据更新
            if (!gameTankWar.IsStop && !gameTankWar.IsGameOver&&!gameTankWar.IsGameWin)
            {
                elapsedFrames++;
                Update();
            }
            this.Invalidate();
            if (gameCheckHit.IsPanelRefresh)
            {
                Panel_Information.Invalidate();//必要时对Panel控件进行重绘
                gameCheckHit.IsPanelRefresh = false;
            }
        }
        /// <summary>
        /// Panel控件绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_Information_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            gamePanelDraw.Draw(g);
        }
        /// <summary>
        /// Button点击事件调出相应窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_operate_Click(object sender, EventArgs e)
        {
            FormOperate frmo = new FormOperate();
            frmo.ShowDialog();
        }

        private void button_information_Click(object sender, EventArgs e)
        {
            FormInformation frmi = new FormInformation();
            frmi.ShowDialog();
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            FormAbout frma = new FormAbout();
            frma.ShowDialog();
        }
    }
}
