using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    public abstract class PageReplacement
    {
        protected memPhysiqueVirtuelle memPhysique;
        protected memPhysiqueVirtuelle memVirtuelle;
        private int defautPages = 0;
        List<PageCase> listedePages = new List<PageCase>(); //liste de page de l'utilisateur
        //Contructeur
        public PageReplacement(int tailleMV, int taillePage, int tailleMP)
        {
            memPhysique = new memPhysiqueVirtuelle(tailleMP, taillePage);
            memVirtuelle = new memPhysiqueVirtuelle(tailleMV, taillePage);
        }
        //Getters
        public int getTailleListedePage()
        {
            return listedePages.Count; //Retourner le nombre de page en attente dans la liste de l'utilisateur
        }
        public int getDefautPage()
        {
            return defautPages;
        }
        //Récupérer l'élément d'indice i de la liste
        public PageCase getListei(int i)
        {
            return listedePages[i];
        }

        //Setters
        public void ajouterAListe(PageCase p)
        {
            listedePages.Add(p);
        }
        public void suppDeListe(int i)
        {
            listedePages.RemoveAt(i);
        }
        public void setDefautPages(int defautPages)
        {
            this.defautPages = defautPages;
        }
        public void IncrDefautPages()
        {
            this.defautPages++;
        }
        public void modifPageUtil(PageCase p, int indice)
        {
            listedePages[indice] = p;
        }
        /****************AFFICHAGE DE  LA LISTE D'UTILISATEUR *********************/
        public void afficherListeUtilisateur()
        {
            Console.WriteLine("Nombre d'elements de la liste:" + listedePages.Count);
            for (int i = 0; i < getTailleListedePage(); i++)
            {
                Console.Write("|" + listedePages[i].getnumPage());
            }
            Console.ReadLine();
        }
        //++++++++++++++++++++++++++++++++++++++++++++
        public int premiereCaseLibre() //retourne l'indice de la première case libre
        {
            return (memPhysique.getnbCasePage() - memPhysique.getnbCaseLibre());
        }
        public void afficherMemoirePhysique()
        {
            for (int i = 0; i < memPhysique.getnbCasePage(); i++)
            {
                Console.WriteLine("\t\t|\t{0}\t|", memPhysique.getContenu(i).getnumPage());
                
            }
            Console.ReadLine();
        }
        public Boolean pageExiste(int ip)
        {
            int i = 0;
            //parcours de la mémoire physique
            while (i < (memPhysique.getnbCasePage() - memPhysique.getnbCaseLibre()))
            {
                if ((memPhysique.getContenu(i)).getnumPage() == ip)
                {
                    return true;
                }
                else i++;
            }
            return false;
        }
        public void calculdefautPage(int numerodepage)
        {
            if (pageExiste(numerodepage) == false)
            {
                IncrDefautPages();
            }
        }
        public Boolean memoirePleine()
        {
            if (memPhysique.getnbCaseLibre() == 0)
            {
                return true;
            }
            else
                return false;
        }
        public void decCasesLibre() //Décrémenter le nombre de cases libres en mémoire physique
        {
            memPhysique.decrNbCaseLibre();
        }
        public void remplacerDansMemoire(PageCase p, int position)
        {
            memPhysique.modifPage(p, position);
        }

        //++++++++++++++++++++++++++++++++++++++++++++
        //creer une liste de page entree par l'utilisateur 
        public void creatlistePageUtil()
        {
            string numPage;
            while ((numPage = Console.ReadLine()) != null)
            {
                int nump = int.Parse(numPage);
                listedePages.Add(new PageCase(nump));
            }
        }
        //afficher la liste de page entree par l'utilisateur
        public void afficherListe()
        {
            foreach (PageCase pg in listedePages)
            {
                Console.WriteLine(pg.ToString());
            }
        }

        //Methode abstraite qui sera implémentée d'après la technique utilisée (FIFO, LRU, NFU, Aging)
        //Rôle: retourne le numéro de la case qui doit être remplacée dans la mémoire physique
        public abstract int OUremplacer(int positionCourr);

        //déroulement entier de l'algorithme
        public abstract void deroulerAlgorithme();
    }
}
