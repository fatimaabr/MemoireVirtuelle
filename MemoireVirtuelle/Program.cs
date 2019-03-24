using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoireVirtuelle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creation de 8 pages
            PageCase p0 = new PageCase(0);
            PageCase p1 = new PageCase(1);
            PageCase p2 = new PageCase(2);
            PageCase p3 = new PageCase(3);
            PageCase p4 = new PageCase(4);
            PageCase p5 = new PageCase(5);
            PageCase p6 = new PageCase(6);
            PageCase p7 = new PageCase(7);

            
             //***** LFU  *****//
             

            //Creation d'un systeme LFU
            /* SystemLFU lfu = new SystemLFU(1024, 128, 512); //768 étant la taille de mémoire physique et 256 la taille de la case/page mémoire

            //Charger la liste de l'utilisateur
            lfu.ajouterAListe(p2);
            lfu.ajouterAListe(p0);
            lfu.ajouterAListe(p3);
            lfu.ajouterAListe(p2);
            lfu.ajouterAListe(p0);
            lfu.ajouterAListe(p5);
            lfu.ajouterAListe(p7);
            lfu.ajouterAListe(p1);
            lfu.ajouterAListe(p3);
            lfu.ajouterAListe(p1);
            lfu.ajouterAListe(p6);

            //Simuler la gestion avec algorithme LFU
            lfu.deroulerAlgorithme(); */

            //-**** Aging  *****-//


            //Creation d'un systeme Aging
            SystemAging aging = new SystemAging(1024, 128, 512); //768 étant la taille de mémoire physique et 256 la taille de la case/page mémoire

            //Charger la liste de l'utilisateur
            aging.ajouterAListe(p2);
            aging.ajouterAListe(p0);
            aging.ajouterAListe(p3);
            aging.ajouterAListe(p2);
            aging.ajouterAListe(p0);
            aging.ajouterAListe(p5);
            aging.ajouterAListe(p7);
            aging.ajouterAListe(p1);
            aging.ajouterAListe(p3);
            aging.ajouterAListe(p1);
            aging.ajouterAListe(p6);

            //Simuler la gestion avec algorithme Aging
            aging.deroulerAlgorithme();

        }
    }
}
