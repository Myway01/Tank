using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public class CheckHit
    {
        bool isbasedetroyed = false;//基地是否被毁
        public bool IsBaseDestyoyed
        {
            set { isbasedetroyed = value; }
            get { return isbasedetroyed; }
        }
        bool ispanelrefresh = true;//panel是否重绘
        public bool IsPanelRefresh
        {
            set { ispanelrefresh = value; }
            get { return ispanelrefresh; }
        }
        /// <summary>
        /// 敌方坦克与我方炮弹
        /// </summary>
        public void ETank_IsHit()
        {
            for (int i = 0; i < gameMain.ListeTank.Count; i++)
            {
                for (int j = 0; j < gameMain.ListBullet.Count; j++)
                {
                    if (gameMain.ListBullet[j].TheType == 1 && IsHit(gameMain.ListeTank[i].X, gameMain.ListeTank[i].Y, 60, 60, gameMain.ListBullet[j].X, gameMain.ListBullet[j].Y, 17, 17))
                    {
                        gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.BulletBlast, gameMain.ListBullet[j].X, gameMain.ListBullet[j].Y));
                        gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.TankBlast, gameMain.ListeTank[i].X, gameMain.ListeTank[i].Y));//动画
                        System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.blast);
                        sp.Play();//音效
                        gameMain.ListeTank.RemoveAt(i);
                        gameMain.ListBullet.RemoveAt(j);
                        --gameMain.gameProductTank.NoweTank;
                        ++gameMain.gameProductTank.DestroyeTank;
                        ispanelrefresh = true;
                        new Property();//道具
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 我方坦克与敌方炮弹
        /// </summary>
        public void PTank_IsHit()
        {
            for (int j = 0; j < gameMain.ListBullet.Count; j++)
            {
                if (gameMain.ListBullet[j].TheType != 1 && IsHit(gameMain.gamep1Tank.X, gameMain.gamep1Tank.Y, 60, 60, gameMain.ListBullet[j].X, gameMain.ListBullet[j].Y, 15, 15))
                {
                    gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.BulletBlast, gameMain.ListBullet[j].X, gameMain.ListBullet[j].Y));
                    gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.TankBlast, gameMain.gamep1Tank.X, gameMain.gamep1Tank.Y));//动画
                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.blast);
                    sp.Play();//音效
                    gameMain.gamep1Tank.IsBorn = false;
                    gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.P1TankBorn, 270, 630));//玩家坦克诞生动画
                    //重置玩家坦克位置及炮弹速度
                    gameMain.gamep1Tank.X = 270;
                    gameMain.gamep1Tank.Y = 630;
                    gameMain.gamep1Tank.PBSpeed = 10;

                    --gameMain.gamep1Tank.p1TankLife;
                    ispanelrefresh = true;
                    gameMain.ListBullet.RemoveAt(j);
                    break;
                }
            }
        }
        /// <summary>
        /// 判定是否撞墙
        /// </summary>
        /// <param name="x"></param>被判断物横坐标
        /// <param name="y"></param>被判断物纵坐标
        /// <param name="width"></param>被判断物宽度
        /// <param name="height"></param>被判断物高度
        /// <returns></returns>
        public bool IsHitWall(int x, int y, int width, int height)
        {
            Rectangle rec = new Rectangle(x, y, width, height);
            for (int i = 0; i < gameMain.gameMap.ListWalls.Count; i++)
            {
                if (rec.IntersectsWith(gameMain.gameMap.ListWalls[i]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 炮弹与墙体类
        /// </summary>
        public void Bullet_Wall()
        {
            bool isblast = false;
            for (int k = 0; k < gameMain.ListBullet.Count; k++)
            {
                for (int i = 0; i < 52; i++)
                {
                    for (int j = 0; j < 46; j++)
                    {
                        if (IsHit(gameMain.ListBullet[k].X - 8, gameMain.ListBullet[k].Y - 8, 32, 32, i * 15, j * 15, 15, 15))
                        {
                            //1砖墙，2铁墙，5主基地，6黑块填充使被打掉的墙不再显示
                            switch (gameMain.gameMap.BattleMap[j, i])
                            {
                                case 1:
                                    gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.BulletBlast, gameMain.ListBullet[k].X, gameMain.ListBullet[k].Y));
                                    gameMain.gameMap.BattleMap[j, i] = 6;
                                    isblast = true;
                                    gameMain.gameMap.MapRefresh = true;
                                    break;
                                case 2:
                                    gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.BulletBlast, gameMain.ListBullet[k].X, gameMain.ListBullet[k].Y));
                                    isblast = true;
                                    if (gameMain.ListBullet[k].TheType == 1)
                                    {
                                        System.Media.SoundPlayer sp1 = new System.Media.SoundPlayer(Properties.Resources.hit);
                                        sp1.Play();
                                    }
                                    break;
                                case 5:
                                    isblast = true;
                                    isbasedetroyed = true;
                                    gameMain.gameTankWar.IsGameOver = true;//游戏结束
                                    System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer(Properties.Resources.blast);
                                    sp2.Play();
                                    gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.Gameover, 215, 690));
                                    break;
                            }
                        }
                    }
                }
                if (isblast)
                {
                    gameMain.ListBullet.RemoveAt(k);
                }
            }
        }
        /// <summary>
        /// 炮弹与炮弹
        /// </summary>
        public void Bullet_Bullet()
        {
            for (int i = 0; i < gameMain.ListBullet.Count; i++)
            {
                if (gameMain.ListBullet[i].TheType == 1)
                {
                    for (int j = 0; j < gameMain.ListBullet.Count; j++)
                    {
                        if (IsHit(gameMain.ListBullet[i].X - 5, gameMain.ListBullet[i].Y - 5, 25, 25, gameMain.ListBullet[j].X - 5, gameMain.ListBullet[j].Y - 5, 25, 25) && gameMain.ListBullet[j].TheType != 1)
                        {
                            gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.BulletBlast, gameMain.ListBullet[i].X - 5, gameMain.ListBullet[i].Y - 5));
                            gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.BulletBlast, gameMain.ListBullet[j].X - 5, gameMain.ListBullet[j].Y - 5));
                            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.blast);
                            sp.Play();
                            gameMain.ListBullet.RemoveAt(i);
                            if (i < j)
                            {
                                gameMain.ListBullet.RemoveAt(j - 1);
                            }
                            else
                                gameMain.ListBullet.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 玩家坦克与道具
        /// </summary>
        public void PTank_Property()
        {
            for (int i = 0; i < gameMain.ListProperty.Count; i++)
            {
                if (IsHit(gameMain.gamep1Tank.X, gameMain.gamep1Tank.Y, 60, 60, gameMain.ListProperty[i].X, gameMain.ListProperty[i].Y, 40, 40))
                {
                    //0爆破道具，1炮弹加速道具
                    switch (gameMain.ListProperty[i].Type)
                    {
                        case 0:
                            gameMain.gameProductTank.DestroyeTank += gameMain.gameProductTank.NoweTank;
                            gameMain.gameProductTank.NoweTank = 0;
                            ispanelrefresh = true;
                            for (int j = 0; j < gameMain.ListeTank.Count; j++)
                            {
                                gameMain.ListAnimation.Add(new Animation(Animation.AnimationType.TankBlast, gameMain.ListeTank[j].X, gameMain.ListeTank[j].Y));
                                gameMain.ListeTank.RemoveAt(j);
                                j--;
                            }
                            break;
                        case 1:
                            gameMain.gamep1Tank.PBSpeed += 5; break;
                    }
                    gameMain.ListProperty.RemoveAt(i);
                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.add);
                    sp.Play();
                    break;
                }
            }
        }
        /// <summary>
        /// 判断两物体是否接触
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="widht1"></param>
        /// <param name="height1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="widht2"></param>
        /// <param name="height2"></param>
        /// <returns></returns>
        public bool IsHit(int x1, int y1, int widht1, int height1, int x2, int y2, int widht2, int height2)
        {

            Rectangle r1 = new Rectangle(x1, y1, widht1, height1);
            Rectangle r2 = new Rectangle(x2, y2, widht2, height2);
            if (r1.IntersectsWith(r2))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 碰撞检测数据更新
        /// </summary>
        public void Update()
        {
            ETank_IsHit();
            PTank_IsHit();
            Bullet_Wall();
            Bullet_Bullet();
            PTank_Property();
        }
    }
}
