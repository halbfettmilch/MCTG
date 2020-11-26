using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class Package
    {
         public List<Card> package = new List<Card>(); 

        public int price { get; set; }

        public int size { get; set; }

        public Package()
        {
            this.price = 5;
            this.size = 5;
        }
    }

    

    
}
