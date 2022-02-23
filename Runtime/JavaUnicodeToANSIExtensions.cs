using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
            { "ꦣ", "?" },       // da mahaprana
            { "ꦞ", "Û" },      // dha mahaprana
            { "ꦜ", "æ" },      // tha mahaprana
            { "ꦙ", "å"},      // ja jera / mahaprana
            { "ꦉ", "x" },       // pa cêrêk
            { "ꦊ", "X" },       // nga lêlêt
            { "ꦋ", "Ü" },      // nga lêlêt raswadi
            { "ꦐ", "è" },       // ka sasak
            { "ꦬ", "Ì" },       // ra agung
            { "ꦄ", "A" },        // A
            { "ꦍ", "ȩ" },       // Ai
            { "ꦆ", "I" },        // I 
            { "ꦈ", "U" },        // U 
            { "ꦌ", "E" },        // E 
            { "ꦎ", "O" },        // O 
        };

        private static bool IsWyanjana(char c) {
            return IsWyanjana(c.ToString());
        }

        private static bool IsWyanjana(string s) {
            return wyanjana.ContainsKey(s);
        }

        private static bool IsWyanjanaANSI(char c) {
            return IsWyanjanaANSI(c.ToString());
        }

        private static bool IsWyanjanaANSI(string s) {
            return wyanjana.ContainsValue(s);
        }
        
        private static string GetWyanjana(char c) {
            return GetWyanjana(c.ToString());
        }

        private static string GetWyanjana(string s) {
            return wyanjana[s];
        }

        public static Dictionary<string, string> pasanganWyanjana = new Dictionary<string, string>() {
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
            { "ꦟ", "®" },      // na murda
            { "ꦑ", "¯" },       // ka murda
            { "ꦡ", "°" },       // ta murda
            { "ꦯ", "±" },      // sa murda
            { "ꦦ", "²" },       // pa murda
            { "ꦘ", "³" },      // nya murda
            { "ꦓ", "´" },      // ga murda
            { "ꦨ", "µ" },       // ba murda
            { "ꦰ", "?" },       // sa mahaprana
            { "ꦖ", "Ð" },      // cha mahaprana
            { "ꦣ", "?" },       // da mahaprana
            { "ꦞ", "ä" },      // dha mahaprana
            { "ꦜ", "ç" },      // tha mahaprana
            { "ꦙ", "? "},      // ja jera / mahaprana
            { "ꦉ", "<" },       // pa cêrêk
            { "ꦊ", ">" },       // nga lêlêt
            { "ꦋ", "?" },      // nga lêlêt raswadi
            { "ꦐ", "é" },       // ka sasak
            { "ꦬ", "?" },       // ra agung
            { "ꦄ", "¶" },        // A
            { "ꦍ", "ý" },          // Ai
            { "ꦆ", "·" },        // I 
            { "ꦈ", "¸" },        // U 
            { "ꦌ", "¹" },        // E 
            { "ꦎ", "º" },        // O 
        };

        private static string GetPasanganWyanjana(char c) {
            return GetPasanganWyanjana(c.ToString());
        }

        private static string GetPasanganWyanjana(string s) {
            return pasanganWyanjana[s];
        }


        // diacritics swara
        public static Dictionary<string, string> sandhanganSwara = new Dictionary<string, string> {
            { "ꦶ", "i" },        // i
            { "ꦸ", "u" },        // u
            { "ꦼ", "ê" },        // e
            { "ꦷ", "»" },       // dirga melik, long i
            { "ꦹ", "×" },       // dirga mendut, long u
        };

        private static bool IsSandhanganSwara(char c) {
            return IsSandhanganSwara(c.ToString());
        }

        private static bool IsSandhanganSwara(string s) {
            return sandhanganSwara.ContainsKey(s);
        }

        private static string GetSandhanganSwara(char c) {
            return GetSandhanganSwara(c.ToString());
        }

        private static string GetSandhanganSwara(string s) {
            return sandhanganSwara[s];
        }

        // diacritics swara
        public static Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string> {
            { "ꦿ", "]" },       // cakra
            { "ꦽ", "}" },       // cakra kêrêt
            { "ꦾ", "-" },      // pengkal
        };

        private static bool IsSandhanganWyanjana(char c) {
            return IsSandhanganWyanjana(c.ToString());
        }

        private static bool IsSandhanganWyanjana(string s) {
            return sandhanganWyanjana.ContainsKey(s);
        }

        private static string GetSandhanganWyanjana(char c) {
            return GetSandhanganWyanjana(c.ToString());
        }

        private static string GetSandhanganWyanjana(string s) {
            return sandhanganWyanjana[s];
        }

        public static Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string> {
            { "꦳", "+" },        // cecak telu
            { "ꦀ", "" },        // panyangga
            { "ꦂ", "/" },         // layar (r)
            { "ꦁ", "=" },        // cecak (ng)
            { "ꦃ", "h" },        // wigyan (h)
            { "꧀", "\\" },        // wigyan (h)
        };

        private static bool IsSandhanganPanyigeg(char c) {
            return IsSandhanganPanyigeg(c.ToString());
        }

        private static bool IsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg.ContainsKey(s);
        }

        private static string GetSandhanganPanyigeg(char c) {
            return GetSandhanganPanyigeg(c.ToString());
        }

        private static string GetSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg[s];
        }

        // punctuations
        public static Dictionary<string, string> pada = new Dictionary<string, string> {
            { "︀", "​"},           // zero width non joiner
            { "꧊", "\"" },         // adeg
            { "꧋", "?" },         // adeg-adeg
            { "ꧏ", "." },        // pangkrangkep
            { "꧞", "«" },        // tirta tumetes
            { "꧟", "." },        // isen-isen
            { "꧌", "(" },        // pada piseleh
            { "꧍", ")" },        // turned pada piseleh
            { "꧁", "" },        // left rerenggan
            { "꧂", "" },        // right rerenggan
            { "꧈", "," },        // pada lingsa
            { "꧉", "." },        // pada lungsi
            { "꧆", "Ä" },        // pada windu
            { "꧃", "§" },         // pada andhap
            { "꧄", "¦" },         // pada madya
            { "꧅", "¥" },         // pada luhur
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

        private static bool IsPada(char c) {
            return IsPada(c.ToString());
        }

        private static bool IsPada(string s) {
            return pada.ContainsKey(s);
        }

        private static string GetPada(char c) {
            return GetPada(c.ToString());
        }

        private static string GetPada(string s) {
            return pada[s];
        }

        public static string JavaUnicodeToANSI(this string str) {
            var length = str.Length;
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++) {
                var c = str[i];

                if(IsSandhanganWyanjana(c)) {
                    sb.Append(GetSandhanganWyanjana(c));
                    continue;
                }
                
                if(IsSandhanganSwara(c)) {
                    sb.Append(GetSandhanganSwara(c));
                    continue;
                }
                
                if(i + 1 < length && IsPangkon(c)) {
                    var c2 = str[i + 1];

                    if(IsWyanjana(c2)) {
                        sb.Append(GetPasanganWyanjana(c2));
                        i++;
                    }

                    if(i == length - 1) {
                        sb.Append("\\");
                    }

                    continue;
                }
                
                if(IsSandhanganPanyigeg(c)) {
                    sb.Append(GetSandhanganPanyigeg(c));
                    continue;
                }
                
                if(IsWyanjana(c)) {
                    sb.Append(GetWyanjana(c));
                    continue;
                }
                
                if(IsTaling(c)) {
                    int talingPos = -1;
                    for(int j = sb.Length - 1; j >= 0; j--) {
                        talingPos = j;
                        if(IsWyanjanaANSI(sb[j])) break;
                    }
                    sb.Insert(talingPos, "[");

                    if(i + 1 < length) {
                        var c2 = str[i + 1];
                        var c12 = c.ToString() + c2.ToString();

                        if(IsTalingTarung(c12)) {
                            sb.Append("o");
                            i++;
                        }
                    }

                    continue;
                }
                
                if(IsSandhanganSwara(c)) {
                    sb.Append(GetSandhanganSwara(c));
                    continue;
                }
                
                if(pada.ContainsKey(str[i].ToString())) {
                    sb.Append(GetPada(c));
                    continue;
                }

                sb.Append(c);
                // Debug.Log(output);
            }

            return sb.ToString();
        }

         private static bool IsPangkon(char c) {
            return c == '꧀';
        }

        private static bool IsTaling(char c) {
            return c == 'ꦺ' || c == 'ꦻ';
        }

        private static bool IsTalingTarung(string s) {
            return s == "ꦺꦴ" || s == " ꦻꦴ";
        }
    }
}