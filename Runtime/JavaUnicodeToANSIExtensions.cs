using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JavaneseToolkit
{
    public static class JavaUnicodeToANSIExtensions
    {
        public static Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
            { "ꦲ", "a" },      // ha 
            { "ꦤ", "n" },      // na
            { "ꦕ", "c" },      // ca
            { "ꦫ", "r" },      // ra
            { "ꦏ", "k" },      // ka
            { "ꦢ", "f" },      // da
            { "ꦠ", "t" },      // ta
            { "ꦱ", "s" },      // sa
            { "ꦮ", "w" },      // wa
            { "ꦭ", "l" },      // la
            { "ꦥ", "p" },      // pa
            { "ꦝ", "d"},      // dha
            { "ꦗ", "j" },      // ja
            { "ꦪ", "y" },      // ya
            { "ꦚ", "v" },     // nya
            { "ꦩ", "m" },      // sa
            { "ꦒ", "g" },      // ga
            { "ꦧ", "b" },      // ba
            { "ꦛ", "q" },      // tha
            { "ꦔ", "z" },     // nga
            { "ꦟ", "na" },      // na murda
            { "ꦑ", "ka" },       // ka murda
            { "ꦡ", "ta" },       // ta murda
            { "ꦯ", "sa" },      // sa murda
            { "ꦦ", "pa" },       // pa murda
            { "ꦘ", "nya" },      // nya murda
            { "ꦓ", "ga" },      // ga murda
            { "ꦨ", "ba" },       // ba murda
            { "ꦰ", "sa" },       // sa mahaprana
            { "ꦖ", "cha" },      // cha mahaprana
            { "ꦣ", "da" },       // da mahaprana
            { "ꦞ", "dha" },      // dha mahaprana
            { "ꦜ", "tha" },      // tha mahaprana
            { "ꦙ", "ja "},      // ja mahaprana
            { "ꦉ", "rê" },       // pa cêrêk
            { "ꦊ", "lê" },       // nga lêlêt
            { "ꦋ", "lêu" },      // nga lêlêt raswadi
            { "ꦐ", "qa" },       // ka sasak
            { "ꦬ", "ra" },       // ra agung
        };

        public static Dictionary<string, string> UNICODEPasanganWyanjana = new Dictionary<string, string>() {
            { "ꦲ", "H" },      // ha 
            { "ꦤ", "N" },      // na
            { "ꦕ", "C" },      // ca
            { "ꦫ", "R" },      // ra
            { "ꦏ", "K" },      // ka
            { "ꦢ", "F" },      // da
            { "ꦠ", "T" },      // ta
            { "ꦱ", "S" },      // sa
            { "ꦮ", "W" },      // wa
            { "ꦭ", "L" },      // la
            { "ꦥ", "P" },      // pa
            { "ꦝ", "D"},      // dha
            { "ꦗ", "J" },      // ja
            { "ꦪ", "Y" },      // ya
            { "ꦚ", "V" },     // nya
            { "ꦩ", "M" },      // sa
            { "ꦒ", "G" },      // ga
            { "ꦧ", "B" },      // ba
            { "ꦛ", "Q" },      // tha
            { "ꦔ", "Z" },     // nga
            { "ꦟ", "!" },      // na murda
            { "ꦑ", "@" },       // ka murda
            { "ꦡ", "#" },       // ta murda
            { "ꦯ", "$" },      // sa murda
            { "ꦦ", "%" },       // pa murda
            { "ꦘ", "^" },      // nya murda
            { "ꦓ", "&" },      // ga murda
            { "ꦨ", "*" },       // ba murda
            { "ꦰ", "Ȱ" },       // sa mahaprana
            { "ꦖ", "¬" },      // cha mahaprana
            // { "ꦣ", "da" },       // da mahaprana
            { "ꦞ", "Û" },      // dha mahaprana
            { "ꦜ", "æ" },      // tha mahaprana
            // { "ꦙ", "ja "},      // ja mahaprana
            { "ꦉ", "x" },       // pa cêrêk
            { "ꦊ", "X" },       // nga lêlêt
            { "ꦋ", "Ü" },      // nga lêlêt raswadi
            { "ꦐ", "è" },       // ka sasak
            { "ꦬ", "Ì" },       // ra agung
        };

        public static Dictionary<string, string> swara = new Dictionary<string, string> {
            { "ꦄ", "A" },        // a
            { "ꦆ", "I" },        // i 
            { "ꦈ", "U" },        // u 
            { "ꦌ", "E" },        // e 
            { "ꦎ", "O" },        // o 
        };

        // diacritics swara
        public static Dictionary<string, string> UNICODEsandhanganSwara = new Dictionary<string, string> {
            { "ꦶ", "i" },        // i
            { "ꦸ", "u" },        // u
            { "ꦼ", "ê" },        // e
            { "ꦷ", "»" },       // dirga melik, long i
            { "ꦹ", "×" },       // dirga mendut, long u
        };

        // diacritics swara
        public static Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string> {
            { "ꦿ", "]" },       // cakra
            { "ꦽ", "}" },       // cakra kêrêt
            { "ꦾ", "-" },      // pengkal
        };

        public static Dictionary<string, string> sandhanganPanyigegingWanda = new Dictionary<string, string> {
            { "ꦀ", "" },        // panyangga
            { "ꦂ", "/" },         // layar (r)
            { "ꦁ", "=" },        // cecak (ng)
            { "ꦃ", "h" },        // wigyan (h)
            { "꧀", "\\" },        // wigyan (h)
        };

        // punctuations
        public static Dictionary<string, string> pada = new Dictionary<string, string> {
            { "꧌", "" },           // left pada piseleh
            { "꧍", "" },           // right pada piseleh
            { "꧊", "" },           // adeg
            { "꧋", "" },           // adeg-adeg
            { "꧈", "," },          // pada lingsa
            { "꧉", "." },          // pada lungsi
            { "꧇", "" },           // pada pangkat
            { "꧆", "" },           // pada windu
            { "꧅", "" },        // pada luhur
            { "꧄", "" },        // pada madya
            { "꧃", "" },        // pada andhap
            { "꧞", "" },           // pada tirta tumetes
            { "꧟", "" },           // pada isen-isen
            { "꧁", "" },        // left rerengengan
            { "꧂", "" },        // right rerengengan
            { "︀", " "},
        };

        public static Dictionary<string, string> angka = new Dictionary<string, string> {
            { "ꧏ", "" },           // pararangkep
            { "꧑", "1" },        // angka 1
            { "꧒", "2" },        // angka 2
            { "꧓", "3" },        // angka 3
            { "꧔", "4" },        // angka 4
            { "꧕", "5" },        // angka 5
            { "꧖", "6" },        // angka 6
            { "꧗", "7" },        // angka 7
            { "꧘", "8" },        // angka 8
            { "꧙", "9" },        // angka 9
            { "꧐", "0" },        // angka 0
        };

        public static string JavaUnicodeToANSI(this string input) {
            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if(sandhanganWyanjana.ContainsKey(input[i].ToString())) {
                    output += sandhanganWyanjana[input[i].ToString()];
                } else if(UNICODEsandhanganSwara.ContainsKey(input[i].ToString())) {
                    output += UNICODEsandhanganSwara[input[i].ToString()];
                } else if(input[i] == '꧀') {
                    if(i + 1 < input.Length && UNICODEPasanganWyanjana.ContainsKey(input[i + 1].ToString())) {
                        output += UNICODEPasanganWyanjana[input[i + 1].ToString()];
                        i++;

                        if(i + 1 < input.Length && input[i + 1] == 'ꦺ') {
                            if(i + 2 < input.Length && input[i + 2] == 'ꦴ') {
                                output = output.Substring(0, output.Length - 2) + "[" + output.Substring(output.Length - 2) + "o";
                                i += 2;
                            } else {
                                output = output.Substring(0, output.Length - 2) + "[" + output.Substring(output.Length - 2);
                                i++;
                            }
                        }
                    } else {
                        output += sandhanganPanyigegingWanda[input[i].ToString()];
                    }
                } else if(sandhanganPanyigegingWanda.ContainsKey(input[i].ToString())) {
                    output += sandhanganPanyigegingWanda[input[i].ToString()];
                } else if(wyanjana.ContainsKey(input[i].ToString())) {
                    output += wyanjana[input[i].ToString()];
                } else if(input[i] == 'ꦺ') {
                    if(i + 1 < input.Length && input[i + 1] == 'ꦴ') {
                        output = output.Substring(0, output.Length - 1) + "[" + output.Substring(output.Length - 1) + "o";
                        i++;
                    } else {
                        output = output.Substring(0, output.Length - 1) + "[" + output.Substring(output.Length - 1);
                    }
                } else if(swara.ContainsKey(input[i].ToString())) {
                    output += swara[input[i].ToString()];
                } else if(pada.ContainsKey(input[i].ToString())) {
                    output += pada[input[i].ToString()];
                } else if(angka.ContainsKey(input[i].ToString())) {
                    output += angka[input[i].ToString()];
                } else {
                    output += input[i].ToString();
                }
                // Debug.Log(output);
            }
            return output;
        }
    }
}