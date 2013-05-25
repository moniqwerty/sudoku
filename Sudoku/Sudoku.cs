using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{

        public enum GameLevel
        {
            SIMPLE,
            MEDIUM,
            COMPLEX

        }
        //Game Combinations to generate game.

        enum GameCombinations
        {
            SWAP_ROWS,
            SWAP_COLS,
            SWAP_SETS,
            REVERSE_ROW_OR_COL
        };
        /*
         * Main class of the concept of sudoku game. First, we generate the solution.
         * Then we mask some of the position based on the chosen complexity.
         * We generate the solution from one unique solution by randomly using some game
         * combination. There are thousands of combinations possible.
       */
        [Serializable]
        public class Sudoku
        {

            //Constructor

            public Sudoku()
            {
                int[,] eden = {{4,1,9,8,6,3,2,5,7},
									 {7,8,5,2,4,9,3,1,6},
									 {6,2,3,5,1,7,4,8,9},
									 {8,5,4,3,2,6,7,9,1},
									 {3,7,2,9,5,1,8,6,4},
									 {1,9,6,7,8,4,5,3,2},
									 {9,6,7,4,3,5,1,2,8},
									 {5,4,8,1,9,2,6,7,3},
									 {2,3,1,6,7,8,9,4,5}
									};
                int [,] dva = {{9,6,4,2,8,7,1,5,3},
                                       {2,7,3,5,6,1,8,6,4},
                                       {1,5,8,6,4,3,2,9,7},
                                       {4,2,5,8,1,9,3,7,6},
                                       {6,8,7,3,5,4,9,2,1},
                                       {3,9,1,7,2,6,5,4,8},
                                       {8,3,9,4,6,2,7,1,5},
                                       {7,4,2,1,3,5,6,8,9},
                                       {5,1,6,9,7,8,4,3,2}};
                int[,] tri = {{7,9,2,3,5,1,8,4,6},
                                      {4,6,8,9,2,7,5,1,3},
                                      {1,3,5,6,8,4,7,9,2},
                                      {6,2,1,5,7,9,4,3,8},
                                      {5,8,3,2,4,6,1,7,9},
                                      {9,7,4,8,1,3,2,6,5},
                                      {8,1,6,4,9,2,3,5,7},
                                      {3,5,7,1,6,8,9,2,4},
                                      {2,4,9,7,3,5,6,8,1}
                                     };
                Random r = new Random();
                int rand = r.Next(1, 4);
                switch (rand)
                {
                    case 1:
                        _originalSet = eden;
                        break;
                    case 2:
                        _originalSet = dva;
                        break;
                    default:
                        _originalSet = tri;
                        break;
                }
                // RESENIE
                _numberSet = new int[MAX_ROWS, MAX_COLS];
                // PROBLEM
                _problemSet = new int[MAX_ROWS, MAX_COLS];
              /*  // copy of problem set to validates that answer positions are not changed

                _problemSetCopy = new int[MAX_ROWS, MAX_COLS]; MOZE DA NE MI TREBA*/
            }


            /// Method:GenerateGame
            /// Purpose:Generates game based on complexity level.
            
            public void GenerateGame(GameLevel level)
            {

                // InitialiseSet
                // This first creates answer set by using Game combinations
                InitialiseSet();
                int minPos, maxPos, noOfSets;

                // Now unmask positions and create problem set.
                switch (level)
                {

                    case GameLevel.SIMPLE:
                        minPos = 4;
                        maxPos = 6;
                        noOfSets = 8;
                        UnMask(minPos, maxPos, noOfSets);
                        break;
                    case GameLevel.MEDIUM:
                        minPos = 3;
                        maxPos = 5;
                        noOfSets = 7;
                        UnMask(minPos, maxPos, noOfSets);
                        break;
                    case GameLevel.COMPLEX:
                        minPos = 3;
                        maxPos = 5;
                        noOfSets = 6;
                        UnMask(minPos, maxPos, noOfSets);
                        break;
                    default:
                        UnMask(3, 6, 7);
                        break;
                }
               /* // Make copy of Problem Set
                for (int i = 0; i < MAX_ROWS; i++)
                {
                    for (int j = 0; j < MAX_COLS; j++)
                    {

                        _problemSetCopy[i, j] = _problemSet[i, j];
                    }
                }*/

            }
 
            /// Method:UnMask
            /// Purpose:UnMasks set positions randomly based on complexity.
 
            private void UnMask(int minPos, int maxPos, int noOfSets)
            {
                int seed;
                int[] posX = { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
                int[] posY = { 0, 1, 2, 0, 1, 2, 0, 1, 2 };
                int[] maskedSet = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                Random number;
                int setCount = 0;
                while (setCount < noOfSets)
                {

                    seed = DateTime.Now.Millisecond;
                    number = new Random(seed);
                    int i = number.Next(0, 9);

                    if (maskedSet[i] == 0)
                    {
                        maskedSet[i] = 1;
                        setCount++;
                        // Mask each set

                        seed = DateTime.Now.Millisecond;
                        number = new Random(seed);
                        int maskPos = number.Next(minPos, maxPos);
                        int j = 0;
                        while (j < maskPos)
                        {
                            seed = DateTime.Now.Millisecond;
                            number = new Random(seed);
                            int newPos = number.Next(1, 9);
                            int x = _setRowPosition[i] + posX[newPos];
                            int y = _setColPosition[i] + posY[newPos];
                            if (_problemSet[x, y] == 0)
                            {
                                _problemSet[x, y] = _numberSet[x, y];
                                j++;
                            }

                        }
                    }
                } 
            }

            //Method:CheckForDuplicate


            public bool CheckForDuplicate(int rowPos, int colPos, int currentValue)
            {
                // check rows
                for (int i = 0; i < MAX_ROWS; i++)
                {

                    if (_problemSet[i, colPos] == currentValue)
                    {
                        if (i != rowPos)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    if (_problemSet[rowPos, i] == currentValue)
                    {
                        if (i != colPos)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                }

                // Check in Mini Set
                int x = rowPos / 3;
                int y = colPos / 3;
                for (int j = 0; j < MINI_SET_ROWS; j++)
                {
                    for (int k = 0; k < MINI_SET_COLS; k++)
                    {
                        int p = x * 3 + j;
                        int q = y * 3 + k;

                        if ((p == rowPos) && (q == colPos))
                        {
                            continue;
                        }
                        else if (_problemSet[p, q] == currentValue)
                        {
                            return true;
                        }

                    }

                }

                return false;

            }
            /*moze drugachje
            public bool CheckIfAnswerPosition(int rowPos, int colPos, int dataValue)
            {


                if (_problemSetCopy[rowPos, colPos] != 0)
                    return true;
                else
                    return false;

            }*/

            //Method:CheckForAnswerChange del od otstranuvanje na problemSetCopy
 
            /*public bool CheckForAnswerChange(int rowPos, int colPos, int currentValue)
            {
                if (_problemSetCopy[rowPos, colPos] != 0)
                {
                    if (_problemSetCopy[rowPos, colPos] != currentValue)
                    {
                        return true;
                    }
                }
                return false;

            }*/
     
            //Method:InitialiseSet
            //Purpose:Creates Answer Set
            private void InitialiseSet()
            {
                int seed = DateTime.Now.Millisecond % 3;


                for (int i = 0; i < MAX_ROWS; i++)
                {
                    for (int j = 0; j < MAX_COLS; j++)
                    {

                        _numberSet[i, j] = _originalSet[i, j];
                        _problemSet[i, j] = 0;
                       // _problemSetCopy[i, j] = 0; nezz?
                    }
                }
               /* Random na = new Random(seed);
                int gr = na.Next(1, 10);
                for (int br = 0; br <= 3; br++)
                {*/
                    Random number = new Random(seed);
                    int roworcolPos = number.Next(1, 3);
                    seed = DateTime.Now.Millisecond % 3;
                    number = new Random(seed);
                    int setNumber = number.Next(1, 3);
                
                    if (seed==2)//(_swapRows)
                    {
                        // swapRows
                        SwapData(setNumber, roworcolPos, GameCombinations.SWAP_ROWS);
                        _swapRows = false;
                    }
                    else
                    {
                        // swapCols
                        SwapData(setNumber, roworcolPos, GameCombinations.SWAP_COLS);
                        _swapRows = true;
                    }

                    seed = DateTime.Now.Millisecond % 3;
                    number = new Random(seed);
                    setNumber = number.Next(1, 3);
                    // swapSet
                    SwapData(setNumber, roworcolPos, GameCombinations.SWAP_SETS);
                //}
            }

            //Method:SwapData
 

            private void SwapData(int setNumber, int roworcolPos, GameCombinations swapType)
            {

                int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
                int i = 0, j = 0;
                switch (swapType)
                {
                    case GameCombinations.SWAP_COLS:
                        y1 = _setColPosition[setNumber * 3] + roworcolPos;
                        if (roworcolPos == 2)
                        {
                            y2 = _setColPosition[setNumber * 3];
                        }
                        else
                        {
                            y2 = y1 + 1;
                        }
                        for (i = 0; i < MAX_ROWS; i++)
                        {

                            _numberSet[i, y2] = _originalSet[i, y1];
                            _numberSet[i, y1] = _originalSet[i, y2];

                        }
                        break;
                    case GameCombinations.SWAP_ROWS:
                        x1 = _setRowPosition[setNumber * 3] + roworcolPos;
                        if (roworcolPos == 2)
                        {
                            x2 = _setRowPosition[setNumber * 3];
                        }
                        else
                        {
                            x2 = x1 + 1;
                        }
                        for (i = 0; i < MAX_COLS; i++)
                        {

                            _numberSet[x2, i] = _originalSet[x1, i];
                            _numberSet[x1, i] = _originalSet[x2, i];

                        }
                        break;

                    case GameCombinations.SWAP_SETS:
                        if (_swapRows)
                        {
                            x1 = setNumber;
                            if (setNumber == 2)
                                x2 = 0;
                            else
                                x2 = x1 + 1;

                            for (j = 0; j < MAX_COLS; j++)
                            {
                                for (i = 0; i < MINI_SET_ROWS; i++)
                                {
                                    int temp = _numberSet[x2 * 3 + i, j];
                                    _numberSet[x2 * 3 + i, j] = _numberSet[x1 * 3 + i, j];
                                    _numberSet[x1 * 3 + i, j] = temp;

                                }
                            }

                        }
                        else
                        {
                            y1 = setNumber;
                            if (setNumber == 2)
                                y2 = 0;
                            else
                                y2 = y1 + 1;

                            for (j = 0; j < MAX_ROWS; j++)
                            {
                                for (i = 0; i < MINI_SET_COLS; i++)
                                {
                                    int temp = _numberSet[j, y1 * 3 + i];
                                    _numberSet[j, y1 * 3 + i] = _numberSet[j, y2 * 3 + i];
                                    _numberSet[j, y2 * 3 + i] = temp;
                                }
                            }



                        }
                        break;
                    default:
                        break;


                }



            }


            //Method:SwapNumberSet
            private bool SwapNumberSet(int x1, int y1, int x2, int y2, int roworcol)
            {
                int n1, n2, n3, n4, cnt = 0;
                if (roworcol == 1)
                {
                    n1 = _numberSet[x1, y1];
                    n2 = _numberSet[x2, y1];
                    n3 = _numberSet[x2, y2];
                    n4 = _numberSet[x1, y2];
                    _numberSet[x1, y1] = n2;
                    _numberSet[x2, y1] = n1;
                    _numberSet[x2, y2] = n4;
                    _numberSet[x1, y2] = n3;

                }
                else
                {
                    n1 = _numberSet[x1, y1];
                    n2 = _numberSet[x1, y2];
                    n3 = _numberSet[x2, y1];
                    n4 = _numberSet[x2, y2];
                    _numberSet[x1, y1] = n2;
                    _numberSet[x1, y2] = n1;
                    _numberSet[x2, y1] = n4;
                    _numberSet[x2, y2] = n3;
                }

                if (roworcol == 1)
                {
                    for (int i = 1; i <= MAX_ROWS; i++)
                    {
                        cnt = 0;
                        for (int j = 0; j < MAX_COLS; j++)
                        {

                            if (_numberSet[x1, j] == i)
                                cnt++;
                        }
                        if (cnt > 1)
                        {
                            _numberSet[x1, y1] = n1;
                            _numberSet[x2, y1] = n2;
                            _numberSet[x2, y2] = n3;
                            _numberSet[x1, y2] = n4;

                            return false;
                        }
                    }

                    for (int i = 1; i <= MAX_ROWS; i++)
                    {
                        cnt = 0;
                        for (int j = 0; j < MAX_COLS; j++)
                        {

                            if (_numberSet[x2, j] == i)
                                cnt++;
                        }
                        if (cnt > 1)
                        {
                            _numberSet[x1, y1] = n1;
                            _numberSet[x2, y1] = n2;
                            _numberSet[x2, y2] = n3;
                            _numberSet[x1, y2] = n4;

                            return false;
                        }
                    }

                }
                else
                {
                    for (int i = 1; i <= MAX_ROWS; i++)
                    {
                        cnt = 0;
                        for (int j = 0; j < MAX_ROWS; j++)
                        {

                            if (_numberSet[j, y1] == i)
                                cnt++;
                        }
                        if (cnt > 1)
                        {
                            _numberSet[x1, y1] = n1;
                            _numberSet[x1, y2] = n2;
                            _numberSet[x2, y1] = n3;
                            _numberSet[x2, y2] = n4;

                            return false;

                        }
                    }

                    for (int i = 1; i <= MAX_ROWS; i++)
                    {
                        cnt = 0;
                        for (int j = 0; j < MAX_ROWS; j++)
                        {

                            if (_numberSet[j, y2] == i)
                                cnt++;
                        }
                        if (cnt > 1)
                        {
                            _numberSet[x1, y1] = n1;
                            _numberSet[x1, y2] = n2;
                            _numberSet[x2, y1] = n3;
                            _numberSet[x2, y2] = n4;

                            return false;
                        }

                    }


                }


                return true;
            }


            //Method: SwapNumber

            private bool SwapNumber(int pos, int number, int set1, int setNumber)
            {
                int[] xpos = { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
                int[] ypos = { 0, 1, 2, 0, 1, 2, 0, 1, 2 };
                int x = 0, y = 0, x1, y1;
                bool duplicate = false;
                for (int i = 0; i < MAX_ROWS; i++)
                {
                    duplicate = false;

                    if (i != pos)
                    {
                        x = _setRowPosition[setNumber] + xpos[i];
                        y = _setColPosition[setNumber] + ypos[i];

                        duplicate = false;
                        for (int j = 0; j < MAX_COLS; j++)
                        {
                            if ((_numberSet[x, j] == number) || (_numberSet[j, y] == number))
                            {
                                duplicate = true;
                                j = MAX_COLS;
                            }
                        }
                        if (!duplicate)
                        {

                            int newNumber = _numberSet[x, y];
                            x1 = _setRowPosition[setNumber] + xpos[pos];
                            y1 = _setColPosition[setNumber] + ypos[pos];
                            _numberSet[x, y] = 0;
                            for (int j = 0; j < MAX_COLS; j++)
                            {
                                if ((_numberSet[x1, j] == newNumber) || (_numberSet[j, y1] == newNumber))
                                {
                                    duplicate = true;
                                    _numberSet[x, y] = newNumber;
                                    j = MAX_COLS;
                                }
                            }

                            if (!duplicate)
                            {
                                // swap Numbers
                                _numberSet[x, y] = number;
                                _numberSet[x1, y1] = newNumber;
                                return true;


                            }



                        }

                    }

                }

                return false;

            }

            #region Fields
            bool _swapRows = true;
            private int[,] _originalSet;          
            public int[,] _numberSet { get; set; }
            public int[,] _problemSet { get; set; }
            //private int[,] _problemSetCopy; uste neznam dali treba
            private int[] _setRowPosition = { 0, 0, 0, 3, 3, 3, 6, 6, 6 };
            private int[] _setColPosition = { 0, 3, 6, 0, 3, 6, 0, 3, 6 };

            #endregion fields

            #region constants
            private const int MAX_ROWS = 9;
            private const int MAX_COLS = 9;
            private const int MINI_SET_ROWS = 3;
            private const int MINI_SET_COLS = 3;
            #endregion constants

        }
}
