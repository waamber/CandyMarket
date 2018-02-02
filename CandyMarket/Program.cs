using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = SetupNewApp();
			var run = true;
			while (run)
			{
				ConsoleKeyInfo userInput = MainMenu();

				switch (userInput.KeyChar)
				{
					case '0':
						run = false;
						break;
					case '1':
						AddNewCandy(db);
						break;
					default:
						break;
				}
			}
		}

		private static DatabaseContext SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";

			int cSharp = 554;
			var db = new DatabaseContext(tone: cSharp);

			Console.SetWindowSize(60, 30);
			Console.SetBufferSize(60, 30);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			return db;
		}

		internal static ConsoleKeyInfo MainMenu()
		{
			View mainMenu = new View()
					.AddMenuOption("Did you just get some new candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
					.AddMenuText("Press 0 to exit.");

			Console.Write(mainMenu.GetFullMenu());
			var userOption = Console.ReadKey();
			return userOption;
		}

		internal static void AddNewCandy(DatabaseContext db)
		{
			var candyTypes = db.GetCandyTypes();

			var newCandyMenu = new View()
					.AddMenuText("What type of candy did you get?")
					.AddMenuOptions(candyTypes);

			Console.Write(newCandyMenu.GetFullMenu());

			var selectedCandyType = Console.ReadKey();

			// I should really be asking what candy we're saving.
			db.SaveNewCandy(selectedCandyType.KeyChar);
		}
	}
}
