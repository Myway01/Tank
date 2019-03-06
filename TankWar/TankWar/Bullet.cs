using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public class Bullet
    {
        int thetype;//类型
        int dir;//方向
        int x;
        int y;
        Image image;
        int speed;//速度
        int width;
        int height;

        public int TheType
        {
            set { thetype = value; }
            get { return thetype; }
        }
        public int Dir
        {
            set { dir = value; }
            get { return dir; }
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

        public Bullet(int type)
        {
            thetype = type;
            switch (type)
            {
                //玩家炮弹
                case 1:
                    image = Properties.Resources.tankmissile;
                    speed = gameMain.gamep1Tank.PBSpeed;
                    width = 17;
                    height = 17;
                    break;
                    //敌方普通坦克炮弹
                case 2:
                    image = Properties.Resources.enemymissile;
                    speed = 10;
                    width = 15;
                    height = 15;
                    break;
                    //敌方轻坦克炮弹
                case 3:
                    image = Properties.Resources.enemymissile;
                    speed = 8;
                    width = 15;
                    height = 15;
                    break;
                    //敌方重坦克炮弹
                case 4:
                    image = Properties.Resources.enemymissile;
                    speed = 12;
                    width = 15;
                    height = 15;
                    break;
            }
        }
        /// <summary>
        /// 炮弹数据更新
        /// </summary>
        public void Update()
        {
            //按发射方向移动：1左，2右，3上，4下
            switch (dir)
            {
                case 1:
                    if (x >= 0)
                        x -= speed;
                    else
                        gameMain.ListBullet.Remove(this);
                    break;
                case 2:
                    if (x <= 780)
                        x += speed;
                    else
                        gameMain.ListBullet.Remove(this);
                    break;
                case 3:
                    if (y >= 0)
                        y -= speed;
                    else
                        gameMain.ListBullet.Remove(this);
                    break;
                case 4:
                    if (y <= 690)
                        y += speed;
                    else
                        gameMain.ListBullet.Remove(this);
                    break;
            }
        }
        /// <summary>
        /// 绘制炮弹
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.DrawImage(image, x, y);
        }

    }
}
