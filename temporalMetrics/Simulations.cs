/* dissertation: Error and Attack Vulnerability of Temporal Networks
 * code: Temporal Metrics and Temporal Robustness
 * Stojan Trajanovski
 * tutorials: Salvatore Scellato and Ilias Leontiadis
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace temporalMetrics
{
    class Simulations
    {
        public TemporalMetrics temporalMetrics;
        public ErdosRenyiTemporalTheoretical ERTemporalMetricsTheoretical;
        public RandomTemporalMetrics randomTemporalMetrics;

        FileInfo f;
        StreamWriter w;

        // Erdos Renyi
        public void SimulationErdosRenyiTemporalMetrics()
        {
            f = new FileInfo("results\\plots\\ErdosRenyiTemporalMetricsPlotsTau_10.dat");
            w = f.CreateText();

            for (int i = 41; i > -1; --i)//-1
            {
                Console.WriteLine(Math.Pow(10, -0.1 * i));
                randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, -0.1 * i), 10, 10, 0.0, -1, 20, 6);
                ERTemporalMetricsTheoretical = new ErdosRenyiTemporalTheoretical(100, Math.Pow(10, -0.1 * i), 100);

                System.Console.WriteLine(Math.Pow(10, -0.1 * i) + ":");
                System.Console.WriteLine(randomTemporalMetrics.Efficiency.ToString("#0.000000") + "\t" + ERTemporalMetricsTheoretical.Efficiency.ToString("#0.000000") + "\t" + (randomTemporalMetrics.Efficiency - ERTemporalMetricsTheoretical.Efficiency).ToString("#0.000000"));
                System.Console.WriteLine(randomTemporalMetrics.Length.ToString("#0.000000") + "\t" + ERTemporalMetricsTheoretical.Length.ToString("#0.000000") + "\t" + (randomTemporalMetrics.Length - ERTemporalMetricsTheoretical.Length).ToString("#0.000000"));
                System.Console.WriteLine(randomTemporalMetrics.ConnCouples.ToString("#0.000000") + "\t" + ERTemporalMetricsTheoretical.ConnCouples.ToString("#0.000000") + "\t" + (randomTemporalMetrics.ConnCouples - ERTemporalMetricsTheoretical.ConnCouples).ToString("#0.000000"));

                w.WriteLine((41 - i).ToString() + "\t" + Math.Pow(10, -0.1 * i).ToString("#0.000000")+ "\t"
                           + randomTemporalMetrics.Efficiency.ToString("#0.000000") + "\t" + ERTemporalMetricsTheoretical.Efficiency.ToString("#0.000000") + "\t"
                           + randomTemporalMetrics.Length.ToString("#0.000000") + "\t" + ERTemporalMetricsTheoretical.Length.ToString("#0.000000") + "\t"
                           + randomTemporalMetrics.ConnCouples.ToString("#0.000000") + "\t" + ERTemporalMetricsTheoretical.ConnCouples.ToString("#0.000000"));;
            }

            w.Close();
        }

        public void SimulationErdosRenyiRandomErrors()
        {
            double[] errorPercentage = new double[] { 0.0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };


            for (int j = -4; j < 1; j++)
            {
                f = new FileInfo("results\\plots\\ErdosRenyiTemporalErrors_100" + Math.Pow(10, j).ToString("#0.00000") + ".dat");
                w = f.CreateText();
                Console.WriteLine("q = " + Math.Pow(10, j).ToString("#0.0000"));

                int k = 1;

                foreach (double errPerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, j), 20, 20, errPerc, 10, 100, 0);

                    w.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    k++;
                }

                w.Close();
            }
        }

        public void SimulationErodosRenyiAttacks_Closeness()
        {
            double[] errorPercentage = new double[] {0.00};//, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

            for (int j = -4; j < 1; j++)
            {
                f = new FileInfo("results\\plots\\ErdosRenyiTemporalAttack_Closenness_100" + Math.Pow(10, j).ToString("#0.0000") + ".dat");
                w = f.CreateText();
                Console.WriteLine("q = " + Math.Pow(10, j).ToString("#0.0000"));

                int k = 1;

                foreach (double errPerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, j), 20, 20, errPerc, 10, 100, 2);

                    w.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    k++;
                }

                w.Close();
            }
        }

        public void SimulationErodosRenyiAttacks_FinalHighestDegree()
        {
            double[] errorPercentage = new double[] {0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

            for (int j = -4; j < 1; j++)
            {
                f = new FileInfo("results\\plots\\ErdosRenyiTemporalAttack_FinalHighestDegree_100" + Math.Pow(10, j).ToString("#0.0000") + ".dat");
                w = f.CreateText();
                Console.WriteLine("q = " + Math.Pow(10, j).ToString("#0.0000"));

                int k = 1;

                foreach (double errPerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, j), 20, 20, errPerc, 10, 100, 3);

                    w.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    k++;
                }

                w.Close();
            }
        }

        public void SimulationErodosRenyiAttacks_AverageHighestDegree()
        {
            double[] errorPercentage = new double[] {0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

            for (int j = -4; j < 1; j++)
            {
                f = new FileInfo("results\\plots\\ErdosRenyiTemporalAttack_AverageHighestDegree_100" + Math.Pow(10, j).ToString("#0.0000") + ".dat");
                w = f.CreateText();
                Console.WriteLine("q = " + Math.Pow(10, j).ToString("#0.0000"));

                int k = 1;

                foreach (double errPerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, j), 20, 20, errPerc, 10, 100, 4);

                    w.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    k++;
                }

                w.Close();
            }
        }

        public void SimulationErodosRenyiAttacks_ContactsUpdates()
        {
            double[] errorPercentage = new double[] {0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

            for (int j = -4; j < 1; j++)
            {
                f = new FileInfo("results\\plots\\ErdosRenyiTemporalAttack_ContactUpdates_100" + Math.Pow(10, j).ToString("#0.0000") + ".dat");
                w = f.CreateText();
                Console.WriteLine("q = " + Math.Pow(10, j).ToString("#0.0000"));

                int k = 1;

                foreach (double errPerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, j), 20, 20, errPerc, 10, 100, 5);

                    w.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(k.ToString() + "\t" + errPerc.ToString("#0.00") + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    k++;
                }

                w.Close();
            }
        }

        // Markov model
        public void SimulationMarkovTemporalMetrics()
        {
            for (int j = -4; j < 1; j++)
            {
                f = new FileInfo("results\\plots\\MarkovTemporalMetricsPlots_100" + Math.Pow(10, j).ToString("#0.0000") + ".dat");
                w = f.CreateText();
                Console.WriteLine("q = " + Math.Pow(10, j).ToString("#0.0000"));

                for (int i = -50; i < 1; i++)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, Math.Pow(10, 0.1*i), Math.Pow(10, j), 100, 100, 0.0, -1, 2, 6);

                    w.WriteLine((51 + i).ToString() + "\t" + Math.Pow(10, 0.1*i).ToString("#0.000000") + "\t" + randomTemporalMetrics.Efficiency.ToString("#0.000000") + "\t" + randomTemporalMetrics.Length.ToString("#0.000000") + "\t" + randomTemporalMetrics.ConnCouples.ToString("#0.000000"));
                    System.Console.WriteLine((51 + i).ToString() + "\t" + Math.Pow(10, 0.1*i).ToString("#0.000000") + "\t" + randomTemporalMetrics.Efficiency.ToString("#0.000000") + "\t" + randomTemporalMetrics.Length.ToString("#0.000000") + "\t" + randomTemporalMetrics.ConnCouples.ToString("#0.000000"));
                }

                w.Close();
            }
        }

        public void SimulationMarkovRandomErrors()
        {
            double[] errorPercentage = new double[] {0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

            double[] P_ONs = new double[] { 0.0001, 0.001, 0.01, 0.1};
            double q = 0.01;

            foreach (double p_on in P_ONs)
            {
                f = new FileInfo("results\\plots\\MarkovTemporalRandomErrorsPlots_100_q_" + p_on.ToString("#0.0000") + ".dat");
                w = f.CreateText();
                int i = 1;

                foreach (double ePerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, q * (1.0 - p_on) / p_on, q, 300, 300, ePerc, 150, 1, 0);

                    w.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    i++;
                }

                w.Close();
            }
        }

        public void SimulationMarkovAttacks_Closeness()
        {
            double[] errorPercentage = new double[] {0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95};

            double[] P_ONs = new double[] { 0.0001, 0.001, 0.01, 0.1 };
            double q = 0.01;

            foreach (double p_on in P_ONs)
            {
                f = new FileInfo("results\\plots\\MarkovTemporalClosenessPlots_100_q_" + p_on.ToString("#0.0000") + ".dat");
                w = f.CreateText();
                int i = 1;

                foreach (double ePerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, q * (1.0 - p_on) / p_on, q, 300, 300, ePerc, 150, 50, 2);

                    w.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    i++;
                }

                w.Close();
            }
        }

        public void SimulationMarkovAttacks_FinalHighestDegree()
        {
            double[] errorPercentage = new double[] { 0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

            double[] P_ONs = new double[] { 0.0001, 0.001, 0.01, 0.1 };
            double q = 0.01;

            foreach (double p_on in P_ONs)
            {
                f = new FileInfo("results\\plots\\MarkovTemporalFinalHighestDegreePlots_100_q_" + p_on.ToString("#0.0000") + ".dat");
                w = f.CreateText();
                int i = 1;

                foreach (double ePerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(1100, q * (1.0 - p_on) / p_on, q, 300, 300, ePerc, 150, 50, 3);

                    w.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    i++;
                }

                w.Close();
            }
        }

        public void SimulationMarkovAttacks_AverageHighestDegree()
        {
            double[] errorPercentage = new double[] { 0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95};

            double[] P_ONs = new double[] { 0.0001, 0.001, 0.01, 0.1 };
            double q = 0.01;

            foreach (double p_on in P_ONs)// j = -4; j < 0; j++)
            {
                f = new FileInfo("results\\plots\\MarkovTemporalAverageHighestDegreePlots_100_q_" + p_on.ToString("#0.0000") + ".dat");
                w = f.CreateText();
                int i = 1;

                foreach (double ePerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, q * (1.0 - p_on) / p_on, q, 300, 300, ePerc, 150, 50, 4);

                    w.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    i++;
                }

                w.Close();
            }
        }

        public void SimulationMarkovAttacks_ContactsUpdates()
        {
            double[] errorPercentage = new double[] { 0.00, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95};

            double[] P_ONs = new double[] { 0.0001, 0.001, 0.01, 0.1 };
            double q = 0.01;

            foreach (double p_on in P_ONs)
            {
                f = new FileInfo("results\\plots\\MarkovTemporalContactUpdatesPlots_100_q_" + p_on.ToString("#0.0000") + ".dat");
                w = f.CreateText();
                int i = 1;

                foreach (double ePerc in errorPercentage)
                {
                    randomTemporalMetrics = new RandomTemporalMetrics(100, q * (1.0 - p_on) / p_on, q, 300, 300, ePerc, 150, 50, 5);

                    w.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));
                    System.Console.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + randomTemporalMetrics.temporalRobustness.ToString("#0.000000"));

                    i++;
                }

                w.Close();
            }
        }

        // Real graphs
        public void SimulationRealGraphsTemporalMetrics(String filename)
        {
            temporalMetrics = new TemporalMetrics(filename, 4, 1);
            temporalMetrics.calculateTemporalEfficiency();
            temporalMetrics.recordImportantNodes();
        }

        public void SimulationRealGraphsTemporalEfficiency(String filename)
        {
            TemporalMetricsClean tmp = new TemporalMetricsClean(filename, -1, 1);
            tmp.calculateTemporalEfficiency();
        }

        public void SimulationRealGraphsRandomErrors(String filename)
        {
            temporalMetrics = new TemporalMetrics(filename, 0, 100);
            temporalMetrics.calculateErrorOrAttack();
        }

        public void SimulationRealGraphsAttacks_Closeness(String filename)
        {
            temporalMetrics = new TemporalMetrics(filename, 2, 1);
            temporalMetrics.calculateErrorOrAttack();
        }

        public void SimulationRealGraphsAttacks_FinalHighestDegree(String filename)
        {
            temporalMetrics = new TemporalMetrics(filename, 3, 1);
            temporalMetrics.calculateErrorOrAttack();
        }

        public void SimulationRealGraphsAttacks_AverageHighestDegree(String filename)
        {
            temporalMetrics = new TemporalMetrics(filename, 4, 1);
            temporalMetrics.calculateErrorOrAttack();
        }

        public void SimulationRealGraphsAttacks_ContactsUpdates(String filename)
        {
            temporalMetrics = new TemporalMetrics(filename, 5, 1);
            temporalMetrics.calculateErrorOrAttack();
        }

    }
}
