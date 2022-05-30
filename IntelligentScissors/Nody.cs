using System.Collections.Generic;

namespace IntelligentScissors
{
    class NOODDEE
    {

        public bool n_Flag;
        public double WEight { get; set; }
        public int count;
        public Queue<int> Q_one;
        public Queue<int> Q_Two;
        public NOODDEE lft, right;

        public NOODDEE()
        {
            count = 0;
            n_Flag = false;
            Q_one = new Queue<int>();
            Q_Two = new Queue<int>();

        }

        public NOODDEE(int y0, int x0, double WW)
        {
            this.WEight = WW;
            count = 1;
            n_Flag = false;
            Q_one = new Queue<int>();
            Q_Two = new Queue<int>();
            Q_one.Enqueue(y0);
            Q_Two.Enqueue(x0);
        }

    }
}
