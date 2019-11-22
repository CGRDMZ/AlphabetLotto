using System;
using System.Threading;

namespace AlphabetLotto
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            char[] alphabetArray = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                                'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            bool[] isPulled = new bool[alphabetArray.Length];

            char[] player1 = new char[8];
            char[] player2 = new char[8];

            bool[] isPulledP1 = new bool[8];
            bool[] isPulledP2 = new bool[8];

            int player1Score = 0;
            int player2Score = 0;

            int player1Count = 0;
            int player2Count = 0;

            int sum;

            bool cinko = true;

            bool flag = true;

            Random rand = new Random();
            int randNumber;

            for (int i = 0; i < alphabetArray.Length; i++)
            {
                isPulled[i] = false;
            }

            for (int i = 0; i < isPulledP1.Length; i++)
            {
                isPulledP1[i] = false;
                isPulledP2[i] = false;
            }

            // player 1 initialization
            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    randNumber = rand.Next(14);
                }
                else
                {
                    randNumber = rand.Next(14, 26);
                }
                while (player1Count < i + 1)
                {
                    if (!isPulled[randNumber])
                    {
                        player1[i] = alphabetArray[randNumber];
                        isPulled[randNumber] = true;
                        player1Count++;
                    }
                    else
                    {
                        randNumber = rand.Next(14);
                    }
                }
            }

            for (int i = 0; i < alphabetArray.Length; i++)
            {
                isPulled[i] = false;
            }

            // player 2 initialization
            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    randNumber = rand.Next(14);
                }
                else
                {
                    randNumber = rand.Next(14, 26);
                }
                while (player2Count < i + 1)
                {
                    if (!isPulled[randNumber])
                    {
                        player2[i] = alphabetArray[randNumber];
                        isPulled[randNumber] = true;
                        player2Count++;
                    }
                    else
                    {
                        randNumber = rand.Next(14);
                    }
                }
            }

            for (int i = 0; i < alphabetArray.Length; i++)
            {
                isPulled[i] = false;
            }

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n-------------------------------------");

                Console.Write("Bag 1: ");
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    if (!isPulled[i])
                    {
                        Console.Write($"{alphabetArray[i]} ");
                    }
                }
                Console.WriteLine();
                Console.Write("\nplayer1: ");
                for (int i = 0; i < player1.Length; i++)
                {
                    if (!isPulledP1[i])
                    {
                        Console.Write($"{player1[i]} ");
                    }
                }
                Console.WriteLine();
                Console.Write("\nplayer2: ");
                for (int i = 0; i < player2.Length; i++)
                {
                    if (!isPulledP2[i])
                    {
                        Console.Write($"{player2[i]} ");
                    }
                }
                Console.WriteLine();

                cinko = true;
                for (int i = 0; i < isPulledP1.Length; i++)
                {
                    if (i < 4 && !isPulledP1[i])
                    {
                        cinko = false;
                    }
                }
                if (cinko && flag)
                {
                    Console.WriteLine("\nPlayer 1 gets $10  (birinci çinko)");
                    player1Score += 10;
                    flag = false;
                }

                cinko = true;
                for (int i = 0; i < isPulledP1.Length; i++)
                {
                    if (i >= 4 && !isPulledP1[i])
                    {
                        cinko = false;
                    }
                }
                if (cinko && flag)
                {
                    Console.WriteLine("\nplayer 1 gets $10  (birinci çinko)");
                    player1Score += 10;
                    flag = false;
                }


                cinko = true;
                for (int i = 0; i < isPulledP2.Length; i++)
                {
                    if (i < 4 && !isPulledP2[i])
                    {
                        cinko = false;
                    }
                }
                if (cinko && flag)
                {
                    Console.WriteLine("\nplayer 2 gets $10 (birinci çinko)");
                    player2Score += 10;
                    flag = false;
                }

                cinko = true;
                for (int i = 0; i < isPulledP2.Length; i++)
                {
                    if (i >= 4 && !isPulledP2[i])
                    {
                        cinko = false;
                    }
                }
                if (cinko && flag)
                {
                    Console.WriteLine("\nplayer 2 gets $10 (birinci çinko)");
                    player2Score += 10;
                    flag = false;
                }

                do
                {
                    randNumber = rand.Next(26);
                } while (isPulled[randNumber]);

                isPulled[randNumber] = true;

                Console.WriteLine($"\nselected number is: {alphabetArray[randNumber]}");
                Console.WriteLine("\n-------------------------------------");

                if (player1Count == 0 && player2Count == 0)
                {
                    player1Score += 30;
                    player2Score += 30;
                    sum = player1Score + player2Score;
                    Console.WriteLine("it is a tie. (${0} amount of money will be shared for each player)", sum / 2);
                    break;
                }
                else if (player1Count == 0)
                {
                    player1Score += 30;
                    Console.WriteLine($"player1 gets: ${player1Score}");
                    Console.WriteLine($"player2 gets: ${player2Score}");
                    break;
                }
                else if (player2Count == 0)
                {
                    player2Score += 30;
                    Console.WriteLine($"player1 gets: ${player1Score}");
                    Console.WriteLine($"player2 gets: ${player2Score}");
                    break;
                }

                for (int i = 0; i < player1.Length; i++)
                {
                    if (alphabetArray[randNumber] == player1[i])
                    {
                        isPulledP1[i] = true;
                        player1Count--;
                    }
                }

                for (int i = 0; i < player2.Length; i++)
                {
                    if (alphabetArray[randNumber] == player2[i])
                    {
                        isPulledP2[i] = true;
                        player2Count--;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}