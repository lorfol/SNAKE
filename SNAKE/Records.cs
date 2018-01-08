using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
	static class Records
	{
		public static void Set()
		{
			if (Game.score != 0)
			{
				string path = @"D:\SnakeRecords.txt";
				string name;

				Console.Clear();
				Console.CursorVisible = true;
				Console.Write("Congratulations!\nInput youre name to save result: ");
				name = Console.ReadLine();

				using (StreamWriter stream = new StreamWriter(path, true, System.Text.Encoding.Default))
				{
					stream.WriteLine($"{name} - {Game.score}");
				}
			}else return;
		}

		public static void Show()
		{
			List<string> records = new List<string>();
			string path = @"D:\SnakeRecords.txt";

			try
			{
				using (StreamReader reader = new StreamReader(path))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
						records.Add(line);

					foreach (var item in records)
					{
						Console.WriteLine(item);
					}
					Console.ReadKey();
				}
			}
			catch(Exception e)
			{
				Console.SetCursorPosition(28, 12);
				Console.WriteLine(e.Message);
				Console.WriteLine("You have no records yet.");
				Console.ReadKey();
				Menu.ShowMenu();
			}
			Menu.ShowMenu();
		}
	}
}
