using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMarket
{
     class Friends
     {
        readonly DatabaseContext _db;

        public string Name { get; set; }

        public Friends(string name, DatabaseContext db)
        {
            Name = name;
            _db = db;
        }

        public void AddCandy(CandyType typeOfCandy, int howMany) //add type of candy and how many
        {
            _db.SaveNewCandy(Name,typeOfCandy, howMany);
        }

        public void GiveCandy(CandyType type, string reciever)
        {
            _db.RemoveCandy(Name, type);
            _db.SaveNewCandy(reciever, type, 1);
        }

       
    }
}
