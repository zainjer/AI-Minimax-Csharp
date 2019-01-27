
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Node
    {
         Node parent;
         List<Node> child = new List<Node>();
         int depth;
         Car state;
         bool isMax = true;
         String res = "";
          String eval = "";
         double step_power;

        public static Node GenerateTree(int givendepth, Car obj)
        {
            Queue<Node> q = new Queue<Node>();
            HashSet<Node> h = new HashSet<Node>();
            Node RootNode = new Node();
            RootNode.depth = 0;
            RootNode.state = obj;
            RootNode.step_power = Car.Calc_StepPower(RootNode.state);
            Node current = RootNode;
            q.Enqueue(RootNode);
            h.Add(RootNode);
            while (q.Count != 0)
            {
                current = q.Dequeue();
                if (current.depth == givendepth + 1)
                {
                    return RootNode;
                }
                else
                {
                    Console.WriteLine("Current Node: dept:{0},children count:{1} current res:{2} current step-power:{3} isMax:{4}", current.depth, current.child.Count, current.res, current.step_power, current.isMax);
                    Addchild(current);
                    foreach (Node child in current.child)
                    {
                        if (!h.Contains(child))
                        {
                            q.Enqueue(child);
                            h.Add(child);
                        }
                    }
                }
            }
            return RootNode;
        }
        public static Node Addchild(Node current)
        {
            for (int i = 1; i < 4; i++)
            {
                Node child = new Node();
                if (current.isMax)
                    child.isMax = false;
                else
                    child.isMax = true;
                current.child.Add(child);
                child.parent = current;
                child.depth = current.depth + 1;
                child.state = current.state;
                child.res = Car.AddResource(child.state, i);
                child.step_power = Car.Calc_StepPower(child.state);
                Console.WriteLine("Child added with Depth: {0} Resource:{1} step_power: {2} isMax:{3}", child.depth, child.res, child.step_power,  child.isMax);
            }
            return current;
        }
        public static String minimax(string resource,float step, Node st, int depth)
        {
            if (depth == 0)
                return s;
            if (st.isMax)
            {
                double maxEval = -1000006;
                double temp = maxEval;
                foreach (Node child in st.child)
                {      
                    maxEval = Math.Max(child.step_power, a);

                    if (temp != maxEval)
                    {
                        resource = child.res;
                        temp = a;
                    }
                }
            }
            else
            {
                double b = 1000000;
                double temp = b;
                foreach (Node child in st.child)
                {
                    b = Math.Min(child.step_power, b);
                    if (temp != b)
                    {
                        s = child.res;
                        Console.WriteLine("Abcd");                        
                        temp = b;
                    }
                }
            }
            return s;
        } 

    }
}
