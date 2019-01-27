using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Car : Node
    {
        public int weight { get; set; }
        public int agility { get; set; }
        public int grip { get; set; }
        public string owner { get; set; }
        public string color { get; set; }
        public float step_power { get; set; }
        public float yaxis { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                   

        public static void TakeTurn(Car p1, int choice)
        {
            AddResource(p1, choice);
            p1.step_power = Calc_StepPower(p1);
        }
        public static Car CreateCar(string owner, string color)
        {
            Car obj = new Car();
            obj.owner = owner;
            obj.color = color;
            obj.weight = 1;
            obj.agility = 1;
            obj.grip = 1;
            obj.step_power = Calc_StepPower(obj);
            return obj;
        }
        public static float Calc_StepPower(Car obj)
        {

            float w = obj.weight;
            float a = obj.agility;
            float g = obj.grip;

            if (w < 4)
            {
                return a / 50 + g / 100;
            }
            else if (w > 4 && w < 10)
            {
                return g / 100;
            }
            else
            {
                return 0;
            }
        }
        public static string AddResource(Car obj, int choice)
        {
            if (choice == 1)
            {
                obj.weight = obj.weight + 1;
                return "W";
            }
            if (choice == 2)
            {
                obj.agility = obj.agility + 1;
                return "A";
            }
            if (choice == 3)
            {
                obj.grip = obj.grip + 1;
                return "G";
            }
            else
                return null;

        }



    }
}