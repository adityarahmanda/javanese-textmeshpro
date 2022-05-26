using System;
using System.Collections.Generic;

namespace JVTMPro.Utilities
{
    /// <summary>
    /// Description
    /// </summary>
    public static class Transliterator
    {
        private static LatinToJava latinToJava = new LatinToJava();
        private static JavaToLatin javaToLatin = new JavaToLatin();

        /// <summary>
        /// Convert latin characters to javanese characters
        /// </summary>
        /// <param name="text">The text to be converted</param>
        /// <param name="murda">If enabled, the first character of ꦤ, ꦏ, ꦠ, ꦱ, ꦥ, ꦘ, ꦒ, ꦧ will be converted into its murda form ꦟ, ꦑ, ꦡ, ꦯ, ꦦ, ꦟ, ꦓ, ꦨ.</param>
        /// <param name="ignoreSpace">If enabled, space character will not be converted int zero width space</param>
        /// <param name="diphthong">If enabled, latin diphthong will be converted into javanese dipthong</param>
        public static string LatinToJava(string text, bool murda = false, bool ignoreSpace = false, bool diphthong = false) {
            return latinToJava.Transliterate(text, murda, ignoreSpace, diphthong);
        }

        /// <summary>
        /// Convert javanese characters to latin characters
        /// </summary>
        /// <param name="text">The text to be converted</param>
        public static string JavaToLatin(string text) {
            return javaToLatin.Transliterate(text);
        }
    }
}