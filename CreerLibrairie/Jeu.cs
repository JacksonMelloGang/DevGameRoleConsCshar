using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CreerLibrairie
{
    public class Jeu
    {
         
        private Personnage joueur1;
        private Personnage joueur2;

        // Tounois Vars
        private int nbtournoi;
        private int tournoigagnerparj1;
        private int tournoigagnerparj2;

        private bool tournoienabled = false;


        #region Constructor
        public Jeu(Personnage p_perso1, Personnage p_perso2)
        {
            this.joueur1 = p_perso1;
            this.joueur2 = p_perso2;
        }
        #endregion



        #region Main Method
        public void LancerLeJeu()
        {
            Console.Write("Activer le mode tournoi ? (1/0)");
            int reponsemodetournoienabled = int.Parse(Console.ReadLine());
            
            //Choix de l'activation du mode tournoi
            switch (reponsemodetournoienabled)
            {
                case 1:
                    tournoienabled = true;
                    Console.WriteLine("Mode Tournoi activé. ");
                    break;
                case 0:
                    tournoienabled = false;
                    Console.WriteLine("Mode Tournoi non activé.");
                    break;
                default:
                    break;
            }


            // Si le mode tournoi est activé effectuer une loop 
            if (tournoienabled)
            {
                // Tant que le mode tournoi est activé.
                while (tournoienabled)
                {
                    nbtournoi += 1; // Nouveau tournoi
                    EffectuerPartie(); 


                    Console.WriteLine("Fin de partie");
                    
                    // Demande si l'on quite ou non le mode tournoi
                    Console.WriteLine("Voulez vous quitter le mode tournoi ? Oui/Non");
                    String reponsequittertournoi = Console.ReadLine();
                    if (reponsequittertournoi.ToLower() == "oui")
                    {
                        tournoienabled = true;
                        Console.WriteLine("Poursuite en mode tournoi.");
                        RegenererPersonnage();
                    }
                    else
                    {
                        tournoienabled = false;
                        Console.WriteLine("Arrêt du mode tournoi.");
                    }

                }
            } else
            {
                EffectuerPartie();
            }

            
            AfficherResultat(tournoienabled);



            Console.ReadKey();
        }
        #endregion

        #region Miscs Methods
        public int LancerleDe()
        {
            Random rd = new Random();
            Thread.Sleep(300);
            return rd.Next(1, 7);
        }

        public bool FinDePartie()
        {
            if(this.joueur1.EnVie() && !this.joueur2.EnVie()) {
                return true;
            }

            if (this.joueur2.EnVie() && !this.joueur1.EnVie())
            {
                return true;
            }

            return false;
        }

        public void RegenererPartie()
        {
            nbtournoi = 0;
            tournoigagnerparj1 = 0;
            tournoigagnerparj2 = 0;
        }

        public void RegenererPersonnage()
        {
            joueur1.VieDuPersonnage = 100;
            joueur2.VieDuPersonnage = 100;
        }

        /// <summary>
        /// Effectuer UNE SEULE partie
        /// </summary>
        private void EffectuerPartie()
        {


            Console.WriteLine("Que la partie commence !");

            int de_perso1 = LancerleDe();
            joueur1.SePresenter();

            int de_perso2 = LancerleDe();
            joueur2.SePresenter();

            int i = 0;
            //déterminer qui joue en premier
            if (de_perso1 > de_perso2)
            {
                i = 1;
            }

            //Tant que la partie n'est pas fini (que les 2 joueurs sont en vie)
            while (!FinDePartie())
            {
                int degats = 0;
                if (i == 1)
                {
                    // Tour du joueur 1
                    Console.WriteLine("----------------------\n C'est au tour de " + joueur1.NomDuPersonnage + ", tapez sur une touche \n----------------------");
                    Console.ReadKey();
                    degats = LancerleDe();
                    joueur1.AttaquerunAdversaire(joueur2, degats);
                    Console.WriteLine("j'inflige " + degats + " de  dégâts à " + joueur2.NomDuPersonnage);
                    i = 0;
                }
                else
                {
                    // Tour du joueur 2
                    Console.WriteLine("----------------------\n C'est au tour de " + joueur2.NomDuPersonnage + ", tapez sur une touche \n----------------------");
                    Console.ReadKey();
                    degats = LancerleDe();
                    joueur2.AttaquerunAdversaire(joueur2, LancerleDe());
                    Console.WriteLine("j'inflige " + degats + " de  dégâts à " + joueur1.NomDuPersonnage);
                    i = 1;
                }
            }

            // SI le joueur 1 est en vie, incrémenter de 1 le nb de tournoi gagner par joueur 1 sinon incrémenter de 1 nb de tournoi gagner par joueur 2
            if(joueur1.EnVie())
            {
                tournoigagnerparj1 += 1;
            } else
            {
                tournoigagnerparj2 += 1;
            }

        }




        /// <summary>
        /// // Afficher resultat en fonction de si le mode tournoi est activé ou non
        /// </summary>
        /// <param name="tournoienabled">Tournoi Activé ?</param>
        private void AfficherResultat(bool tournoienabled)
        {
            if (tournoienabled)
            {
                Console.WriteLine("\n-----------------------------------------------------\n");
                Console.WriteLine("Vous avez effectué " + nbtournoi + " tournois.");
                Console.WriteLine("Le joueur 1 à gagner " + tournoigagnerparj1);
                Console.WriteLine("Le joueur 2 à gagner " + tournoigagnerparj2);
                Console.WriteLine("\n-----------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("\n-----------------------------------------------------\n");
                Console.WriteLine("Le joueur 1 à gagner " + tournoigagnerparj1 + " tournois");
                Console.WriteLine("Le joueur 2 à gagner " + tournoigagnerparj2 + " tournois");
                Console.WriteLine("\n-----------------------------------------------------\n");
            }


        }
        #endregion

        #region Getters & Setters
        public int Tournoi { get => this.nbtournoi; }
        public int TounoiParJ1 { get => tournoigagnerparj1; }
        public int TounoiParJ2 { get => tournoigagnerparj2; }

        #endregion



    }
}
