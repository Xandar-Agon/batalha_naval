﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace batalha_naval
{
    class Board
    {
        private char[,] player_grid;
        private int diff;
        private int tiros;

        public Board(int diff)
        {
           player_grid = FillBoard(diff);
           this.diff = diff;

        }

        public int GetTiros()
        {
            return tiros;
        }

        public void SetTiros(int settiros)
        {
            tiros = settiros;
        }

        public bool CheckLoss()
        {
            bool loss = true;
            for (int i = 0; i < player_grid.GetLength(0); i++)
            {
                for (int j = 0; j < player_grid.GetLength(1); j++)
                {
                    if (player_grid[i, j] == '@')
                    {
                        loss = false;
                    }
                }
            }
            if (loss == true)
            {
                Console.WriteLine("You Lose");
            }
            return loss;
        }

        public void PlaceShips()
        {
            string cord;
            Console.WriteLine("Onde quer colocar os seus navios?");
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    cord = Program.GetCord();
                } while (!Program.CheckCord(cord,diff));
                player_grid[(int)cord[0] - 96, (int)cord[2] - 48] = '@';
            }
        }

        public void Fire()
        {
            Console.WriteLine("Onde pretende disparar?");
            string cord;
            do
            {
                cord = Program.GetCord();
            } while (!Program.CheckCord(cord,diff));

            int x = (int)cord[0] - 96;
            int y = (int)cord[2] - 48;

            if(player_grid[x,y] == '@')
            {
                player_grid[x, y] = 'x';
                SetTiros(GetTiros() + 1);
            }
            else
            {
                if (player_grid[x, y] == 'x')
                {
                    Console.WriteLine("Já disparou aí");
                    Fire();
                }
                else
                {
                    player_grid[x, y] = 'a';
                    SetTiros(GetTiros() + 1);
                }
                
            }
            

            return;
        }

        public char[,] FillBoard(int diff)
        {
            char[,] grid = new char[diff,diff];
            for (int i = 0; i < grid.GetLength(1); ++i)
            {
                grid[0,i] = (char)(Convert.ToInt32('a') + (i-1));
                grid[i, 0] = (char)(Convert.ToInt32('0') + i);
            }
            return grid;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < player_grid.GetLength(0); i++)
            {
                for (int j = 0; j < player_grid.GetLength(1); j++)
                {
                    if (player_grid[i, j] == '@')
                    {
                        Console.Write(' ');
                        Console.Write('|');
                    }
                    else
                    {
                        Console.Write(player_grid[i, j]);
                        Console.Write('|');
                    }
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
