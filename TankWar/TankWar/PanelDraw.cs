using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankWar
{
    public class PanelDraw
    {
        /// <summary>
        /// 画右侧Panel控件
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            //画敌方坦克数量
            for (int i = 0; i <= 19 - gameMain.gameProductTank.DestroyeTank; i++)
            {
                int j = i / 5;
                g.DrawImage(Properties.Resources.mintank, 40 + 50 * (i % 5), 80 + 50 * j);
            }
            //己方坦克及其生命数
            g.DrawImage(Properties.Resources.selecttank, 90, 330);
            g.DrawString("x " + gameMain.gamep1Tank.p1TankLife, new Font("微软雅黑", 25),Brushes.Black,145,330);
        }
    }
}
