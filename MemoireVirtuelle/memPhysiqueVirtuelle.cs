using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    public class memPhysiqueVirtuelle : Memoire
    {
        private static int taillePage;
        private int nbCasePage;
        private int nbCaseLibre;
        //creation de la memoire (une liste)
        List<PageCase> listMemoire = new List<PageCase>();
        //constructeur 
        public memPhysiqueVirtuelle(int taille, int tailPage) : base(taille)
        {
            taillePage = tailPage;
            this.nbCasePage = taille / taillePage;
            this.nbCaseLibre = nbCasePage;
            //Créer les éléments de la liste
            for (int i = 0; i < nbCasePage; i++)
            {
                listMemoire.Add(new PageCase(-1));
            }
        }
        //Getters
        public static int getTaillePage()
        {
            return taillePage;
        }
        public int getnbCasePage()
        {
            return this.nbCasePage;
        }
        public int getnbCaseLibre()
        {
            return this.nbCaseLibre;
        }
        public PageCase getContenu(int i) //renvoie la page/case d'indice i (i de 0 à nbContenu)
        {
            return listMemoire[i];
        }
        //Setters
        public void setMemoire(int t, int taillep)
        {
            base.settaille(t);
            taillePage = taillep;
            this.nbCasePage = t / taillep;
            this.nbCaseLibre = nbCasePage;

        }
        public void setTaillePage(int tpage)
        {
            taillePage = tpage;
            this.nbCasePage = base.gettaille() / taillePage;
        }
        public void setNbpage(int nbp)
        {
            this.nbCasePage = nbp;
            taillePage = base.gettaille() / nbCasePage;

        }
        public void setNbCaseLibre(int lib)
        {
            this.nbCaseLibre = lib;
        }
        public void decrNbCaseLibre()
        {
            this.nbCaseLibre--;
        }
        public void modifPage(PageCase p, int indice)
        { 
            try
            {
                listMemoire[indice] = p;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void ajouter(PageCase p)
        {
            listMemoire.Add(p);
        }
    }
}
