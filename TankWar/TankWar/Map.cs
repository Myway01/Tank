using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankWar
{
    public class Map
    {
        int[,] battlemap;//检测碰撞等用到的实际内存地图 行数：46，列数：52
        int[,] paintmap;//实行绘制用到的地图 行数：23,列数：26
        bool maprefresh = true;//是否刷新map
        List<Rectangle> listwalls;//不可通过的墙体的矩形块的集合
        public List<Rectangle> ListWalls
        {
            set { listwalls = value; }
            get { return listwalls; }
        }
        public int[,] BattleMap
        {
            set { battlemap = value; }
            get { return battlemap; }
        }
        public bool MapRefresh
        {
            set { maprefresh = value; }
            get { return maprefresh; }
        }

        public Map()
        {
            //画地图
            paintmap = new int[23, 26]
            {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0 },
            {0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0 },
            {0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0 },
            {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0 },
            {0,0,1,1,0,0,0,0,0,0,0,0,2,2,0,0,1,1,0,0,0,1,1,0,0,0 },
            {0,0,1,1,0,0,0,0,0,0,0,0,2,2,0,0,1,1,0,0,0,1,1,0,0,0 },
            {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0 },
            {0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0 },
            {0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0 },
            {0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,1,1,0,0,0,1,1,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2 },
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,},
            {3,3,3,3,3,3,1,1,1,1,1,0,0,0,0,1,1,1,1,1,3,3,3,3,3,3 },
            {3,3,3,3,3,3,1,1,0,0,0,0,0,0,0,0,0,0,1,1,3,3,3,3,3,3 },
            {0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0 },
            {0,0,0,0,1,1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
            };
            //将地图信息存入真正判断时要调用的地图
            battlemap = new int[46, 52];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    battlemap[j * 2 + 1, i * 2 + 1] = paintmap[j, i];
                    battlemap[j * 2 + 1, i * 2] = paintmap[j, i];
                    battlemap[j * 2, i * 2 + 1] = paintmap[j, i];
                    battlemap[j * 2, i * 2] = paintmap[j, i];
                }
            }
            //存入基地位置信息
            for (int i = 12; i < 14; i++)
            {
                for (int j = 21; j < 23; j++)
                {
                    battlemap[j * 2 + 1, i * 2 + 1] = 5;
                    battlemap[j * 2 + 1, i * 2] = 5;
                    battlemap[j * 2, i * 2 + 1] = 5;
                    battlemap[j * 2, i * 2] = 5;
                }
            }
        }
        /// <summary>
        /// 画地图
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if (maprefresh)
            {
                listwalls = new List<Rectangle>();
                for (int i = 0; i < 52; i++)
                {
                    for (int j = 0; j < 46; j++)
                    {
                        switch (battlemap[j, i])
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 5:
                                Rectangle rec = new Rectangle(i * 15, j * 15, 15, 15);
                                listwalls.Add(rec);
                                break;
                        }

                    }
                }
                maprefresh = false;
            }
            for (int i = 0; i < 52; i++)
            {
                for (int j = 0; j < 46; j++)
                {
                    if (battlemap[j,i]==6)
                    {
                        g.FillRectangle(Brushes.Black, i * 15, j * 15, 16, 16);
                    }
                }
            }
        }
    }
}
