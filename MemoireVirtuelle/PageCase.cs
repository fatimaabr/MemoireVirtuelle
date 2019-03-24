using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    public class PageCase
    {
        private static int taille; //Taille de la page/case (puissance de 2)
        private int numPage;      //Numero de la page 
        private int numCase;    //Numero de la case (si la page est en mémoire centrale) 


        //Constructeur
        public PageCase(int numeroPage)
        {
            this.numPage = numeroPage;
            this.numCase = -1;

        }
        //Getters
        public static int gettailepage()
        {
            return taille;
        }
        public int getnumPage()
        {
            return this.numPage;
        }
        public int getNumCase()
        {
            return numCase;
        }

        //Setters 
        static public void setTaille(int tail)
        {
            taille = tail;
        }
        public void setnumPage(int num)
        {
            this.numPage = num;
        }
        public void setNumeroCase(int numeroCase)
        {
            this.numCase = numeroCase;
        }

    }
}
