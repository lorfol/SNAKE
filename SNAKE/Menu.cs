using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
	class Menu
	{
		public static void ShowMenu()
		{
			Console.CursorVisible = false;
			Console.Clear();
			Console.SetCursorPosition(32, 8);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("1. Start new game.");
			Console.SetCursorPosition(32, 10);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("2. Show records.");
			Console.SetCursorPosition(32, 12);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("3. Exit.");

			
			var key =  Console.ReadKey();

			switch(key.Key)
			{
				case ConsoleKey.D1:
					Console.Clear();
					Game.StartNewGame();
					break;

				case ConsoleKey.D2:
					Console.Clear();
					Records.Show();
					break;

				case ConsoleKey.D3:
					Console.Clear();
					return;

				case ConsoleKey.Escape:
					Console.Clear();
					return;

				default:
					Console.Clear();
					ShowMenu();
					break;
			}
		}
	}
}
