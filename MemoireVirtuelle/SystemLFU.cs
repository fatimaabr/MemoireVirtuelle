using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    public class SystemLFU : PageReplacement
    {
        //List<PageCase> listeLFU = new List<PageCase>();
        List<PageCaseLFU> cpt = new List<PageCaseLFU>();
        //constructeur
        public SystemLFU(int tMV, int tPage, int tMP) : base(tMV, tPage, tMP)
        {
            //Créer la liste des frequences
            for (int i = 0; i < memVirtuelle.getnbCasePage(); i++)
            {
                cpt.Add(new PageCaseLFU(0, i));
            }
        }
        public void afficherListeFrequence()
        {
            Console.WriteLine("Nombre d'elements de la liste des frequences:" + memVirtuelle.getnbCasePage());
            for (int i = 0; i < memVirtuelle.getnbCasePage(); i++)
            {
                Console.WriteLine("|p {0}||frequ {1}|", cpt[i].getPagenum(), cpt[i].getfrequence());
            }
            Console.ReadLine();
        }
        /***********LA MEMOIRE EST PLEINE _DONC UNE PAGE DE POSITION "positon" DANS LA MP SERA REMPLACER ************/
        public override int OUremplacer(int positionCourr)
        {
            int i = 0; int k = 0; int min = 1; int position = -1; bool stop = false; bool findmin = false;
            while (!findmin)
            {
                if (pageExiste(getListei(i).getnumPage()))
                {
                    min = cpt[getListei(i).getnumPage()].getfrequence();
                    findmin = true;
                }
                i++;
            }
            i = 0;
            while (i < positionCourr)
            {
                if (pageExiste(getListei(i).getnumPage()))
                {
                    if (cpt[getListei(i).getnumPage()].getfrequence() < min)
                    {
                        min = cpt[getListei(i).getnumPage()].getfrequence();
                    }
                }
                i++;
            }
            //Console.WriteLine("min ={0}", min);
            //Console.WriteLine("la ferqu min {0}", min);

            while (k < positionCourr && !stop)
            {
                //Console.WriteLine("cpt[getListei({0}).getnumPage()].getfrequence() = {1}",k,cpt[getListei(k).getnumPage()].getfrequence());
                //Console.WriteLine("pageExiste(getListei({0}).getnumPage()) = {1}",k, pageExiste(getListei(k).getnumPage()));
                if ((min == cpt[getListei(k).getnumPage()].getfrequence()) && (pageExiste(getListei(k).getnumPage())))
                {
                    stop = true;
                    position = getListei(k).getNumCase();
                    getListei(positionCourr).setNumeroCase(position);
                    getListei(k).setNumeroCase(-1);
                }
                k++;
            }
            return position;
            throw new NotImplementedException();
        }
        //****************DEROULEMENT DE LA METHODE LFU*************************//
        public override void deroulerAlgorithme()
        {
            Console.WriteLine("La liste de pages:");
            afficherListeUtilisateur();
            Console.WriteLine("\tContenu memoire physique:");
            afficherMemoirePhysique();
            Console.WriteLine("Nombre de defauts de page: " + getDefautPage());
            Console.WriteLine("Les frequences des pages:");
            afficherListeFrequence();
            /*________________________________*****__________________________________*/
            int i = 0;
            //parcourir la liste de page 
            while (i < getTailleListedePage())
            {
                
                //tant que la memoire physique n'est pas pleine 

                if (!pageExiste(getListei(i).getnumPage()))
                {
                    IncrDefautPages();
                    if (!memoirePleine())
                    {                        
                        getListei(i).setNumeroCase(premiereCaseLibre());
                        memPhysique.modifPage(getListei(i), premiereCaseLibre());
                        memPhysique.decrNbCaseLibre();
                        //Console.WriteLine(" getListei(2).getNumCase()= {0}", getListei(2).getNumCase());
                    }
                    else
                    {
                        int q = OUremplacer(i);
                        //Console.WriteLine("position = {0}",q);
                        getListei(i).setNumeroCase(q);
                        memPhysique.modifPage(getListei(i),q);
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
                cpt[getListei(i).getnumPage()].incrfrequence();
                Console.WriteLine("\t\t\tContenu intermediaire de la memoire physique:");
                afficherMemoirePhysique();
                i++;
            }
            /*________________________________*****__________________________________*/
            Console.WriteLine("\t\t\t******************Contenu final de la memoire physique:*******************");
            afficherMemoirePhysique();
            Console.WriteLine("Nombre de defauts de page: " + getDefautPage());
            Console.WriteLine("Les frequences des pages:");
            afficherListeFrequence();
            Console.ReadLine();
            throw new NotImplementedException();
        }
    }
}
