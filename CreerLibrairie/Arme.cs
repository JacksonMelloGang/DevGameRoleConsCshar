using System;
using System.Collections.Generic;
using System.Text;

namespace CreerLibrairie
{
    public class Arme
    {
        #region Private variables
        private String weaponname;
        private int degats;
        #endregion

        #region Constructors

        public Arme(String p_name)
        {
            this.weaponname = p_name;
            this.degats = 10;
        }
        #endregion

        #region Getters and Setters
        public string NomDeLarme { get => weaponname; set => weaponname = value; }
        public int DegatDeLarme { get => degats; set => degats = value; }
        #endregion


    }
}
