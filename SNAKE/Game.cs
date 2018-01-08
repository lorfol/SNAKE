using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SNAKE
{
	class Game
	{
		static bool inGame = true;
		static Food food = new Food();
		public static int score = 0;


		public static void StartNewGame()
		{
			inGame = true;
			score = 0;
			Console.Clear();
			MakePlayground();
			Snake.Make();
			food.SetFood();
			Play();

		}

		private static void MakePlayground()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			for (int x = 1; x < 79; x++)
			{
				Console.SetCursorPosition(x, 0);
				Console.WriteLine("=");
				Console.SetCursorPosition(x, 23);
				Console.WriteLine("=");
			}
			for (int i = 1; i < 23; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.WriteLine("|");
				Console.SetCursorPosition(79, i);
				Console.WriteLine("|");
			}
			Console.SetCursorPosition(1, 24);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write($"Score = {score}");
			Console.ForegroundColor = ConsoleColor.White;
		}

		private static void Play()
		{
			while (inGame)
			{
				CheckForInput();
				CheckForSelfColision();
				Move();
				IsFoodEaten();
				Thread.Sleep(100);
			}
		}

		private static void CheckForInput()
		{
			if (Console.KeyAvailable)
			{
				ConsoleKeyInfo key = Console.ReadKey();

				if (key.Key == ConsoleKey.LeftArrow)
				{
					if (Snake.direction != Directions.right)
					{
						Snake.direction = Directions.left;
					}

				}
				if (key.Key == ConsoleKey.RightArrow)
				{
					if (Snake.direction != Directions.left)
					{
						Snake.direction = Directions.right;
					}

				}
				if (key.Key == ConsoleKey.UpArrow)
				{
					if (Snake.direction != Directions.down)
					{
						Snake.direction = Directions.up;
					}

				}
				if (key.Key == ConsoleKey.DownArrow && Snake.direction != Directions.up)
				{
					Snake.direction = Directions.down;
				}
				if (key.Key == ConsoleKey.Escape)
				{
					inGame = false;
				}
			}
		}

		private static void CheckForSelfColision()
		{
			if (Snake.CheckForSelfColission())
			{
				GameOver();
			}
		}

		private static void Move()
		{
			bool on = Snake.Move();
			if (!on)
			{
				GameOver();
			}
		}

		private static void GameOver()
		{
			inGame = false;
			Console.SetCursorPosition(35, 11);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("GAME OVER.");
			

			Console.ForegroundColor = ConsoleColor.White;
			Console.ReadKey();
			Snake.ClearSnake();
			Records.Set();
			Menu.ShowMenu();
		}

		private static void IsFoodEaten()
		{
			if (Snake.CheckColission(food.X, food.Y))
			{
				score += 100;
				Snake.Grow();
				Console.SetCursorPosition(1, 24);
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Score = {0}", score);
				Console.ForegroundColor = ConsoleColor.White;

				food = new Food();
				food.SetFood();
			}
		}
	}
}
