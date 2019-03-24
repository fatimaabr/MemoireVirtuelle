using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    class PageCaseLFU
    {
        private int frequence;
        private int numPage;      //Numero de la page 
        //constructeur 
        public PageCaseLFU(int frequence, int numPage)
        {
            this.frequence = frequence;
            this.numPage = numPage;
        }
        //getter
        public int getfrequence()
        {
            return frequence;
        }
        public int getPagenum()
        {
            return this.numPage;
        }
        //setter
        public void setfrequence(int f)
        {
            frequence = f;
        }
        public void setnumPage(int num)
        {
            this.numPage = num;
        }
        //incrementer la frequence d'une page
        public void incrfrequence()
        {
            frequence++;
        }
    }
}
