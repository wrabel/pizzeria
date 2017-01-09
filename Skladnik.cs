using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria
{
    public class Skladnik : IComparable<Skladnik>
    { 
        private string nazwaSkladnika;
        private double cenaSkladnika;

        public Skladnik(string nazwaSkladnika_,double cenaSkladnika_)
        {
            this.cenaSkladnika = cenaSkladnika_;
            this.nazwaSkladnika = nazwaSkladnika_;
        }

        public override string ToString()
        {
            return string.Format("Nazwa: {0}, cena: {1}", nazwaSkladnika, cenaSkladnika);
        }

        public double PodajCeneSkladnika()
        {
            return cenaSkladnika;
        }
        
        public int CompareTo(Skladnik other)
        {
            return this.nazwaSkladnika.CompareTo(other.nazwaSkladnika);
        }

    }
}
