using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public class ProductTank
    {
        int destroyetank;//已经击毁的敌方坦克数量
        int nowetank = 0;//场上存在的敌方坦克数量
        int alletank = 0;//总共产生的敌方坦克数量
        int nowetankmost = 5;//场上可共存的最大敌方坦克数量
        int alletankmost = 20;//最多可产生的敌方坦克数量

        public int DestroyeTank
        {
            set { destroyetank = value; }
            get { return destroyetank; }
        }
        public int NoweTank
        {
            set { nowetank = value; }
            get { return nowetank; }
        }
        public int AlleTank
        {
            set { alletank = value; }
            get { return alletank; }
        }
        public int NoweTankmost
        {
            set { nowetankmost = value; }
            get { return nowetankmost; }
        }
        public int AlleTankmost
        {
            set { alletankmost = value; }
            get { return alletankmost; }
        }
        /// <summary>
        /// 数据更新，产生敌方坦克
        /// </summary>
        public void Update()
        {
            //场上坦克数小于5，并且坦克出现总数低于20时产生敌方坦克
            if (nowetank < nowetankmost && alletank < alletankmost && gameMain.elapsedFrames % 60 == 0)
            {
                eTank etank = new eTank();
                gameMain.ListeTank.Add(etank);
                nowetank++;
                alletank++;
            }
        }

        
    }
}
