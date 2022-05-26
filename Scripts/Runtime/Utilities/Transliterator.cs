using System;
using System.Collections.Generic;

namespace JVTMPro.Utilities
{
    /// <summary>
    /// Description
    /// </summary>
    public static class Transliterator
    {
        #region LatinToJava
        public static Dictionary<string, string> wyanjanaLTJ = new Dictionary<string, string>() {
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

        private static bool IsWyanjanaLTJ(string s) { 
            return wyanjanaLTJ.ContainsValue(s); 
        }

        private static bool IsWyanjanaLTJ(char c) { 
            return IsWyanjanaLTJ(c.ToString());
        }

        private static bool IsWyanjanaPasanganInRight(string wyanjanaLTJ) { 
            return wyanjanaLTJ == "ꦥ" || wyanjanaLTJ == "ꦥ꦳" || wyanjanaLTJ == "ꦲ" || wyanjanaLTJ == "ꦏ꧀ꦱ" || wyanjanaLTJ == "ꦰ" || wyanjanaLTJ == "ꦱ" || wyanjanaLTJ == "ꦦ"; 
        }

        private static bool IsWyanjanaPasanganInRight(char wyanjanaLTJ) { 
            return IsWyanjanaPasanganInRight(wyanjanaLTJ.ToString());
        }

        private static bool IsWyanjanaPasanganInBelow(string wyanjanaLTJ) { 
            return IsWyanjanaLTJ(wyanjanaLTJ) && !IsWyanjanaPasanganInRight(wyanjanaLTJ); 
        }

        private static bool IsWyanjanaPasanganInBelow(char wyanjanaLTJ) { 
            return IsWyanjanaPasanganInBelow(wyanjanaLTJ.ToString()); 
        }
        
        private static string GetWyanjana(char c) {
            return wyanjanaLTJ[c.ToString()];
        }

        private static string GetWyanjana(string s) {
            return wyanjanaLTJ[s];
        }

        private static Dictionary<string, string> swaraLTJ = new Dictionary<string, string>() {
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
            return swaraLTJ[c.ToString()];
        }

        private static string GetSwara(string s) {
            return swaraLTJ[s];
        }

        private static Dictionary<string, string> murdaLTJ = new Dictionary<string, string>() {
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
            return murdaLTJ[s];
        }

        private static Dictionary<string, string> sandhanganWyanjanaLTJ = new Dictionary<string, string>() {
            { "r", "ꦿ" },   // cakra
            { "ṛ", "ꦽ" },   // cakra keret
            { "y", "ꦾ" },   // pengkal
        };

        private static string GetSandhanganWyanjana(char c) {
            return sandhanganWyanjanaLTJ[c.ToString()];
        }

        private static string GetSandhanganWyanjana(string s) {
            return sandhanganWyanjanaLTJ[s];
        }

        private static Dictionary<string, string> sandhanganPanyigegLTJ = new Dictionary<string, string>() {
            { "r", "ꦂ" },
            { "h", "ꦃ" }, 
            { "ng", "ꦁ" },
        };

        private static string GetSandhanganPanyigegLTJ(char c) {
            return sandhanganPanyigegLTJ[c.ToString()];
        }

        private static string GetSandhanganPanyigegLTJ(string s) {
            return sandhanganPanyigegLTJ[s];
        }

        private static bool IsSandhanganPanyigegLTJ(char c) {
            return IsSandhanganPanyigegLTJ(c.ToString());
        }

        private static bool IsSandhanganPanyigegLTJ(string s) {
            return s == "ꦁ" || s == "ꦃ" || s == "ꦂ";
        }

        private static Dictionary<string, string> sandhanganSwaraLTJ = new Dictionary<string, string>() {
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
            return sandhanganSwaraLTJ[c.ToString()];            
        }

        private static string GetSandhanganSwara(string s) {
            return sandhanganSwaraLTJ[s];            
        }

        private static Dictionary<string, string> padaLTJ = new Dictionary<string, string>() {
            { " ", "​" },
            { ".", "꧉" },
            { ",", "꧈" },
            { "-", "" },
        };

        private static string GetPada(char c) {
            return padaLTJ[c.ToString()];            
        }

        private static string GetPada(string s) {
            return padaLTJ[s];            
        }

        public static string LatinToJava(string str, bool murda = false, bool ignoreSpace = false, bool diphthong = false) {
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
                                    output.Add(GetSandhanganPanyigegLTJ(c12));
                                    continue;
                                }
                            }

                            if(i - 2 >= 0 && i == length - 1) {
                                var cBefore = str[i - 2];

                                if(IsVowels(cBefore)) {
                                    output.Add(GetSandhanganPanyigegLTJ(c12));
                                    continue;
                                }
                            }
                        }

                        // prevent "tumpuk telu" by adding zero width space
                        if(output.Count - 2 >= 0) {
                            var lastOutput = output[output.Count - 1];
                            var lastOutput2 = output[output.Count - 2];
                            
                            if(IsPangkonLTJ(lastOutput) && IsWyanjanaPasanganInBelow(lastOutput2)) { 
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

                            if(IsPangkonLTJ(lastOutput)) {
                                output.RemoveAt(output.Count - 1);
                            }
                        }

                        output.Add(GetSandhanganPanyigegLTJ(c));
                        continue;
                    }
                }
                
                if(IsConsonantsSandhanganWyanjana(c)) {
                    isAlreadyStacked = false;
                    bool isSandhanganWyanjana = false;

                    if(i - 2 >= 0) {
                        var cBefore = str[i - 2].ToString() + str[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigegLTJ(output[output.Count - 1])) {
                            isSandhanganWyanjana = true;
                        }
                    }

                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigegLTJ(output[output.Count - 1])) {
                            isSandhanganWyanjana = true;
                        }
                    }

                    if(isSandhanganWyanjana) {
                        // remove pangkon if exist
                        if(output.Count - 1 >= 0) {
                            var lastOutput = output[output.Count - 1];   

                            if(IsPangkonLTJ(lastOutput)) {
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
                        
                        if(IsPangkonLTJ(lastOutput) && IsWyanjanaPasanganInBelow(lastOutput2)) { 
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
                                
                                if(cBefore == 'l' && !IsPangkonLTJ(lastOutputChar)) {
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
                            
                            if(IsPangkonLTJ(lastOutputChar)) {
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
            return wyanjanaLTJ.ContainsKey(c.ToString());
        }

        private static bool IsConsonants(string s) {
            return wyanjanaLTJ.ContainsKey(s);
        }

        private static bool IsConsonantsMurda(char c) {
            return IsConsonantsMurda(c.ToString());
        }

        private static bool IsConsonantsMurda(string s) {
            return murdaLTJ.ContainsKey(s);
        }

        private static bool IsConsonantsSandhanganPanyigeg(char c) {
            return sandhanganPanyigegLTJ.ContainsKey(c.ToString());
        }

        private static bool IsConsonantsSandhanganPanyigeg(string s) {
            return sandhanganPanyigegLTJ.ContainsKey(s);
        }

        private static bool IsConsonantsSandhanganWyanjana(char c) {
            return sandhanganWyanjanaLTJ.ContainsKey(c.ToString());
        }

        private static bool IsConsonantsSandhanganWyanjana(string s) {
            return sandhanganWyanjanaLTJ.ContainsKey(s);
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
            return sandhanganSwaraLTJ.ContainsKey(c.ToString());
        }

        private static bool IsVowels(string s) {
            return sandhanganSwaraLTJ.ContainsKey(s);
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

        private static bool IsPangkonLTJ(string s) {
            return s == "꧀";
        }

        private static bool IsPangkonLTJ(char c) {
            return IsPangkonLTJ(c.ToString());
        }

        private static bool IsVowelsSwara(string s) {
            return swaraLTJ.ContainsKey(s);
        }

        private static bool IsVowelsSwara(char c) {
            return IsVowelsSwara(c.ToString());
        }

        private static bool IsCharactersPada(string s) {
            return padaLTJ.ContainsKey(s);
        }

        private static bool IsCharactersPada(char c) {
            return padaLTJ.ContainsKey(c.ToString());
        }

        private static bool IsCakra(string s) {
            return s == "ꦿ";
        }

        private static bool IsCakra(char c) {
            return IsCakra(c.ToString());
        }
        #endregion

        #region JavaToLatin
        private static Dictionary<string, string> wyanjanaJTL = new Dictionary<string, string>() {
            { "ꦲ", "h" },      // ha 
            { "ꦤ", "n" },      // na
            { "ꦕ", "c" },      // ca
            { "ꦫ", "r" },      // ra
            { "ꦏ", "k" },      // ka
            { "ꦢ", "d" },      // da
            { "ꦠ", "t" },      // ta
            { "ꦱ", "s" },      // sa
            { "ꦮ", "w" },      // wa
            { "ꦭ", "l" },      // la
            { "ꦥ", "p" },      // pa
            { "ꦝ", "dh" },      // dha
            { "ꦗ", "j" },      // ja
            { "ꦪ", "y" },      // ya
            { "ꦚ", "ny" },     // nya
            { "ꦩ", "m" },      // sa
            { "ꦒ", "g" },      // ga
            { "ꦧ", "b" },      // ba
            { "ꦛ", "t" },      // tha
            { "ꦔ", "ng" },     // nga
            { "ꦟ", "n" },       // na murda
            { "ꦑ", "k" },       // ka murda
            { "ꦡ", "t" },       // ta murda
            { "ꦯ", "s" },       // sa murda
            { "ꦦ", "p" },       // pa murda
            { "ꦘ", "ny" },      // nya murda
            { "ꦓ", "g" },       // ga murda
            { "ꦨ", "b" },       // ba murda
            { "ꦰ", "s" },       // sa mahaprana
            { "ꦖ", "ch" },      // cha mahaprana
            { "ꦣ", "d" },        // da mahaprana
            { "ꦞ", "dh" },      // dha mahaprana
            { "ꦜ", "th" },      // tha mahaprana
            { "ꦐ", "qa" },       // ka sasak
            { "ꦬ", "r" },       // ra agung
        };

        private static bool IsWyanjanaJLT(char c) {
            return IsWyanjanaJLT(c.ToString());
        }

        private static bool IsWyanjanaJLT(string s) {
            return wyanjanaJTL.ContainsKey(s);
        }

        private static Dictionary<string, string> rekanJTL = new Dictionary<string, string>() { 
            { "ꦢ", "dz" },        // dz 
            { "ꦒ", "gh" },        // gha 
            { "ꦗ", "z" },        // za
            { "ꦥ", "f" },        // fa
            { "ꦮ", "v" },        // va
        };

        private static bool IsRekan(char c) {
            return IsRekan(c.ToString());
        }

        private static bool IsRekan(string s) {
            return rekanJTL.ContainsKey(s);
        }

        private static Dictionary<string, string> swaraJTL = new Dictionary<string, string>() { 
            { "ꦄ", "A" },        // a 
            { "ꦆ", "I" },        // i 
            { "ꦅ", "I" },        // i kawi
            { "ꦈ", "U" },        // u 
            { "ꦌ", "E" },        // e 
            { "ꦎ", "O" },        // o 
        };

        private static bool IsSwara(char c) {
            return IsSwara(c.ToString());
        }

        private static bool IsSwara(string s) {
            return swaraJTL.ContainsKey(s);
        }

        // diacritics swara
        private static Dictionary<string, string> sandhanganSwaraJTL = new Dictionary<string, string> {
            { "ꦶ", "i" },        // i
            { "ꦸ", "u" },        // u
            { "ꦼ", "ê" },        // ê
            { "ꦺ", "e" },        // e
            { "ꦺꦴ", "o" },        // o
            { "ꦻ", "ai" },        // e
            { "ꦻꦴ", "au" },        // e
            { "ꦷ", "ī" },       // dirga melik, long i
            { "ꦹ", "ū" },       // dirga mendut, long u
        };

        private static bool IsSandhanganSwara(char c) {
            return IsSandhanganSwara(c.ToString());
        }

        private static bool IsSandhanganSwara(string s) {
            return sandhanganSwaraJTL.ContainsKey(s);
        }

        // diacritics swara
        private static Dictionary<string, string> sandhanganWyanjanaJTL = new Dictionary<string, string> {
            { "ꦿ", "r" },       // cakra
            { "ꦽ", "r" },       // cakra kêrêt
            { "ꦾ", "y" },       // pengkal
        };

        private static bool IsSandhanganWyanjana(char c) {
            return IsSandhanganWyanjana(c.ToString());
        }

        private static bool IsSandhanganWyanjana(string s) {
            return sandhanganWyanjanaJTL.ContainsKey(s);
        }

        private static Dictionary<string, string> sandhanganPanyigegJTL = new Dictionary<string, string> {
            { "ꦂ", "r" },        // layar (r)
            { "ꦁ", "ng" },       // cecak (ng)
            { "ꦃ", "h" },        // wigyan (h)            
            { "ꦀ", "ṁ" },          // panyangga (ṁ)
        };

        private static bool IsSandhanganPanyigegJLT(char c) {
            return IsSandhanganPanyigegJLT(c.ToString());
        }

        private static bool IsSandhanganPanyigegJLT(string s) {
            return sandhanganPanyigegJTL.ContainsKey(s);
        }

        // punctuations
        private static Dictionary<string, string> padaJTL = new Dictionary<string, string> {
            { "​", " "},          // zero width non joiner
            { "꧊", "" },         // adeg
            { "꧋", "" },         // adeg-adeg
            { "ꧏ", "" },        // pangkrangkep
            { "꧞", "" },        // tirta tumetes
            { "꧟", "" },        // isen-isen
            { "꧌", "(" },        // pada piseleh
            { "꧍", ")" },        // turned pada piseleh
            { "꧁", "" },        // left rerenggan
            { "꧂", "" },        // right rerenggan
            { "꧈", "," },        // pada lingsa
            { "꧉", "." },        // pada lungsi
            { "꧆", "" },        // pada windu
            { "꧃", "" },         // pada andhap
            { "꧄", "" },         // pada madya
            { "꧅", "" },         // pada luhur
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
            return padaJTL.ContainsKey(s);
        }

        public static string JavaToLatin(string str) {
            var length = str.Length;
            List<string> output = new List<string>();

            for (int i = 0; i < length; i++) {
                var c = str[i];

                if(IsPangkonJLT(c)) {
                    if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                        output.RemoveAt(output.Count - 1);
                        continue;
                    }
                }

                if(IsCecakTelu(c)) {
                    if(i - 1 >= 0 && IsRekan(str[i - 1])) {
                        if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                            output.RemoveAt(output.Count - 1);
                        }
                        output.RemoveAt(output.Count - 1);
                        output.Add(GetConsonantsRekan(str[i - 1]));
                        output.Add("a");
                        continue;
                    }
                }

                if(IsSandhanganWyanjana(c)) {
                    if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                        output.RemoveAt(output.Count - 1);
                    }
                    output.Add(GetConsonantsSandhanganWyanjana(c)); 
                    if(IsCakraKeret(c)) {
                        output.Add("ê");
                    } else {
                        output.Add("a");
                    }
                    continue;
                } 
                
                if(IsSandhanganSwara(c)) {
                    if(i - 1 >= 0) {
                        if(IsWyanjanaJLT(str[i - 1]) || (IsSandhanganWyanjana(str[i - 1]) && !IsCakraKeret(str[i - 1]))) {
                            if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                                output.RemoveAt(output.Count - 1);
                            }

                            output.Add(GetVowelsSandhanganSwara(c));
                            continue;
                        }

                        if(IsCecakTelu(str[i - 1])) {
                            if(i - 2 >= 0) {
                                if(IsWyanjanaJLT(str[i - 2]) || (IsSandhanganWyanjana(str[i - 2]) && !IsCakraKeret(str[i - 2]))) {
                                    if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                                        output.RemoveAt(output.Count - 1);
                                    }
                
                                    output.Add(GetVowelsSandhanganSwara(c));
                                    continue;
                                }
                            }
                        }
                    }
                }

                if(IsTarung(c)) {
                    if(output.Count - 1 >= 0) {
                        var lastOutput = output[output.Count - 1];

                        if(lastOutput == "a") {
                            output.RemoveAt(output.Count - 1);
                            output.Add("ā");
                            continue;
                        }

                        if(lastOutput == "ê") {
                            output.RemoveAt(output.Count - 1);
                            output.Add("êu");
                            continue;
                        }

                        if(lastOutput == "e") {
                            output.RemoveAt(output.Count - 1);
                            output.Add("o");
                            continue;
                        }

                        if(lastOutput == "ai") {
                            output.RemoveAt(output.Count - 1);
                            output.Add("au");
                            continue;
                        }

                        if(lastOutput == "Ê") {
                            output.Add("u");
                            continue;
                        }
                    }
                }
                
                if(IsSandhanganPanyigegJLT(c)) {
                    output.Add(GetConsonantsSandhanganPanyigeg(c));
                    continue;
                }

                if(IsPaCeret(c)) {
                    output.Add("r");
                    output.Add("ê");
                    continue;
                }

                if(IsNgaLelet(c)) {
                    output.Add("l");
                    output.Add("ê");
                    continue;
                }

                if(IsNgaLeletRaswadi(c)) {
                    output.Add("l");
                    output.Add("êu");
                    continue;
                }

                if(IsSwara(c)) {
                    output.Add(GetConsonantsSwara(c));
                    continue;
                }
                
                if(IsWyanjanaJLT(c)) {
                    output.Add(GetConsonantsWyanjana(c));
                    output.Add("a");
                    continue;
                }
                
                if(IsPada(c)) {
                    output.Add(GetPunctuations(c));
                    continue;
                }
                    
                output.Add(c.ToString());
            }
            
            return String.Join("", output);
        }

        private static bool IsPaCeret(char c) { 
            return c == 'ꦉ'; 
        }

        private static bool IsNgaLelet(char c) { 
            return c == 'ꦊ'; 
        }

        private static bool IsNgaLeletRaswadi(char c) { 
            return c == 'ꦋ'; 
        }

        private static bool IsPangkonJLT(char c) {
            return c == '꧀';
        }

        private static bool IsCakraKeret(char c){ 
            return c == 'ꦽ';
        }

        private static bool IsTarung(char c) { 
            return c == 'ꦴ'; 
        }

        private static bool IsCecakTelu(char c) { 
            return c == '꦳'; 
        }

        private static string GetConsonantsWyanjana(char c) {
            return GetConsonantsWyanjana(c.ToString());
        }

        private static string GetConsonantsWyanjana(string s) {
            return wyanjanaJTL[s];
        }

        private static string GetConsonantsRekan(char c) {
            return GetConsonantsRekan(c.ToString());
        }

        private static string GetConsonantsRekan(string s) {
            return rekanJTL[s];
        }

        private static string GetConsonantsSwara(char c) {
            return GetConsonantsSwara(c.ToString());
        }

        private static string GetConsonantsSwara(string s) {
            return swaraJTL[s];
        }

        private static string GetConsonantsSandhanganWyanjana(char c) {
            return GetConsonantsSandhanganWyanjana(c.ToString());
        }

        private static string GetConsonantsSandhanganWyanjana(string s) {
            return sandhanganWyanjanaJTL[s];
        }

        private static string GetConsonantsSandhanganPanyigeg(char c) {
            return GetConsonantsSandhanganPanyigeg(c.ToString());
        }

        private static string GetConsonantsSandhanganPanyigeg(string s) {
            return sandhanganPanyigegJTL[s];
        }

        private static string GetVowelsSandhanganSwara(char c) {
            return GetVowelsSandhanganSwara(c.ToString());
        }

        private static string GetVowelsSandhanganSwara(string s) {
            return sandhanganSwaraJTL[s];
        }
        
        private static string GetPunctuations(char c) {
            return GetPunctuations(c.ToString());
        }

        private static string GetPunctuations(string s) {
            return padaJTL[s];
        }
        #endregion
    }
}