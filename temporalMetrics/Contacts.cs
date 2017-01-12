/* dissertation: Error and Attack Vulnerability of Temporal Networks
 * code: Temporal Metrics and Temporal Robustness
 * Stojan Trajanovski
 * tutorials: Salvatore Scellato and Ilias Leontiadis
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace temporalMetrics
{
    class Contacts
    {
        private int endNode1;

        public int EndNode1
        {
            get { return endNode1; }
            set { endNode1 = value; }
        }

        private int endNode2;

        public int EndNode2
        {
            get { return endNode2; }
            set { endNode2 = value; }
        }

        private int t;

        public int T
        {
            get { return t; }
            set { t = value; }
        }

        public Contacts(int end1, int end2, int time)
        {
            EndNode1 = end1;
            EndNode2 = end2;
            T = time;
        }
    }
}
