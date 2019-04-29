/* CREATED BY: Davis M. Brace  (Davis Designs of Michigan LLC)
 * STARTED ON: 04/25/2019
 * TITLE: Farmerland Business District Extension
 * 
 * DESCRIPTION:
 * Class of the FarmerLand app.  Represents a business district for buildings/businesses and 
 * associated data and methods.
 */

using System;
using System.Collections.Generic;

namespace FarmerLand
{
    [Serializable]
    class BusinessDistrict
    {
        List<int> owned = new List<int>();

        public double Buy(int selection, double cash)
        {
            if (!owned.Contains(selection))
            {
                //Calculate cost
                double cost = selection * 100000;

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

            foreach (int building in owned)
            {
                revenue += building * 200;
            }

            return revenue;
        }
    }
}