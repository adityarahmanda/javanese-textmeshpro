using System.Collections;
using System.Collections.Generic;
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
        };

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
        };

        public static Dictionary<string, string> swara = new Dictionary<string, string> {
            { "A", "A" },        // a 
            { "ȩ", "Ai" },       // ai 
            { "I", "I" },        // i 
            { "U", "U" },        // u 
            { "E", "E" },        // e 
            { "O", "O" },        // o 
        };

        public static Dictionary<string, string> pasanganSwara = new Dictionary<string, string> {
            { "¶", "A" },       // aksara swara a pasangan
            { "ý", "Ai" },      // aksara swara ai pasangan
            { "·", "I" },       // aksara swara i pasangan
            { "¸", "U" },       // aksara swara u pasangan
            { "¹", "E" },       // aksara swara e pasangan
            { "º", "O" },       // aksara swara o pasangan
        };

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

        public static Dictionary<string, string> sandhanganPanyigegingWanda = new Dictionary<string, string> {
            { "/", "r" },        // layar (r)
            { "=", "ng" },       // cecak (ng)
            { "h", "h" },        // wigyan (h)
            { "\\", "" },        // pangkon
        };

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
        };

        public static Dictionary<string, string> angka = new Dictionary<string, string> {
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

        public static string JavaANSIToLatin(this string input) {
            bool isWyanjana = false;
            int talingValuePos = -1;
            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if(sandhanganWyanjana.ContainsKey(input[i].ToString())) {
                    if(talingValuePos == i) {
                        output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + sandhanganWyanjana[input[i].ToString()].Substring(0, sandhanganWyanjana[input[i].ToString()].Length - 1) + "e";
                        isWyanjana = false;
                    } else {
                        output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + sandhanganWyanjana[input[i].ToString()];
                        isWyanjana = true;
                    }
                } else if(pasangan.ContainsKey(input[i].ToString())) {
                    if(talingValuePos == i) {
                        output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + pasangan[input[i].ToString()].Substring(0, pasangan[input[i].ToString()].Length - 1) + "e";
                        isWyanjana = false;
                    } else {
                        output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + pasangan[input[i].ToString()];
                        isWyanjana = true; 
                    }
                } else if(sandhanganSwara.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + sandhanganSwara[input[i].ToString()];
                    isWyanjana = false;
                } else if(input[i] == '[') {
                    for(int j = 1; j <= 5; j++) {
                        talingValuePos = i + j;

                        if(i + (j + 1) > input.Length - 1 || input[i + (j + 1)] == 'o' || wyanjana.ContainsKey(input[i + (j + 1)].ToString())) {
                            break;
                        }
                    }
                } else if (input[i] == 'o') {
                    if(talingValuePos != -1 && i - 1 == talingValuePos) {
                        output = output.Substring(0, output.Length - 1) + "o";
                        isWyanjana = false;
                    }
                } else if(sandhanganPanyigegingWanda.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, input[i] == '\\' ? output.Length - 1 : output.Length) + sandhanganPanyigegingWanda[input[i].ToString()];
                    isWyanjana = false;
                } else if(wyanjana.ContainsKey(input[i].ToString())) {
                    if(talingValuePos == i) {
                        output += wyanjana[input[i].ToString()].Substring(0, wyanjana[input[i].ToString()].Length - 1) + "e";
                        isWyanjana = false;
                    } else {
                        output += wyanjana[input[i].ToString()];
                        isWyanjana = true;
                    }
                } else if(pada.ContainsKey(input[i].ToString())) {
                    output += pada[input[i].ToString()];
                } else {
                    output += input[i].ToString();
                }
                // Debug.Log(output);
            }
            return output;
        }       
    }
}