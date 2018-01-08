using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
	class Food
	{
		public int X;
		public int Y;


		public Food()
		{
			Random rand = new Random();
			X = rand.Next(1, 78);
			Y = rand.Next(1, 22);
		}

		public void SetFood()
		{
			Console.SetCursorPosition(X, Y);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write('@');
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
