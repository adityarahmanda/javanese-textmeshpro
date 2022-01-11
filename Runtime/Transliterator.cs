using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JavaneseToolkit 
{
    public class Transliterator
    {
        #region ANSI Based Transliterator
        public static Dictionary<string, string> aksaraWyanjana = new Dictionary<string, string>() {
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
        public static Dictionary<string, string> pasanganWyanjana = new Dictionary<string, string> {
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

        public static Dictionary<string, string> aksaraSwara = new Dictionary<string, string> {
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

        public static string JavaToLatin(string input) {
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
                } else if(pasanganWyanjana.ContainsKey(input[i].ToString())) {
                    if(talingValuePos == i) {
                        output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + pasanganWyanjana[input[i].ToString()].Substring(0, pasanganWyanjana[input[i].ToString()].Length - 1) + "e";
                        isWyanjana = false;
                    } else {
                        output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + pasanganWyanjana[input[i].ToString()];
                        isWyanjana = true; 
                    }
                } else if(sandhanganSwara.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, isWyanjana ? output.Length - 1 : output.Length) + sandhanganSwara[input[i].ToString()];
                    isWyanjana = false;
                } else if(input[i] == '[') {
                    for(int j = 1; j <= 5; j++) {
                        talingValuePos = i + j;

                        if(i + (j + 1) > input.Length - 1 || input[i + (j + 1)] == 'o' || aksaraWyanjana.ContainsKey(input[i + (j + 1)].ToString())) {
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
                } else if(aksaraWyanjana.ContainsKey(input[i].ToString())) {
                    if(talingValuePos == i) {
                        output = output.Substring(0, output.Length) + aksaraWyanjana[input[i].ToString()].Substring(0, aksaraWyanjana[input[i].ToString()].Length - 1) + "e";
                        isWyanjana = false;
                    } else {
                        output = output.Substring(0, output.Length) + aksaraWyanjana[input[i].ToString()];
                        isWyanjana = true;
                    }
                } else if(pada.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + pada[input[i].ToString()];
                } else {
                    output = output.Substring(0, output.Length) + input[i].ToString();
                }
                Debug.Log(output);
            }
            return output;
        }
        #endregion

        #region Unicode Based Transliterator
        public static Dictionary<string, string> letters = new Dictionary<string, string>() {
            { "ꦲ", "ha"},
            { "ꦤ", "na"},
            { "ꦟ", "na" },     // na murda
            { "ꦕ", "ca"},
            { "ꦖ", "ca" },     // ca murda
            { "ꦫ", "ra"},
            { "ꦬ", "ra" },     // ra Agung
            { "ꦏ", "ka"},
            { "ꦑ", "ka" },     // ka murda
            { "ꦢ", "da"},
            { "ꦣ", "da" },     // da murda
            { "ꦠ", "ta"},
            { "ꦡ", "ta" },     // ta murda
            { "ꦱ", "sa"},
            { "ꦯ", "sa" },     // sa murda
            { "ꦰ", "ṣa" },     // sa mahaprana
            { "ꦮ", "wa"},
            { "ꦭ", "la"},
            { "ꦥ", "pa"},
            { "ꦦ", "pa" },     // pa murda
            { "ꦝ", "dha"},     // dha/ḍa
            { "ꦞ", "dha" },    // dha/ḍa Murda
            { "ꦗ", "ja"},
            { "ꦙ", "ja" },    // ja Mahaprana
            { "ꦪ", "ya"},
            { "ꦚ", "nya"},    // nya/ña
            { "ꦘ", "nya" },    // ja Sasak, nya/ña Murda
            { "ꦩ", "ma"},
            { "ꦒ", "ga"},
            { "ꦓ", "ga" },    // ga murda
            { "ꦧ", "ba"},
            { "ꦨ", "bʰa" },    // ba murda
            { "ꦛ", "tha"},     // tha/ṭa 
            { "ꦜ", "ṭʰa" },    // tha/ṭa murda
            { "ꦔ", "nga"},     // nga/ŋa
            { "ꦉ", "rê" },     // pa cêrêk
            { "ꦊ", "lê" },     // nga lêlêt
            { "ꦋ", "lêu" },    // nga lêlêt raswadi -- archaic
            { "ꦐ", "qa" },     // ka sasak
        };

        public static Dictionary<string, string> letterRekans = new Dictionary<string, string> {
            { "ꦲ꦳", "ḥa" },
            { "ꦏ꦳", "kha" },
            { "ꦢ꦳", "dza" },
            { "ꦱ꦳", "sya" },
            { "ꦥ꦳", "fa" },
            { "ꦗ꦳", "za" },
            { "ꦒ꦳", "gha" },
            { "ꦔ꦳", "'a" },
        };

        public static Dictionary<string, string> letterSwara = new Dictionary<string, string> {
            { "ꦄ", "A" },      //swara-A
            { "ꦅ", "I" },      //I-Kawi -- archaic
            { "ꦆ", "I" },      //I
            { "ꦇ", "I" },     //Ii -- archaic
            { "ꦈ", "U" },      //U
            { "ꦌ", "E" },      //E
            { "ꦍ", "Ai" },     //Ai
            { "ꦎ", "O" },      //O
        };

        public static Dictionary<string, string> diacriticsWyanjana = new Dictionary<string, string>() {
            { "ꦿ", "ra"},
            { "ꦾ", "ya"},
            { "ꦽ", "rê"},
        };

        public static Dictionary<string, string> diacriticsSwara = new Dictionary<string, string>() {
            { "ꦴ", "aa"},
            { "ꦶ", "i"},
            { "ꦷ", "ii" }, 
            { "ꦸ", "u"},
            { "ꦹ", "uu" }, 
            { "ꦺ", "e"},
            { "ꦼ", "ê"},
            { "ꦻ", "ai" }, 
        };

        public static Dictionary<string, string> diacriticsSigeg = new Dictionary<string, string>() {
            { "ꦀ", "m"},
            { "ꦁ", "ng"},    // sigeg ng/ŋ
            { "ꦂ", "r"},
            { "ꦃ", "h"}
        };

        public static Dictionary<string, string> numbers = new Dictionary<string, string> {
            { "꧐", "0" }, 
            { "꧑", "1" }, 
            { "꧒", "2" }, 
            { "꧓", "3" }, 
            { "꧔", "4" }, 
            { "꧕", "5" }, 
            { "꧖", "6" }, 
            { "꧗", "7" }, 
            { "꧘", "8" }, 
            { "꧙", "9" }
        };

        public static Dictionary<string, string> specialCharacters = new Dictionary<string, string>() {
            { "꧁", "—" }, 
            { "꧂", "—" }, 
            { "꧃", "—" }, 
            { "꧄", "—" }, 
            { "꧅", "—" },
            { "꧊", "" },
            { "꧋", "" },
            { "꧌", "(" },
            { "꧍", ")" },
            { "꧞", "—" }, 
            { "꧟", "—" },
            { "꧆", "" }, 
            { "꧇", "" },
            { "꧈", "," }, 
            { "꧉", "." },  
            { "​", " " }    // zero-width space
        };

        public static string UnicodeJavaToLatin(string input) {
            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if(letters.ContainsKey(input[i].ToString())) {
                    if(i + 1 < input.Length && input[i + 1] == '꦳') {
                        output = output.Substring(0, output.Length) + letterRekans[input[i].ToString() + "꦳"];
                        i++;
                    } else {
                        output = output.Substring(0, output.Length) + letters[input[i].ToString()];
                    }
                } else if(letterSwara.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + letterSwara[input[i].ToString()];
                } else if(i - 1 > 0 && input[i] == '꧀' && letters.ContainsKey(input[i - 1].ToString())) {
                    output = output.Substring(0, output.Length - 1);
                } else if(diacriticsWyanjana.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length - 1) + diacriticsWyanjana[input[i].ToString()];
                } else if(diacriticsSwara.ContainsKey(input[i].ToString())) {
                    if(i + 1 < input.Length && input[i] == 'ꦺ' && input[i + 1] == 'ꦴ') {
                        output = output.Substring(0, output.Length - 1) + "o";
                        i++;
                    } else {
                        output = output.Substring(0, output.Length - 1) + diacriticsSwara[input[i].ToString()];
                    }
                } else if(diacriticsSigeg.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + diacriticsSigeg[input[i].ToString()];
                } else if(numbers.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + numbers[input[i].ToString()];
                } else if(specialCharacters.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + specialCharacters[input[i].ToString()];
                } else {
                    output = output.Substring(0, output.Length) + input[i].ToString();
                }
            }
            return output;
        }

        public static Dictionary<string, string> oneLetterConsonant = new Dictionary<string, string>() {
            { "b", "ꦧ" },
            { "c", "ꦕ" },
            { "d", "ꦢ" },
            { "f", "ꦥ꦳" },
            { "g", "ꦒ" },
            { "h", "ꦲ" },
            { "j", "ꦗ" },
            { "k", "ꦏ" },
            { "l", "ꦭ" },
            { "m", "ꦩ" },
            { "n", "ꦤ" },
            { "ṇ", "ꦟ" },
            { "p", "ꦥ" },
            // { "q", "꧀" },
            { "r", "ꦫ" },
            { "s", "ꦱ" },
            { "ś", "ꦯ" },
            { "ṣ", "ꦰ" },
            { "t", "ꦠ" },
            { "v", "ꦮ꦳" },
            { "w", "ꦮ" },
            // { "x", "ꦲꦼ" },
            { "y", "ꦪ" },
            { "z", "ꦗ꦳" },
            { "ñ", "ꦚ" }, //ny
            { "ḍ", "ꦝ" },
            { "ṭ", "ꦛ" },
            // { "ṛ", "ꦽ" }
            { "A", "ꦄ" },
            { "I", "ꦆ" },
            { "U", "ꦈ" },
            { "E", "ꦌ" },
            { "È", "ꦌ" },
            { "É", "ꦌ" },
            { "Ê", "ꦄꦼ" },
            { "Ě", "ꦄꦼ" },
            { "O", "ꦎ" },
        };

        public static Dictionary<string, string> twoLettersConsonants = new Dictionary<string, string>() {
            { "dz", "ꦢ꦳" },
            { "gh", "ꦒ꦳" },
            { "kh", "ꦏ꦳" },
            { "ng", "ꦔ" },
            { "ny", "ꦚ" }
        };

        public static Dictionary<string, string> diacriticsConsonant = new Dictionary<string, string>() {
            { "h", "ꦃ" },
            { "r", "ꦿ" },
            { "y", "ꦾ" },
            { "ṛ", "ꦽ" },
        };

        public static Dictionary<string, string> vowels = new Dictionary<string, string>() {
            { "a", "" },
            { "i", "ꦶ" },
            { "u", "ꦸ" },
            { "e", "ꦺ" },
            { "è", "ꦺ" },
            { "é", "ꦺ" },
            { "ê", "ꦼ" },
            { "ě", "ꦼ" },
            { "o", "ꦺꦴ" },
            { "ô", "" },
        };
        
        public static string UnicodeLatinToJava(string input) {
            string output = "";
            // bool isConsonant = false;
            // bool isVowel = false;
            for (int i = 0; i < input.Length; i++) {
                if(i + 1 < input.Length && twoLettersConsonants.ContainsKey(input[i].ToString() + input[i + 1].ToString())) {
                    output = output.Substring(0, output.Length) + twoLettersConsonants[input[i].ToString() + input[i + 1].ToString()];
                    i++;
                } else if(oneLetterConsonant.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + oneLetterConsonant[input[i].ToString()];
                } else if(diacriticsConsonant.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + diacriticsConsonant[input[i].ToString()];
                } else if(vowels.ContainsKey(input[i].ToString())) {
                    output = output.Substring(0, output.Length) + vowels[input[i].ToString()];
                }
            }
            return output;
        }
        #endregion
    }
}