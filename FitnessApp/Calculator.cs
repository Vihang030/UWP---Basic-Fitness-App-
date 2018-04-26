using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Calculator
    {

        private double calories;
        private double protein;
        private double carbohydrate;
        private double fat;
        private double sugar;
        private double sodium;
        private double cholesterol;

        public Calculator(double weight, double height, double age)
        {
            if (height < 0 || weight < 0 || age < 0)
            {
                throw new ArgumentOutOfRangeException("If any of your height, weight, age is less than 0, You are not part of the universe according to physics!");
            }
            else
            {
                calories = (66.47 + (13.75 * weight) + (5.0 * height) - (6.75 * age)) + 400;
                protein = weight * 2.2;
                carbohydrate = weight * 2.2 * 2;
                fat = ( ((66.47 + (13.75 * weight) + (5.0 * height) - (6.75 * age)) + 400)*0.25) / 9;
                sugar = ((66.47 + (13.75 * weight) + (5.0 * height) - (6.75 * age))) / 15;
                

            }

        }

        public double Calory { get { return Math.Round(calories, 2); } }
        public double Proteins { get { return Math.Round(protein, 2); } }
        public double Carbohydrate { get { return Math.Round(carbohydrate, 2); } }
        public double Fat { get { return Math.Round(fat, 2); } }
        public double Sugar { get { return Math.Round(sugar, 2); } }
        public double Sodium { get { return Math.Round(sodium, 2); } }
        public double Cholesterol { get { return Math.Round(cholesterol, 2); } }
    }
}
