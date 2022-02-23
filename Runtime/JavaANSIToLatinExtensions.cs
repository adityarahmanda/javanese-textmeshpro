using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JavaneseToolkit
{
    public static class JavaANSIToLatinExtensions 
    {
        public static Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
            { "a", "ha" },      // ha 
            { "n", "na" },      // na
            { "c", "ca" },      // ca
            { "r", "ra" },      // ra
            { "k", "ka" },      // ka
            { "f", "da" },      // da
            { "t", "ta" },      // ta
            { "s", "sa" },      // sa
            { "w", "wa" },      // wa
            { "l", "la" },      // la
            { "p", "pa" },      // pa
            { "d", "dha"},      // dha
            { "j", "ja" },      // ja
            { "y", "ya" },      // ya
            { "v", "nya" },     // nya
            { "m", "ma" },      // sa
            { "g", "ga" },      // ga
            { "b", "ba" },      // ba
            { "q", "ta" },      // tha
            { "z", "nga" },     // nga
            { "!", "na" },       // na murda
            { "@", "ka" },       // ka murda
            { "#", "ta" },       // ta murda
            { "$", "sa" },       // sa murda
            { "%", "pa" },       // pa murda
            { "^", "nya" },      // nya murda
            { "&", "ga" },       // ga murda
            { "*", "ba" },       // ba murda
            { "Ȱ", "sa" },       // sa mahaprana
            { "¬", "cha" },      // cha mahaprana
            { "Û", "dha" },      // dha mahaprana
            { "æ", "tha" },      // tha mahaprana
            { "x", "rê" },       // pa cêrêk
            { "X", "lê" },       // nga lêlêt
            { "Ü", "lêu" },      // nga lêlêt raswadi
            { "å", "jha" },      // ja jera
            { "è", "qa" },       // ka sasak
            { "Ì", "ra" },       // ra agung
            { "ß", "ba" },       // ba murda for diacritics suku, cakra, keret, pengkal
            { "à", "ku" },       // ka murda + suku (u)
            { "A", "A" },        // a 
            { "ȩ", "Ai" },       // ai 
            { "I", "I" },        // i 
            { "U", "U" },        // u 
            { "E", "E" },        // e 
            { "O", "O" },        // o 
        };

        private static bool IsWyanjana(char c) {
            return IsWyanjana(c.ToString());
        }

        private static bool IsWyanjana(string s) {
            return wyanjana.ContainsKey(s);
        }

        // conjunct
        public static Dictionary<string, string> pasangan = new Dictionary<string, string> {
            { "H", "ha" },       // ha pasangan
            { "N", "na" },       // na pasangan
            { "C", "ca" },       // ca pasangan
            { "R", "ra" },       // ra pasangan
            { "K", "ka" },       // ka pasangan
            { "F", "da" },       // da pasangan
            { "T", "ta" },       // ta pasangan
            { "S", "sa" },       // sa pasangan
            { "W", "wa" },       // wa pasangan
            { "L", "la" },       // la pasangan
            { "P", "pa" },       // pa pasangan
            { "D", "dha" },      // dha pasangan
            { "J", "ja" },       // ja pasangan
            { "Y", "ya" },       // ya pasangan
            { "V", "nya" },      // nya pasangan
            { "M", "ma" },       // ma pasangan
            { "G", "ga" },       // ga pasangan
            { "B", "ba" },       // ba pasangan
            { "Q", "tha" },      // tha pasangan
            { "Z", "nga" },      // nga pasangan
            { "®", "na" },       // na murda pasangan
            { "¯", "ka" },       // ka murda pasangan
            { "°", "ta" },       // ta murda pasangan
            { "±", "sa" },       // sa murda pasangan
            { "²", "pa" },       // pa murda pasangan
            { "³", "nya" },      // nya murda pasangan
            { "´", "ga" },       // ga murda pasangan
            { "µ", "ba" },       // ba murda pasangan
            { ">", "rê" },       // pa cêrêk pasangan
            { "<", "lê" },       // nga lêlêt pasangan
            // { "?", "lêu" },      // nga lêlêt raswadi pasangan
            { "é", "qa" },      // ka sasak pasangan
            { "Ð", "cha" },      // cha mahaprana pasangan 
            { "ä", "dha" },      // dha mahaprana pasangan 
            { "ç", "tha" },      // tha mahaprana pasangan
            // { "?", "ra" },       // ra agung pasangan
            { "Ñ", "ka" },       // ka pasangan for diacritics suku, cakra, keret, pengkal
            { "Ò", "ta" },       // ta pasangan for diacritics suku, cakra, keret, pengkal 
            { "Ó", "la" },       // la pasangan for diacritics suku, cakra, keret, pengkal
            { "Ô", "dha" },      // dha pasangan for diacritics suku, cakra, keret, pengkal 
            { "Õ", "tha" },      // tha pasangan for diacritics suku, cakra, keret, pengkal
            { "â", "ba" },       // ba murda pasangan for diacritics suku, cakra, keret, pengkal
            { "á", "ku" },       // ka murda pasangan + suku (u)
            { "Ö", "nu" },       // na pasangan + suku (u)
            { "Ø", "nra" },      // na pasangan + cakra
            { "Ù", "nrê" },      // na pasangan + cakra kêrêt
            { "¶", "A" },       // aksara swara a pasangan
            { "ý", "Ai" },      // aksara swara ai pasangan
            { "·", "I" },       // aksara swara i pasangan
            { "¸", "U" },       // aksara swara u pasangan
            { "¹", "E" },       // aksara swara e pasangan
            { "º", "O" },       // aksara swara o pasangan
        };

        private static bool IsPasangan(char c) {
            return IsPasangan(c.ToString());
        }

        private static bool IsPasangan(string s) {
            return pasangan.ContainsKey(s);
        }

        // diacritics swara
        public static Dictionary<string, string> sandhanganSwara = new Dictionary<string, string> {
            { "i", "i" },        // i
            { "u", "u" },        // u
            { "e", "ê" },        // e
            { "»", "ii" },       // dirga melik, long i
            { "×", "uu" },       // dirga mendut, long u
            { "|", "u" },        // u for pasangan
            /*
            { "_", "ing" },      // i + cecak (ng)
            { "Æ", "ê" },        // rekan + ê
            { "Ë", "i" },        // rekan + i
            { "Ç", "r" },        // rekan + layar (r)
            { "Ê", "ng" },       // rekan + cecak (ng)
            { "È", "ing" },      // rekan + i + cecak (ng)
            */
        };

        private static bool IsSandhanganSwara(char c) {
            return IsSandhanganSwara(c.ToString());
        }

        private static bool IsSandhanganSwara(string s) {
            return sandhanganSwara.ContainsKey(s);
        }

        // diacritics swara
        public static Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string> {
            { "]", "ra" },       // cakra
            { "}", "rê" },       // cakra kêrêt
            { "-", "ya" },       // pengkal
            { "Â", "ya" },       // pengkal for pasangan (short pengkal)
            { "Ã", "ya" },       // pengkal for pasangan (tall pengkal)
            { "(", "ru" },       // cakra + u
            { "`", "ra" },       // cakra for pasangan
            { ")", "ru" },       // cakra + u for pasangan 
            { "~", "re" },       // cakra keret for pasangan
        };

        private static bool IsSandhanganWyanjana(char c) {
            return IsSandhanganWyanjana(c.ToString());
        }

        private static bool IsSandhanganWyanjana(string s) {
            return sandhanganWyanjana.ContainsKey(s);
        }

        public static Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string> {
            { "/", "r" },        // layar (r)
            { "=", "ng" },       // cecak (ng)
            { "h", "h" },        // wigyan (h)
            { "\\", "" },        // pangkon
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
            { "\"", "" },        // adeg-adeg
            { "?", "" },         // adeg-adeg
            { ",", "," },        // pada lingsa
            { ".", "." },        // pada lungsi
            { ";", "" },         // pada pangkat
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
            { "1", "1" },        // angka 1
            { "2", "2" },        // angka 2
            { "3", "3" },        // angka 3
            { "4", "4" },        // angka 4
            { "5", "5" },        // angka 5
            { "6", "6" },        // angka 6
            { "7", "7" },        // angka 7
            { "8", "8" },        // angka 8
            { "9", "9" },        // angka 9
            { "0", "0" },        // angka 0
        };

        private static bool IsPada(char c) {
            return IsPada(c.ToString());
        }

        private static bool IsPada(string s) {
            return pada.ContainsKey(s);
        }

        public static string JavaANSIToLatin(this string str) {
            int talingValuePos = -1;

            var length = str.Length;
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++) {
                var c = str[i];

                if(IsSandhanganWyanjana(c)) {
                    if(talingValuePos == i) {
                        if(i - 1 >= 0 && (IsWyanjana(str[i - 1]) || IsPasangan(str[i - 1]))) {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append(GetConsonantsSandhanganWyanjana(c));
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("e");
                        continue;
                    }

                    if(i - 1 >= 0 && (IsWyanjana(str[i - 1]) || IsPasangan(str[i - 1]))) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append(GetConsonantsSandhanganWyanjana(c));
                    continue;
                } 
                
                if(IsPasangan(c)) {
                    if(talingValuePos == i) {
                        if(i - 1 >= 0 && (IsWyanjana(str[i - 1]) || IsPasangan(str[i - 1]))) {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append(GetConsonantsPasangan(c));
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("e");
                        continue;
                    }

                    if(i - 1 >= 0 && (IsWyanjana(str[i - 1]) || IsPasangan(str[i - 1]))) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append(GetConsonantsPasangan(c));
                    continue;
                }
                
                if(IsSandhanganSwara(c)) {
                    if(i - 1 >= 0 && (IsWyanjana(str[i - 1]) || IsPasangan(str[i - 1]))) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append(GetVowelsSandhanganSwara(c));
                    continue;
                }
                
                if(IsTaling(c)) {
                    if(i + 1 < length && IsWyanjana(str[i + 1])) {
                        for(int j = i + 2; j <= length; j++) {
                            talingValuePos = j - 1;
                            if(j == length) break;
                            if(IsWyanjana(str[j])) break;
                        }
                        Debug.Log(talingValuePos);
                    }
                    continue;
                }
                
                if(IsTarung(c)) {
                    if(talingValuePos != -1 && talingValuePos == i) {
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("o");
                    }
                    continue;
                }
                
                if(IsSandhanganPanyigeg(c)) {
                    if(IsPangkon(c)) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append(GetConsonantsSandhanganPanyigeg(c));
                    continue;
                }
                
                if(IsWyanjana(c)) {
                    if(talingValuePos == i) {
                        sb.Append(GetConsonantsWyanjana(c));
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("e");
                        continue;
                    }
                    
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

        private static bool IsTaling(char c) {
            return c == '[';
        }

        private static bool IsTarung(char c) {
            return c == 'o';
        }

        private static bool IsPangkon(char c) {
            return c == '\\';
        }

        private static string GetConsonantsWyanjana(char c) {
            return GetConsonantsWyanjana(c.ToString());
        }

        private static string GetConsonantsWyanjana(string s) {
            return wyanjana[s];
        }

        private static string GetConsonantsPasangan(char c) {
            return GetConsonantsPasangan(c.ToString());
        }

        private static string GetConsonantsPasangan(string s) {
            return pasangan[s];
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