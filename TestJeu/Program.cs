using System;
using CreerLibrairie;

namespace ProgramMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour!");

            // Création d'instance d'armes
            Arme weapon001 = new Arme("Weapon001");
            Arme weapon002 = new Arme("Weapon002");

            // Création d'instance de personnages
            Personnage user001 = new Personnage("Sultana", weapon001);
            Personnage user002 = new Personnage("Personnage2", weapon002);

            // Création de la partie 
            Jeu jeu = new Jeu(user001, user002);
            jeu.LancerLeJeu(); // Démarrer la partie

            Console.ReadKey();

        }
    }
}
