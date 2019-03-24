using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    public class SystemAging : PageReplacement
    {
        //List<PageCase> listeAging = new List<PageCase>();
        List<TabledePage> pageTable = new List<TabledePage>();
        uint v = 0b_10000000;
        public SystemAging(int tailleMV, int taillePage, int tailleMP) : base(tailleMV, taillePage, tailleMP)
        {
            //Créer la table de page 
            for (int i = 0; i < memVirtuelle.getnbCasePage(); i++)
            {
                pageTable.Add(new TabledePage(i));
            }
        }
        public void afficherTabledePage()
        {
           // Console.WriteLine("Nombre d'elements de la table:" + memVirtuelle.getnbCasePage());
            for (int i = 0; i < memVirtuelle.getnbCasePage(); i++)
            {
                Console.WriteLine("Page | {0} || Pr| {1} || R|    {2}     || Case | {3}", pageTable[i].getnumPage(), pageTable[i].getPr(), pageTable[i].getR(), pageTable[i].getnumCase());
            }
            Console.ReadLine();
        }
        /***********LA MEMOIRE EST PLEINE _DONC UNE PAGE DE POSITION "positon" DANS LA MP SERA REMPLACER ************/
        public override int OUremplacer(int positionCourr)
        {
            int i = 0; int k = 0; uint min = 1; int position = -1; bool stop = false; bool findmin = false;
            while (!findmin)
            {
                if (pageExiste(getListei(i).getnumPage()))
                {
                    min = pageTable[getListei(i).getnumPage()].getR();
                    findmin = true;
                }
                i++;
            }
            i = 0;
            while (i < positionCourr)
            {
                if (pageExiste(getListei(i).getnumPage()))
                {
                    if (pageTable[getListei(i).getnumPage()].getR() < min)
                    {
                        min = pageTable[getListei(i).getnumPage()].getR();
                    }
                }
                i++;
            }
            Console.WriteLine("min={0}", min);

            while (k < positionCourr && !stop)
            {
                if ((min == pageTable[getListei(k).getnumPage()].getR()) && (pageExiste(getListei(k).getnumPage())))
                {
                    stop = true;
                    position = getListei(k).getNumCase();
                    getListei(positionCourr).setNumeroCase(position);
                    getListei(k).setNumeroCase(-1);
                    pageTable[getListei(k).getnumPage()].setPr(0);
                }
                k++;
            }
            return position;
            throw new NotImplementedException();
        }
        //****************DEROULEMENT DE LA METHODE Aging***********************//
        public override void deroulerAlgorithme()
        {
            Console.WriteLine("La liste de pages:");
            afficherListeUtilisateur();
            Console.WriteLine("\t\t\tContenu memoire physique:");
            afficherMemoirePhysique();
            Console.WriteLine("Nombre de defauts de page: " + getDefautPage());
            Console.WriteLine("La table de pages:");
            afficherTabledePage();
            /*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
            int i = 0; int j = 0;
            //parcourir la liste de page 
            while (i < getTailleListedePage())
            {
               
             
                if (!pageExiste(getListei(i).getnumPage()))
                {
                    IncrDefautPages();
                    if (!memoirePleine())
                    {
                        getListei(i).setNumeroCase(premiereCaseLibre());
                        //Console.WriteLine("getListei({0}).getNumCase()={1}", i, getListei(i).getNumCase());
                        pageTable[getListei(i).getnumPage()].setnumCase(premiereCaseLibre());
                        memPhysique.modifPage(getListei(i), premiereCaseLibre());
                        memPhysique.decrNbCaseLibre();
                    }
                    else
                    {
                        int q = OUremplacer(i);
                        Console.WriteLine("position = {0}",q);
                        getListei(i).setNumeroCase(q);
                        pageTable[getListei(i).getnumPage()].setnumCase(q);
                        memPhysique.modifPage(getListei(i), q);
                        Console.WriteLine(" la page {0} est dans la case {1}", getListei(i).getnumPage(), getListei(i).getNumCase());
                    }
                }
                else
                {
                    bool find = false; int k = 0;
                    while (!find)
                    {
                        if (getListei(k).getnumPage() == getListei(i).getnumPage())
                        {
                            find = true;
                            getListei(i).setNumeroCase(getListei(k).getNumCase());
    Console.WriteLine("La page {0} existe deja dans la MP dans la case {1} ", getListei(i).getnumPage(), getListei(k).getNumCase());
                        }
                        k++;
                    }
                }
                //_____________________________________
                pageTable[getListei(i).getnumPage()].setPr(1); //mettre le bit de presence a 1 
                //decalage a droite de tous les Ri (registre de reference) dans la table de page 
                j = 0;
                while (j < pageTable.Count)
                {
                    //Console.WriteLine("pageTable[{0}].getR()={1}", j, pageTable[j].getR());                   
                    uint Rdec = pageTable[j].getR() / 2;
                    //Console.WriteLine("Rdec= {0}", Rdec);
                    pageTable[j].setR(Rdec);
                    //Console.WriteLine("pageTable[{0}].getR()={1}", j, pageTable[j].getR());
                    j++;
                }
                pageTable[getListei(i).getnumPage()].setR(pageTable[getListei(i).getnumPage()].getR() | v); //ou logique avec "10000000"
                //_____________________________________
                Console.WriteLine("Nombre de defauts de page: " + getDefautPage());
                Console.WriteLine("\t\t\tContenu interm memoire physique:");
                afficherMemoirePhysique();
                Console.WriteLine("La table de pages:");
                afficherTabledePage();
                i++;
            }
            /*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
            Console.WriteLine("\t\t\tContenu final memoire physique:");
            afficherMemoirePhysique();
            Console.WriteLine("Nombre final de defauts de page: " + getDefautPage());
            Console.WriteLine("La table de pages finale:");
            afficherTabledePage();
            throw new NotImplementedException();
        }

    }
}
