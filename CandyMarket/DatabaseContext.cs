using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    internal class DatabaseContext
    {
        //public Dictionary<CandyType, List<string>> BagOfCandy { get; set; }
        int _countOfTaffy = 0;
        int _countOfCandyCoated;
        int _countOfChocolateBar;
        int _countOfZagnut;

        public DatabaseContext(int tone)
        {
        }

        internal List<string> GetCandyTypes()
        {
            var candyTypes = Enum.GetNames(typeof(CandyType)).ToList();
            return candyTypes.Select(candyType => candyType.Humanize(LetterCasing.Title)).ToList();
        }

        internal void SaveNewCandy(char selectedCandyMenuOption)
        {
            // The long way
            //var candyOption = int.Parse(selectedCandyMenuOption.ToString());
            //var forRealTheCandyThisTime = (CandyType)candyOption;

            // The short way...probably buggy
            var candyOption = (CandyType)selectedCandyMenuOption;

            switch (candyOption)
            {
                case CandyType.Taffy:
                    ++_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    ++_countOfCandyCoated;
                    break;
                case CandyType.ChocolateBar:
                    ++_countOfChocolateBar;
                    break;
                case CandyType.Zagnut:
                    ++_countOfZagnut;
                    break;
                default:
                    break;
            }
        }
    }
}