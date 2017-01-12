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
    class RandomTemporalMetrics
    {
         private Random randomGenerator;
         private int NumberOfNodes;
         private double p;
         private double q;
         private int Tau;
         private int T;
         private double prob_ON;
         private double errorProb;
         private int failTime;
         private int NumRuns;
         private int TypeOfError;

         /* 0 - random errors
          * 2 - tempral closeness
          * 4 - avergage highest degree
          * 5 - number of contacts updates         
          */

         private bool[,] edges;
         private int[,] vector_clock;
         private int[,] new_vector_clock;
         private int[,] last_seen;
         private int[,] new_last_seen;
         private bool[] active_nodes;
         private Dictionary<int, double> nodesImportance;
         private Dictionary<int, double> nodesImportanceAverage;

         public double Efficiency;
         public double Length;
         public double ConnCouples;
         public double temporalRobustness;
         

         // Markovian Model Constructor
         public RandomTemporalMetrics(int NumN, double prob_p, double prob_q, int _tau, int _T, double _errP, int _failTime, int _numRuns, int eType)
         {
             NumberOfNodes = NumN;
             p = prob_p;
             q = prob_q;
             Tau = _tau;
             T = _T;
             errorProb = _errP;
             failTime = _failTime;
             TypeOfError = eType;
             NumRuns = _numRuns;

             prob_ON = q/(p+q);
             randomGenerator = new Random();

             initEdges();
             computeTemporalEfficiency(failTime);
         }

         // Erdos-Renyi Model Constructor
         public RandomTemporalMetrics(int NumN, double prob_appearance, int _tau, int _T, double _errP, int _failTime, int _numRuns, int eType)
         {
             NumberOfNodes = NumN;
             p = 1 - prob_appearance;
             q = prob_appearance;
             Tau = _tau;
             T = _T;
             errorProb = _errP;
             failTime = _failTime;
             TypeOfError = eType;
             NumRuns = _numRuns;

             prob_ON = prob_appearance;
             randomGenerator = new Random();

             initEdges();
             computeTemporalEfficiency(failTime);
         }

         private void initEdges()
         {

           double initProb = q / (p + q);

           edges = new bool[NumberOfNodes, NumberOfNodes];
           vector_clock = new int[NumberOfNodes, NumberOfNodes];
           new_vector_clock = new int[NumberOfNodes, NumberOfNodes];
           last_seen = new int[NumberOfNodes, NumberOfNodes];
           new_last_seen = new int[NumberOfNodes, NumberOfNodes];
           active_nodes = new bool[NumberOfNodes];
           nodesImportance = new Dictionary<int, double>();
           nodesImportanceAverage = new Dictionary<int, double>();

           for (int i = 0; i < NumberOfNodes; i++)
           {
               for (int j = 0; j < NumberOfNodes; j++)
               {
                  vector_clock[i, j] = -1;
                  new_vector_clock[i, j] = -1;
                  last_seen[j, i] = -1;
                  new_last_seen[j, i] = -1;
               }

               active_nodes[i] = true;
               nodesImportance.Add(i, 0.0);
               nodesImportanceAverage.Add(i, 0.0);
           }

           for (int i = 0; i < NumberOfNodes; i++)
           {
               for (int j = i; j < NumberOfNodes; j++)
                    {
                        double rnd = randomGenerator.NextDouble();
                        edges[i, j] = rnd <= prob_ON;
                        edges[j, i] = rnd <= prob_ON;
                    }
            }
         }


         public void updateEdge(int n1, int n2)
         {
            bool on = edges[n1, n2];
            bool new_on;
            double rnd = randomGenerator.NextDouble();

            if (on)
            {
               if (rnd <= p)
                   new_on = false;
               else
                   new_on = on;
            }
            else if (rnd <= q)
            {
               new_on = true;
            }
            else
            {
               new_on = on;
            }
              edges[n1, n2] = new_on;
              edges[n2, n1] = new_on;
         }

         public void updateVectorClock(int n1, int n2, int t)
         {
             for (int n3 = 0; n3 < NumberOfNodes; (n3)++)
             {
                 if (n3 == n2)
                 {
                     continue;
                 }

                 if (vector_clock[n1, n3] > new_vector_clock[n2, n3])
                 {
                    new_vector_clock[n2, n3] = vector_clock[n1, n3];
                    new_last_seen[n2, n3] = t;

                    if (TypeOfError == 5)
                        nodesImportance[n1] += 1.0;
                 }
             }

             new_last_seen[n2, n1] = t;
             new_vector_clock[n2, n1] = t;

             if (TypeOfError == 5)
                 nodesImportance[n1] += 1.0;
         }

         public double[] getEfficiency(int t)
         {
             double[] metrics = new double[3];
             metrics[0] = 0.0;
             metrics[1] = 0.0;
             metrics[2] = 0.0;

             if (NumberOfNodes == 0)
                return metrics;

             double len = 0.0;
             double eff = 0.0;
             double conCoupl = 0.0;

             for (int n1 = 0; n1 < NumberOfNodes; n1++)
             {

               if (!(active_nodes[n1]))
               {
                   continue;
               }

               for (int n2 = 0; n2 < NumberOfNodes; n2++)
               {

                  if (!(active_nodes[n2]))
                  {
                     continue;
                  }

                  if (n1 == n2)
                  {
                     continue;
                  }

                  int v = vector_clock[n1, n2];
                  int ls = last_seen[n1, n2];

                  if (v == -1)
                      continue;

                  if (t - v < Tau)
                  {
                      int dist = t - v + 1;

                      if (t == (failTime - 1))
                      {
                          if (TypeOfError == 2)
                              nodesImportance[n1] += dist;
                      }
                      //printf("t %d: v %d, ls %d, dist %d\n",t,v,ls,dist);
                      len += dist;
                      eff += 1.0 / dist;
                      conCoupl += 1.0;
                  }

                 }
              }

            eff = eff / NumberOfNodes / (NumberOfNodes - 1);
            
            if (conCoupl > 0)
            {
               len = len / conCoupl;
            }

            metrics[0] = eff;
            metrics[1] = len;
            metrics[2] = conCoupl;

            return metrics;
      }

      public int failNodes()
      {
          FileInfo f;
          TextWriter w;

          int k = 0;

          if (TypeOfError == 0)
          {
              for (int i = 0; i < NumberOfNodes; i++)
              {
                  double rnd = randomGenerator.NextDouble();

                  if (rnd < errorProb)
                  {
                      active_nodes[i] = false;
                      k++;
                  }
                  else
                      active_nodes[i] = true;
              }
          }
          else if (TypeOfError == 2)
          {

              foreach (KeyValuePair<int, double> act in nodesImportance)
              {
                  nodesImportanceAverage[act.Key] += act.Value;
              }


              // temporal closseness centrality
              foreach (KeyValuePair<int, double> act in nodesImportance.OrderBy(x => x.Value).Take((int)(errorProb * NumberOfNodes)))
              {
                  active_nodes[act.Key] = false;
                  k++;
              }

          }
          else if ((TypeOfError == 4) || (TypeOfError == 5))
          {
              foreach (KeyValuePair<int, double> act in nodesImportance)
              {
                  nodesImportanceAverage[act.Key] += act.Value;
              }

              // the highest degree or cummulative highest degree or number of contacts/updates
              foreach (KeyValuePair<int, double> act in nodesImportance.OrderByDescending(x => x.Value).Take((int)(errorProb * NumberOfNodes)))
              {
                  active_nodes[act.Key] = false;
                  k++;
              }

          }

          return (NumberOfNodes - k);
      }


      public void computeTemporalEfficiency(int fail_time)
      {
          double eff = 0.0;
          double len = 0.0;
          double cc = 0.0;

          Efficiency = 0.0;
          Length = 0.0;
          ConnCouples = 0.0;
          temporalRobustness = 0.0;

           for (int run = 0; run < NumRuns; run++)
           {
               double[] results = null;
               initEdges();
               int k = 0;

               for (int i = 0; i < NumberOfNodes; i++)
               {
                   for (int j = 0; j < NumberOfNodes; j++)
                   {
                       if (edges[i, j])
                            k++;

                   }
               }


            int active = NumberOfNodes;

            for (int t = 0; t < T; t++)
            {
               //loop over all couples of nodes
               int count = 0;

               for (int n1 = 0; n1 < NumberOfNodes; n1++)
                 for (int n2 = n1 + 1; n2 < NumberOfNodes; n2++)
                 {
                       if (edges[n1, n2])
                       {
                          count++;
                          updateVectorClock(n1, n2, t);
                          updateVectorClock(n2, n1, t);
                       }

                       updateEdge(n1, n2);
                 }

               for (int n1 = 0; n1 < NumberOfNodes; n1++)
                  for (int n2 = 0; n2 < NumberOfNodes; n2++)
                  {
                      vector_clock[n1, n2] = new_vector_clock[n1, n2];
                      last_seen[n1, n2] = new_last_seen[n1, n2];
                  }

               //compute metrics
               results = getEfficiency(t);
               eff = results[0];
               len = results[1];
               cc = (results[2]/NumberOfNodes)/(NumberOfNodes-1);

               if ((TypeOfError == 4) && (t <= (failTime - 1)))
               {
                   for (int i = 0; i < NumberOfNodes; i++)
                       for (int j = 0; j < NumberOfNodes; j++)
                           if(edges[i,j])
                             nodesImportance[i] += 1.0;
               }

               if ((TypeOfError == 3) && (t == (failTime - 1)))
               {
                   for (int i = 0; i < NumberOfNodes; i++)
                       for (int j = 0; j < NumberOfNodes; j++)
                           if (edges[i, j])
                               nodesImportance[i] += 1.0;
               }

               if (t == (fail_time - 1))
                   temporalRobustness += eff;

               if (t == fail_time)
                  active = failNodes();
            }

            Efficiency += eff;
            Length += len;
            ConnCouples += cc;
         }

         FileInfo f;
         TextWriter w;

         if (TypeOfError == 2)
             f = new FileInfo("results\\plots\\MarkovImportantNodesCloseness.txt");
         else if (TypeOfError == 3)
             f = new FileInfo("results\\plots\\MarkovImportantNodesFinalDegree.txt");
         else if (TypeOfError == 4)
             f = new FileInfo("results\\plots\\MarkovImportantNodesAverageDegree.txt");
         else
             f = new FileInfo("results\\plots\\MarkovImportantContactUpdates.txt");

         w = f.CreateText();

         foreach (KeyValuePair<int, double> act in nodesImportance)
         {
             if (TypeOfError == 2)
             {
                 w.Write((act.Value / (NumberOfNodes * NumRuns)) + " ");
                 Console.Write((act.Value / (NumberOfNodes * NumRuns)) + " ");
             }
             else
             {
                 w.Write((act.Value / (NumRuns)) + " ");
                 Console.Write((act.Value / (NumRuns)) + " ");
             }
         }

         w.Close();

         Efficiency /= NumRuns;
         Length /= NumRuns;
         ConnCouples /= NumRuns;
         temporalRobustness /= NumRuns;

         temporalRobustness = Efficiency / temporalRobustness;
      }
   }
}
