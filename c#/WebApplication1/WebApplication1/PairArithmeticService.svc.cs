using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PairArithmeticService" in code, svc and config file together.

    public class PairArithmeticService : IPairArithmeticService
    {
        public Pair Add(Pair p1, Pair p2)
        {
            Pair p = new Pair();
            p.First = p1.First + p2.First;
            p.Second = p1.Second + p2.Second;

            return p;
        }

        public Pair Substract(Pair p1, Pair p2)
        {
            Pair p = new Pair();
            p.First = p1.First - p2.First;
            p.Second = p1.Second - p2.Second;

            return p;
        }
    }


    public class Pair
    {
        int m_first;

        [DataMember]
        public int First
        {
            get { return m_first; }
            set { m_first = value; }
        }
        int m_second;

        [DataMember]
        public int Second
        {
            get { return m_second; }
            set { m_second = value; }
        }

        public Pair()
        {
            m_first = 0;
            m_second = 0;
        }


        public Pair(int first, int second)
        {
            m_first = first;
            m_second = second;
        }

    }
}
