using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata.ClassLib
{
    public static class RomanConverter
    {
        /// <summary>
        /// Converti un entier en nombre romain
        /// </summary>
        /// <param name="number">entier à convertir</param>
        /// <returns>nombre romain en lettres</returns>
        public static string IntegerToRomanNumber(int number)
        {
            StringBuilder sb = new StringBuilder();
            // par puissance de 10 à partir de 1000

            // unité des milliers du nombre total
            int unite = (int)(number / 1000);
            sb.Append(string.Empty.PadRight(unite, 'M'));

            // unité des centaines du nombre total
            number = number - unite * 1000;
            unite = (int)(number / 100);
            sb.Append(GetChiffreRomain(unite, 'C', 'D', 'M'));

            // unité des dizaines du nombre total
            number = number - unite * 100;
            unite = (int)(number / 10);
            sb.Append(GetChiffreRomain(unite, 'X', 'L', 'C'));

            // unité du nombre total
            number = number - unite * 10;
            sb.Append(GetChiffreRomain(number, 'I', 'V', 'X'));
            return sb.ToString();

        }

        /// <summary>
        /// converti un chiffre (de 0 a 9) en nombre romain en fonction des lettres correspondant à l'unité à afficher
        /// </summary>
        /// <param name="chiffre">chiffre (de 0 a 9)</param>
        /// <param name="un">lettre représentant l'unité (C pour les centaines, X pour les dixaine par exemple)</param>
        /// <param name="cinq">lettre représentant la valeur 5 de l'unité (V pour 5, D pour les centaine, L pour les dixaines)</param>
        /// <param name="dix">lettre représentant la valeur 10 de l'unité (X pour les unités, C pour les dixaines, M pour les centaines)</param>
        /// <returns>chaine représentant le chiffre en lettres</returns>
        private static string GetChiffreRomain(int chiffre, char un, char cinq, char dix)
        {
            if (chiffre != 0)
            {
                string result = string.Empty;
                // Pour un chiffre = à 9, on retranche une unité de dix unités (doit IX pour 9, XC pour 90, ...)
                if (chiffre == 9)
                {
                    result = un.ToString() + dix;
                }
                else
                {
                    // Pour un chiffre compris entre 4 et 8, on affiche la valeur de 5 unités. 
                    if (chiffre >= 4 && chiffre < 9)
                    {
                        result = cinq.ToString();
                        chiffre -= 5;
                    }

                    // si c'était 4, on retranche 1
                    if (chiffre < 0)
                    {
                        result = un + result;
                    }

                    // si c'était entre 6 et 8 on complete avec des 'un'
                    if (chiffre > 0)
                    {
                        result = result.PadRight(result.Length + chiffre, un);
                    }
                }
                return result;
            }
            return string.Empty;
        }
    }
}
