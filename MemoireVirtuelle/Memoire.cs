using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
   public class Memoire
    {
        private int taille;
        //constructeur
        public Memoire(int taille)
        {
            this.taille = taille;
        }
        //Getter
        public int gettaille()
        {
            return this.taille;
        }
        //Setter
        public void settaille(int t)
        {
            this.taille = t;
        }
    }
}
