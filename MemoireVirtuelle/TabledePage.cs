using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    class TabledePage
    {
        private int numPage;
        private int bitPresence = 0;
        private uint ReferencePage = 0b_00000000;
        private int numCase = -1;
        //constructeur
        public TabledePage(int i)
        {
            this.numPage = i;
        }

        //Getters
        public int getnumPage()
        {
            return this.numPage;
        }
        public uint getR()
        {
            return this.ReferencePage;
        }
        public int getPr()
        {
            return this.bitPresence;
        }
        public int getnumCase()
        {
            return this.numCase;
        }
        //Setters
        public void setnumPage(int n)
        {
            this.numPage = n;
        }
        public void setR(uint r)
        {
            this.ReferencePage = r;
        }
        public void setPr(int pr)
        {
            this.bitPresence = pr;
        }
        public void setnumCase(int c)
        {
            this.numCase = c;
        }
    }
}
