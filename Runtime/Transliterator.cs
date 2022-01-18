using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JavaneseToolkit 
{
    public static class Transliterator
    {
        
        #region Latin To Java
        public static Dictionary<string, string> consonants = new Dictionary<string, string>() {
            { "b", "b" },       // ba
            { "c", "c" },       // ca
            { "d", "f" },       // da
            { "dz", "f+" },     // dza rekan
            { "f", "p+" },      // fa rekan
            { "g", "g" },       // ga
            { "gh", "g+" },     // gha rekan
            { "h", "a" },       // ha
            { "j", "j" },       // ja
            { "k", "k" },       // ka
            { "kh", "k+" },     // kha rekan
            { "l", "l" },       // la
            { "m", "m" },       // ma
            { "n", "n" },       // na
            { "ṇ", "!" },       // na murda
            { "ng", "z" },      // nga
            { "ny", "v" },       // nya
            { "p", "p" },       // pa
            // { "q", "꧀" },
            { "r", "r" },       // ra
            { "s", "s" },       // sa
            { "ś", "$" },       // sa murda
            { "ṣ", "Ȱ" },       // sa mahaprana
            { "t", "t" },       // ta
            { "v", "w+" },      // va rekan
            { "w", "w" },       // wa
            // { "x", "ꦲꦼ" },
            { "y", "y" },       // ya
            { "z", "j+" },      // za rekan
            { "ñ", "v" },       // nya
            { "ḍ", "d" },       // dha
            { "ṭ", "q" },       // tha
            // { "ṛ", "ꦽ" }
            { "A", "A" },       // aksara swara a
            { "I", "I" },       // aksara swara i
            { "U", "U" },       // aksara swara u
            { "E", "E" },       // aksara swara e
            { "È", "E" },       // aksara swara e
            { "É", "E" },       // aksara swara e
            { "Ê", "Ee" },      // aksara swara ê
            { "Ě", "Ee" },      // aksara swara ê
            { "O", "O" },       // aksara swara o
        };

        public static Dictionary<string, string> consonantPasangan = new Dictionary<string, string>() {
            { "b", "B" },       // ba
            { "c", "C" },       // ca
            { "d", "F" },       // da
            { "dz", "F+" },     // dza rekan
            { "f", "P+" },      // fa rekan
            { "g", "G" },       // ga
            { "gh", "G+" },     // gha rekan
            { "h", "H" },       // ha
            { "j", "J" },       // ja
            { "k", "K" },       // ka
            { "kh", "K+" },     // kha rekan
            { "l", "L" },       // la
            { "m", "M" },       // ma
            { "n", "N" },       // na
            { "ṇ", "!" },       // na murda
            { "ng", "Z" },      // nga
            { "ny", "V" },       // nya
            { "p", "P" },       // pa
            // { "q", "꧀" },
            { "r", "R" },       // ra
            { "s", "S" },       // sa
            { "ś", "$" },       // sa murda
            { "ṣ", "Ȱ" },       // sa mahaprana
            { "t", "T" },       // ta
            { "v", "W+" },      // va rekan
            { "w", "W" },       // wa
            // { "x", "ꦲꦼ" },
            { "y", "Y" },       // ya
            { "z", "J+" },      // za rekan
            { "ñ", "V" },       // nya
            { "ḍ", "D" },       // dha
            { "ṭ", "Q" },       // tha
            // { "ṛ", "ꦽ" }
            { "A", "¶" },       // aksara swara a
            { "I", "·" },       // aksara swara i
            { "U", "¸" },       // aksara swara u
            { "E", "¹" },       // aksara swara e
            { "È", "¹" },       // aksara swara e
            { "É", "¹" },       // aksara swara e
            { "Ê", "¹e" },      // aksara swara ê
            { "Ě", "¹e" },      // aksara swara ê
            { "O", "º" },       // aksara swara o
        };

        public static Dictionary<string, string> consonantSandhanganWyanjana = new Dictionary<string, string>() {
            { "r", "]" },
            { "y", "-" },
            { "ṛ", "}" },
        };

        public static Dictionary<string, string> consonantSandhanganPanyigeg = new Dictionary<string, string>() {
            { "r", "/" },
            { "h", "h" }, 
            { "ng", "=" },
        };

        public static Dictionary<string, string> vowels = new Dictionary<string, string>() {
            { "a", "" },
            { "ô", "" },
            { "i", "i" },
            { "u", "u" },
            { "e", "[" },
            { "è", "[" },
            { "é", "[" },
            { "ê", "e" },
            { "ě", "e" },
            { "o", "[o" },
        };

        public static Dictionary<string, string> punctuations = new Dictionary<string, string>() {
            { " ", "​" },
        };

        public static string LatinToJava(this string input) {
            bool isConsonant = false;
            bool isPasangan = false;

            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == 'g') {
                    if(i + 1 < input.Length && input[i + 1] == 'h') {
                        if(isConsonant) {
                            output += consonantPasangan["gh"];
                            isConsonant = true;
                            isPasangan = true;
                        } else {
                            output += consonants["gh"];

                            if(i == input.Length - 2) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                        i++;
                    } else {
                        if(isConsonant) {
                            output += consonantPasangan["g"];
                            isConsonant = true;
                            isPasangan = true;
                        } else {
                            output += consonants["g"];
                            
                            if(i == input.Length - 1) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                    }
                } else if (input[i] == 'k') {
                    if(i + 1 < input.Length && input[i + 1] == 'h') {
                            if(isConsonant) {
                                output += consonantPasangan["kh"];
                                isConsonant = true;
                                isPasangan = true;
                            } else {
                                output += consonants["kh"];
                                
                                if(i == input.Length - 2) {
                                    output += "\\";
                                }

                                isConsonant = true;
                                isPasangan = false;
                            }
                            i++;
                    } else {
                        if(isConsonant) {
                            output += consonantPasangan["k"];
                            isConsonant = true;
                            isPasangan = true;
                        } else {
                            output += consonants["k"];
                            
                            if(i == input.Length - 1) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                    }
                } else if (input[i] == 'n') {
                    if(i + 1 < input.Length && input[i + 1] == 'g') {
                        if(isConsonant) {
                            output += consonantPasangan["ng"];
                            isConsonant = true;
                            isPasangan = true;
                        } else {
                            output += consonants["ng"];
                            
                            if(i == input.Length - 2) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                        i++;
                    } else if(i + 1 < input.Length && input[i + 1] == 'y') {
                        if(isConsonant) {
                            output += consonantPasangan["ny"];
                            isConsonant = true;
                            isPasangan = true;
                        } else {
                            output += consonants["ny"];
                            
                            if(i == input.Length - 2) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                        i++;
                    } else {
                        if(isConsonant) {
                            output += consonantPasangan["n"];
                            isConsonant = true;
                            isPasangan = true;
                        } else {
                            output += consonants["n"];
                            
                            if(i == input.Length - 1) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                    }
                } else if(input[i] == 'r') {
                    if(i + 1 < input.Length && IsVowels(input[i + 1])) {
                        if(isConsonant) {
                            output += consonantSandhanganWyanjana["r"];
                            isConsonant = true;
                            isPasangan = false;
                        } else {
                            output += consonants["r"];
                            
                            if(i == input.Length - 1) {
                                output += "\\";
                            }

                            isConsonant = true;
                            isPasangan = false;
                        }
                    } else {
                        if(isConsonant) {
                            output += consonantSandhanganWyanjana["r"];
                            isConsonant = true;
                            isPasangan = false;
                        } else {
                            output += consonantSandhanganPanyigeg["r"];
                            isConsonant = false;
                            isPasangan = false;
                        }
                    }
                } else if(input[i] == 'y') {
                    if(isConsonant) {
                        output += consonantSandhanganWyanjana["y"];
                        isConsonant = true;
                        isPasangan = false;
                    } else {
                        output += consonants["y"];
                        
                        if(i == input.Length - 1) {
                            output += "\\";
                        }

                        isConsonant = true;
                        isPasangan = false;
                    }
                } else if(consonantSandhanganWyanjana.ContainsKey(input[i].ToString())) {
                    output += consonantSandhanganWyanjana[input[i].ToString()];
                    isConsonant = true;
                    isPasangan = false;
                } else if(consonants.ContainsKey(input[i].ToString())) {
                    if(isConsonant) {
                        output += consonantPasangan[input[i].ToString()];
                        isConsonant = true;
                        isPasangan = true;
                    } else {
                        output += consonants[input[i].ToString()];
                        
                        if(i == input.Length - 1) {
                            output += "\\";
                        }

                        isConsonant = true;
                        isPasangan = false;
                    }
                } else if(vowels.ContainsKey(input[i].ToString())) {
                    if(isConsonant) {
                        if(input[i] == 'o') {
                            if(isPasangan) {
                                output = output.Substring(0, output.Length - 3) + "[" + output.Substring(output.Length - 3) + "o";
                            } else {
                                output = output.Substring(0, output.Length - 1) + "[" + output.Substring(output.Length - 1) + "o";
                            }
                            isConsonant = false;
                            isPasangan = false;
                        } else if(input[i] == 'e' || input[i] == 'è' || input[i] == 'é') {
                            if(i == 1) {
                                output = "[" + output;
                            } else {
                                if(isPasangan) {
                                    output = output.Substring(0, output.Length - 3) + "[" + output.Substring(output.Length - 3);
                                } else {
                                    output = output.Substring(0, output.Length - 1) + "[" + output.Substring(output.Length - 1);
                                }
                            }
                            isConsonant = false;
                            isPasangan = false;
                        } else {
                            output += vowels[input[i].ToString()];
                            isConsonant = false;
                            isPasangan = false;
                        }
                    } else {
                        output += 'a' + vowels[input[i].ToString()];
                        isConsonant = false;
                        isPasangan = false;
                    }

                    if(i + 2 < input.Length && consonantSandhanganPanyigeg.ContainsKey(input[i + 1].ToString()) && !IsVowels(input[i + 2])) {
                        output += consonantSandhanganPanyigeg[input[i + 1].ToString()];
                        isConsonant = false;
                        isPasangan = false;
                        i++;
                    } else if(i + 2 < input.Length && input[i + 1] == 'n' && input[i + 2] == 'g') {
                        output += consonantSandhanganPanyigeg["ng"];
                        isConsonant = false;
                        isPasangan = false;
                        i += 2;
                    }

                    if(i + 1 < input.Length && input[i] == 'i' && IsVowels(input[i + 1])) {
                        input = input.Substring(0, i + 1) + "y" + input.Substring(i + 1);
                    } else if (i + 1 < input.Length && input[i] == 'u' && IsVowels(input[i + 1])) {
                        input = input.Substring(0, i + 1) + "w" + input.Substring(i + 1);
                    }
                } else if (punctuations.ContainsKey(input[i].ToString())) {
                    if(i - 1 > 0 && consonants.ContainsKey(input[i - 1].ToString())) {
                        output += "\\";
                    }

                    output += punctuations[input[i].ToString()];
                    isConsonant = false;
                    isPasangan = false;
                } else {
                    output += input[i].ToString();
                }
            }
            return output;
        }

        private static bool IsVowels(char value) {
            return value == 'a' || value == 'u' || value == 'e' || value == 'ê' || value == 'o';
        }
        #endregion

        #region Java To Latin
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
            { "︀", " "},
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

        public static string JavaToLatin(this string input) {
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
                        output += aksaraWyanjana[input[i].ToString()].Substring(0, aksaraWyanjana[input[i].ToString()].Length - 1) + "e";
                        isWyanjana = false;
                    } else {
                        output += aksaraWyanjana[input[i].ToString()];
                        isWyanjana = true;
                    }
                } else if(pada.ContainsKey(input[i].ToString())) {
                    output += pada[input[i].ToString()];
                } else {
                    output += input[i].ToString();
                }
                Debug.Log(output);
            }
            return output;
        }
        #endregion

        #region Java Unicode to ASCII
        // conjunct
        public static Dictionary<string, string> UNICODEWyanjana = new Dictionary<string, string>() {
            { "ꦲ", "h" },      // ha 
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

        public static Dictionary<string, string> UNICODESwara = new Dictionary<string, string> {
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
        public static Dictionary<string, string> UNICODEsandhanganWyanjana = new Dictionary<string, string> {
            { "ꦿ", "]" },       // cakra
            { "ꦽ", "}" },       // cakra kêrêt
            { "ꦾ", "-" },      // pengkal
        };

        public static Dictionary<string, string> UNICODEsandhanganPanyigegingWanda = new Dictionary<string, string> {
            { "ꦀ", "" },        // panyangga
            { "ꦂ", "/" },         // layar (r)
            { "ꦁ", "=" },        // cecak (ng)
            { "ꦃ", "h" },        // wigyan (h)
            { "꧀", "\\" },        // wigyan (h)
        };

        // punctuations
        public static Dictionary<string, string> UNICODEpada = new Dictionary<string, string> {
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

        public static Dictionary<string, string> UNICODEangka = new Dictionary<string, string> {
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

        public static string JavaUnicodeToASCII(this string input) {
            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if(UNICODEsandhanganWyanjana.ContainsKey(input[i].ToString())) {
                    output += UNICODEsandhanganWyanjana[input[i].ToString()];
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
                        output += UNICODEsandhanganPanyigegingWanda[input[i].ToString()];
                    }
                } else if(UNICODEsandhanganPanyigegingWanda.ContainsKey(input[i].ToString())) {
                    output += UNICODEsandhanganPanyigegingWanda[input[i].ToString()];
                } else if(UNICODEWyanjana.ContainsKey(input[i].ToString())) {
                    output += UNICODEWyanjana[input[i].ToString()];
                } else if(input[i] == 'ꦺ') {
                    if(i + 1 < input.Length && input[i + 1] == 'ꦴ') {
                        output = output.Substring(0, output.Length - 1) + "[" + output.Substring(output.Length - 1) + "o";
                        i++;
                    } else {
                        output = output.Substring(0, output.Length - 1) + "[" + output.Substring(output.Length - 1);
                    }
                } else if(UNICODESwara.ContainsKey(input[i].ToString())) {
                    output += UNICODESwara[input[i].ToString()];
                } else if(UNICODEpada.ContainsKey(input[i].ToString())) {
                    output += UNICODEpada[input[i].ToString()];
                } else if(UNICODEangka.ContainsKey(input[i].ToString())) {
                    output += UNICODEangka[input[i].ToString()];
                } else {
                    output += input[i].ToString();
                }
                Debug.Log(output);
            }
            return output;
        }
        #endregion
    }
}