using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JVTMPro
{
    public static class LatinToJavaExtension
    {
        public static Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
            { "b", "ꦧ" },       // ba
            { "c", "ꦕ" },       // ca
            { "d", "ꦢ" },       // da
            {"dh", "ꦝ" },       // dha
            { "ḍ", "ꦝ" },       // dha
            { "ḍh", "ꦞ" },       // dha mahaprana
            { "dz", "ꦢ꦳" },     // dza rekan
            { "f", "ꦥ꦳" },      // fa rekan
            { "g", "ꦒ" },       // ga
            { "gh", "ꦒ꦳" },     // gha rekan
            { "h", "ꦲ" },       // ha
            { "j", "ꦗ" },       // ja
            { "k", "ꦏ" },       // ka
            { "kh", "ꦏ꦳" },     // kha rekan
            { "l", "ꦭ" },       // la
            { "m", "ꦩ" },       // ma
            { "n", "ꦤ" },       // na
            { "ng", "ꦔ" },      // nga
            { "ŋ", "ꦔ" },       // nga
            { "ny", "ꦚ" },       // nya
            { "nc", "ꦚ꧀ꦕ" },       // nca
            { "nj", "ꦚ꧀ꦗ" },       // nja
            { "ñ", "ꦚ" },       // nya
            { "ṇ", "ꦟ" },       // na murda
            { "p", "ꦥ" },       // pa
            { "p̣", "ꦦ" },       // pa murda
            { "q", "ꦐ" },       // ka sasak
            { "r", "ꦫ" },       // ra
            { "s", "ꦱ" },       // sa
            { "ś", "ꦯ" },       // sa murda
            { "ṣ", "ꦰ" },       // sa mahaprana
            { "t", "ꦠ" },       // ta
            { "th", "ꦛ" },       // ta
            { "ṭ", "ꦡ" },       // ta murda
            { "ṭh", "ꦜ" },      // tha mahaprana
            { "v", "ꦮ꦳" },      // va rekan
            { "w", "ꦮ" },       // wa
            { "x", "ꦏ꧀ꦱ" },     // ks 
            { "y", "ꦪ" },       // ya
            { "z", "ꦗ꦳" },      // za rekan
        };

        private static bool IsWyanjana(string s) { 
            return wyanjana.ContainsValue(s); 
        }

        private static bool IsWyanjana(char c) { 
            return IsWyanjana(c.ToString());
        }

        private static bool IsWyanjanaPasanganInRight(string wyanjana) { 
            return wyanjana == "ꦥ" || wyanjana == "ꦥ꦳" || wyanjana == "ꦲ" || wyanjana == "ꦏ꧀ꦱ" || wyanjana == "ꦰ" || wyanjana == "ꦱ" || wyanjana == "ꦦ"; 
        }

        private static bool IsWyanjanaPasanganInRight(char wyanjana) { 
            return IsWyanjanaPasanganInRight(wyanjana.ToString());
        }

        private static bool IsWyanjanaPasanganInBelow(string wyanjana) { 
            return IsWyanjana(wyanjana) && !IsWyanjanaPasanganInRight(wyanjana); 
        }

        private static bool IsWyanjanaPasanganInBelow(char wyanjana) { 
            return IsWyanjanaPasanganInBelow(wyanjana.ToString()); 
        }
        
        private static string GetWyanjana(char c) {
            return wyanjana[c.ToString()];
        }

        private static string GetWyanjana(string s) {
            return wyanjana[s];
        }

        public static Dictionary<string, string> swara = new Dictionary<string, string>() {
            { "A", "ꦄ" },     // aksara swara a
            { "I", "ꦆ" },     // aksara swara i
            { "U", "ꦈ" },     // aksara swara u
            { "E", "ꦌ" },     // aksara swara e
            { "È", "ꦌ" },     // aksara swara e
            { "É", "ꦌ" },     // aksara swara e
            { "Ê", "ꦄꦼ" },    // aksara swara ê
            { "Ě", "ꦄꦼ" },    // aksara swara ê
            { "O", "ꦎ" },     // aksara swara o
        };
        
        private static string GetSwara(char c) {
            return swara[c.ToString()];
        }

        private static string GetSwara(string s) {
            return swara[s];
        }

        public static Dictionary<string, string> murda = new Dictionary<string, string>() {
            { "n", "ꦟ" },      // na murda
            { "k", "ꦑ" },       // ka murda
            { "kh", "ꦑ꦳" },       // kha murda
            { "t", "ꦡ" },       // ta murda
            { "s", "ꦯ" },      // sa murda
            { "p", "ꦦ" },       // pa murda
            { "f", "ꦦ꦳" },       // fa murda
            { "ny", "ꦘ" },      // nya murda
            { "ñ", "ꦘ" },       // nya murda
            { "g", "ꦓ" },      // ga murda
            { "gh", "ꦓ꦳" },      // gha murda
            { "b", "ꦨ" },       // ba murda
        };

        private static string GetMurda(char c) {
            return GetMurda(c.ToString());
        }

        private static string GetMurda(string s) {
            return murda[s];
        }

        public static Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string>() {
            { "r", "ꦿ" },   // cakra
            { "ṛ", "ꦽ" },   // cakra keret
            { "y", "ꦾ" },   // pengkal
        };

        private static string GetSandhanganWyanjana(char c) {
            return sandhanganWyanjana[c.ToString()];
        }

        private static string GetSandhanganWyanjana(string s) {
            return sandhanganWyanjana[s];
        }

        public static Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string>() {
            { "r", "ꦂ" },
            { "h", "ꦃ" }, 
            { "ng", "ꦁ" },
        };

        private static string GetSandhanganPanyigeg(char c) {
            return sandhanganPanyigeg[c.ToString()];
        }

        private static string GetSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg[s];
        }

        private static bool IsSandhanganPanyigeg(char c) {
            return IsSandhanganPanyigeg(c.ToString());
        }

        private static bool IsSandhanganPanyigeg(string s) {
            return s == "ꦁ" || s == "ꦃ" || s == "ꦂ";
        }

        public static Dictionary<string, string> sandhanganSwara = new Dictionary<string, string>() {
            { "a", "" },
            { "ô", "" },
            { "aa", "ꦴ"},
            { "ai", "ꦻ" },
            { "au", "ꦻꦴ" },
            { "ôô", "" },
            { "ā", "ꦴ" },
            { "i", "ꦶ" },
            { "ii", "ꦷ"},
            { "ī", "ꦷ"},
            { "u", "ꦸ" },
            { "uu", "ꦹ"},
            { "ū", "ꦹ"},
            { "e", "ꦺ" },
            { "è", "ꦺ" },
            { "é", "ꦺ" },
            { "ê", "ꦼ" },
            { "ě", "ꦼ" },
            { "o", "ꦺꦴ" },
        };

        private static string GetSandhanganSwara(char c) {
            return sandhanganSwara[c.ToString()];            
        }

        private static string GetSandhanganSwara(string s) {
            return sandhanganSwara[s];            
        }

        public static Dictionary<string, string> pada = new Dictionary<string, string>() {
            { " ", "​" },
            { ".", "꧉" },
            { ",", "꧈" },
            { "-", "" },
        };

        private static string GetPada(char c) {
            return pada[c.ToString()];            
        }

        private static string GetPada(string s) {
            return pada[s];            
        }

        public static string LatinToJava(this string str, bool murda = false, bool ignoreSpace = false, bool diphthong = false) {
            int length = str.Length;
            List<string> output = new List<string>();
            bool isMurdaAlreadyIncluded = false;
            bool isAlreadyStacked = false;

            for (int i = 0; i < length; i++)
            {
                var c = str[i];

                if(i + 1 < length) {
                    var c2 = str[i + 1];
                    var c12 = c.ToString() + c2.ToString();
                    
                    if(IsConsonants(c12)) {
                        i++;

                        if(c12 == c12.ToUpper()) {
                            c12 = c12.ToLower();
                        }

                        if(IsConsonantsSandhanganPanyigeg(c12)) {
                            isAlreadyStacked = false;

                            if(i - 2 >= 0 && i + 1 < length) {
                                var cBefore = str[i - 2];
                                var cAfter = str[i + 1];

                                if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                                    output.Add(GetSandhanganPanyigeg(c12));
                                    continue;
                                }
                            }

                            if(i - 2 >= 0 && i == length - 1) {
                                var cBefore = str[i - 2];

                                if(IsVowels(cBefore)) {
                                    output.Add(GetSandhanganPanyigeg(c12));
                                    continue;
                                }
                            }
                        }

                        // prevent "tumpuk telu" by adding zero width space
                        if(output.Count - 2 >= 0) {
                            var lastOutput = output[output.Count - 1];
                            var lastOutput2 = output[output.Count - 2];
                            
                            if(IsPangkon(lastOutput) && IsWyanjanaPasanganInBelow(lastOutput2)) { 
                                if(isAlreadyStacked) {
                                    output.Insert(output.Count - 2, "​"); // insert zero width space
                                    isAlreadyStacked = false;
                                } else {
                                    isAlreadyStacked = true;
                                }
                            }
                        }

                        if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c12)) {
                            output.Add(GetMurda(c12));
                            isMurdaAlreadyIncluded = true;
                        } else {
                            output.Add(GetWyanjana(c12));
                        }
                        
                        output.Add("꧀");
                        continue;
                    }
                }

                if(IsConsonantsSandhanganPanyigeg(c)) {
                    isAlreadyStacked = false;
                    bool isSandhanganPanyigeg = false;

                    if(i - 1 >= 0 && i + 1 < length) {
                        var cBefore = str[i - 1];
                        var cAfter = str[i + 1];

                        if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                            isSandhanganPanyigeg = true;
                        }
                    }

                    if(i - 1 >= 0 && i == length - 1) {
                        var cBefore = str[i - 1];

                        if(IsVowels(cBefore)) {
                            isSandhanganPanyigeg = true;
                        }
                    }

                    if(isSandhanganPanyigeg) {
                        // remove pangkon if exist
                        if(output.Count - 1 >= 0) {
                            var lastOutput = output[output.Count - 1];   

                            if(IsPangkon(lastOutput)) {
                                output.RemoveAt(output.Count - 1);
                            }
                        }

                        output.Add(GetSandhanganPanyigeg(c));
                        continue;
                    }
                }
                
                if(IsConsonantsSandhanganWyanjana(c)) {
                    isAlreadyStacked = false;
                    bool isSandhanganWyanjana = false;

                    if(i - 2 >= 0) {
                        var cBefore = str[i - 2].ToString() + str[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(output[output.Count - 1])) {
                            isSandhanganWyanjana = true;
                        }
                    }

                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(output[output.Count - 1])) {
                            isSandhanganWyanjana = true;
                        }
                    }

                    if(isSandhanganWyanjana) {
                        // remove pangkon if exist
                        if(output.Count - 1 >= 0) {
                            var lastOutput = output[output.Count - 1];   

                            if(IsPangkon(lastOutput)) {
                                output.RemoveAt(output.Count - 1);
                            }
                        }

                        output.Add(GetSandhanganWyanjana(c));
                        continue;
                    }
                }
                
                if(IsConsonants(c) || IsConsonants(Char.ToLower(c))) {
                    if(c == Char.ToUpper(c)) {
                        c = Char.ToLower(c);
                    }

                    // prevent "tumpuk telu" by adding zero width space
                    if(output.Count - 2 >= 0) {
                        var lastOutput = output[output.Count - 1];
                        var lastOutput2 = output[output.Count - 2];
                        
                        if(IsPangkon(lastOutput) && IsWyanjanaPasanganInBelow(lastOutput2)) { 
                            if(isAlreadyStacked) {
                                output.Insert(output.Count - 2, "​"); // insert zero width space
                                isAlreadyStacked = false;
                            } else {
                                isAlreadyStacked = true;
                            }
                        }
                    }

                    if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c)) {
                        output.Add(GetMurda(c));
                        isMurdaAlreadyIncluded = true;
                    } else {
                        output.Add(GetWyanjana(c));
                    }

                    output.Add("꧀");
                    continue;
                }

                if(IsVowelsSwara(c)) {
                    isAlreadyStacked = false;

                    output.Add(GetSwara(c));
                    continue;
                }
                
                if(IsVowels(c)) {
                    isAlreadyStacked = false;

                    if(i + 1 < length) {
                        var c2 = str[i + 1];

                        // change ia, iu, ie, iê, io to iya, iyu, iye, iyê, iyo
                        if(IsVowelsWulu(c) && IsVowels(c2) && !IsVowelsWulu(c2)) {
                            str = str.Substring(0, i + 1) + "y" + str.Substring(i + 1);
                            length = str.Length;
                        }

                        // change ua, ui, ue, uê, uo to uwa, uwi, uwe, uwê, uwo
                        if(IsVowelsSuku(c) && IsVowels(c2) && !IsVowelsSuku(c2)) {
                            str = str.Substring(0, i + 1) + "w" + str.Substring(i + 1);
                            length = str.Length;
                        }

                        // change ea to eya
                        if(IsVowelsTaling(c) && IsVowelsA(c2)) {
                            str = str.Substring(0, i + 1) + "y" + str.Substring(i + 1);
                            length = str.Length;
                        }

                        // change eo to eyo
                        if(IsVowelsTaling(c) && IsVowelsTalingTarung(c2)) {
                            str = str.Substring(0, i + 1) + "y" + str.Substring(i + 1);
                            length = str.Length;
                        }
                        
                        // change oa to owa
                        if(IsVowelsTalingTarung(c) && IsVowelsA(c2)) {
                            str = str.Substring(0, i + 1) + "w" + str.Substring(i + 1);
                            length = str.Length;
                        }
                        
                        // change oe to owe
                        if(IsVowelsTalingTarung(c) && IsVowelsTaling(c2)) {
                            str = str.Substring(0, i + 1) + "w" + str.Substring(i + 1);
                            length = str.Length;
                        }
                    }
                    
                    if(IsVowelsPepet(c)) {
                        if(output.Count - 1 >= 0) {
                            var lastOutputChar = output[output.Count - 1];
                            
                            // check cakra keret
                            if(IsCakra(lastOutputChar)) {
                                output.RemoveAt(output.Count - 1); // remove cakra
                                output.Add("ꦽ"); // replace cakra with cakra keret
                                continue;
                            }

                            // check nga lelet
                            if(i - 1 >= 0) {
                                var cBefore = str[i - 1];
                                
                                if(cBefore == 'l' && !IsPangkon(lastOutputChar)) {
                                    output.RemoveAt(output.Count - 1); // pop pangkon
                                    output.RemoveAt(output.Count - 1); // pop aksara la
                                    output.Add("ꦊ"); // replace them with nga lelet
                                    continue;
                                }
                            }
                        }

                        if(i - 1 >= 0) {
                            var cBefore = str[i - 1];
                            
                            // check pa ceret
                            if(cBefore == 'r') {
                                output.RemoveAt(output.Count - 1); // pop pangkon
                                output.RemoveAt(output.Count - 1); // pop aksara la
                                output.Add("ꦉ"); // replace them with pa ceret
                                continue;
                            }
                        }
                    }            
                    
                    if(i - 1 >= 0 && IsConsonants(str[i - 1])) {
                        // check pangkon
                        if(output.Count - 1 >= 0) {
                            var lastOutputChar = output[output.Count - 1];
                            
                            if(IsPangkon(lastOutputChar)) {
                                output.RemoveAt(output.Count - 1);
                            }
                        }

                        output.Add(GetSandhanganSwara(c));
                    } else {
                        output.Add(GetWyanjana("h"));
                        output.Add(GetSandhanganSwara(c));
                    }

                    // Diphthong
                    if(diphthong && i + 1 < length && IsVowels(str[i + 1])) {
                        var c2 = str[i + 1];

                        if(IsVowelsA(c) && IsVowelsA(c2)) {
                            output.Add(GetSandhanganSwara("aa"));
                            i++;
                            continue;
                        }

                        if(IsVowelsA(c) && IsVowelsWulu(c2)) {
                            output.Add(GetSandhanganSwara("ai"));
                            i++;
                            continue;
                        }

                        if(IsVowelsA(c) && IsVowelsSuku(c2)) {
                            output.Add(GetSandhanganSwara("au"));
                            i++;
                            continue;
                        }

                        if(IsVowelsWulu(c) && IsVowelsWulu(c2)) {
                            output.RemoveAt(output.Count - 1);
                            output.Add(GetSandhanganSwara("ii"));
                            i++;
                            continue;
                        }
                        
                        if (IsVowelsSuku(c) && IsVowelsSuku(c2)) {
                            output.RemoveAt(output.Count - 1);
                            output.Add(GetSandhanganSwara("uu"));
                            i++;
                            continue;
                        }
                    }

                    continue;
                }
                
                if(IsCharactersPada(c)) {
                    isAlreadyStacked = false;

                    if(ignoreSpace && c == ' ') {
                        continue;
                    }

                    output.Add(GetPada(c));
                    continue;
                }
                
                output.Add(c.ToString());
            }

            return String.Join("", output);
        }

        private static bool IsConsonants(char c) {
            return wyanjana.ContainsKey(c.ToString());
        }

        private static bool IsConsonants(string s) {
            return wyanjana.ContainsKey(s);
        }

        private static bool IsConsonantsMurda(char c) {
            return IsConsonantsMurda(c.ToString());
        }

        private static bool IsConsonantsMurda(string s) {
            return murda.ContainsKey(s);
        }

        private static bool IsConsonantsSandhanganPanyigeg(char c) {
            return sandhanganPanyigeg.ContainsKey(c.ToString());
        }

        private static bool IsConsonantsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg.ContainsKey(s);
        }

        private static bool IsConsonantsSandhanganWyanjana(char c) {
            return sandhanganWyanjana.ContainsKey(c.ToString());
        }

        private static bool IsConsonantsSandhanganWyanjana(string s) {
            return sandhanganWyanjana.ContainsKey(s);
        }

        private static bool IsConsonantsPasanganOnRight(string s) {
            return s == "h" || s == "s" || s == "p" || s == "p̣" || s == "ny" || s == "ñ";
        }

        private static bool IsConsonantsPasanganOnRight(char c) {
            return IsConsonantsPasanganOnRight(c.ToString());
        }

        private static bool IsConsonantsPasanganOnBelow(string s) {
            return IsConsonants(s) && !IsConsonantsPasanganOnRight(s);
        }

        private static bool IsConsonantsPasanganOnBelow(char c) {
            return IsConsonants(c.ToString()) && !IsConsonantsPasanganOnRight(c.ToString());
        }

        private static bool IsPaCeret(string s) {
            return s[0] == 'r' && IsVowelsPepet(s[1]);
        }
        
        private static bool IsNgaLelet(string s) {
            return s[0] == 'l' && IsVowelsPepet(s[1]);
        }

        private static bool IsNaMatiKetemuCaJa(string s) {
            return s[0] == 'n' && s[1] == 'c' || s[0] == 'n' && s[1] == 'j';
        }

        private static bool IsVowels(char c) {
            return sandhanganSwara.ContainsKey(c.ToString());
        }

        private static bool IsVowels(string s) {
            return sandhanganSwara.ContainsKey(s);
        }

        private static bool IsVowelsA(string s) {
            return s == "a" || s == "ô";
        }

        private static bool IsVowelsA(char c) {
            return IsVowelsA(c.ToString());
        }

        private static bool IsVowelsPepet(string s) {
            return s == "ê" || s == "ě";
        }

        private static bool IsVowelsPepet(char c) {
            return IsVowelsPepet(c.ToString());
        }

        private static bool IsVowelsWulu(string s) {
            return s == "i";
        }

        private static bool IsVowelsWulu(char c) {
            return IsVowelsWulu(c.ToString());
        }

        private static bool IsVowelsSuku(string s) {
            return s == "u";
        }

        private static bool IsVowelsSuku(char c) {
            return IsVowelsSuku(c.ToString());
        }

        private static bool IsVowelsTaling(string s) {
            return s == "e" || s == "é" || s == "è";
        }

        private static bool IsVowelsTaling(char c) {
            return IsVowelsTaling(c.ToString());
        }

        private static bool IsVowelsTalingTarung(string s) {
            return s == "o";
        }

        private static bool IsVowelsTalingTarung(char c) {
            return IsVowelsTalingTarung(c.ToString());
        }

        private static bool IsPangkon(string s) {
            return s == "꧀";
        }

        private static bool IsPangkon(char c) {
            return IsPangkon(c.ToString());
        }

        private static bool IsVowelsSwara(string s) {
            return swara.ContainsKey(s);
        }

        private static bool IsVowelsSwara(char c) {
            return IsVowelsSwara(c.ToString());
        }

        private static bool IsCharactersPada(string s) {
            return pada.ContainsKey(s);
        }

        private static bool IsCharactersPada(char c) {
            return pada.ContainsKey(c.ToString());
        }

        private static bool IsCakra(string s) {
            return s == "ꦿ";
        }

        private static bool IsCakra(char c) {
            return IsCakra(c.ToString());
        }
    }
}