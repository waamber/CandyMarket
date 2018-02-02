using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	internal class DatabaseContext
	{
		private int _countOfTaffy;
		private int _countOfCandyCoated;
		private int _countOfChocolateBar;
		private int _countOfZagnut;

		public Dictionary<CandyType, List<string>> BagOfCandy { get; set; }

		public DatabaseContext(int tone) => Console.Beep(tone, 2500);

		internal List<string> GetCandyTypes()
		{
			return Enum
				.GetNames(typeof(CandyType))
				.Select(candyType =>
					candyType.Humanize(LetterCasing.Title))
				.ToList();
		}

		internal void SaveNewCandy(char selectedCandyMenuOption)
		{
			var candyOption = int.Parse(selectedCandyMenuOption.ToString());

			var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
			var forRealTheCandyThisTime = (CandyType)candyOption;

			switch (forRealTheCandyThisTime)
			{
				case CandyType.TaffyNotLaffy:
					++_countOfTaffy;
					break;
				case CandyType.CandyCoated:
					++_countOfCandyCoated;
					break;
				case CandyType.CompressedSugar:
					++_countOfChocolateBar;
					break;
				case CandyType.ZagnutStyle:
					++_countOfZagnut;
					break;
				default:
					break;
			}
		}
	}
}