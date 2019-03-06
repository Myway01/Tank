using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TankWar
{
    public class p1Tank
    {
        int p1tanklife = 3;//p1坦克生命值
        int x;
        int y;
        Image image;
        int speed;//速度值
        int width;
        int height;
        bool canFire = true;//是否可发射炮弹，用于控制每次发射一枚炮弹
        bool isborn = false;//是否坦克生成动画已结束
        moveDirection xMove = moveDirection.Stop;//横向移动
        moveDirection yMove = moveDirection.Stop;//纵向移动
        moveDirection fireDirection = moveDirection.Up;//开炮方向
        int pbspeed = 10;//炮弹速度
        public int p1TankLife
        {
            set { p1tanklife = value; }
            get { return p1tanklife; }
        }
        public int X
        {
            set { x = value; }
            get { return x; }
        }
        public int Y
        {
            set { y = value; }
            get { return y; }
        }
        public int Width
        {
            set { width = value; }
            get { return width; }
        }
        public int Height
        {
            set { height = value; }
            get { return height; }
        }
        public int Speed
        {
            set { speed = value; }
            get { return speed; }
        }
        public bool CanFire
        {
            set { canFire = value; }
            get { return canFire; }
        }
        public bool IsBorn
        {
            set { isborn = value; }
            get { return isborn; }
        }
        public int PBSpeed
        {
            set { pbspeed = value; }
            get { return pbspeed; }
        }

        /// <summary>
        /// 构造函数设置玩家坦克初始值
        /// </summary>
        public p1Tank()
        {
            gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.P1TankBorn, 270, 630));//生成动画
            image = Properties.Resources.p1tankU;
            x = 270; y = 630;
            width = 60; height = 60;
            speed = 5;
            gameMain.gameForm.KeyUp += new KeyEventHandler(gameForm_KeyUp);//添加键盘事件
            gameMain.gameForm.KeyDown += new KeyEventHandler(gameForm_KeyDown);//添加键盘事件
        }
        /// <summary>
        /// 按键抬起移动停止，重新开始，退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gameForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.S:
                    yMove = moveDirection.Stop;
                    break;
                case Keys.A:
                case Keys.D:
                    xMove = moveDirection.Stop;
                    break;
                case Keys.J:
                    break;
                case Keys.O:
                    //游戏结束状态下松开O键重新开始
                    if (gameMain.gameTankWar.IsGameOver || gameMain.gameTankWar.IsGameWin)
                    {
                        gameMain.gameForm.KeyUp -= new KeyEventHandler(gameForm_KeyUp);
                        gameMain.gameForm.KeyDown -= new KeyEventHandler(gameForm_KeyDown);
                        gameMain.ListAnimation = new List<Animation>();
                        gameMain.gamep1Tank = new p1Tank();
                        gameMain.gameProductTank = new ProductTank();
                        gameMain.gameMap = new Map();
                        gameMain.gameCheckHit = new CheckHit();
                        gameMain.ListBullet = new List<Bullet>();
                        gameMain.ListeTank = new List<eTank>();
                        gameMain.gameTankWar = new TankWar();
                        gameMain.gamePanelDraw = new PanelDraw();
                        System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.start);
                        sp.Play();
                    }
                    break;
                case Keys.Escape:
                    Application.Exit();//退出
                    break;

            }
        }
        /// <summary>
        /// 按键控制移动，开火，暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //游戏进行阶段有效
            if (!gameMain.gameTankWar.IsStop && !gameMain.gameTankWar.IsGameOver)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        yMove = moveDirection.Up;
                        xMove = moveDirection.Stop;
                        fireDirection = moveDirection.Up;
                        image = Properties.Resources.p1tankU;
                        break;
                    case Keys.S:
                        yMove = moveDirection.Down;
                        xMove = moveDirection.Stop;
                        fireDirection = moveDirection.Down;
                        image = Properties.Resources.p1tankD;
                        break;
                    case Keys.A:
                        xMove = moveDirection.Left;
                        yMove = moveDirection.Stop;
                        fireDirection = moveDirection.Left;
                        image = Properties.Resources.p1tankL;
                        break;
                    case Keys.D:
                        xMove = moveDirection.Right;
                        yMove = moveDirection.Stop;
                        fireDirection = moveDirection.Right;
                        image = Properties.Resources.p1tankR;
                        break;
                    case Keys.J://开火
                        Bullet bullet = new Bullet(1);
                        Fire(bullet);
                        break;
                }
            }
            if (e.KeyCode==Keys.P)//暂停
            {
                gameMain.gameTankWar.IsStop = !gameMain.gameTankWar.IsStop;
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.pause2);
                sp.Play();
            }
        }
        /// <summary>
        /// 控制坦克发射
        /// </summary>
        /// <param name="bullet"></param>
        void Fire(Bullet bullet)
        {
            //使坦克每次只能发射一发炮弹
            canFire = true;
            foreach (var b in gameMain.ListBullet)
            {
                if (b.TheType == 1)
                    canFire = false;
            }
            //分方向发射
            if (canFire)
            {
                switch (fireDirection)
                {
                    case moveDirection.Left:
                        bullet.X = x - 15;
                        bullet.Y = y + 22;
                        bullet.Dir = 1;
                        break;
                    case moveDirection.Right:
                        bullet.X = x + 60;
                        bullet.Y = y + 22;
                        bullet.Dir = 2;
                        break;
                    case moveDirection.Up:
                        bullet.X = x + 22;
                        bullet.Y = y - 15;
                        bullet.Dir = 3;
                        break;
                    case moveDirection.Down:
                        bullet.X = x + 22;
                        bullet.Y = y + 60;
                        bullet.Dir = 4;
                        break;
                }
                gameMain.ListBullet.Add(bullet);
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.fire);
                sp.Play();
            }
        }
        /// <summary>
        /// 数据更新
        /// </summary>
        public void Update()
        {
            //不撞墙可以移动
            if (!gameMain.gameCheckHit.IsHitWall(this.x, this.y, 60, 60))
            {
                switch (xMove)
                {
                    case moveDirection.Left:
                        Move.Left(ref x, speed);
                        break;
                    case moveDirection.Right:
                        Move.Right(ref x, speed, image);
                        break;
                }
                switch (yMove)
                {
                    case moveDirection.Up:
                        Move.Up(ref y, speed);
                        break;
                    case moveDirection.Down:
                        Move.Down(ref y, speed, image);
                        break;
                }
            }
            //这段使坦克不至于卡进墙里
            else
            {
                switch (fireDirection)
                {
                    case moveDirection.Left:
                        x = x + speed;
                        break;
                    case moveDirection.Right:
                        x = x - speed;
                        break;
                    case moveDirection.Up:
                        y = y + speed;
                        break;
                    case moveDirection.Down:
                        y = y - speed;
                        break;
                }
            }
        }
        /// <summary>
        /// 画出坦克
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.DrawImage(image, x, y);
        }
        /// <summary>
        /// 移动方向枚举
        /// </summary>
        enum moveDirection
        {
            Left, Right, Up, Down, Stop
        }
    }
}
