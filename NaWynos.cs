using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria
{
    class NaWynos :Zamowienie
    {
        public override bool PoprawnyCzas()
        {
            if (czasDostawy.Hour > DateTime.Now.Hour + 3) return true;
            else return false;
        }

    }
}
