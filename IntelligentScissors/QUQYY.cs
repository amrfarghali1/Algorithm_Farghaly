using System;

namespace IntelligentScissors
{

    class priorityqueue
    {
        public NOODDEE rt
            ;
        public NOODDEE tempNode = new NOODDEE();
        public int c, xa;

        public priorityqueue(int t3, int t4, double w)
        {
            rt = new NOODDEE(t3, t4, w);
            xa++;
            c++;
        }
        public void PUSHING(int t1, int t2, double we)
        {
            if (rt == null)
            {
                rt = new NOODDEE(t1, t2, we);
                xa++;
                c++;
                return;
            }

            tempNode = rt;
            for (; ; )
            {
                if (tempNode.WEight > we)
                {
                    if (tempNode.WEight != we && tempNode.lft == null)
                    {
                        tempNode.lft = new NOODDEE(t1, t2, we);
                        break;
                    }
                    else if (tempNode.WEight == we)
                    {
                        tempNode.count++;
                        tempNode.Q_one.Enqueue(t1);
                        tempNode.Q_Two.Enqueue(t2);
                        break;
                    }

                    else
                    {
                        tempNode = tempNode.lft;
                    }
                }
                else
                {
                    if (tempNode.WEight != we && tempNode.right == null)
                    {
                        tempNode.right = new NOODDEE(t1, t2, we);
                        break;
                    }
                    else if (tempNode.WEight == we)
                    {
                        tempNode.count++;
                        tempNode.Q_one.Enqueue(t1);
                        tempNode.Q_Two.Enqueue(t2);
                        break;
                    }

                    else
                    {
                        tempNode = tempNode.right;
                    }
                }

            }
            c++;
        }

        public void show2(NOODDEE checker2)
        {
            if (checker2 == null)
                return;
            Show(checker2);
        }
        private void Show(NOODDEE checker)
        {


            Console.WriteLine(checker.WEight + " " + checker.n_Flag + " ");
            Show(checker.lft);
            Show(checker.right);

        }
        public void Pop()
        {

            NOODDEE M_NODE = rt;
            NOODDEE PAr = rt;
            while (M_NODE.lft != null)
            {

                if (M_NODE.lft.n_Flag == true)
                    break;
                else
                {
                    PAr = M_NODE;
                    M_NODE = M_NODE.lft;

                }


            }
            if (M_NODE.count > 1)
            {
                M_NODE.count--;
                c--;
                M_NODE.Q_one.Dequeue();
                M_NODE.Q_Two.Dequeue();

                return;
            }

            NOODDEE n = new NOODDEE();
            n = M_NODE;


            if ((n.lft == null) && (n.right == null))
            {


                if (n != rt)
                {


                    if (PAr.WEight < M_NODE.WEight)
                    {
                        PAr.right = null;
                    }
                    else
                    {
                        PAr.lft = null;
                    }



                }

                else
                {
                    rt = null;
                }



                M_NODE.n_Flag = true;
            }
            else if ((n.lft == null) && (n.right != null))
            {

                if (n != rt)
                {

                    if (M_NODE.WEight > PAr.WEight)
                    {
                        PAr.right = n.right;
                    }

                    else
                        PAr.lft = n.right;


                }



                else
                    rt = n.right;


            }
            else if ((n.lft != null) && (n.right == null))
            {

                if (n != rt)
                {

                    if (M_NODE.WEight > PAr.WEight)
                    {
                        PAr.right = n.lft;
                    }


                    else
                        PAr.lft = n.lft;

                }

                else
                    rt = n.lft;


            }
            else
            {
                n.WEight = M_NODE.WEight;


                if (PAr != n)
                {
                    PAr.lft = M_NODE.right;
                }



                else
                    PAr.right = M_NODE.right;


            }
            c--;
        }
        public NOODDEE Top()
        {
            NOODDEE minNode = rt;

            while (minNode.lft != null)
            {
                minNode = minNode.lft;
            }
            return minNode;
        }
        public bool Empty()
        {

            return c == 0;
        }


    }
}



