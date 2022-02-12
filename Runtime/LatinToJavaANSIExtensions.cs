using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JavaneseToolkit
{
    public static class LatinToJavaANSIExtensions 
    {
        public static Dictionary<string, string> consonants = new Dictionary<string, string>() {
            { "b", "b" },       // ba
            { "c", "c" },       // ca
            { "d", "f" },       // da
            { "f", "p+" },      // fa rekan
            { "g", "g" },       // ga
            { "h", "a" },       // ha
            { "j", "j" },       // ja
            { "k", "k" },       // ka
            { "l", "l" },       // la
            { "m", "m" },       // ma
            { "n", "n" },       // na
            { "ṇ", "!" },       // na murda
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

        public static Dictionary<string, string> consonants2 = new Dictionary<string, string>() {
            { "gh", "g+" },     // gha rekan
            { "kh", "k+" },     // kha rekan
            { "dh", "d" },       // dha
            { "dz", "f+" },     // dza rekan
            { "ng", "z" },      // nga
            { "ny", "v" },       // nya
        };

        public static Dictionary<string, string> consonantPasangan = new Dictionary<string, string>() {
            { "b", "B" },       // ba
            { "c", "C" },       // ca
            { "d", "F" },       // da
            { "f", "P+" },      // fa rekan
            { "g", "G" },       // ga
            { "h", "H" },       // ha
            { "j", "J" },       // ja
            { "k", "K" },       // ka
            { "l", "L" },       // la
            { "m", "M" },       // ma
            { "n", "N" },       // na
            { "ṇ", "!" },       // na murda
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

        public static Dictionary<string, string> consonantPasangan2 = new Dictionary<string, string>() {
            { "dh", "D" },       // dha
            { "dz", "F+" },     // dza rekan
            { "gh", "G+" },     // gha rekan
            { "kh", "K+" },     // kha rekan
            { "ng", "Z" },      // nga
            { "ny", "V" },       // nya
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
            { "o", "o" },
        };

        public static Dictionary<string, string> punctuations = new Dictionary<string, string>() {
            { " ", "​" },
            { ".", "." },
            { ",", "," }
        };

        public static string LatinToJavaANSI(this string input) {
            bool isConsonant = false;
            bool isPasangan = false;
            bool isSandhanganPanyigeg = false;
            bool htmlTag = false;
            int inputTagStart = 0;
            int inputTagEnd = 0;
            int outputTagStart = 0;
            int outputTagEnd = 0;

            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if(input[i] == 'r') {
                    if(i + 1 < input.Length && IsVowels(input[i + 1])) {
                        if(isConsonant) {
                            output += consonantSandhanganWyanjana["r"];
                            isConsonant = true;
                            isPasangan = false;
                        } else {
                            output += consonants["r"];
                            isConsonant = true;
                            isPasangan = false;
                        }
                        isSandhanganPanyigeg = false;
                    } else {
                        if(isConsonant) {
                            output += consonantSandhanganWyanjana["r"];
                            isConsonant = true;
                            isPasangan = false;
                            isSandhanganPanyigeg = false;
                        } else {
                            output += consonantSandhanganPanyigeg["r"];
                            isConsonant = false;
                            isPasangan = false;
                            isSandhanganPanyigeg = true;
                        }
                    }
                } else if(input[i] == 'y') {
                    if(isConsonant) {
                        output += consonantSandhanganWyanjana["y"];
                        isConsonant = true;
                        isPasangan = false;
                    } else {
                        output += consonants["y"];
                        isConsonant = true;
                        isPasangan = false;
                    }
                    isSandhanganPanyigeg = false;
                } else if(i + 1 < input.Length && input[i].ToString() + input[i + 1].ToString() == "ng") {
                    if(i + 2 < input.Length && IsVowels(input[i + 2])) {
                        output += consonants2["ng"];
                        isConsonant = true;
                        isPasangan = false;
                        isSandhanganPanyigeg = false;
                    } else {
                        output += consonantSandhanganPanyigeg["ng"];
                        isConsonant = false;
                        isPasangan = false;
                        isSandhanganPanyigeg = true;
                    }
                    i++;
                } else if(i - 1 > 0 && IsVowels(input[i - 1]) && consonantSandhanganPanyigeg.ContainsKey(input[i].ToString())) {
                    if(i + 1 < input.Length && IsVowels(input[i + 1])) {
                        output += consonants[input[i].ToString()];
                        isConsonant = true;
                        isPasangan = false;
                        isSandhanganPanyigeg = false;
                    } else {
                        output += consonantSandhanganPanyigeg[input[i].ToString()];
                        isConsonant = false;
                        isPasangan = false;
                        isSandhanganPanyigeg = true;
                    }
                } else if(consonantSandhanganWyanjana.ContainsKey(input[i].ToString())) {
                    output += consonantSandhanganWyanjana[input[i].ToString()];
                    isConsonant = true;
                    isPasangan = false;
                    isSandhanganPanyigeg = false;
                } else if(i + 1 < input.Length && consonants2.ContainsKey(input[i].ToString() + input[i + 1].ToString())) {
                    string key = input[i].ToString() + input[i + 1].ToString();   
                
                    if(isConsonant) {
                        output += consonantPasangan2[key];
                        isConsonant = true;
                        isPasangan = true;
                    } else {
                        output += consonants2[key];
                        isConsonant = true;
                        isPasangan = false;
                    }

                    isSandhanganPanyigeg = false;
                    i++;
                } else if(consonants.ContainsKey(input[i].ToString())) {
                    if(isConsonant) {
                        output += consonantPasangan[input[i].ToString()];
                        isConsonant = true;
                        isPasangan = true;
                    } else {
                        output += consonants[input[i].ToString()];
                        isConsonant = true;
                        isPasangan = false;
                    }
                    
                    isSandhanganPanyigeg = false;
                } else if(vowels.ContainsKey(input[i].ToString())) {
                    if(isConsonant) {
                        if(input[i] == 'o') {
                            if(isPasangan) {
                                if(i - 2 > 0 && input[i - 2] == ' ') {
                                    output = output.Substring(0, output.Length - 3) + vowels["e"] + output.Substring(output.Length - 3) + vowels[input[i].ToString()];
                                } else {
                                    output = output.Substring(0, output.Length - 2) + vowels["e"] + output.Substring(output.Length - 2) + vowels[input[i].ToString()];
                                }
                            } else {
                                if(i - 1 > 0 && input[i - 1] == ' ') {
                                    output = output.Substring(0, output.Length - 2) + vowels["e"] + output.Substring(output.Length - 2) + vowels[input[i].ToString()];
                                } else {
                                    output = output.Substring(0, output.Length - 1) + vowels["e"] + output.Substring(output.Length - 1) + vowels[input[i].ToString()];
                                }
                            }
                            isConsonant = false;
                            isPasangan = false;
                        } else if(input[i] == 'e' || input[i] == 'è' || input[i] == 'é') {
                            if(isPasangan) {
                                if(i - 2 > 0 && input[i - 2] == ' ') {
                                    output = output.Substring(0, output.Length - 3) + vowels[input[i].ToString()] + output.Substring(output.Length - 3);
                                } else {
                                    output = output.Substring(0, output.Length - 2) + vowels[input[i].ToString()] + output.Substring(output.Length - 2);
                                }
                            } else {
                                if(i - 1 > 0 && input[i - 1] == ' ') {
                                    output = output.Substring(0, output.Length - 2) + vowels[input[i].ToString()] + output.Substring(output.Length - 2);
                                } else {
                                    output = output.Substring(0, output.Length - 1) + vowels[input[i].ToString()] + output.Substring(output.Length - 1);
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
                        if(input[i] == 'o') {
                            output += vowels["e"] + "a" + vowels[input[i].ToString()];
                            isConsonant = false;
                            isPasangan = false;
                        } else if(input[i] == 'e' || input[i] == 'è' || input[i] == 'é') {
                            output += vowels[input[i].ToString()] + 'a';
                            isConsonant = false;
                            isPasangan = false;
                        } else {
                            output += 'a' + vowels[input[i].ToString()];
                            isConsonant = false;
                            isPasangan = false;
                        }
                    }

                    if(i + 1 < input.Length && input[i] == 'i' && IsVowels(input[i + 1])) {
                        input = input.Substring(0, i + 1) + "y" + input.Substring(i + 1);
                    } else if (i + 1 < input.Length && input[i] == 'u' && IsVowels(input[i + 1])) {
                        input = input.Substring(0, i + 1) + "w" + input.Substring(i + 1);
                    }
                    
                    isSandhanganPanyigeg = false;
                } else if (punctuations.ContainsKey(input[i].ToString())) {
                    output += punctuations[input[i].ToString()];
                    if(input[i] != ' ') {
                        isConsonant = false;
                        isPasangan = false;
                        isSandhanganPanyigeg = false;
                    }
                } else {
                    output += input[i].ToString();
                    isConsonant = false;
                    isPasangan = false;
                    isSandhanganPanyigeg = false;
                }
       
                if(i == input.Length - 1) {
                    if(isConsonant && !isPasangan && !isSandhanganPanyigeg) {
                        output += "\\";
                    }
                }

                // check html tag
                if(input[i] == '<') {
                    htmlTag = true;
                    inputTagStart = i;
                    outputTagStart = output.Length - 1;
                }
                
                if(htmlTag && input[i] == '>') {
                    htmlTag = false;
                    inputTagEnd = i;
                    outputTagEnd = output.Length - 1;

                    output = output.Remove(outputTagStart, outputTagEnd - outputTagStart).Insert(outputTagStart, input.Substring(inputTagStart, inputTagEnd - inputTagStart));
                }

                // Debug.Log(output);
            }
            return output;
        }

        private static bool IsVowels(char value) {
            return value == 'a' || value == 'i' || value == 'u' || value == 'e' || value == 'ê' || value == 'o';
        }
    }
}