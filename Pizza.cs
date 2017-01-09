using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria
{
    public class Pizza
    {
        private string nazwa;
        private decimal suma = 15;
        private List<Skladnik> skladniki = new List<Skladnik>();
        private string sos;

        public void DodajSkladnik (string nazwa_,double cena_)
        {
            skladniki.Add(new Skladnik(nazwa_, cena_));
            suma += decimal.Parse( cena_.ToString());
        }

        public void DodajSos (string sos_)
        {
            this.sos = sos_;

        }
        public void UstawNazwe(string nazwa_)
        {
            this.nazwa = nazwa_;

        }
        public override string ToString()
        {
            if (skladniki.Count == 0)
            {
                return "";
            }
            string tmp = "";

            foreach (var itm in skladniki)
            {
                tmp += itm.ToString() + "\n";
            }
            return string.Format("Pizza: \nNazwa: {0}\n{1}\nSos: {2}\nSuma: {3}", nazwa, tmp, sos, suma);
        }
        public bool CzyNazwa()
        {
            if (nazwa == null) return false;
            else return true;
        }
        public bool CzyPoprawnaPizza()
        {
            if (skladniki.Count > 1 && sos != null) return true;
            else return false;
        }

    }
}
