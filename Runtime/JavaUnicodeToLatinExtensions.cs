using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JavaneseToolkit
{
    public static class JavaUnicodeToLatinExtensions 
    {
        public static Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
            { "ꦲ", "ha" },      // ha 
            { "ꦤ", "na" },      // na
            { "ꦕ", "ca" },      // ca
            { "ꦫ", "ra" },      // ra
            { "ꦏ", "ka" },      // ka
            { "ꦢ", "da" },      // da
            { "ꦠ", "ta" },      // ta
            { "ꦱ", "sa" },      // sa
            { "ꦮ", "wa" },      // wa
            { "ꦭ", "la" },      // la
            { "ꦥ", "pa" },      // pa
            { "ꦝ", "dha"},      // dha
            { "ꦗ", "ja" },      // ja
            { "ꦪ", "ya" },      // ya
            { "ꦚ", "nya" },     // nya
            { "ꦩ", "ma" },      // sa
            { "ꦒ", "ga" },      // ga
            { "ꦧ", "ba" },      // ba
            { "ꦛ", "ta" },      // tha
            { "ꦔ", "nga" },     // nga
            { "ꦟ", "na" },       // na murda
            { "ꦑ", "ka" },       // ka murda
            { "ꦡ", "ta" },       // ta murda
            { "ꦯ", "sa" },       // sa murda
            { "ꦦ", "pa" },       // pa murda
            { "ꦘ", "nya" },      // nya murda
            { "ꦓ", "ga" },       // ga murda
            { "ꦨ", "ba" },       // ba murda
            { "ꦰ", "sa" },       // sa mahaprana
            { "ꦖ", "cha" },      // cha mahaprana
            { "ꦣ", "da"},        // da mahaprana
            { "ꦞ", "dha" },      // dha mahaprana
            { "ꦜ", "tha" },      // tha mahaprana
            { "ꦉ", "rê" },       // pa cêrêk
            { "ꦊ", "lê" },       // nga lêlêt
            { "ꦋ", "lêu" },      // nga lêlêt raswadi
            { "å", "jha" },      // ja jera
            { "ꦐ", "qa" },       // ka sasak
            { "ꦙ", "ra" },       // ra agung
            { "ꦄ", "A" },        // a 
            { "ꦆ", "I" },        // i 
            { "ꦅ", "I" },        // i kawi
            { "ꦈ", "U" },        // u 
            { "ꦌ", "E" },        // e 
            { "ꦎ", "O" },        // o 
        };

        private static bool IsWyanjana(char c) {
            return IsWyanjana(c.ToString());
        }

        private static bool IsWyanjana(string s) {
            return wyanjana.ContainsKey(s);
        }

        // diacritics swara
        public static Dictionary<string, string> sandhanganSwara = new Dictionary<string, string> {
            { "ꦶ", "i" },        // i
            { "ꦸ", "u" },        // u
            { "ꦼ", "ê" },        // ê
            { "ꦺ", "e" },        // e
            { "ꦺꦴ", "o" },        // o
            { "ꦻ", "ai" },        // e
            { "ꦻꦴ", "au" },        // e
            { "ꦷ", "ii" },       // dirga melik, long i
            { "ꦹ", "uu" },       // dirga mendut, long u
        };

        private static bool IsSandhanganSwara(char c) {
            return IsSandhanganSwara(c.ToString());
        }

        private static bool IsSandhanganSwara(string s) {
            return sandhanganSwara.ContainsKey(s);
        }

        // diacritics swara
        public static Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string> {
            { "ꦿ", "ra" },       // cakra
            { "ꦽ", "rê" },       // cakra kêrêt
            { "ꦾ", "ya" },       // pengkal
        };

        private static bool IsSandhanganWyanjana(char c) {
            return IsSandhanganWyanjana(c.ToString());
        }

        private static bool IsSandhanganWyanjana(string s) {
            return sandhanganWyanjana.ContainsKey(s);
        }

        public static Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string> {
            { "ꦂ", "r" },        // layar (r)
            { "ꦁ", "ng" },       // cecak (ng)
            { "ꦃ", "h" },        // wigyan (h)
            { "꧀", "" },        // pangkon
        };

        private static bool IsSandhanganPanyigeg(char c) {
            return IsSandhanganPanyigeg(c.ToString());
        }

        private static bool IsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg.ContainsKey(s);
        }

        // punctuations
        public static Dictionary<string, string> pada = new Dictionary<string, string> {
            { "Í", "" },         // laku
            { "Î", "" },         // lila
            { "꧊", "" },        // adeg-adeg
            { "꧋", "" },         // adeg-adeg
            { "꧈", "," },        // pada lingsa
            { "꧉", "." },        // pada lungsi
            { "꧇", "" },         // pada pangkat
            { "ª", "" },         // pada pancak
            { "«", "" },         // pada windu
            { "Ä", "" },         // pada windu
            { "©", "" },         // pada guru
            { "¥", "" },         // pada luhur
            { "¦", "" },         // pada madya
            { "§", "" },         // pada andhap
            { "¡", "" },         // purwa pada
            { "¢", "" },         // madya pada
            { "£", "" },         // wasana pada
            { "¨", "_" },        // underscore
            { ":", ":" },        // colon
            { "¿", "?" },        // question mark
            { "À", "(" },        // left parenthesis
            { "Á", ")" },        // right parenthesis
            { "​", " "},
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

        public static string JavaUnicodeToLatin(this string str) {
            var length = str.Length;
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++) {
                var c = str[i];

                if(IsSandhanganWyanjana(c)) {
                    if(i - 1 >= 0 && IsWyanjana(str[i - 1])) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append(GetConsonantsSandhanganWyanjana(c));
                    continue;
                } 
                
                if(IsSandhanganSwara(c)) {
                    if(i - 1 >= 0 && IsWyanjana(str[i - 1])) {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    if(i + 1 < length) {
                        var c2 = str[i + 1];
                        var c12 = c.ToString() + c2.ToString();

                        if(IsTalingTarung(c12)) {
                            sb.Append(GetVowelsSandhanganSwara(c12));
                            i++;
                            continue;
                        }
                    }

                    sb.Append(GetVowelsSandhanganSwara(c));
                    continue;
                }
                
                if(IsSandhanganPanyigeg(c)) {
                    if(IsPangkon(c) && i - 1 >= 0 && IsWyanjana(str[i - 1])) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append(GetConsonantsSandhanganPanyigeg(c));
                    continue;
                }
                
                if(IsWyanjana(c)) {
                    sb.Append(GetConsonantsWyanjana(c));
                    continue;
                }
                
                if(IsPada(c)) {
                    sb.Append(GetPunctuations(c));
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

        private static bool IsTalingTarung(string s) {
            return s == "ꦺꦴ";
        }

        private static string GetConsonantsWyanjana(char c) {
            return GetConsonantsWyanjana(c.ToString());
        }

        private static string GetConsonantsWyanjana(string s) {
            return wyanjana[s];
        }

        private static string GetConsonantsSandhanganWyanjana(char c) {
            return GetConsonantsSandhanganWyanjana(c.ToString());
        }

        private static string GetConsonantsSandhanganWyanjana(string s) {
            return sandhanganWyanjana[s];
        }

        private static string GetConsonantsSandhanganPanyigeg(char c) {
            return GetConsonantsSandhanganPanyigeg(c.ToString());
        }

        private static string GetConsonantsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg[s];
        }

        private static string GetVowelsSandhanganSwara(char c) {
            return GetVowelsSandhanganSwara(c.ToString());
        }

        private static string GetVowelsSandhanganSwara(string s) {
            return sandhanganSwara[s];
        }
        
        private static string GetPunctuations(char c) {
            return GetPunctuations(c.ToString());
        }

        private static string GetPunctuations(string s) {
            return pada[s];
        }
    }
}