using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankWar
{/// <summary>
/// 上下左右的移动，并保证不出边界
/// </summary>
    public class Move
    {            
        public static void Left(ref int x, int speed)
        {
            if (x >= speed)
            {
                x -= speed;
            }
            else x = 0;
        }
        public static void Right(ref int x, int speed, Image image)
        {
            if (x <= 780 - image.Width - speed)
            {
                x += speed;
            }
            else x = 780-image.Width;
        }
        public static void Up(ref int y, int speed)
        {
            if (y >= speed)
            {
                y -= speed;
            }
            else y = 0;
        }
        public static void Down(ref int y, int speed, Image image)
        {
            if (y <= 690 - image.Height - speed)
            {
                y += speed;
            }
            else y = 690 - image.Height;
        }
    }
}
