using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public class Property
    {
        Random rd = new Random();//用于产生随机位置
        int x;
        int y;
        int type;//类型
        int time = 0;//用于控制道具出现时间
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
        public int Type
        {
            set { type = value; }
            get { return type; }
        }
        public Property()
        {
            //在随机地点有六分之一概率产生道具
            int produce = rd.Next(0, 6);
            if (produce == 0)
            {
                type = rd.Next(0, 2);
                gameMain.ListProperty.Add(this);
                x = rd.Next(0, 740);
                y = rd.Next(0, 650);
            }
        }
        /// <summary>
        /// 画出道具
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            //一定时间内道具存在
            ++time;
            if (time <= 600)
            {
                switch (type)
                {
                    case 0: g.DrawImage(Properties.Resources.bomb, x, y); break;
                    case 1: g.DrawImage(Properties.Resources.star, x, y); break;
                }
            }
            else
            {
                gameMain.ListProperty.Remove(this);
            }
        }
    }
}
