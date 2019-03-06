using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankWar
{
    public class TankWar
    {
        bool isstop = false;//是否暂停
        public bool IsStop
        {
            set { isstop = value; }
            get { return isstop; }
        }
        bool isgameover = false;//是否游戏失败
        public bool IsGameOver
        {
            set { isgameover = value; }
            get { return isgameover; }
        }
        bool isgamewin = false;//是否游戏胜利
        public bool IsGameWin
        {
            set { isgamewin = value; }
            get { return isgamewin; }
        }
        /// <summary>
        /// 数据更新
        /// </summary>
        public void Update()
        {
            //玩家坦克生命值为0时游戏失败
            if (gameMain.gamep1Tank.p1TankLife == 0)
            {
                isgameover = true;
                gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.Gameover, 215, 690));//动画效果
            }
            //消灭敌方坦克20辆时游戏胜利
            if (gameMain.gameProductTank.DestroyeTank == 20)
            {
                isgamewin = true;
                gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.GameWin, 180, 690));//动画效果
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.gamewin);//音效
                sp.Play();
            }
        }

    }
}
