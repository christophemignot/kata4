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
        public void Convert1ToRoman()
        {
            string result = RomanConverter.IntegerToRomanNumber(1);
            Assert.AreEqual("I", result);
        }
		
		[TestMethod]
        public void Convert10ToRoman()
        {
            string result = RomanConverter.IntegerToRomanNumber(10);
            Assert.AreEqual("X", result);
        }
		
		
        [TestMethod]
        public void Convert4ToRoman()
        {
            string result = RomanConverter.IntegerToRomanNumber(4);
            Assert.AreEqual("IV", result);
        }

        [TestMethod]
        public void Convert100ToRoman()
        {
            string result = RomanConverter.IntegerToRomanNumber(100);
            Assert.AreEqual("C", result);
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
    }
}
