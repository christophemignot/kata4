using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Kata.ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.UnitTests
{
    [TestClass]
    public class RomanCalculatorTest
    {
        [TestMethod]
        public void EntrerNombreRomainTest()
        {
            ICalculator calculator = new RomanCalculator();
            calculator.Entrer("I");
            Assert.AreEqual("I", calculator.NombreA);
            Assert.IsNull(calculator.NombreB);
        }

        [TestMethod]
        public void Entrer2NombresRomainTest()
        {
            ICalculator calculator = new RomanCalculator();
            calculator.Entrer("I");
            calculator.Entrer("II");
            Assert.AreEqual("I", calculator.NombreA);
            Assert.AreEqual("II", calculator.NombreB);
        }

        [TestMethod]
        public void Convert_I_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("I");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Convert_V_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("V");
            Assert.AreEqual(5, result);
        }


        [TestMethod]
        public void Convert_X_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("X");
            Assert.AreEqual(10, result);
        }


        [TestMethod]
        public void Convert_L_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("L");
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Convert_C_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("C");
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Convert_D_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("D");
            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Convert_M_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("M");
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void Convert_IV_RomanToInt_Test()
        {
            int result = RomanConverter.RomanNumberToInteger("IV");
            Assert.AreEqual(4, result);
        }
        
        [TestMethod]
        public void Convert_Complex_MLVIII_RomanToInt_Test()
        {
            /* 
             *  exemple                                     D    C    X    I   V
             * Tous doivent être de valeur décroissante
             * On marque celles qui ne le sont pas :        500  100  10  *1*  5
             * On ajoute toutes les valeurs sauf celles marquées, que l'on retranche.
             */
            int result = RomanConverter.RomanNumberToInteger("MLVIII");
            Assert.AreEqual(1058, result);
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MultipleLowerNumberSubstract_Test()
        {
            // On ne peut pas avoir deux nombres plus petit que le troisièmes
            RomanConverter.RomanNumberToInteger("IIV");
        }


        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanFourM_Test()
        {
            // Ca devrait être I¨v (pas possible ... on s'arrete a 4999 => MMMM CM XC IX)
            RomanConverter.RomanNumberToInteger("MMMMM");
        }


        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanThreeI_Test()
        {
            // Ca devrait être IV
            RomanConverter.RomanNumberToInteger("IIII");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanThreeX_Test()
        {
            // Ca devrait être XL
            RomanConverter.RomanNumberToInteger("XXXX");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanThreeC_Test()
        {
            // Ca devrait être CD
            RomanConverter.RomanNumberToInteger("CCCC");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanOneV_Test()
        {
            // Ca devrait être X (V + V = 10)
            RomanConverter.RomanNumberToInteger("VV");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanOneL_Test()
        {
            // Ca devrait être C (L + L = 100)
            RomanConverter.RomanNumberToInteger("LL");
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalNumberException))]
        public void IncorrectNumber_MoreThanOneD_Test()
        {
            // Ca devrait être M (D + D = 1000)
            RomanConverter.RomanNumberToInteger("DD");
        }

        [TestMethod]
        public void Convert100ToRoman()
        {
            string result = RomanConverter.IntegerToRomanNumber(100);
            Assert.AreEqual("C", result);
        }

        [TestMethod]
        public void Convert4ToRoman()
        {
            string result = RomanConverter.IntegerToRomanNumber(4);
            Assert.AreEqual("IV", result);
        }

        [TestMethod]
        public void Convert1999ToRoman()
        {
            /* 
             * Par puissance de 10 :
             *  3277 => MMM  CC  LXX VII
             *  Si on doit utiliser 4 symboles identiques, on repart du suivant en soustrayant : 400 => CCCC => CD
             *  Si on doit utiliser 5 symboles de la même unité, on repart de l'unité suivante en soustrayant : 900 => DCCCC => CM
             */
            string result = RomanConverter.IntegerToRomanNumber(1999);
            Assert.AreEqual("MCMXCIX", result);
        }

        [TestMethod]
        public void CalculerNombreRomainSimpleTest()
        {
            ICalculator calculator = new RomanCalculator();
            calculator.Entrer("I");
            calculator.Entrer("II");
            Assert.AreEqual("III", calculator.Add());
        }


        [TestMethod]
        public void CalculerNombreRomainComplexeTest()
        {
            ICalculator calculator = new RomanCalculator();
            calculator.Entrer("DCXIV"); // 614
            calculator.Entrer("DIV"); // 504
            Assert.AreEqual("MCXVIII", calculator.Add()); 
        }


        [TestMethod]
        public void CalculerMCLXXXIXComplexeTest()
        {
            ICalculator calculator = new RomanCalculator();
            calculator.Entrer("MCLXXXIV"); 
            calculator.Entrer("V"); 
            Assert.AreEqual("MCLXXXIX", calculator.Add());
        }

        [TestMethod]
        public void CalculerMMMCCLXXXVIComplexeTest()
        {
            ICalculator calculator = new RomanCalculator();
            calculator.Entrer("MMMCCLXXXV"); 
            calculator.Entrer("I"); 
            Assert.AreEqual("MMMCCLXXXVI", calculator.Add());
        }

    }
}
