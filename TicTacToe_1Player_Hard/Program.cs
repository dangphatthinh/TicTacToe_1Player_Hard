using System;

namespace TikTakGame
{
    class Program
    {
        private static char c;
        private static int player;

        static void Main(string[] args)
        {

            Random random = new Random();
            int[] arr = new int[9];
            char key;
            int value;

            PrintTitle();
            
            key = char.Parse(Console.ReadLine());
            while (key == 's')
            {
                InitialMatrix(arr);
                Console.Clear();
                for (int i = 0; i < 9; i++)
                {
                    if (i == 0) { PrintMatrix(arr); }
                    if (i % 2 == 0)
                    {
                        c = 'X';
                        player = 1;
                    RET: Console.Write("PLAYER{0}({1}) Choose your step (1-9): ", player, c);
                        int step = int.Parse(Console.ReadLine());
                        if (arr[step - 1] == 'X' || arr[step - 1] == 'O')
                        {
                            Console.WriteLine("Your step has already exist, Please try another step");
                            goto RET;
                        }
                        arr[step - 1] = c;
                    }
                    else
                    {
                        c = 'O';
                        player = 2;
                        if (i == 1)
                        {
                            if (arr[4] != 32)
                            {
                                RET3:  value = random.Next(0, 8);
                                if(value == 0|| value == 2|| value == 6|| value == 8)
                                {
                                    arr[value] = c;
                                    goto RET2;
                                }
                                else
                                {
                                    goto RET3;
                                }
                            }
                            else
                            {
                                arr[4] = c;
                                goto RET2;
                            }
                        }
                        if (Player2Move1(arr, c) == 1) { goto RET2; }
                        if (Player2Move2(arr, c) == 1) { goto RET2; }
                    RET1: int step = random.Next(1, 9);
                        if (arr[step - 1] == 'X' || arr[step - 1] == 'O')
                        {
                            goto RET1;
                        }
                        arr[step - 1] = c;
                    }

                RET2: Console.Clear();
                    PrintMatrix(arr);

                    if (Win(arr, c) == 1) { break; };
                    if (i == 8)
                    {
                        Console.WriteLine("\nPLAYER1 HOA PLAYER2\n");
                        break;
                    }
                }
                Console.WriteLine("Press 's' to start the new game, 'e' to exit");
                key = char.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine("Thank you!!!See you later");
            return;
        }

        static void PrintMatrix(int[] arr)
        {
             Console.WriteLine("   {0}   |   {1}   |  {2}   ", (char)arr[0], (char)arr[1], (char)arr[2]);
             Console.WriteLine("-------*-------*------");
             Console.WriteLine("   {0}   |   {1}   |  {2}   ", (char)arr[3], (char)arr[4], (char)arr[5]);
             Console.WriteLine("-------*-------*------");
             Console.WriteLine("   {0}   |   {1}   |  {2}   ", (char)arr[6], (char)arr[7], (char)arr[8]);
            
        }

        static int Win(int[] arr, char c)
        {
            if ((arr[0] == arr[1] && arr[0] == arr[2] && arr[0] == c)||
                (arr[3] == arr[4] && arr[3] == arr[5] && arr[3] == c)||
                (arr[6] == arr[7] && arr[6] == arr[8] && arr[6] == c)||
                (arr[0] == arr[3] && arr[0] == arr[6] && arr[0] == c)||
                (arr[1] == arr[4] && arr[1] == arr[7] && arr[1] == c)||
                (arr[2] == arr[5] && arr[2] == arr[8] && arr[2] == c)||
                (arr[0] == arr[4] && arr[0] == arr[8] && arr[0] == c)||
                (arr[2] == arr[4] && arr[2] == arr[6] && arr[2] == c))
            {
                if (c == 'X'){
                    Console.WriteLine("\nPLAYER1 WIN\n");
                }
                else { 
                    Console.WriteLine("\nPLAYER2 WIN\n");
                }
                return 1;
            }
            else { return 0; }           
        }
        static void PrintTitle()
        {
            Console.WriteLine("Welcome to Tic Tac Toe Game ^^");
            Console.WriteLine("PLAYER1 ({0}) vs PLAYER2 ({1})", 'X', 'O');
            Console.WriteLine("Press 's' to start the new game, 'e' to exit");
        }
        static void InitialMatrix(int[] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                arr[i] = 32;
            }
        }
        static int Player2Move1(int[] arr,char c)
        {
            for (int j = 0; j < 9; j++)
            {
                if (arr[j] == 32)
                {
                    arr[j] = c;
                    if (Win(arr, c) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        arr[j] = 32;
                    }
                }
            }
            return 0;
        }
        static int Player2Move2(int[] arr, char c)
        {
            for (int j = 0; j < 9; j++)
            {
                if (arr[j] == 32)
                {
                    arr[j] = 'X';
                    if (Win(arr, 'X') == 1)
                    {
                        arr[j] = c;
                        return 1;
                    }
                    else
                    {
                        arr[j] = 32;
                    }
                }
            }
            return 0;
        }
    }
}
