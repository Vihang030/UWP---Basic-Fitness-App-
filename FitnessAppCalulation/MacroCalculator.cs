using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppCalulation
{
    public class MacroCalculator
    {
        private double calories;
        private double protein;
        private double carbohydrate;
        private double fat;
        private double sugar;
        private double sodium;
        private double fiber;
        private double cholesterol;

        public MacroCalculator(double weight, double height, double age)
        {
            if (height < 0 || weight < 0 || age < 0)
            {
                throw new ArgumentOutOfRangeException("If any of your height, weight, age is less than 0, You are not part of the universe according to physics!");
            }
            else
            {
                calories = 66.47 + (13.75*weight) +(5.0*height) -(6.75*age);
                protein = weight * 2.2;
                carbohydrate = weight * 2.2 * 2;
                
            }

        }

        public double calory { get { return Math.Round(calories, 2); } }


    }
}
