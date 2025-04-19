﻿using System;
using System.Data;
using System.Numerics;

namespace ConnectFourProject
{

    public class Board
    {
        private readonly char[,] cells;
        private const int Row = 6;
        private const int Column = 7;
        private const char EmptyCell = '.';

        public Board()
        {
            cells = new char[Rows, Columns];
            Clear();
        }

        public void Clear()
        {
            for(int row = 0, row < Rows; row++) 
                for(int col = 0; col < Columns; col++)
                    cells[row, col] = EmptyCell;kkk
        }

        public void Show()
        {

            for (int row = 0; row < Rows; row++)
            {
                Console.Write("|");
                for (int col = 0; col < Columns; col++)
                {
                    Console.Write($" {cells[row, col]}");
                }
                Console.WriteLine(" |");
            }
            Console.Write("-----------------");
            Console.WriteLine("\n  1 2 3 4 5 6 7");
        }

        public char GetCell(int row, int col)
        {
            return cells[row, col];
        }

        private int FindAvailableRow(int column)//Method to check if the column has space to drop symbols
        {
            if (column < 0 || column >= Columns)
                return -1;

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (cells[row, column] == EmptyCell)
                    return row;
            }

            return -1;
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect Four!");
            Console.WriteLine("Please, select your symbol: ");
            Console.WriteLine("Would you like to play with X or 0?");

            string input = Console.ReadLine()?.ToUpper();

            char player1Symbol;
            char player2Symbol;

            if(input == "X")
            {
                player1Symbol = 'X';
                player2Symbol = '0';
            } 
            else if(input == "0")
            {
                player1Symbol = '0';
                player2Symbol = 'X';
            }
            else
            {
                Console.WriteLine("Invalid selection. Defaulting to X.");
                player1Symbol = 'X';
                player2Symbol = '0';
            }

            Console.WriteLine($"You choose: {player1Symbol}");
            Console.WriteLine($"Your oponent will play as: {player2Symbol}");
            
        }
    }
}
