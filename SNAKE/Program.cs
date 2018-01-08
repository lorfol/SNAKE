using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetBufferSize(80, 25);
			Console.SetWindowSize(80, 26);
			Console.CursorVisible = false;

			Logo();
			Menu.ShowMenu();
		}

		private static void Logo()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(0, 5);
			Console.WriteLine(@"
             L        OOOOOOOO   RRRRR     FFFFFFFF  OOOOOOOO  L        
             L        O      O  R     R    F         O      O  L       
             L        O      O  R      R   F         O      O  L       
             L        O      O  R   RRR    FFFFF     O      O  L       
             L        O      O  R    R     F         O      O  L        
             L        O      O  R      R   F         O      O  L       
             LLLLLLL  OOOOOOOO  R       R  F         OOOOOOOO  LLLLLLL 





				SNAKE THE GAME                                ");
			Console.SetCursorPosition(58, 25);
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Press any button...");
			Console.ReadKey();
		}
	}
}
