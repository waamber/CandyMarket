using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    class Program
    {
        static void Main(string[] args)
        {


            // wanna be a l33t h@x0r? skip all this console menu nonsense and go with straight command line arguments. something like `candy-market add taffy "blueberry cheesecake" yesterday`
            var db = SetupNewApp();
            var me = new Friends("Amber", db);
            var friend = new Friends("Karen", db);
            
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
                        // add candy to your bag
                        // select a candy type
                        var selectedCandyType = AddNewCandyType(db);
                        var candyType = (CandyType)int.Parse(selectedCandyType.KeyChar.ToString()); //take key that was pressed and turning it into a string, then turning it into an int then turning it to candytype enum
                        me.AddCandy(candyType, 1); //adding candy type and one of that type
                        
                        break;
                    case '2':
                        // eat candy

                        var eatenCandy = EatCandyType(db);
                        var eatenCandyType = (CandyType)int.Parse(eatenCandy.KeyChar.ToString());
                        db.RemoveCandy("Amber", eatenCandyType);
                        

                        break;
                    case '3':
                        //throw away candy

                        var candyThrownAway = AddNewCandyType(db);
                        var thrownAwayType = (CandyType)int.Parse(candyThrownAway.KeyChar.ToString());
                        db.RemoveCandy("Amber", thrownAwayType);

                        break;
                    case '4':
                        // give candy
                        var selectedCandy = GiveCandyType(db);
                        
                        var givenCandy = (CandyType)int.Parse(selectedCandyType.KeyChar.ToString());
                        db.SaveNewCandy("Karen", givenCandy, 1);
                        
                        
                            
                        break;
                    case '5':
                        /** trade candy
						 * this is the next logical step. who wants to just give away candy forever?
						 */
                        break;
                    default: // what about requesting candy? like a wishlist. that would be cool.
                        break;
                }
            }
        }

        static DatabaseContext SetupNewApp()
        {
            Console.Title = "Cross Confectioneries Incorporated";

            var cSharp = 554;
            var db = new DatabaseContext(tone: cSharp);

            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return db;
        }

        static ConsoleKeyInfo MainMenu()
        {
            
            View mainMenu = new View()
                    .AddMenuOption("Did you just get some new candy? Add it here.")
                    .AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Do you want to throw away some candy?")
                    .AddMenuOption("Do you want to give candy to a friend?")
                    .AddMenuText("Press 0 to exit.");

            Console.Write(mainMenu.GetFullMenu());
            ConsoleKeyInfo userOption = Console.ReadKey();
            return userOption;
        }

        static ConsoleKeyInfo AddNewCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText("What type of candy did you get?")
                    .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static ConsoleKeyInfo EatCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var eatCandyMenu = new View()
                    .AddMenuText("What kind of candy do you want to eat?")
                    .AddMenuOptions(candyTypes);

            Console.Write(eatCandyMenu.GetFullMenu());
            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static ConsoleKeyInfo GiveCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var giveCandyMenu = new View()
                    .AddMenuText("What kind of candy do you want to give?")
                    .AddMenuOptions(candyTypes);

            Console.Write(giveCandyMenu.GetFullMenu());
            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static ConsoleKeyInfo EatenCandy(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var eatCandyMenu = new View()
                    .AddMenuText("What type of candy did you eat?")
                    .AddMenuOptions(candyTypes);

            Console.Write(eatCandyMenu.GetFullMenu());
            ConsoleKeyInfo eatenCandy = Console.ReadKey();
            return eatenCandy;
        }

        
       
        
    }
}
