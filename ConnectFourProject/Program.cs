﻿
using System;
namespace ConnectFourProject
{
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
