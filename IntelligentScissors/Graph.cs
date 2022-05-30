namespace IntelligentScissors
{

    public class Graph
    {


        public static bool valid(int y, int x, int h, int w)
        {
            if (x >= 0 && y >= 0 && y < h && x < w)
                return true;
            return false;
        }
        public static double[,] Dijkstra(Pathalong[,] graph, int x, int y, int destinationX, int destinationY, int[,] fromx, int[,] fromy, int h, int w)
        {
            double[,] dis = new double[h, w];


            int i = 0;
            while (i < h)
            {
                for (int j = 0; j < w; ++j)
                {
                    dis[i, j] = 1E+17;
                }
                i++;
            }

            priorityqueue pq;
            pq = new priorityqueue(x, y, 0.0);
            dis[y, x] = 0;

            while (!pq.Empty())
            {
                double d = pq.Top().WEight;
                int xx = pq.Top().Q_one.Peek();
                int yy = pq.Top().Q_Two.Peek();
                pq.Pop();



                if (d > dis[yy, xx])
                    continue;
                if (valid(yy + 1, xx, h, w) && dis[yy + 1, xx] > d + graph[yy, xx].down && graph[yy, xx].down != -1)
                {
                    dis[yy + 1, xx] = d + graph[yy, xx].down;
                    fromx[yy + 1, xx] = xx;
                    fromy[yy + 1, xx] = yy;
                    //MessageBox.Show(fromx[yy+1, xx].ToString() + " down " + fromy[yy+1, xx].ToString());
                    if (xx == destinationX && yy + 1 == destinationY)
                    {
                        pq = null;
                        return dis;
                    }
                    pq.PUSHING(xx, yy + 1, dis[yy + 1, xx]);
                }

                if (valid(yy, xx + 1, h, w) && dis[yy, xx + 1] > d + graph[yy, xx].right && graph[yy, xx].right != -1)
                {
                    dis[yy, xx + 1] = d + graph[yy, xx].right;
                    pq.PUSHING(xx + 1, yy, dis[yy, xx + 1]);
                    fromx[yy, xx + 1] = xx;
                    fromy[yy, xx + 1] = yy;
                    //MessageBox.Show(fromx[yy, xx+1].ToString() + " right " + fromy[yy, xx+1].ToString());
                    if (xx + 1 == destinationX && yy == destinationY)
                    {
                        pq = null;
                        return dis;
                    }
                }
                if (valid(yy - 1, xx, h, w) && dis[yy - 1, xx] > d + graph[yy, xx].up && graph[yy, xx].up != -1)
                {
                    dis[yy - 1, xx] = d + graph[yy, xx].up;
                    pq.PUSHING(xx, yy - 1, dis[yy - 1, xx]);
                    fromx[yy - 1, xx] = xx;
                    fromy[yy - 1, xx] = yy;

                    if (xx == destinationX && yy - 1 == destinationY)
                    {
                        pq = null;
                        return dis;
                    }
                }
                if (valid(yy, xx - 1, h, w) && dis[yy, xx - 1] > d + graph[yy, xx].left && graph[yy, xx].left != -1)
                {
                    dis[yy, xx - 1] = d + graph[yy, xx].left;
                    pq.PUSHING(xx - 1, yy, dis[yy, xx - 1]);
                    fromx[yy, xx - 1] = xx;
                    fromy[yy, xx - 1] = yy;

                    if (xx - 1 == destinationX && yy == destinationY)
                    {
                        pq = null;
                        return dis;
                    }
                }
            }

            return dis;
        }



    }
}
