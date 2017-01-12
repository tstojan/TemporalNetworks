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

    public class Globals
    {
        
        public static int Main(string[] argv)
        {
            Simulations tsm = new Simulations();

            tsm.SimulationErdosRenyiTemporalMetrics();
            tsm.SimulationErdosRenyiRandomErrors();
            tsm.SimulationErodosRenyiAttacks_Closeness();
            tsm.SimulationErodosRenyiAttacks_FinalHighestDegree();
            tsm.SimulationErodosRenyiAttacks_AverageHighestDegree();
            tsm.SimulationErodosRenyiAttacks_ContactsUpdates();


            tsm.SimulationMarkovTemporalMetrics();
            tsm.SimulationMarkovRandomErrors();
            Console.WriteLine("Closeness");
            tsm.SimulationMarkovAttacks_Closeness();
            Console.WriteLine("Contact Updates");
            tsm.SimulationMarkovAttacks_ContactsUpdates();
            Console.WriteLine("AverageHighestDegree");
            tsm.SimulationMarkovAttacks_AverageHighestDegree();
            Console.WriteLine("FinalHighestDegree");
            tsm.SimulationMarkovAttacks_FinalHighestDegree();

            Console.WriteLine("---------------------------------- INFOCOM ------------------------------------ ");
            tsm.SimulationRealGraphsTemporalMetrics("infocom2006_day2345.dat");
            tsm.SimulationRealGraphsTemporalEfficiency("infocom2006_day2345.dat");

            Console.WriteLine("---------------------------------- Random Error ------------------------------------ ");
            tsm.SimulationRealGraphsRandomErrors("infocom2006_day2345.trace");

            Console.WriteLine("---------------------------------- Closeness ------------------------------------ ");
            tsm.SimulationRealGraphsAttacks_Closeness("infocom2006_day2345.trace");

            Console.WriteLine("---------------------------------- Average Highest Degree ------------------------------------ ");
            tsm.SimulationRealGraphsAttacks_AverageHighestDegree("infocom2006_day2345.trace");

            Console.WriteLine("---------------------------------- Contacts Updates ------------------------------------ ");
            tsm.SimulationRealGraphsAttacks_ContactsUpdates("infocom2006_day2345.trace");


            Console.WriteLine("---------------------------------- Cab-spotting ------------------------------------ ");
            tsm.SimulationRealGraphsTemporalMetrics("cabspotting_contacts_2days.txt");
            tsm.SimulationRealGraphsTemporalEfficiency("cabspotting_contacts_2days.txt");

            Console.WriteLine("---------------------------------- Random Error ------------------------------------ ");
            tsm.SimulationRealGraphsRandomErrors("cabspotting_contacts_2days.txt");

            Console.WriteLine("---------------------------------- Closeness ------------------------------------ ");
            tsm.SimulationRealGraphsAttacks_Closeness("cabspotting_contacts_2days.txt");

            Console.WriteLine("---------------------------------- Average Highest Degree ------------------------------------ ");
            tsm.SimulationRealGraphsAttacks_AverageHighestDegree("cabspotting_contacts_2days.txt");

            Console.WriteLine("---------------------------------- Contacts Updates ------------------------------------ ");
            tsm.SimulationRealGraphsAttacks_ContactsUpdates("cabspotting_contacts_2days.txt");


            String[] mobTraces = new String[] { "RWP_10-1.trace", "RWP_10-2.trace", "RWP_10-3.trace", "RWP_10-4.trace", "RPGM_20x5_10-1.trace", "RPGM_20x5_10-2.trace", "RPGM_20x5_10-3.trace", "RPGM_20x5_10-4.trace" };//, 

            //String[] mobTraces = new String[] { "RPGM_20x5_10-2.trace", "RPGM_20x5_10-3.trace", "RPGM_20x5_10-4.trace" };//, 


            foreach (String fl in mobTraces)
            {
                //tsm.SimulationRealGraphsTemporalMetrics(fl);

                //Console.WriteLine("---------------------------------- Closeness ------------------------------------ ");
                //tsm.SimulationRealGraphsAttacks_Closeness(fl);

                Console.WriteLine("---------------------------------- Average Highest Degree ------------------------------------ ");
                tsm.SimulationRealGraphsAttacks_AverageHighestDegree(fl);

                Console.WriteLine("---------------------------------- Contacts Updates ------------------------------------------ ");
                tsm.SimulationRealGraphsAttacks_ContactsUpdates(fl);

                //Console.WriteLine("---------------------------------- Random Errors ------------------------------------ ");
                //tsm.SimulationRealGraphsRandomErrors(fl);
            }

            Console.ReadLine();
            return 0;
        }
    }
}
