using System;
using System.Collections.Generic;

namespace JVTMPro.Utilities
{
    /// <summary>Perkakas untuk mentransliterasikan teks Latin-Jawa atau Jawa-Latin.</summary>
    /// <example>
    /// <code lang="csharp">
    /// using UnityEngine;
    /// using JVTMPro;
    /// using JVTMPro.Utilities;
    ///
    /// public class ExampleScript : MonoBehaviour
    /// {
    ///    [SerializeField] private JVTextMeshPro sampleText;
    ///
    ///     private void Start()
    ///     {
    ///         // Mentransliterasikan teks menjadi aksara Jawa dan menerapkan hasilnya pada teks sampleText
    ///         sampleText.text = Transliterator.LatinToJava("aja rumangsa bisa, nanging bisaa rumangsa");
    ///     }
    /// }
    /// </code>
    /// </example>
    public static class Transliterator
    {
        private static LatinToJava latinToJava = new LatinToJava();
        private static JavaToLatin javaToLatin = new JavaToLatin();

        /// <summary>Mentransliterasikan teks huruf Latin menjadi aksara Jawa</summary>
        /// <param name="text">Teks yang akan ditransliterasikan</param>
        /// <param name="murda">
        /// Saat bernilai true, aksara murda yang khususnya digunakan dalam penulisan nama, gelar, 
        /// atau tempat dalam penulisan aksara Jawa akan diturutsertakan dalam proses transliterasi.
        /// </param>
        /// <param name="dirga">
        /// Saat bernilai true, vokal rangkap 'ai', 'au', 'aa', 'ii', dan 'uu' akan dikonversikan menjadi 
        /// sandangan swara dirga.
        /// </param>
        /// <param name="ignoreSpace">
        /// Saat bernilai true, spasi dari kolom masukan akan diabaikan dalam proses transliterasi. 
        /// Sebaliknya saat bernilai false, spasi akan dikonversikan menjadi zero width space (spasi tak nampak).
        /// </param>
        /// <returns>Hasil luaran dari proses transliterasi</returns>
        public static string LatinToJava(string text, bool murda = false, bool dirga = false, bool ignoreSpace = true) {
            return latinToJava.Transliterate(text, murda, dirga, ignoreSpace);
        }

        /// <summary>Mentransliterasikan teks aksara Jawa menjadi huruf Latin</summary>
        /// <param name="text">Teks yang akan ditransliterasikan</param>
        /// <returns>Hasil luaran dari proses transliterasi</returns>
        public static string JavaToLatin(string text) {
            return javaToLatin.Transliterate(text);
        }
    }
}