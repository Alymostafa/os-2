using System;
using System.Collections.Generic;
using System.Text;


namespace make_2
{
    class Class1
    {
        public List<List<int>> shape1 = new List<List<int>>(); //declaring the first shape as a vector of vectors of int
        public List<List<int>> shape2 = new List<List<int>>(); //declaring the first shape as a vector of vectors of int
        public List<List<int>> shape3 = new List<List<int>>(); //declaring the first shape as a vector of vectors of int
        public List<List<int>> shape4 = new List<List<int>>(); //declaring the first shape as a vector of vectors of int
        public List<List<int>> shape5 = new List<List<int>>(); //declaring the first shape as a vector of vectors of int
        public int numOfShapes;
        public List<List<List<int>>> solutionMatrcies = new List<List<List<int>>>();

        public List<List<int>> rotateVector(List<List<int>> input, int n, int m)
        {
            List<List<int>> output = VectorHelper.NestedList(m, n, 0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    output[j][n - 1 - i] = input[i][j];
                }
            }
            return output;
        }

        public List<List<int>> flipV(List<List<int>> input)
        {
            return input;
        }
        public List<List<int>> flipH(List<List<int>> input)
        {
            int q;
            int j;
            if (input.Count % 2 == 0)
            {
                List<List<int>> garen = new List<List<int>>();
                for (int i = 0; i < (input.Count / 2); i++)
                {
                    garen.Add(input[i]);
                }
                for (q = (input.Count) / 2, j = (input.Count / 2) - 1; q < input.Count && j >= 0; q++)
                {
                    input[j] = input[q];
                    input[q] = garen[j];
                    j--;
                }
                return input;
            }
            else
            {
                int middle = (input.Count) / 2;
                List<List<int>> garen = new List<List<int>>();
                for (int i = 0; i < middle; i++)
                {
                    garen.Add(input[i]);
                }
                for (q = middle + 1, j = middle - 1; q < input.Count && j >= 0; q++)
                {
                    input[j] = input[q];
                    j--;
                }
                for (q = 0, j = (input.Count) - 1; q < garen.Count && j > middle; q++)
                {
                    input[j] = garen[q];
                    j--;
                }
                return input;
            }
        }

        //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
        public int removeOverlapping_flag = 0;
        public void removeOverlapping(List<List<int>> solM)
        {

            //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
            //	static int flag = 0;
            if (removeOverlapping_flag == 0)
            {
                removeOverlapping_flag++;
                solutionMatrcies.Add(solM);
                return;
            }
            else
            {
                if (solutionMatrcies.Contains(solM))
                {
                    return;
                }
                else
                {
                    solutionMatrcies.Add(solM);
                }
            }
        }
        public bool findMatch(List<List<int>> subMatrix, List<List<int>> shape, int tempi, int tempj, int i, int j)
        {
            bool garen = true;
            int q;
            int s;
            q = i;
            for (int k = 0; k < shape.Count && q < tempi; k++)
            {
                s = j;
                for (int p = 0; p < shape[0].Count && s < tempj; p++)
                {
                    //start checking if thhere is a value in the solution submatrix equal to 1 and a value in the shape equal to 1 then it won't fit in this
                    //partition and return false
                    if (shape[k][p] >= 1 && subMatrix[q][s] == 1)
                    {
                        garen = false;
                        break;
                    }
                    s++;
                }
                q++;
            }
            return garen;
        }

        public void solve1(List<List<int>> solM, List<List<int>> shape)
        {
            int i;
            int j;
            int tempi;
            int tempj;
            bool flag = false; //declaring a boolean value to return
            Console.WriteLine("before enter for loop solve 1");
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    //partitioning with the 4 possible possiblities
                    if (shape.Count == 4 && shape[0].Count == 4)
                    {
                        tempi = shape.Count - 1;
                        tempj = shape[0].Count - 1;
                    }
                    else if (shape.Count == 4)
                    {
                        if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[i].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (shape[0].Count == 4)
                    {
                        if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((i + shape.Count) <= 4 && (j + shape[0].Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (findMatch(solM, shape, tempi, tempj, i, j))
                    {
                        fit1(solM, shape, tempi, tempj, i, j);
                    }
                }

            }
        }

        public void solve2(List<List<int>> solM, List<List<int>> shape)
        {
            int i;
            int j;
            int tempi;
            int tempj;
            bool flag = false; //declaring a boolean value to return
            Console.WriteLine("before enter for loop solve 2");

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    //partitioning with the 4 possible possiblities
                    if (shape.Count == 4 && shape[0].Count == 4)
                    {
                        tempi = shape.Count - 1;
                        tempj = shape[0].Count - 1;
                    }
                    else if (shape.Count == 4)
                    {
                        if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[i].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (shape[0].Count == 4)
                    {
                        if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((i + shape.Count) <= 4 && (j + shape[0].Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (findMatch(solM, shape, tempi, tempj, i, j))
                    {
                        fit2(solM, shape, tempi, tempj, i, j);
                    }
                }
            }
        }
        public void solve3(List<List<int>> solM, List<List<int>> shape)
        {

            int i;
            int j;
            int tempi;
            int tempj;
            bool flag = false; //declaring a boolean value to return
            Console.WriteLine("before for loop solve 2");

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    //partitioning with the 4 possible possiblities
                    if (shape.Count == 4 && shape[0].Count == 4)
                    {
                        tempi = shape.Count - 1;
                        tempj = shape[0].Count - 1;
                    }
                    else if (shape.Count == 4)
                    {
                        if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[i].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (shape[0].Count == 4)
                    {
                        if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((i + shape.Count) <= 4 && (j + shape[0].Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (findMatch (solM, shape, tempi, tempj, i, j))
                    {
                        fit3(solM, shape, tempi, tempj, i, j);
                    }
                }
            }
        }
        public void solve4(List<List<int>> solM, List<List<int>> shape)
        {
            int i;
            int j;
            int tempi;
            int tempj;
            bool flag = false; //declaring a boolean value to return
            Console.WriteLine("before for loop solve 4");
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    //partitioning with the 4 possible possiblities
                    if (shape.Count == 4 && shape[0].Count == 4)
                    {
                        tempi = shape.Count - 1;
                        tempj = shape[0].Count - 1;
                    }
                    else if (shape.Count == 4)
                    {
                        if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[i].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (shape[0].Count == 4)
                    {
                        if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((i + shape.Count) <= 4 && (j + shape[0].Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (findMatch(solM, shape, tempi, tempj, i, j))
                    {
                        Console.WriteLine("before if fit 4");
                        fit4(solM, shape, tempi, tempj, i, j);
                    }
                }
            }
        }
        public void solve5(List<List<int>> solM, List<List<int>> shape)
        {

            int i;
            int j;
            int tempi;
            int tempj;
            bool flag = false; //declaring a boolean value to return
            Console.WriteLine("after for loop solve 5");

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    //partitioning with the 4 possible possiblities
                    if (shape.Count == 4 && shape[0].Count == 4)
                    {
                        tempi = shape.Count - 1;
                        tempj = shape[0].Count - 1;
                    }
                    else if (shape.Count == 4)
                    {
                        if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[i].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (shape[0].Count == 4)
                    {
                        if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((i + shape.Count) <= 4 && (j + shape[0].Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((j + shape[0].Count) <= 4)
                        {
                            tempi = shape.Count;
                            tempj = j + shape[0].Count;
                        }
                        else if ((i + shape.Count) <= 4)
                        {
                            tempi = i + shape.Count;
                            tempj = shape[0].Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (findMatch(solM, shape, tempi, tempj, i, j))
                    {
                        fit5(solM, shape, tempi, tempj, i, j);
                    }
                }

            }
        }



    private void swapElement(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    private List<List<int>> swapColumn(List<List<int>> arr, int col, int rows)
    {
        int colMirror = arr[0].Count - col - 1;
        for (int row = 0; row < rows; row++)
        {
            swapElement(ref(arr[row][col]), ref(arr[row][colMirror]));
        }
        return arr;
    }
    private List<List<int>> flipVertical(List<List<int>>arr, int cols, int rows)
    {
        int axis = cols / 2;
        for (int col = 0; col < axis; col++)
        {
            arr = swapColumn(arr, col, rows);
        }
        return arr;
    }


    public void fit1(List<List<int>> solM, List<List<int>> shape, int tempi, int tempj, int i, int j)
        {

            int q;
            int s;
            q = i;
            Console.WriteLine("before enter for loop fit 1");
            for (int k = 0; k < shape.Count && q < tempi; k++)
            {
                s = j;
                for (int p = 0; p < shape[0].Count && s < tempj; p++)
                {
                    if (shape[k][p] >= 1 && solM[q][s] == 0)
                    {
                        solM[q][s] = shape[k][p];
                    }
                    s++;
                }
                q++;
            }
            //shape without rotation or flipping
            solve2(solM, shape2);

            //shape without rotation with flipping H
            List<List<int>> fliph = new List<List<int>>();
            fliph = flipH(shape2);
            solve2(solM, fliph);

            //shape without rotation with flipping V
            List<List<int>> flipv = new List<List<int>>();
            flipv = flipVertical(shape2, shape2[0].Count, shape2.Count);
            //solve2(solM, flipv);
            
            //shape without rotation with flipping V and flipping H
            List<List<int>> flipvh = flipH(flipv    );
            //solve2(solM, flipvh);

            /////////////////////////////////////////

            //shape rotated 90d without flipping
            List<List<int>> rotated = new List<List<int>>();
            rotated = rotateVector(shape2, shape2.Count, shape2[0].Count);
            solve2(solM, rotated);

            //shape rotated 90d with flipping H
            List<List<int>> rfliph = new List<List<int>>();
            rfliph = flipH(rotated);
            solve2(solM, rfliph);

            //shape rotated 90d with flipping V
            List<List<int>> rflipv = new List<List<int>>();
            rflipv = flipVertical(rotated, rotated[0].Count, rotated.Count);
            //solve2(solM, rflipv);

            //shape rotated 90d with flipping V and flipping H
            List<List<int>> rflipvh = new List<List<int>>();
            rflipvh = flipH(rflipv);
            //solve2(solM, rflipvh);

            //////////////////////////////////////////

            /*//shape rotated 180d without flipping
            vector<vector<int> > rotated1 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve2(solM, rotated1);
            //shape rotated 180d with flipping H
            vector<vector<int> > r180fliph = flipH(rotated1);
            //solve2(solM, r180fliph);
            //shape rotated 180d with flipping V
            vector<vector<int> >r180flipv = flipV(rotated1);
            //solve2(solM, r180flipv);
            //shape rotated 180d with flipping V and flipping H
            vector<vector<int> >r180flipvh = flipH(r180flipv);
            //solve2(solM, r180flipvh);
            ///////////////////////////////////////////////
            //shape rotated 270d without flipping
            vector<vector<int> >rotated2 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve2(solM, rotated2);
            //shape rotated 270d with flipping H
            vector<vector<int> > r270fliph = flipH(rotated2);
            //solve4(solM, r270fliph);
            //shape rotated 270 with flipping V
            vector<vector<int> >r270flipv = flipV(rotated2);
            //solve4(solM, r270flipv);
            //shape rotated 270d with flipping V and flipping H
            vector<vector<int> > r270flipvh = flipH(r270flipv);
            //solve4(solM, r270flipvh);
            */
        }

        public void fit2(List<List<int>> solM, List<List<int>> shape, int tempi, int tempj, int i, int j)
        {

            int q;
            int s;
            q = i;
            for (int k = 0; k < shape.Count && q < tempi; k++)
            {
                s = j;
                for (int p = 0; p < shape[0].Count && s < tempj; p++)
                {
                    if (shape[k][p] >= 1 && solM[q][s] == 0)
                    {
                        solM[q][s] = shape[k][p];
                    }
                    s++;
                }
                q++;
            }
            //shape without rotation or flipping
            solve3(solM, shape3);

            //shape without rotation with flipping H
            List<List<int>> fliph = new List<List<int>>();
            fliph = flipH(shape3);
            solve3(solM, fliph);

            //shape without rotation with flipping V
            List<List<int>> flipv = new List<List<int>>();
            flipv = flipVertical(shape3, shape3[0].Count, shape3.Count);
            //solve3(solM, flipv);

            //shape without rotation with flipping V and flipping H
            List<List<int>> flipvh = flipH(flipv);
            //solve3(solM, flipvh);

            /////////////////////////////////////////

            //shape rotated 90d without flipping
            List<List<int>> rotated = new List<List<int>>();
            rotated = rotateVector(shape3, shape3.Count, shape3[0].Count);
            solve3(solM, rotated);

            //shape rotated 90d with flipping H
            List<List<int>> rfliph = new List<List<int>>();
            rfliph = flipH(rotated);
            solve3(solM, rfliph);

            //shape rotated 90d with flipping V
            List<List<int>> rflipv = new List<List<int>>();
            rflipv = flipVertical(rotated, rotated[0].Count, rotated.Count);
            //solve3(solM, rflipv);

            //shape rotated 90d with flipping V and flipping H
            List<List<int>> rflipvh = new List<List<int>>();
            rflipvh = flipH(rflipv);
            //solve3(solM, rflipvh);
            //////////////////////////////////////////

            /*/
            shape rotated 180d without flipping
            vector<vector<int> > rotated1 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve3(solM, rotated1);
            //shape rotated 180d with flipping H
            vector<vector<int> > r180fliph = flipH(rotated1);
            //solve3(solM, r180fliph);
            //shape rotated 180d with flipping V
            vector<vector<int> >r180flipv = flipV(rotated1);
            //solve3(solM, r180flipv);
            //shape rotated 180d with flipping V and flipping H
            vector<vector<int> >r180flipvh = flipH(r180flipv);
            //solve3(solM, r180flipvh);
            ///////////////////////////////////////////////
            //shape rotated 270d without flipping
            vector<vector<int> >rotated2 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve3(solM, rotated2);
            //shape rotated 270d with flipping H
            vector<vector<int> > r270fliph = flipH(rotated2);
            //solve3(solM, r270fliph);
            //shape rotated 270 with flipping V
            vector<vector<int> >r270flipv = flipV(rotated2);
            //solve3(solM, r270flipv);
            //shape rotated 270d with flipping V and flipping H
            vector<vector<int> > r270flipvh = flipH(r270flipv);
            //solve3(solM, r270flipvh);*/
        }

        public void fit3(List<List<int>> solM, List<List<int>> shape, int tempi, int tempj, int i, int j)
        {


            int q;
            int s;
            q = i;
            for (int k = 0; k < shape.Count && q < tempi; k++)
            {
                s = j;
                for (int p = 0; p < shape[0].Count && s < tempj; p++)
                {
                    if (shape[k][p] >= 1 && solM[q][s] == 0)
                    {
                        solM[q][s] = shape[k][p];
                    }
                    s++;
                }
                q++;
            }
            //shape without rotation or flipping
            //shape without rotation or flipping
            solve4(solM, shape4);

            //shape without rotation with flipping H
            List<List<int>> fliph = new List<List<int>>();
            fliph = flipH(shape4);
            solve4(solM, fliph);

            //shape without rotation with flipping V
            List<List<int>> flipv = new List<List<int>>();
            flipv = flipVertical(shape4, shape4[0].Count, shape4.Count);
            //solve4(solM, flipv);

            //shape without rotation with flipping V and flipping H
            List<List<int>> flipvh = flipH(flipv);
            //solve4(solM, flipvh);

            /////////////////////////////////////////

            //shape rotated 90d without flipping
            List<List<int>> rotated = new List<List<int>>();
            rotated = rotateVector(shape4, shape4.Count, shape4[0].Count);
            solve4(solM, rotated);

            //shape rotated 90d with flipping H
            List<List<int>> rfliph = new List<List<int>>();
            rfliph = flipH(rotated);
            solve4(solM, rfliph);

            //shape rotated 90d with flipping V
            List<List<int>> rflipv = new List<List<int>>();
            rflipv = flipVertical(rotated, rotated[0].Count, rotated.Count);
            //solve4(solM, rflipv);

            //shape rotated 90d with flipping V and flipping H
            List<List<int>> rflipvh = new List<List<int>>();
            rflipvh = flipH(rflipv);
            //solve4(solM, rflipvh);

            /*/////////////////////////////////////////
            //shape rotated 180d without flipping
            vector<vector<int> > rotated1 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve4(solM, rotated1);
            //shape rotated 180d with flipping H
            vector<vector<int> > r180fliph = flipH(rotated1);
            //solve4(solM, r180fliph);
            //shape rotated 180d with flipping V
            vector<vector<int> >r180flipv = flipV(rotated1);
            //solve4(solM, r180flipv);
            //shape rotated 180d with flipping V and flipping H
            vector<vector<int> >r180flipvh = flipH(r180flipv);
            //solve4(solM, r180flipvh);
            ///////////////////////////////////////////////
            //shape rotated 270d without flipping
            vector<vector<int> >rotated2 = rotateVector(rotated, rotated.size(), rotated[0].size());
            solve4(solM, rotated2);
            //shape rotated 270d with flipping H
            vector<vector<int> > r270fliph = flipH(rotated2);
            //solve4(solM, r270fliph);
            //shape rotated 270 with flipping V
            vector<vector<int> >r270flipv = flipV(rotated2);
            //solve4(solM, r270flipv);
            //shape rotated 270d with flipping V and flipping H
            vector<vector<int> > r270flipvh = flipH(r270flipv);
            //solve4(solM, r270flipvh);*/
        }

        public void fit4(List<List<int>> solM, List<List<int>> shape, int tempi, int tempj, int i, int j)
        {

            
            int q;
            int s;
            q = i;
            Console.WriteLine("before for loop fit 4");
            for (int k = 0; k < shape.Count && q < tempi; k++)
            {
                s = j;
                for (int p = 0; p < shape[0].Count && s < tempj; p++)
                {
                    if (shape[k][p] >= 1 && solM[q][s] == 0)
                    {
                        solM[q][s] = shape[k][p];
                    }
                    s++;
                }
                q++;
            }

            if (numOfShapes == 4)
            {
                bool flag = true;
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        if (solM[i][j] == 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                Console.WriteLine("after for loop fit 4");

                if (flag)
                {
                    removeOverlapping(new List<List<int>>(solM));
                }
            }
            else if (numOfShapes == 5)
            {
                //shape without rotation or flipping
                solve5(new List<List<int>>(solM), new List<List<int>>(shape5));

                //shape without rotation with flipping H
                List<List<int>> fliph = flipH(new List<List<int>>(shape5));
                solve5(new List<List<int>>(solM), new List<List<int>>(fliph));

                //shape without rotation with flipping V
                List<List<int>> flipv = flipV(new List<List<int>>(shape5));
                //solve5(solM, flipv);

                //shape without rotation with flipping V and flipping H
                List<List<int>> flipvh = flipH(new List<List<int>>(flipv));
                //solve5(solM, flipvh);

                /////////////////////////////////////////

                //shape rotated 90d without flipping
                List<List<int>> rotated = rotateVector(new List<List<int>>(shape5), shape5.Count, shape5[0].Count);
                solve5(new List<List<int>>(solM), new List<List<int>>(rotated));

                //shape rotated 90d with flipping H
                List<List<int>> rfliph = flipH(new List<List<int>>(rotated));
                solve5(new List<List<int>>(solM), new List<List<int>>(rfliph));

                //shape rotated 90d with flipping V
                List<List<int>> rflipv = flipV(new List<List<int>>(rotated));
                //solve5(solM, rflipv);

                //shape rotated 90d with flipping V and flipping H
                List<List<int>> rflipvh = flipH(new List<List<int>>(rflipv));
                //solve5(solM, rflipvh);

                /*/////////////////////////////////////////
                //shape rotated 180d without flipping
                vector<vector<int> > rotated1 = rotateVector(rotated, rotated.size(), rotated[0].size());
                solve5(solM, rotated1);
                //shape rotated 180d with flipping H
                vector<vector<int> > r180fliph = flipH(rotated1);
                solve5(solM, r180fliph);
                //shape rotated 180d with flipping V
                vector<vector<int> >r180flipv = flipV(rotated1);
                solve5(solM, r180flipv);
                //shape rotated 180d with flipping V and flipping H
                vector<vector<int> >r180flipvh = flipH(r180flipv);
                solve5(solM, r180flipvh);
                ///////////////////////////////////////////////
                //shape rotated 270d without flipping
                vector<vector<int> >rotated2 = rotateVector(rotated, rotated.size(), rotated[0].size());
                solve5(solM, rotated2);
                //shape rotated 270d with flipping H
                vector<vector<int> > r270fliph = flipH(rotated2);
                solve5(solM, r270fliph);
                //shape rotated 270 with flipping V
                vector<vector<int> >r270flipv = flipV(rotated2);
                solve5(solM, r270flipv);
                //shape rotated 270d with flipping V and flipping H
                vector<vector<int> > r270flipvh = flipH(r270flipv);
                solve5(solM, r270flipvh);*/
            }
        }

        public void fit5(List<List<int>> solM, List<List<int>> shape, int tempi, int tempj, int i, int j)
        {


            int q;
            int s;
            q = i;
            for (int k = 0; k < shape.Count && q < tempi; k++)
            {
                s = j;
                for (int p = 0; p < shape[0].Count && s < tempj; p++)
                {
                    if (shape[k][p] >= 1 && solM[q][s] == 0)
                    {
                        solM[q][s] = shape[k][p];
                    }
                    s++;
                }
                q++;
            }

            bool flag = true;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (solM[i][j] == 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                removeOverlapping(new List<List<int>>(solM));
            }
        }

        //----------------------------------------------------------------------------------------
        //	Copyright © 2006 - 2018 Tangible Software Solutions, Inc.
        //	This class can be used by anyone provided that the copyright notice remains intact.
        //
        //	This class is used to convert some of the C++ std::vector methods to C#.
        //----------------------------------------------------------------------------------------


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

        public static void Resize<T>(List<T> list, int newSize, T value = default(T))
        {
            if (list.Count > newSize)
                list.RemoveRange(newSize, list.Count - newSize);
            else if (list.Count < newSize)
            {
                for (int i = list.Count; i < newSize; i++)
                {
                    list.Add(value);
                }
            }
        }

        public void Swap<T>(List<T> list1, List<T> list2)
        {
            List<T> temp = new List<T>(list1);
            list1.Clear();
            list1.AddRange(list2);
            list2.Clear();
            list2.AddRange(temp);
        }

        //----------------------------------------------------------------------------------------
        //	Copyright © 2006 - 2018 Tangible Software Solutions, Inc.
        //	This class can be used by anyone provided that the copyright notice remains intact.
        //
        //	This class provides the ability to convert basic C++ 'cin' and C 'scanf' behavior.
        //----------------------------------------------------------------------------------------
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
