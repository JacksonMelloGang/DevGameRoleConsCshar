using System;
using System.Collections.Generic;
using System.Text;

namespace CreerLibrairie
{
    public class Personnage
    {

        #region private variables
        private String nom;
        private int positionX, positionY; // position
        
        private int health;
        private Arme weapon;
        #endregion

        #region Constructor
        /// <summary>
        /// Classe Constructeur, Créer un personnage
        /// </summary>
        /// <param name="p_nom">Nom du personnage</param>
        /// <param name="p_weapon">Arme du personnage</param>
        public Personnage(String p_nom, Arme p_weapon)
        {
            this.health = 100;
            this.positionX = 0;
            this.positionY = 0;

            // Args
            this.nom = p_nom;
            this.weapon = p_weapon;
        }
        #endregion


        // Methods
        public void SePresenter()
        {
            Console.WriteLine("Bonjour je suis " + this.nom + ", et j'ai une arme qui s'appelle " + this.weapon.NomDeLarme);
        }

        public void AttaquerunAdversaire(Personnage personnage, int damage)
        {
            personnage.health -= damage;
        }

        public void RecevoirDesDegats(int nombre)
        {
            this.health -= nombre;
        }

        public void SeDeplacer(int ajouterpositionX, int ajouterpositionY)
        {
            this.positionX += ajouterpositionX;
            this.positionY += ajouterpositionY;
        }

        public bool EnVie()
        {
            if(this.health > 0)
            {
                return true;
            }
            return false;
        }


        #region Getters and setters
        public string NomDuPersonnage { get => nom; set => nom = value;}
        public int PositionXDuPersonnage { get => positionX; }
        public int PositionYDuPersonnage { get => positionY; }
        public int VieDuPersonnage { get => health; set => health = value; }
        public Arme Arme { get => weapon; set => weapon = value; }
        #endregion
    }
}
