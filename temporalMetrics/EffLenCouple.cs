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
    class EffLenCouple
    {
        private double _eff;

        public double Eff
        {
            get { return _eff; }
            set { _eff = value; }
        }

        private double _len;

        public double Len
        {
            get { return _len; }
            set { _len = value; }
        }

        private double _couple;

        public double Couple
        {
            get { return _couple; }
            set { _couple = value; }
        }

        private int _time;

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public EffLenCouple(double e, double l, double c, int t)
        {
            Eff = e;
            Len = l;
            Couple = c;
            Time = t;
        }

    }
}
