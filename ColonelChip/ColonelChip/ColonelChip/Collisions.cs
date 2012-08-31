using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ColonelChip
{
    class Collisions
    {
        public bool IntersectPerPixelBottom(
            Rectangle rect1, Color[] data1,
            Rectangle rect2, Color[] data2)
        {
            if (rect1.Intersects(rect2))
                return true;
            //int top = Math.Max(rect1.Top, rect2.Top);
            //int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            //int left = Math.Max(rect1.Left, rect2.Left);
            //int right = Math.Min(rect1.Right, rect2.Right);

            //for (int y = bottom; y > top; y--)
            //{
            //    for (int x = left; x < right; x++)
            //    {
            //        Color color1 = data1[(x - rect1.Left) + ((rect1.Bottom - y) * rect1.Width)];
            //        Color color2 = data2[(x - rect2.Left) + ((rect2.Bottom - y) * rect2.Width)];

            //        if ((color1.A != 0) &&
            //            (color2.A != 0))
            //        {
            //            if ((rect1.Bottom > rect2.Top) &&
            //                (rect1.Bottom < rect2.Bottom) &&
            //                (rect1.Top < rect2.Top))
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //}

            return false;
        }

        public bool IntersectPerPixelTop(
            Rectangle rect1, Color[] data1,
            Rectangle rect2, Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color color1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color color2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

                    if ((color1.A != 0) &&
                        (color2.A != 0))
                    {
                        if ((rect1.Top < rect2.Bottom) &&
                            (rect1.Bottom > rect2.Bottom))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IntersectPerPixelLeft(
            Rectangle rect1, Color[] data1,
            Rectangle rect2, Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color color1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color color2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

                    if ((color1.A != 0) &&
                        (color2.A != 0))
                    {
                        if ((rect1.Left < rect2.Right) &&
                            (rect1.Right > rect2.Right))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IntersectPerPixelRight(
            Rectangle rect1, Color[] data1,
            Rectangle rect2, Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color color1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color color2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

                    if ((color1.A != 0) &&
                        (color2.A != 0))
                    {
                        if ((rect1.Right > rect2.Left) &&
                            (rect1.Left < rect2.Left))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IntersectPerPixel(
            Rectangle rect1, Color[] data1,
            Rectangle rect2, Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color color1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color color2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

                    if ((color1.A != 0) &&
                        (color2.A != 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
