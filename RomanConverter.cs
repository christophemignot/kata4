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
        private static readonly IEnumerable<KeyValuePair<char, int>> LettreRomaines = new Collection<KeyValuePair<char, int>>
                                                                                   {
                                                                                       new KeyValuePair<char, int>('I', 1),
                                                                                       new KeyValuePair<char, int>('V', 5),
                                                                                       new KeyValuePair<char, int>('X', 10),
                                                                                       new KeyValuePair<char, int>('L', 50),
                                                                                       new KeyValuePair<char, int>('C', 100),
                                                                                       new KeyValuePair<char, int>('D', 500),
                                                                                       new KeyValuePair<char, int>('M', 1000),
                                                                                   };
        /// <summary>
        /// Converti un nombre romain en entier
        /// </summary>
        /// <param name="number">nombre romain a convertir</param>
        /// <returns>valeur numérique</returns>
        public static int RomanNumberToInteger(string number)
        {
            // On valide le format de la chaine en parametre soit : 
            // 0 et 4 M     pour les milliers
            // CM ou CD ou D ou rien  + entre 0 et 3 C pour les centaines
            // XC ou XL ou L ou rien  + entre 0 et 3 X pour les dixaines
            // IX ou IV ou V ou rien  + entre 0 et 3 I pour les unités
            Regex expression = new Regex("^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            if (expression.IsMatch(number))
            {
                int[] tabValeur = new int[number.Length];
                // On parcours les valeurs, toutes celles qui sont suivis par une valeur suppérieure sont multiplié par -1 pour être retranchée
                for (int i = 0; i < tabValeur.Length; i++)
                {
                    tabValeur[i] = LettreRomaines.First(x => x.Key == number[i]).Value;

                    if (i != 0 && tabValeur[i] > tabValeur[i - 1])
                    {
                        tabValeur[i - 1] *= -1;
                    }
                }

                return tabValeur.Sum();
            }

            // nombre non pris en charge
            throw new IllegalNumberException();
        }

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
