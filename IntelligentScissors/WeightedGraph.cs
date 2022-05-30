namespace IntelligentScissors
{
    public class Pathalong
    {
        public double up { get; set; }
        public double down { get; set; }
        public double left { get; set; }
        public double right { get; set; }

        public Pathalong()
        {
            up = -1;
            down = -1;
            left = -1;
            right = -1;
        }
        public Pathalong(double u, double d, double l, double r)
        {
            up = u;
            down = d;
            left = l;
            right = r;
        }
        public Pathalong(Pathalong dr)
        {
            up = dr.up;
            down = dr.down;
            left = dr.left;
            right = dr.right;
        }
    }
    class WeighedGraph
    {



        public static Pathalong[,] Getting_width(RGBPixel[,] ImageMatrix)
        {
            int height = ImageOperations.GetHeight(ImageMatrix);
            int width = ImageOperations.GetWidth(ImageMatrix);
            Pathalong[,] weights = new Pathalong[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Vector2D ee;
                    ee = ImageOperations.CalculatePixelEnergies(x, y, ImageMatrix);
                    Pathalong dr = new Pathalong();
                    if (y < height - 1)
                    {

                        ee.Y = 1 / ee.Y;
                        if (double.IsInfinity(ee.Y))

                            dr.down = 1E+16;
                        else
                            dr.down = ee.Y;
                    }
                    if (x < width - 1)
                    {
                        ee.X = 1 / ee.X;
                        if (double.IsInfinity(ee.X))
                        { dr.right = 1E+16; }
                        else
                            dr.right = ee.X;
                    }
                    if (y > 0)
                    {
                        ee = ImageOperations.CalculatePixelEnergies(x, y - 1, ImageMatrix);

                        ee.Y = 1 / ee.Y;
                        if (double.IsInfinity(ee.Y))
                            dr.up = 1E+16;
                        else
                            dr.up = ee.Y;
                    }
                    if (x > 0)
                    {
                        ee = ImageOperations.CalculatePixelEnergies(x - 1, y, ImageMatrix);
                        ee.X = 1 / ee.X;
                        if (double.IsInfinity(ee.X))
                            dr.left = 1E+16;
                        else
                            dr.left = ee.X;

                    }
                    weights[y, x] = new Pathalong(dr);





                }
            }


            return weights;
        }
    }
}
