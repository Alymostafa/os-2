using System;
using System.Collections.Generic;
using System.Threading;
namespace make_2
{
    public class Program
    {
       

        static int Main()   
        {

            Class1 c1 = new Class1();
            List<List<int>> solM = VectorHelper.NestedList(4, 4, 0); //creating the solution matrix and initilize it to all 0
            int m;
            int n;
            int i;
            int j;
            
            //scanning the number of shapes 
            Console.Write("enter number of shapes\n");
            c1.numOfShapes = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            if (c1.numOfShapes < 4 || c1.numOfShapes > 5) //validation on the number of shapes to be 4 or 5
            {       
                Console.Write("wrong input");
                return 0;
            }
            Console.Write("enter dimentiions\n");
            m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            int value;
            Console.Write("enter values\n");
            for (i = 0; i < m; i++)
            {
                List<int> row = new List<int>();
                for (j = 0; j < n; j++) // scanning the values
                {
                    value = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    row.Add(value); // pushing in the vector rows
                }
                c1.shape1.Add(row); // pushing the complete row
            }
            /////////////////// same applies for the rest of dimentions
            Console.Write("enter dimentiions\n");
            m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            Console.Write("enter values\n");
            for (i = 0; i < m; i++)
            {
                List<int> row = new List<int>();
                for (j = 0; j < n; j++)
                {
                    value = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    if (value == 1)
                    {
                        value = 2;
                    }
                    row.Add(value);
                }
                c1.shape2.Add(row);
            }
            Console.Write("enter dimentiions\n");
            m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            Console.Write("enter values\n");
            for (i = 0; i < m; i++)
            {
                List<int> row = new List<int>();
                for (j = 0; j < n; j++)
                {
                    value = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    if (value == 1)
                    {
                        value = 3;
                    }
                    row.Add(value);
                }
                c1.shape3.Add(row);
            }
            Console.Write("enter dimentiions\n");
            m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            Console.Write("enter values\n");
            for (i = 0; i < m; i++)
            {
                List<int> row = new List<int>();
                for (j = 0; j < n; j++)
                {
                    value = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    if (value == 1)
                    {
                        value = 4;
                    }
                    row.Add(value);
                }
                c1.shape4.Add(row);
            }
            if (c1.numOfShapes == 5)
            {
                Console.Write("enter dimentiions\n");
                m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                Console.Write("enter values\n");
                for (i = 0; i < m; i++)
                {
                    List<int> row = new List<int>();
                    for (j = 0; j < n; j++)
                    {
                        value = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                        if (value == 1)
                        {
                            value = 5;
                        }
                        row.Add(value);
                    }
                    c1.shape5.Add(row);
                }
            }
            Console.WriteLine("before enter 1");
            //shape without rotation or flipping
            c1.solve1(new List<List<int>>(solM), new List<List<int>>(c1.shape1));

            //Thread t1 = new Thread(() => c1.solve1(new List<List<int>>(solM), new List<List<int>>(c1.shape1)));
            //t1.Start();
            Console.WriteLine("after enter 1");

            //shape without rotation with flipping H
            List<List<int>> fliph = c1.flipH(new List<List<int>>(c1.shape1));
            Console.WriteLine("before enter 3");
            c1.solve1(new List<List<int>>(solM), new List<List<int>>(fliph));
            //Thread t2 = new Thread(() => c1.solve1(new List<List<int>>(solM), new List<List<int>>(fliph)));
            //t2.Start();
            Console.WriteLine("after enter 3");



            //shape without rotation with flipping V
            List<List<int>> flipv = c1.flipV(new List<List<int>>(c1.shape1));
            //solve1(solM, flipv);

            //shape without rotation with flipping V and flipping H
            List<List<int>> flipvh = c1.flipH(new List<List<int>>(flipv));
            //solve1(solM, flipvh);

            /////////////////////////////////////////

            //shape rotated 90d without flipping
            List<List<int>> rotated = c1.rotateVector(new List<List<int>>(c1.shape1), c1.shape1.Count, c1.shape1[0].Count);
            c1.solve1(new List<List<int>>(solM), new List<List<int>>(rotated));
            //Thread t3 = new Thread(() => c1.solve1(new List<List<int>>(solM), new List<List<int>>(rotated)));
            //t3.Start();

            //shape rotated 90d with flipping H
            List<List<int>> rfliph = c1.flipH(new List<List<int>>(rotated));
            c1.solve1(new List<List<int>>(solM), new List<List<int>>(rfliph));
            //Thread t4 = new Thread(() => c1.solve1(new List<List<int>>(solM), new List<List<int>>(rfliph)));
            //t4.Start();

            //shape rotated 90d with flipping V
            List<List<int>> rflipv = c1.flipV(new List<List<int>>(rotated));
            //solve1(solM, rflipv);

            //shape rotated 90d with flipping V and flipping H
            List<List<int>> rflipvh = c1.flipH(new List<List<int>>(rflipv));
            //solve1(solM, rflipvh);

            //////////////////////////////////////////

            /*//shape rotated 180d without flipping
            vector<vector<int> > rotated1 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve1(solM, rotated1);
            //shape rotated 180d with flipping H
            vector<vector<int> > r180fliph = flipH(rotated1);
            //solve1(solM, r180fliph);
            //shape rotated 180d with flipping V
            vector<vector<int> >r180flipv = flipV(rotated1);
            //solve1(solM, r180flipv);
            //shape rotated 180d with flipping V and flipping H
            vector<vector<int> >r180flipvh = flipH(r180flipv);
            //solve1(solM, r180flipvh);

            ///////////////////////////////////////////////
            //shape rotated 270d without flipping
            vector<vector<int> >rotated2 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve1(solM, rotated2);
            //shape rotated 270d with flipping H
            vector<vector<int> > r270fliph = flipH(rotated2);
            //solve1(solM, r270fliph);
            //shape rotated 270 with flipping V
            vector<vector<int> >r270flipv = flipV(rotated2);
            //solve1(solM, r270flipv);
            //shape rotated 270d with flipping V and flipping H
            vector<vector<int> > r270flipvh = flipH(r270flipv);
            //solve1(solM, r270flipvh);
            */
           
            int k;
            for (i = 0; i < c1.solutionMatrcies.Count; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    for (k = 0; k < 4; k++)
                    {
                        Console.Write(c1.solutionMatrcies[i][j][k]);
                        Console.Write(" ");
                    }
                    Console.Write("\n");
                }
            }

            return 0;
        }
        internal class VectorHelper
        {


            public static List<T> InitializedList<T>(int size, T value)
            {
                List<T> temp = new List<T>();
                for (int count = 1; count <= size; count++)
                {
                    temp.Add(value);
                }

                return temp;
            }


            public static List<List<T>> NestedList<T>(int outerSize, int innerSize)
            {
                List<List<T>> temp = new List<List<T>>();
                for (int count = 1; count <= outerSize; count++)
                {
                    temp.Add(new List<T>(innerSize));
                }

                return temp;
            }

            public static List<List<T>> NestedList<T>(int outerSize, int innerSize, T value)
            {
                List<List<T>> temp = new List<List<T>>();
                for (int count = 1; count <= outerSize; count++)
                {
                    temp.Add(InitializedList(innerSize, value));
                }

                return temp;
            }
        }
        internal static class ConsoleInput
        {
            public static bool goodLastRead = false;
            public static bool LastReadWasGood
            {
                get
                {
                    return goodLastRead;
                }
            }

            public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
            {
                string input = "";

                char nextChar;
                while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                {
                    //accumulate leading white space if skipLeadingWhiteSpace is false:
                    if (!skipLeadingWhiteSpace)
                        input += nextChar;
                }
                //the first non white space character:
                input += nextChar;

                //accumulate characters until white space is reached:
                while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                {
                    input += nextChar;
                }

                goodLastRead = input.Length > 0;
                return input;
            }

            public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
            {
                string input = "";

                char nextChar;
                if (unwantedSequence != null)
                {
                    nextChar = '\0';
                    for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
                    {
                        if (char.IsWhiteSpace(unwantedSequence[charIndex]))
                        {
                            //ignore all subsequent white space:
                            while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                            {
                            }
                        }
                        else
                        {
                            //ensure each character matches the expected character in the sequence:
                            nextChar = (char)System.Console.Read();
                            if (nextChar != unwantedSequence[charIndex])
                                return null;
                        }
                    }

                    input = nextChar.ToString();
                    if (maxFieldLength == 1)
                        return input;
                }

                while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                {
                    input += nextChar;
                    if (maxFieldLength == input.Length)
                        return input;
                }

                return input;
            }
        }




    }
}
