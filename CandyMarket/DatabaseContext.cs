using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	internal class DatabaseContext
	{
        Dictionary<string, int> _taffy = new Dictionary<string, int>(); //if _taffy isn't intialized, it will default to null
        Dictionary<string, int> _compressedSugar= new Dictionary<string, int>();
        Dictionary<string, int> _chocolateBar = new Dictionary<string, int>();
        Dictionary<string, int> _zagnut = new Dictionary<string, int>();
        
		public DatabaseContext(int tone) => Console.Beep(tone, 2500);

		internal List<string> GetCandyTypes()
		{
			return Enum
				.GetNames(typeof(CandyType))
				.Select(candyType =>
					candyType.Humanize(LetterCasing.Title))
				.ToList();
		}

        internal void SaveNewCandy(string userName, CandyType candyType, int howMany) //save candy type and the amount of candy
		{
            if (!_taffy.ContainsKey(userName)) //if taffy dictionary does not contain userName key
            {
                _taffy.Add(userName, 0);
                _compressedSugar.Add(userName, 0);
                _chocolateBar.Add(userName, 0);
                _zagnut.Add(userName, 0);
            }

            switch (candyType)
			{
				case CandyType.TaffyNotLaffy:
					_taffy[userName] += howMany;
					break;
				case CandyType.ChocolateBar:
					_chocolateBar[userName] += howMany;
					break;
				case CandyType.CompressedSugar:
					_compressedSugar[userName] += howMany;
					break;
				case CandyType.ZagnutStyle:
					_zagnut[userName] += howMany;
					break;
				default:
					break;
			}
		}

        internal void RemoveCandy(string name, CandyType type)
        {
            switch (type)
            {
                case CandyType.TaffyNotLaffy:
                    if (_taffy[name] > 0)
                    {
                        _taffy[name]--; 
                    }
                    break;
                case CandyType.ChocolateBar:
                    if (_chocolateBar[name] > 0)
                    {
                        _chocolateBar[name]--; 
                    }
                    break;
                case CandyType.CompressedSugar:
                    if (_compressedSugar[name] > 0)
                    {
                        _compressedSugar[name]--; 
                    }
                    break;
                case CandyType.ZagnutStyle:
                    if (_zagnut[name] > 0)
                    {
                        _zagnut[name]--; 
                    }
                    break;
                default:
                    break;
            }


        }

        }
    }
