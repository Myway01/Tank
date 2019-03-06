using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public class eTank
    {
        static Random rd = new Random();//备用随机数
        int type = rd.Next(1, 4);//随机类型：1普通坦克，2轻坦克，3重坦克
        int pos = rd.Next(1, 4);//随机初始位置：1左，2中，3右
        int dir;//方向：1左，2右，3上，4下
        bool changeDir = false;//是否转向
        bool isFire = false;//是否开火
        int etankFrames = 0;//用于敌方坦克的帧
        int x;
        int y;
        Image image;
        int speed;//速度
        int width;
        int height;
        public int Type
        {
            set { type = value; }
            get { return type; }
        }
        public int Pos
        {
            set { pos = value; }
            get { return pos; }
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
        public int ETankFrames
        {
            set { etankFrames = value; }
            get { return etankFrames; }
        }

        public eTank()
        {
            //随机初始位置设定
            switch (pos)
            {
                case 1:
                    x = 0; y = 0;
                    break;
                case 2:
                    x = 360; y = 0;
                    break;
                case 3:
                    x = 720; y = 0;
                    break;
            }
            gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.Etankborn, x, y));
            //随机类型设定
            switch (type)
            {
                case 1:
                    image = Properties.Resources.enemy1D;
                    width = 60;
                    height = 60;
                    speed = 4;
                    break;
                case 2:
                    image = Properties.Resources.enemy2D;
                    width = 60;
                    height = 60;
                    speed = 6;
                    break;
                case 3:
                    image = Properties.Resources.enemy3D;
                    width = 60;
                    height = 60;
                    speed = 3;
                    break;
            }
        }
        /// <summary>
        /// 数据更新
        /// </summary>
        public void Update()
        {
            if (etankFrames % 90 == 40|| (x == 0 && dir == 1)|| (x == 720 && dir == 2)|| (y == 0 && dir == 3)|| (y == 630 && dir == 4))
            {
                changeDir = true;//隔一定时间或撞上边界换向
            }
            if (etankFrames % 100 == 0)
            {
                isFire = true;//隔一定时间开火
            }
            eTankMove();//坦克直线行走
            if (isFire)
            {
                //按坦克类型与方向发射炮弹 dir:1左，2右，3上，4下 type:1普通坦克，2轻坦克，3重坦克
                switch (dir)
                {
                    case 1:
                        switch (type)
                        {
                            case 1: Bullet bullet1 = new Bullet(2); Fire(bullet1, 1); break;
                            case 2: Bullet bullet2 = new Bullet(3); Fire(bullet2, 1); break;
                            case 3: Bullet bullet3 = new Bullet(4); Fire(bullet3, 1); break;
                        }
                        break;
                    case 2:
                        switch (type)
                        {
                            case 1: Bullet bullet1 = new Bullet(2); Fire(bullet1, 2); break;
                            case 2: Bullet bullet2 = new Bullet(3); Fire(bullet2, 2); break;
                            case 3: Bullet bullet3 = new Bullet(4); Fire(bullet3, 2); break;
                        }
                        break;
                    case 3:
                        switch (type)
                        {
                            case 1: Bullet bullet1 = new Bullet(2); Fire(bullet1, 3); break;
                            case 2: Bullet bullet2 = new Bullet(3); Fire(bullet2, 3); break;
                            case 3: Bullet bullet3 = new Bullet(4); Fire(bullet3, 3); break;
                        }
                        break;
                    case 4:
                        switch (type)
                        {
                            case 1: Bullet bullet1 = new Bullet(2); Fire(bullet1, 4); break;
                            case 2: Bullet bullet2 = new Bullet(3); Fire(bullet2, 4); break;
                            case 3: Bullet bullet3 = new Bullet(4); Fire(bullet3, 4); break;
                        }
                        break;
                }
                isFire = false;
            }
        }
        /// <summary>
        /// 坦克行驶
        /// </summary>
        void eTankMove()
        {
            if (changeDir)
            {
                dir = rd.Next(1, 5);//随机方向
                //转向并防止坦克卡在墙中
                switch (dir)
                {
                    case 1:
                        switch (type)
                        {
                            case 1:
                                image = Properties.Resources.enemy1L;
                                break;
                            case 2:
                                image = Properties.Resources.enemy2L;
                                break;
                            case 3:
                                image = Properties.Resources.enemy3L;
                                break;
                        }
                        if (!gameMain.gameCheckHit.IsHitWall(this.x, this.y, 60, 60))
                            Move.Left(ref x, speed);
                        else x = x + speed;
                        break;
                    case 2:
                        switch (type)
                        {
                            case 1:
                                image = Properties.Resources.enemy1R;
                                break;
                            case 2:
                                image = Properties.Resources.enemy2R;
                                break;
                            case 3:
                                image = Properties.Resources.enemy3R;
                                break;
                        }
                        if (!gameMain.gameCheckHit.IsHitWall(this.x, this.y, 60, 60))
                            Move.Right(ref x, speed, image);
                        else x = x - speed;
                        break;
                    case 3:
                        switch (type)
                        {
                            case 1:
                                image = Properties.Resources.enemy1U;
                                break;
                            case 2:
                                image = Properties.Resources.enemy2U;
                                break;
                            case 3:
                                image = Properties.Resources.enemy3U;
                                break;
                        }
                        if (!gameMain.gameCheckHit.IsHitWall(this.x, this.y, 60, 60))
                            Move.Up(ref y, speed);
                        else y = y + speed;
                        break;
                    case 4:
                        switch (type)
                        {
                            case 1:
                                image = Properties.Resources.enemy1D;
                                break;
                            case 2:
                                image = Properties.Resources.enemy2D;
                                break;
                            case 3:
                                image = Properties.Resources.enemy3D;
                                break;
                        }
                        if (!gameMain.gameCheckHit.IsHitWall(this.x, this.y, 60, 60))
                            Move.Down(ref y, speed, image);
                        else y = y - speed;
                        break;
                }
                changeDir = false;
            }
            else 
            {
                //未撞墙直行
                if (!gameMain.gameCheckHit.IsHitWall(this.x, this.y, 60, 60))
                {
                    switch (dir)
                    {
                        case 1:
                            Move.Left(ref x, speed); break;
                        case 2:
                            Move.Right(ref x, speed, image); break;
                        case 3:
                            Move.Up(ref y, speed); break;
                        case 4:
                            Move.Down(ref y, speed, image); break;
                    }
                }
                //撞墙转向并阻止坦克卡在墙中
                else
                {
                    switch (dir)
                    {
                        case 1:
                            x = x + speed;
                            break;
                        case 2:
                            x = x - speed;
                            break;
                        case 3:
                            y = y + speed;
                            break;
                        case 4:
                            y = y - speed;
                            break;
                    }
                    changeDir = true;
                }
            }
        }
        /// <summary>
        /// 坦克开炮
        /// </summary>
        /// <param name="bullet"></param>
        /// <param name="fireDirection"></param>
        void Fire(Bullet bullet, int fireDirection)
        {
            //分方向生成炮弹
            switch (fireDirection)
            {
                case 1:
                    bullet.X = x - 15;
                    bullet.Y = y + 22;
                    bullet.Dir = 1;
                    break;
                case 2:
                    bullet.X = x + 60;
                    bullet.Y = y + 22;
                    bullet.Dir = 2;
                    break;
                case 3:
                    bullet.X = x + 22;
                    bullet.Y = y - 15;
                    bullet.Dir = 3;
                    break;
                case 4:
                    bullet.X = x + 22;
                    bullet.Y = y + 60;
                    bullet.Dir = 4;
                    break;
            }
            gameMain.ListBullet.Add(bullet);
        }
        /// <summary>
        /// 绘制坦克
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.DrawImage(image, x, y);
        }
    }
}
