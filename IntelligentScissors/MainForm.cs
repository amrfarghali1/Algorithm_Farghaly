using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IntelligentScissors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public RGBPixel[,] ImageMatrix;
        int WIDTH, HEIGHT;
        Pathalong[,] conne;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
                CALC();
                MessageBox.Show("Hello Dr , Are U Ready ? ", "OMG What R U Doing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conne = WeighedGraph.Getting_width(ImageMatrix);




            }


        }
        public void CALC()
        {
            WIDTH = ImageOperations.GetWidth(ImageMatrix);
            HEIGHT = ImageOperations.GetHeight(ImageMatrix);
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }


        private const int object_radius = 3;





        private List<Point> MyPoint = new List<Point>();

        private List<Point> Swapaya = new List<Point>();


        private bool PAINTINGG = false;
        private Point POINT_ONE, SEC_POINT;

        private List<Point> Lists = new List<Point>();



        private void MOUSEDRAW(object sender, MouseEventArgs e)
        {


            pictureBox1.MouseMove += PATH;
            pictureBox1.MouseUp += DRAWING_BY_MOUSE;
            PAINTINGG = true;
            POINT_ONE = new Point(e.X, e.Y);
            SEC_POINT = new Point(e.X, e.Y);


        }

        #region "Drawing"


        private void DRAWING_BY_MOUSE(object sender, MouseEventArgs e)
        {

            pictureBox1.MouseMove -= PATH;
            pictureBox1.MouseUp -= DRAWING_BY_MOUSE;
            MyPoint.Add(POINT_ONE);
            int countya = MyPoint.Count;

            if (countya > 1)
            {

                List<Point> LISTYAA = new List<Point>();
                int[,] xis = new int[WIDTH, HEIGHT];
                int[,] yis = new int[WIDTH, HEIGHT];
                double[,] distances = Graph.Dijkstra(conne, MyPoint[countya - 1].X, MyPoint[countya - 1].Y, MyPoint[countya - 2].X, MyPoint[countya - 2].Y, xis, yis, WIDTH, HEIGHT);

                path(MyPoint[countya - 2].X, MyPoint[countya - 2].Y, MyPoint[countya - 1].X, MyPoint[countya - 1].Y, xis, yis, distances, ImageMatrix, LISTYAA);
                coloring(LISTYAA, ImageMatrix);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox2);


            }
            pictureBox1.Invalidate();

        }





        #endregion 


        private void imagedrawing(object sender, PaintEventArgs e)
        {
            int yeah = MyPoint.Count;
            int opa = Lists.Count - 1;
            Console.WriteLine("amr");
            foreach (Point pt in MyPoint)
            {
                int f1, f2;
                f1 = pt.X - object_radius;
                f2 = pt.Y - object_radius;
                int oper = 2 * object_radius + 67 - 66;


                Rectangle Actions = new Rectangle(f1, f2, oper, oper);
                e.Graphics.FillEllipse(Brushes.Red, Actions);
                e.Graphics.DrawEllipse(Pens.DarkRed, Actions);
                Console.WriteLine("eshta");
            }
            if (PAINTINGG)
            {
                if (yeah > 0)

                {

                    Console.WriteLine("hena");
                    Console.WriteLine(Lists);


                    for (int i = 0; i < opa; i++)
                    {
                        Console.WriteLine("OPAAAA");

                        e.Graphics.DrawLine(Pens.AntiqueWhite, Lists[i], Lists[i + 1]);


                    }
                }
            }





        }



        private void PATH(object sender, MouseEventArgs e)
        {
            SEC_POINT = new Point(e.X, e.Y);
            if (MyPoint.Count > 0 && e.X < HEIGHT && e.Y < WIDTH)
            {

                Lists.Clear();
                int[,] xis = new int[WIDTH, HEIGHT];
                int[,] yis = new int[WIDTH, HEIGHT];
                double[,] dis = Graph.Dijkstra(conne, MyPoint[MyPoint.Count - 1].X, MyPoint[MyPoint.Count - 1].Y, e.X, e.Y, xis, yis, WIDTH, HEIGHT);

                path(e.X, e.Y, MyPoint[MyPoint.Count - 1].X, MyPoint[MyPoint.Count - 1].Y, xis, yis, dis, ImageMatrix, Lists);


            }
            pictureBox1.Invalidate();


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





        public static void path(int x, int y, int p1, int p2, int[,] firstX, int[,] firstY, double[,] w, RGBPixel[,] imagMat, List<Point> ps)
        {
            Console.WriteLine("p1" + p1);
            Console.WriteLine("p2" + p2);


            while (((x != p1) || (y != p2)) && (x != 0 && y != 0))
            {
                Console.WriteLine("ERORR");
                ps.Add(new Point(x, y));




                showPath(ps);

                x = firstX[y, x];
                y = firstY[y, x];
            }



        }



        public static void showPath(List<Point> ps)
        {

            using (StreamWriter sw = new StreamWriter("showPath.txt"))
            {
                for (int i = 0; i < ps.Count; i++)
                {
                    sw.WriteLine("x " + ps[i].X + "    y " + ps[i].Y);
                }

            }

        }
        public static void coloring(List<Point> points, RGBPixel[,] img)
        {
            for (int i = 0; i < points.Count; i++)
            {
                img[points[i].Y, points[i].X].blue = 255; img[points[i].Y, points[i].X].red = 255; img[points[i].Y, points[i].X].green = 250;
            }
        }






    }
}