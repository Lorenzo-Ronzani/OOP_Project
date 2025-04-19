using System;
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
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    cells[row, col] = EmptyCell;
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

        //Method to insert the symbols inside the board
        public bool Drop(int column, char symbol)
        {
            int row = FindAvailableRow(column);

            if (row == -1)
                return false;

            cells[row, column] = symbol;
            return true;
        }

        //Method to check if the board is full
        public bool IsFull()
        {
            for (int col = 0; col < Columns; col++)
            {
                if (cells[0, col] == EmptyCell)
                    return false;
            }
            return true;
        }

    }

    public abstract class Player
    {
        public char Symbol { get; }
        public string Name { get; }

        public Player(char symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }

        public abstract int ChooseColumn();
    }

    public class HumanPlayer : Player
    {
        public HumanPlayer(char symbol, string name) : base(symbol, name) { }

        public override int ChooseColumn()
        {
            int column;
            Console.WriteLine($"{Name}'s turn ({Symbol}): Choose a column (1-7): ");
            while (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > 7)
            {
                Console.WriteLine("Invalid input! Please choose a column between 1 and 7.");
            }
            //Adjust for 0 (based index)
            return column - 1;
        }
    }


    public class GameController
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public GameController(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            currentPlayer = player1;  // Player1 starts
            board = new Board();
        }

        public void Start()
        {
            while(true)
            {
                board.Show();
                int column = currentPlayer.ChooseColumn();

                if(!board.Drop(column, currentPlayer.Symbol))
                {
                    Console.WriteLine("Column full! Choose another.");
                    continue;
                }

                if(CheckWin(currentPlayer.Symbol))
                {
                    board.Show();
                    Console.WriteLine($"{currentPlayer.Name} wins");
                    break;
                }

                if(board.IsFull())
                {
                    board.Show();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                //Switch players
                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
        }

        private bool CheckWin(char symbol)
        {
            for (int row = 0; row < 6; row++)
                for (int col = 0; col < 7; col++)
                {
                    if (cellsInLine(row, col, 1, 0, symbol) ||
                        cellsInLine(row, col, 0, 1, symbol) ||
                        cellsInLine(row, col, 1, 1, symbol) ||
                        cellsInLine(row, col, 1, -1, symbol))
                    {
                        return true;
                    }
                }
            return false;
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

                if (input == "X")
                {
                    player1Symbol = 'X';
                    player2Symbol = '0';
                }
                else if (input == "0")
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
