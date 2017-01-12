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
    class TemporalMetrics
    {
         private Random randomGenerator;
         private int NumberOfNodes;
         private double p;
         private double q;
         private int Tau;
         private int T;
         private double prob_ON;
         public double errorProb;
         private int failTime;
         private double percErrorTime;
         private int NumRuns;
         private String FileName;
         private int TypeOfError;

         /* 0 - random errors
          * 2 - tempral closeness
          * 4 - the highest degree
          * 5 - number of contacts updates         
          */

         private List<int> Nodes;
         private Dictionary<int, Dictionary<int,bool>> edges;
         private Dictionary<int, Dictionary<int, int>> vector_clock;
         private Dictionary<int, Dictionary<int, int>> new_vector_clock;
         private Dictionary<int, Dictionary<int, int>> last_seen;
         private Dictionary<int, Dictionary<int, int>> new_last_seen;
         private Dictionary<int, bool> active_nodes;
         private int MinimumTime;
         private int MaximumTime;
         private List<Contacts> ContactsList;
         private Dictionary<int, Dictionary<int, List<int>>> Graphs;
         private Dictionary<int, Dictionary<int, List<int>>> Graphs_1;
         private Dictionary<int, double> nodesImportance;

         private Dictionary<int, double> nodesImportanceCloseness;
         private Dictionary<int, double> nodesImportanceHighestDegree;
         private Dictionary<int, double> nodesImportanceContactsUpdates;

         Dictionary<int, List<int>> currentGraph;
         private List<int> timeChangeingMoments;
         

         public double Efficiency;
         public double Length;
         public double ConnCouples;
         public double temporalRobustness;
         

         // Markovian Model Constructor
         public TemporalMetrics(string inFile, int _errType, int numRn)
         {
             FileName = inFile;
             Tau = 3600;
             NumRuns = numRn;
             TypeOfError = _errType;

             readGraph(FileName);
             randomGenerator = new Random();
         }

         private void readGraph(string fileName)
         {
             String line;
             TextReader f = null;

             int node1, node2, start, duration, nm = -1;

             Tau = 3600;

             MinimumTime = Int32.MaxValue;
             MaximumTime = -1;

             Nodes = new List<int>();
             Graphs = new Dictionary<int,Dictionary<int,List<int>>>();
             Graphs_1 = new Dictionary<int, Dictionary<int, List<int>>>();
             nodesImportance = new Dictionary<int, double>();
             timeChangeingMoments = new List<int>();

             nodesImportanceCloseness = new Dictionary<int, double>();
             nodesImportanceHighestDegree = new Dictionary<int, double>();
             nodesImportanceContactsUpdates = new Dictionary<int, double>();

             int i = 1;
             
             f = new StreamReader(fileName);
             String[] elem;

             while ((line = f.ReadLine()) != null) //  (i < 1001)
             {
                try
                {
                   elem = line.Split(' ');

                   node1 = Convert.ToInt32(elem[0]);
                   node2 = Convert.ToInt32(elem[1]);
                   start = Convert.ToInt32(elem[2]);
                   duration = Convert.ToInt32(elem[3]);

                   //if (start > 1212048008)
                     // break;

                   if(duration>0)
                   {
                       if (!Nodes.Contains(node1))
                       {
                           Nodes.Add(node1);
                           nodesImportance.Add(node1, 0.0);
                           nodesImportanceCloseness.Add(node1, 0.0);
                           nodesImportanceHighestDegree.Add(node1, 0.0);
                           nodesImportanceContactsUpdates.Add(node1, 0.0);
                       }

                       if (!Nodes.Contains(node2))
                       {
                           Nodes.Add(node2);
                           nodesImportance.Add(node2, 0.0);
                           nodesImportanceCloseness.Add(node2, 0.0);
                           nodesImportanceHighestDegree.Add(node2, 0.0);
                           nodesImportanceContactsUpdates.Add(node2, 0.0);
                       }

                       if (MinimumTime > start)
                           MinimumTime = start;

                       if (MaximumTime < (start + duration))
                           MaximumTime = (start + duration);


                       for (int t = start; t <= (start + duration); t++)
                       {
                           if (!Graphs.ContainsKey(t))
                               Graphs.Add(t, new Dictionary<int, List<int>>());

                           if (!Graphs[t].ContainsKey(node1))
                               Graphs[t].Add(node1, new List<int>());

                           if (!Graphs[t].ContainsKey(node2))
                               Graphs[t].Add(node2, new List<int>());

                               Graphs[t][node1].Add(node2);
                               Graphs[t][node2].Add(node1);
                        }

                        if (!timeChangeingMoments.Contains(start))
                            timeChangeingMoments.Add(start);


                        if (!timeChangeingMoments.Contains(start + duration))
                            timeChangeingMoments.Add(start + duration);

                        i++;
                    }
                }
                catch
                {
                        i++;
                        continue;
                }

             }

             f.Close();               

             timeChangeingMoments.Sort();
             NumberOfNodes = Nodes.Count;             
         }

         public void calculateTemporalEfficiency()
         {
             FileInfo f;
             StreamWriter w;

             f = new FileInfo("results\\plots\\TemporalMetricsPlots"+FileName);
             w = f.CreateText();
             errorProb = 0.0;

             computeTemporalEfficiency();

             System.Console.WriteLine(Efficiency.ToString("#0.000000") + "\t" + Length.ToString("#0.000000") + "\t" + ConnCouples.ToString("#0.000000"));

             w.WriteLine(Efficiency.ToString("#0.000000") + "\t" + Length.ToString("#0.000000") + "\t" + ConnCouples.ToString("#0.000000"));
             w.Close();
         }

         public void calculateErrorOrAttack()
         {
             int i = 1;
             FileInfo f;
             StreamWriter w;
             double effGen;
             String fileAddition = "";
             double[] errorPercentage = new double[] { 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95 };

             switch (TypeOfError)
             {
                 case 0:
                     fileAddition = "RandomErrors";
                     break;
                 case 2:
                     fileAddition = "TemporalCloseness";
                     break;
                 case 4:
                     fileAddition = "AverageHighestDegree";
                     break;
                 case 5:
                     fileAddition = "AverageContactUpdates";
                     break;
                 default:
                     Console.WriteLine("Invalid selection. Please select 0, 2, 4 or 5.");
                     break;
             }

             f = new FileInfo("results\\plots\\" + fileAddition + "_" + FileName);
             w = f.CreateText();

             errorProb = 0.0;

             int tempNumRuns = NumRuns;

             NumRuns = 1;

             computeTemporalEfficiency();
             effGen = Efficiency;
             NumRuns = tempNumRuns;


             w.WriteLine(i.ToString() + "\t0.00" + "\t1.000000");
             System.Console.WriteLine(i.ToString() + "\t0.00" + "\t1.000000");
             i++;

             foreach (double ePerc in errorPercentage)
             {
                 errorProb = ePerc;
                 computeTemporalEfficiency();
                 temporalRobustness = Efficiency / effGen;

                 w.WriteLine(i.ToString() + "\t" + ePerc.ToString() + "\t" + temporalRobustness.ToString("#0.000000"));

                 i++;
             }

             w.Close();
         }

         private void initEdges()
         {

           Dictionary<int, int> tempVect;
           Dictionary<int, int> tempNewVect;
           Dictionary<int, int> tempLastSeen;
           Dictionary<int, int> tempNewLastSeen;
           Dictionary<int, bool> tmpEdgeI;

           edges = new Dictionary<int, Dictionary<int, bool>>(NumberOfNodes);
           vector_clock = new Dictionary<int, Dictionary<int, int>>(NumberOfNodes);
           new_vector_clock = new Dictionary<int, Dictionary<int, int>>(NumberOfNodes);
           last_seen = new Dictionary<int, Dictionary<int, int>>(NumberOfNodes);
           new_last_seen = new Dictionary<int, Dictionary<int, int>>(NumberOfNodes);
           active_nodes = new Dictionary<int, bool>(NumberOfNodes);

           

           foreach (int i in Nodes)
           {
               tempVect = new Dictionary<int, int>(NumberOfNodes);
               tempNewVect = new Dictionary<int, int>(NumberOfNodes);
               tempLastSeen = new Dictionary<int, int>(NumberOfNodes);

               foreach (int j in Nodes)
               {
                   tempVect.Add(j, -1);
                   tempNewVect.Add(j, -1);
                   tempLastSeen.Add(j, -1);
               }

               vector_clock.Add(i,tempVect);
               new_vector_clock.Add(i,tempNewVect);
               last_seen.Add(i, tempLastSeen);
           }

           foreach (int i in Nodes)
           {
               tempNewLastSeen = new Dictionary<int, int>();
               tmpEdgeI = new Dictionary<int, bool>();

               foreach (int j in Nodes)
               {
                   tempNewLastSeen.Add(j, -1);
                   tmpEdgeI.Add(j, false);
               }

               active_nodes.Add(i, true);

               new_last_seen.Add(i, tempNewLastSeen);
               edges.Add(i, tmpEdgeI);
           }       

           currentGraph = Graphs[MinimumTime];

           foreach (KeyValuePair<int, List<int>> nd1 in currentGraph)  
               foreach (int nd2 in nd1.Value)
                   edges[nd1.Key][nd2] = true;

         }

         public void updateVectorClock(int n1, int n2, int t)
         {
             foreach (int n3 in Nodes)
             {
                 if (n3 == n2)
                 {
                     continue;
                 }

                 if (vector_clock[n1][n3] > new_vector_clock[n2][n3])
                 {
                    new_vector_clock[n2][n3] = vector_clock[n1][n3];
                    new_last_seen[n2][n3] = t;

                    if ((errorProb == 0.0)) //(TypeOfError == 5) && 
                    {
                        nodesImportance[n1] += 1.0;
                        nodesImportanceContactsUpdates[n1] += 1.0;
                    }
                 }
             }

             new_last_seen[n2][n1] = t;
             new_vector_clock[n2][n1] = t;

             if (errorProb == 0.0) //(TypeOfError == 5) && 
             {
                 nodesImportance[n1] += 1.0;
                 nodesImportanceContactsUpdates[n1] += 1.0;
             }
         }

         public void getEfficiency(int t, out double e, out double l, out double c)
         {
             if (NumberOfNodes == 0)
             {
                 e = l = c = 0.0;
                 return;
             }

             double len = 0.0;
             double eff = 0.0;
             double conCoupl = 0.0;

             foreach (int n1 in Nodes)
             {
                 if (t == (failTime - 1)) // && (TypeOfError == 2)
                 {
                     nodesImportance[n1] = 0.0;
                     nodesImportanceContactsUpdates[n1] = 0.0;
                 }

                if (!(active_nodes[n1]))
                {
                    continue;
                }

               foreach (int n2 in Nodes)
               {

                  if ((!(active_nodes[n2]))||(n1==n2))
                       continue;

                  int v = vector_clock[n1][n2];
                  int ls = last_seen[n1][n2];

                  if (v == -1)
                      continue;

                  if (t - v < Tau)
                  {
                      int dist = t - v + 1;

                      if (errorProb == 0.0) //(TypeOfError == 2) && 
                      {
                          nodesImportance[n1] += dist;
                          nodesImportanceCloseness[n1] += 1.0/dist;
                      }
                      //printf dist

                      if (dist >= 1)
                      {
                          len += dist;
                          eff += 1.0 / dist;
                          conCoupl += 1.0;
                      }
                   }
                 }
             }

             e = eff;

            if (conCoupl > 0)
            {
                l = len/conCoupl;
            }
            else
                l = 0.0;
        
            c = conCoupl;
      }

      public int failNodes()
      {
          int k = 0;
          Console.Write("Failing nodes with probability {0}\n", errorProb);

          if(TypeOfError==0)
            foreach (int i in Nodes)
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
          else if (TypeOfError == 2)
          {
              // temporal closseness centrality

              //foreach (KeyValuePair<int, double> act in nodesImportance.OrderByDescending(x => x.Value).Take((int)(errorProb * NumberOfNodes))) // used for rubustness range
              foreach (KeyValuePair<int, double> act in nodesImportance.OrderBy(x => x.Value).Take((int)(errorProb * NumberOfNodes)))  // used for robustness            
              {
                  active_nodes[act.Key] = false;
                  k++;
                  Console.WriteLine(k.ToString() + "\t" + act.Key.ToString() + "\t" + act.Value.ToString());
              }
          }
          else if ((TypeOfError == 4) || (TypeOfError == 5))
          {
              // the highest degree or cummulative highest degree or number of contacts/updates

              foreach (KeyValuePair<int, double> act in nodesImportance.OrderBy(x => x.Value).Take((int)(errorProb * NumberOfNodes))) // used for rubustness range
              //foreach (KeyValuePair<int, double> act in nodesImportance.OrderByDescending(x => x.Value).Take((int)(errorProb * NumberOfNodes))) // used for robustness      
              {
                  active_nodes[act.Key] = false;
                  k++;
                  Console.WriteLine(k.ToString() + "\t" + act.Key.ToString() + "\t" + act.Value.ToString());
              }
          }

          Console.Write("{0} out of {1} nodes removed\n", k, NumberOfNodes);

          return NumberOfNodes - k;
      }


      public void computeTemporalEfficiency()
      {
          double eff = 0.0;
          double len = 0.0;
          double cc = 0.0;
          Dictionary<int, List<int>> currentGraph;

          Efficiency = 0.0;
          Length = 0.0;
          ConnCouples = 0.0;
          temporalRobustness = 0.0;


          for (int run = 0; run < NumRuns; run++)
          {

            initEdges();
            MaximumTime = timeChangeingMoments.LastOrDefault();
            
            if(errorProb!=0.0)
              failNodes();

            int p = 0;
            
            foreach(int t in timeChangeingMoments)
            {
               currentGraph = Graphs[t];

               foreach (int n1 in Nodes)
                 foreach (int n2 in Nodes)
                 {
                       if((n1<n2)&&edges[n1][n2])
                       {
                          updateVectorClock(n1, n2, t);
                          updateVectorClock(n2, n1, t);
                       }

                       if (!currentGraph.ContainsKey(n1))
                           edges[n1][n2] = false;
                       else
                           edges[n1][n2] = currentGraph[n1].Contains(n2);
                 }

               foreach (int n1 in Nodes)
                   foreach (int n2 in Nodes)
                   {
                      vector_clock[n1][n2] = new_vector_clock[n1][n2];
                      last_seen[n1][n2] = new_last_seen[n1][n2];
                   }

               //compute metrics
               getEfficiency(t, out eff, out len, out cc);

               if (errorProb == 0.0)
               {
                   //if ((TypeOfError == 4)) //cummulative degree
                   {
                       foreach (int i in Nodes)
                       {
                           nodesImportance[i] += edges[i].Where(x => x.Value == true).Count();
                           nodesImportanceHighestDegree[i] += edges[i].Where(x => x.Value == true).Count();
                       }
                   }

                   if ((t == MaximumTime) && (TypeOfError == 3)) // degree nodes
                   {
                       foreach (int i in Nodes)
                           nodesImportance[i] = edges[i].Where(x => x.Value == true).Count();
                   }
               }

               // for real graphs we calculate 
               Efficiency += eff;
               Length += len;
               ConnCouples += ((cc / NumberOfNodes) / (NumberOfNodes - 1));
            }
         }

         Efficiency = ((Efficiency / NumberOfNodes) / (NumberOfNodes - 1));
         Length = ((Length / NumberOfNodes) / (NumberOfNodes - 1));

         ConnCouples /= timeChangeingMoments.Count;
         Efficiency /= timeChangeingMoments.Count;
         Length /= timeChangeingMoments.Count;
         
         Efficiency /= NumRuns;
         Length /= NumRuns;
         ConnCouples /= NumRuns;
      }

      public void recordImportantNodes()
      {
          FileInfo f = new FileInfo("results\\plots\\ClosenessImportantNodes.txt");
          StreamWriter w = f.CreateText();
          int k;

          Console.WriteLine("Closeness Nodes");
          k = 0;

          foreach (KeyValuePair<int, double> act in nodesImportanceCloseness.OrderBy(x => x.Value))
          {
              k++;
              w.WriteLine(k.ToString() + "\t" + act.Key.ToString() + "\t" + act.Value.ToString());
          }

          w.Close();

          f = new FileInfo("results\\plots\\DegreeImportantNodes.txt");
          w = f.CreateText();

          Console.WriteLine("Degree nodes");
          k = 0;

          foreach (KeyValuePair<int, double> act in nodesImportanceHighestDegree.OrderBy(x => x.Value))
          {
              k++;
              w.WriteLine(k.ToString() + "\t" + act.Key.ToString() + "\t" + act.Value.ToString());
          }

          w.Close();

          f = new FileInfo("results\\plots\\ContactUpdatesImportantNodes.txt");
          w = f.CreateText();

          Console.WriteLine("Contacts/Updates nodes");
          k = 0;

          foreach (KeyValuePair<int, double> act in nodesImportanceContactsUpdates.OrderBy(x => x.Value))
          {
              k++;
              w.WriteLine(k.ToString() + "\t" + act.Key.ToString() + "\t" + act.Value.ToString());
          }

          w.Close();
      }
   }
}
