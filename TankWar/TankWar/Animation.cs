using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public class Animation
    {
        int x;
        int y;
        int animationFrame = 0;//动画帧
        AnimationType thetype;//动画类型
        public AnimationType TheType
        {
            set { thetype = value; }
            get { return thetype; }
        }
        public enum AnimationType
        {
            Gameover, GameWin, BulletBlast, TankBlast, P1TankBorn, Etankborn
        }

        public Animation(AnimationType type, int ax, int ay)
        {
            x = ax; y = ay;
            thetype = type;
        }
        /// <summary>
        /// 游戏失败动画
        /// </summary>
        /// <param name="g"></param>
        public void GameOver(Graphics g)
        {
            //使图片以一定速度由下向上
            if (y >= 250)
            {
                y = y - 2;
            }
            g.DrawImage(Properties.Resources.over, x, y);
        }
        /// <summary>
        /// 游戏成功动画
        /// </summary>
        /// <param name="g"></param>
        public void GameWin(Graphics g)
        {
            //使图片以一定速度由下向上
            if (y >= 280)
            {
                y = y - 2;
            }
            g.DrawImage(Properties.Resources.victory, x, y);
        }
        /// <summary>
        /// 炮弹爆炸动画
        /// </summary>
        /// <param name="g"></param>
        public void BulletBlast(Graphics g)
        {
            if (gameMain.elapsedFrames % 3 == 0)
            {
                ++animationFrame;
            }
            switch (animationFrame)
            {
                case 1: g.DrawImage(Properties.Resources.blastb1, x, y); break;
                case 2: g.DrawImage(Properties.Resources.blastb2, x, y); break;
                case 3: g.DrawImage(Properties.Resources.blastb3, x, y); break;
                case 4: g.DrawImage(Properties.Resources.blastb4, x, y); break;
                case 5: g.DrawImage(Properties.Resources.blastb5, x, y); break;
                case 6: g.DrawImage(Properties.Resources.blastb6, x, y); break;
                case 7: g.DrawImage(Properties.Resources.blastb7, x, y); break;
                case 8: g.DrawImage(Properties.Resources.blastb8, x, y); break;
                case 9: gameMain.ListAnimation.Remove(this); break;
            }
        }
        /// <summary>
        /// 坦克爆炸动画
        /// </summary>
        /// <param name="g"></param>
        public void TankBlast(Graphics g)
        {
            if (gameMain.elapsedFrames % 3 == 0)
            {
                ++animationFrame;
            }
            switch (animationFrame)
            {
                case 1: g.DrawImage(Properties.Resources.blast1, x, y); break;
                case 2: g.DrawImage(Properties.Resources.blast2, x, y); break;
                case 3: g.DrawImage(Properties.Resources.blast3, x, y); break;
                case 4: g.DrawImage(Properties.Resources.blast4, x, y); break;
                case 5: g.DrawImage(Properties.Resources.blast5, x, y); break;
                case 6: g.DrawImage(Properties.Resources.blast6, x, y); break;
                case 7: g.DrawImage(Properties.Resources.blast7, x, y); break;
                case 8: g.DrawImage(Properties.Resources.blast8, x, y); break;
                case 9: gameMain.ListAnimation.Remove(this); break;
            }
        }
        /// <summary>
        /// 玩家坦克产生动画
        /// </summary>
        /// <param name="g"></param>
        public void P1TankBorn(Graphics g)
        {
            if (gameMain.elapsedFrames % 3 == 0)
            {
                ++animationFrame;
            }
            switch (animationFrame)
            {
                case 1: g.DrawImage(Properties.Resources.born1, x, y); break;
                case 2: g.DrawImage(Properties.Resources.born2, x, y); break;
                case 3: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 4: g.DrawImage(Properties.Resources.born4, x, y); break;
                case 5: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 6: g.DrawImage(Properties.Resources.born2, x, y); break;
                case 7: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 8: g.DrawImage(Properties.Resources.born4, x, y); break;
                case 9: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 10: g.DrawImage(Properties.Resources.born2, x, y); break;
                case 11: g.DrawImage(Properties.Resources.born1, x, y); break;
                case 12:
                    gameMain.ListAnimation.Remove(this);
                    gameMain.gamep1Tank.IsBorn = true; break;
            }
        }
        /// <summary>
        /// 敌方坦克产生动画
        /// </summary>
        /// <param name="g"></param>
        public void ETankBorn(Graphics g)
        {
            if (gameMain.elapsedFrames % 3 == 0)
            {
                ++animationFrame;
            }
            switch (animationFrame)
            {
                case 1: g.DrawImage(Properties.Resources.born1, x, y); break;
                case 2: g.DrawImage(Properties.Resources.born2, x, y); break;
                case 3: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 4: g.DrawImage(Properties.Resources.born4, x, y); break;
                case 5: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 6: g.DrawImage(Properties.Resources.born2, x, y); break;
                case 7: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 8: g.DrawImage(Properties.Resources.born4, x, y); break;
                case 9: g.DrawImage(Properties.Resources.born3, x, y); break;
                case 10: g.DrawImage(Properties.Resources.born2, x, y); break;
                case 11: g.DrawImage(Properties.Resources.born1, x, y); break;
                case 12:
                    gameMain.ListAnimation.Remove(this); break;
            }
        }
        /// <summary>
        /// 动画效果绘制
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            switch (thetype)
            {
                case AnimationType.Gameover:
                    GameOver(g);
                    break;
                case AnimationType.GameWin:
                    GameWin(g);
                    break;
                case AnimationType.BulletBlast:
                    BulletBlast(g);
                    break;
                case AnimationType.TankBlast:
                    TankBlast(g);
                    break;
                case AnimationType.P1TankBorn:
                    P1TankBorn(g);
                    break;
                case AnimationType.Etankborn:
                    ETankBorn(g);
                    break;
            }
        }
    }
}
