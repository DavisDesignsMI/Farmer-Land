/* CREATED BY: Davis M. Brace  (Davis Designs of Michigan LLC)
 * STARTED ON: 04/25/2019
 * TITLE: Farmerland Field Extension
 * 
 * DESCRIPTION:
 * Class of the FarmerLand app.  Represents a field and associated data and methods.
 */

using System;

namespace FarmerLand
{
    [Serializable]
    class Field
    {
        //============================================================================================

        //Sizes
        public double sizeX;
        public double sizeY;

        //Seed Type
        public int seedType = 0;

        //Rotten bool
        public bool rotten = false;

        //Upgrade Factors 1
        public int tractor = 1;
        public int irrigation = 1;
        public int greenHouse = 1;

        //Upgrade Factors 2
        public double gardener = 1;
        public double waterer = 1;
        public double planter = 1;

        //============================================================================================

        //Constructor
        public Field(int x, int y)
        {
            //Set field size
            sizeX = x;
            sizeY = y;
        }

        //============================================================================================

        public bool GetSeedCost(int type, double cash)
        {
            double SeedCost = type * sizeX * sizeY;
            
            if (SeedCost <= cash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //============================================================================================

        //Expand method
        public double Expand(double x, double y, double cash)
        {
            //Calculate cost
            double cost = (x * y * 20) - 2000;

            //Expand successfully if cost 
            //is less than or equal to cash
            if (cost <= cash)
            {
                //Set size
                sizeX = x;
                sizeY = y;

                if (cost < 0)
                {
                    return 0;
                }
                else
                {
                    return cost;
                }
            }
            else
            {
                //do nothing
                return 0;
            }
        }

        //============================================================================================

        //Plant method
        public double Plant(int type, double cash)
        {
            //Calculate cost of seeds
            double cashMinus = type * sizeX * sizeY;

            if (cash >= cashMinus)
            {
                //Set seedtype to input type
                seedType = type;

                //Return cost if cash is not too low
                return cashMinus;
            }
            else
            {
                //Return 0 if cash is too low
                return 0;
            }
        }

        //============================================================================================

        //Harvest Method
        public double Harvest()
        {
            //Set factorTotal to the product of all applicable upgrade factors
            double factorTotal = tractor * irrigation * greenHouse * gardener * waterer * planter;

            if (seedType != 0 && !rotten)
            {
                //Store seed type in temp
                int temp = seedType;
                //Reset seedtype to empty field
                seedType = 0;
                //Reset rotten bool
                rotten = false;
                //Return cash to add
                return temp * sizeX * sizeY * factorTotal * 1.5;
            }
            else
            {
                //Return 0 cash update if no seed is
                //planted or plants are rotten (future addition)
                seedType = 0;
                //Reset rotten bool
                rotten = false;
                return 0;
            }
        }

        //============================================================================================
    }
}