using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
	static class Snake
	{
		private static List<Part> snake = new List<Part>();
		public static Directions direction;


		public static void Make()
		{
			for (int i = 1; i < 6; i++)
			{
				Part part = new Part();
				part.X = i;
				part.Y = 5;
				snake.Add(part);
			}
			direction = Directions.right;
			DrawSnake();
		}

		private static void DrawSnake()
		{
			foreach (var item in snake)
			{
				Console.SetCursorPosition(item.X, item.Y);
				Console.Write('O');
			}
		}

		public static void ClearSnake()
		{
			for (int i = 0; i < snake.Count; i++)
			{
				ClearPart(snake[i]);
			}
			snake.Clear();
		}

		public static bool Move()
		{
			switch (direction)
			{
				case Directions.up:
					if (snake[snake.Count - 1].Y <= 1)
					{
						return false;
					}
					Up();
					break;

				case Directions.down:
					if (snake[snake.Count - 1].Y >= 22)
					{
						return false;
					}
					Down();
					break;

				case Directions.left:
					if (snake[snake.Count - 1].X <= 1)
					{
						return false;
					}
					Left();
					break;

				case Directions.right:
					if (snake[snake.Count - 1].X >= 78)
					{
						return false;
					}
					Right();
					break;

				default:
					break;
			}
			return true;
		}

		private static void Up()
		{
			ClearPart(snake[0]);
			snake.RemoveAt(0);
			Part part = new Part();
			part.Y = snake[snake.Count - 1].Y - 1;
			part.X = snake[snake.Count - 1].X;
			snake.Add(part);
			DrawPart(part);
		}

		private static void Down()
		{
			ClearPart(snake[0]);
			snake.RemoveAt(0);
			Part part = new Part();
			part.Y = snake[snake.Count - 1].Y + 1;
			part.X = snake[snake.Count - 1].X;
			snake.Add(part);
			DrawPart(part);
		}

		private static void Left()
		{
			ClearPart(snake[0]);
			snake.RemoveAt(0);
			Part part = new Part();
			part.Y = snake[snake.Count - 1].Y;
			part.X = snake[snake.Count - 1].X - 1;
			snake.Add(part);
			DrawPart(part);
		}

		private static void Right()
		{
			ClearPart(snake[0]);
			snake.RemoveAt(0);
			Part part = new Part();
			part.Y = snake[snake.Count - 1].Y;
			part.X = snake[snake.Count - 1].X + 1;
			snake.Add(part);
			DrawPart(part);
		}

		private static void ClearPart(Part part)
		{
			Console.SetCursorPosition(part.X, part.Y);
			Console.Write(" ");
		}

		private static void DrawPart(Part part)
		{
			Console.SetCursorPosition(part.X, part.Y);
			Console.Write('O');
		}

		public static bool CheckColission(int x, int y)
		{
			for (int i = 0; i < snake.Count; i++)
			{
				if (snake[i].X == x && snake[i].Y == y)
				{
					return true;
				}
			}
			return false;
		}

		public static bool CheckForSelfColission()
		{
			for (int i = 4; i < snake.Count; i++)
			{
				if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
				{
					return true;
				}
			}
			return false;
		}

		public static void Grow()
		{
			Part part = new Part();
			switch (direction)
			{
				case Directions.right:
					part.Y = snake[snake.Count - 1].Y;
					part.X = snake[snake.Count - 1].X + 1;
					break;

				case Directions.left:
					part.Y = snake[snake.Count - 1].Y;
					part.X = snake[snake.Count - 1].X - 1;
					break;

				case Directions.up:
					part.Y = snake[snake.Count - 1].Y - 1;
					part.X = snake[snake.Count - 1].X;
					break;

				case Directions.down:
					part.Y = snake[snake.Count - 1].Y + 1;
					part.X = snake[snake.Count - 1].X;
					break;

				default:
					break;
			}

			snake.Add(part);		
			DrawPart(part);
		}
	}
}
