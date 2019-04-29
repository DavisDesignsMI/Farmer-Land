/* CREATED BY: Davis M. Brace  (Davis Designs of Michigan LLC)
 * STARTED ON: 04/25/2019
 * TITLE: Farmerland Barn Extension
 * 
 * DESCRIPTION:
 * Class of the FarmerLand app.  Represents a barn for animals and associated data
 * and methods.
 */

using System;
using System.Collections.Generic;

namespace FarmerLand
{
    [Serializable]
    class Barn
    {
        public List<int> owned = new List<int>();

        public bool TryBuy(int selection, double cash)
        {
            if (!owned.Contains(selection))
            {
                //Calculate cost
                double cost = selection * 10000;

                //Determine if cost is too high
                if (cost <= cash)
                {
                    return true;
                }
            }

            //Return 0 as default
            return false;
        }

        public double Buy(int selection, double cash)
        {
            if (!owned.Contains(selection))
            {
                //Calculate cost
                double cost = selection * 10000;

                //Determine if cost is too high
                if (cost <= cash)
                {
                    //Purchase
                    owned.Add(selection);
                    return cost;
                }
            }

            //Return 0 as default
            return 0;
        }

        public double Collect()
        {
            //Initiate revenue variable
            double revenue = 0;

            foreach (int animal in owned)
            {
                revenue += animal * 2000;
            }

            return revenue;
        }
    }
}
