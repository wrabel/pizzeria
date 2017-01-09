using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria
{
    abstract class Zamowienie
    {
        protected DateTime czasDostawy;
        
        public virtual bool PoprawnyCzas()
        {
            if (czasDostawy > DateTime.Now) return true;
            else return false;
        }
        public void UstawCzasDostawy(DateTime data)
        {
            this.czasDostawy = data;
        }

    }
}
