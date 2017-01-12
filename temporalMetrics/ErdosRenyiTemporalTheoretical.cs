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
    
    class ErdosRenyiTemporalTheoretical
    {
        private int _numNodes = -1;

        public int NumNodes
        {
            get
            {
                return _numNodes;
            }

            set
            {
                _numNodes = value;
            }
        }

        private double _pr = -1;

        public double Pr
        {
            get { return _pr; }
            set { _pr = value; }
        }

        private double[,] prob;

        private double[,] Prob
        {
            get { return prob; }
            set { prob = value; }
        }

        private int _noIter = -1;

        public int NoIter
        {
            get { return _noIter; }
            set { _noIter = value; }
        }

        private double[] receivingProbabilities;

        private double[] ReceivingProbabilities
        {
            get { return receivingProbabilities; }
            set { receivingProbabilities = value; }
        }

        public EffLenCouple theorEffLenCouple;

        public double probability_pM(int m)
        {
            return 1.0-Math.Pow(1-Pr,(double) m);
        }

        private List<List<List<double>>> binomialProbabilities;

        public List<List<List<double>>> BinomialProbabilities
        {
            get { return binomialProbabilities; }
            set { binomialProbabilities = value; }
        }

        private void calculateBinomialProbabilities()
        {
            BinomialProbabilities = new List<List<List<double>>>(NumNodes+1);
                //double[NumNodes+1, NumNodes+1, NumNodes+1];//<binomialCoefficientClass,double>();
            List<List<double>> bnm = new List<List<double>>(NumNodes + 1);

            List<double> tmp;

            double pm;

            for (int m = 1; m <= NumNodes; m++)
            {
                pm = probability_pM(m);
                bnm = new List<List<double>>(NumNodes + 1);

                for (int i = 0; i <= NumNodes; i++)
                {
                    tmp = new List<double>(NumNodes + 1);
                    for (int j = 0; j <= NumNodes; j++)
                        tmp.Add(0.0);
                        bnm.Add(tmp);
                }

               
                for (int i = 0; i <= NumNodes; i++)
                {
                    for (int j = 0; j <= i; j++)
                        if (j == 0)
                            bnm[i][j] = Math.Pow(1 - pm, i);
                        else
                            bnm[i][j] = (pm * i / j) * bnm[i - 1][j - 1];
                }

                BinomialProbabilities.Add(bnm);
            }
        }

        public void calclulate_Probs()
        {
            Prob = new double[NoIter + 1, NumNodes + 1];

            Prob[0, 1] = 1;

            for (int n = 2; n <= NumNodes; n++)
                Prob[0, n] = 0;

            for (int t = 0; t < NoIter; t++)
                for (int k = 1; k <= NumNodes; k++)
                {
                    Prob[t + 1, k] = 0.0;
                    for (int m = 1; m <= k; m++)
                        Prob[t + 1, k] += (BinomialProbabilities[m-1][NumNodes - m][k - m] * Prob[t, m]);
                }
        }

        public void calculate_recievingProbs()
        {
            ReceivingProbabilities = new double[NoIter + 1];

            for (int t = 0; t <= NoIter; t++)
                for (int k = 1; k <= NumNodes; k++)
                    ReceivingProbabilities[t] += Prob[t, k] * ((double)(k - 1) / (NumNodes - 1));
        }

        public void calculate_effLenCoup()
        {
            double sumLength = 0.0;
            double sumEfficiency = 0.0;

            for(int i=1; i<=NoIter;i++)
            {
                sumLength+=((ReceivingProbabilities[i]-ReceivingProbabilities[i-1])*i);
                sumEfficiency += ((ReceivingProbabilities[i] - ReceivingProbabilities[i - 1]) / i);
            }

            theorEffLenCouple = new EffLenCouple(sumEfficiency, sumLength / ReceivingProbabilities[NoIter], ReceivingProbabilities[NoIter],0);
        }

        public ErdosRenyiTemporalTheoretical(int nd, double p, int it)
        {
            NumNodes = nd;
            Pr = p;
            NoIter = it;

            calculateBinomialProbabilities();
            calclulate_Probs();
            calculate_recievingProbs();
            calculate_effLenCoup();

           

                Efficiency = theorEffLenCouple.Eff;
                Length = theorEffLenCouple.Len;
                ConnCouples = theorEffLenCouple.Couple;
          
            //System.Console.WriteLine(theorEffLenCouple.Eff + "\t" + theorEffLenCouple.Len + "\t" + theorEffLenCouple.Couple);
        }

        private double _efficiency;

        public double Efficiency
        {
            get { return _efficiency; }
            set { _efficiency = value; }
        }

        private double _length;

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private double _connCouples;

        public double ConnCouples
        {
            get { return _connCouples; }
            set { _connCouples = value; }
        }
    }
}
