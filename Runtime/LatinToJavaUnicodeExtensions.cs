using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JavaneseToolkit
{
    public static class LatinToJavaUnicodeExtensions 
    {
        public static Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
            { "b", "ꦧ" },       // ba
            { "c", "ꦕ" },       // ca
            { "d", "ꦢ" },       // da
            { "dh", "ꦝ" },       // dha
            { "ḍ", "ꦝ" },       // dha
            { "ḋ", "ꦣ" },       // da mahaprana
            { "dz", "ꦢ꦳" },     // dza rekan
            { "f", "ꦥ꦳" },      // fa rekan
            { "g", "ꦒ" },       // ga
            { "gh", "ꦒ꦳+" },     // gha rekan
            { "h", "ꦲ" },       // ha
            { "j", "ꦗ" },       // ja
            { "k", "ꦏ" },       // ka
            { "kh", "ꦏ꦳" },     // kha rekan
            { "l", "ꦭ" },       // la
            { "m", "ꦩ" },       // ma
            { "n", "ꦤ" },       // na
            { "ng", "ꦔ" },      // nga
            { "ny", "ꦚ" },       // nya
            { "ñ", "ꦚ" },       // nya
            { "ṇ", "ꦟ" },       // na murda
            { "p", "ꦥ" },       // pa
            { "p̣", "ꦦ" },       // pa murda
            { "r", "ꦫ" },       // ra
            { "s", "ꦱ" },       // sa
            { "ś", "ꦯ" },       // sa murda
            { "ṣ", "ꦰ" },       // sa mahaprana
            { "t", "ꦠ" },       // ta
            { "ṭ", "ꦡ" },       // tha
            { "v", "ꦮ꦳" },      // va rekan
            { "w", "ꦮ" },       // wa
            { "y", "ꦪ" },       // ya
            { "z", "ꦗ꦳" },      // za rekan
            { "A", "ꦄ" },       // aksara swara a
            { "I", "ꦆ" },       // aksara swara i
            { "U", "ꦈ" },       // aksara swara u
            { "E", "ꦌ" },       // aksara swara e
            { "È", "ꦌ" },       // aksara swara e
            { "É", "ꦌ" },       // aksara swara e
            { "Ê", "ꦄꦼ" },      // aksara swara ê
            { "Ě", "ꦄꦼ" },      // aksara swara ê
            { "O", "ꦎ" },       // aksara swara o
        };

        private static string GetWyanjana(char c) {
            return wyanjana[c.ToString()];
        }

        private static string GetWyanjana(string s) {
            return wyanjana[s];
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

        public static string LatinToJavaUnicode(this string str, bool murda = true) {
            var length = str.Length;
            var sb = new StringBuilder(length);
            bool isMurdaAlreadyIncluded = false;

            for (var i = 0; i < length; i++)
            {
                var c = str[i];

                if(i + 1 < length) {
                    var c2 = str[i + 1];
                    var c12 = c.ToString() + c2.ToString();
                    
                    if(IsConsonants(c12)) {
                        i++;

                        if(IsConsonantsSandhanganPanyigeg(c12)) {
                            if(i - 2 >= 0 && i + 1 < length) {
                                var cBefore = str[i - 2];
                                var cAfter = str[i + 1];

                                if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                                    sb.Append(GetSandhanganPanyigeg(c12));
                                    continue;
                                }
                            }

                            if(i - 2 >= 0 && i == length - 1) {
                                var cBefore = str[i - 2];

                                if(IsVowels(cBefore)) {
                                    sb.Append(GetSandhanganPanyigeg(c12));
                                    continue;
                                }
                            }
                        }
                      
                        if(i - 3 >= 0) {
                            var cBefore = str[i - 3].ToString() + str[i - 2].ToString();

                            if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                                sb.Append("꧀");
                                if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c12)) {
                                    sb.Append(GetMurda(c12));
                                    isMurdaAlreadyIncluded = true;
                                } else {
                                    sb.Append(GetWyanjana(c12));
                                }
                                continue;
                            }
                        }
                        
                        if(i - 2 >= 0) {
                            var cBefore = str[i - 2];

                            if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                                sb.Append("꧀");
                                if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c12)) {
                                    sb.Append(GetMurda(c12));
                                    isMurdaAlreadyIncluded = true;
                                } else {
                                    sb.Append(GetWyanjana(c12));
                                }
                                continue;
                            }
                        }

                        if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c12)) {
                            sb.Append(GetMurda(c12));
                            isMurdaAlreadyIncluded = true;
                        } else {
                            sb.Append(GetWyanjana(c12));
                        }
                        
                        if(i == length - 1) {
                            sb.Append("꧀");
                        }
                        continue;
                    }
                }

                if(IsConsonantsSandhanganPanyigeg(c)) {
                    if(i - 1 >= 0 && i + 1 < length) {
                        var cBefore = str[i - 1];
                        var cAfter = str[i + 1];

                        if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                            sb.Append(GetSandhanganPanyigeg(c));
                            continue;
                        }
                    }

                    if(i - 1 >= 0 && i == length - 1) {
                        var cBefore = str[i - 1];

                        if(IsVowels(cBefore)) {
                            sb.Append(GetSandhanganPanyigeg(c));
                            continue;
                        }
                    }
                }
                
                if(IsConsonantsSandhanganWyanjana(c)) {
                    if(i - 2 >= 0) {
                        var cBefore = str[i - 2].ToString() + str[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append(GetSandhanganWyanjana(c));
                            continue;
                        }
                    }

                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append(GetSandhanganWyanjana(c));
                            continue;
                        }
                    }
                }
                
                if(IsConsonants(c)) {
                    if(i - 2 >= 0) {
                        var cBefore = str[i - 2].ToString() + str[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append("꧀");
                            if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c)) {
                                sb.Append(GetMurda(c));
                                isMurdaAlreadyIncluded = true;
                            } else {
                                sb.Append(GetWyanjana(c));
                            }
                            continue;
                        }
                    }
                    
                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append("꧀");
                            if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c)) {
                                sb.Append(GetMurda(c));
                                isMurdaAlreadyIncluded = true;
                            } else {
                                sb.Append(GetWyanjana(c));
                            }
                            continue;
                        }
                    }

                    if(i + 1 < length) {
                        var c2 = str[i + 1];
                        var c12 = c.ToString() + c2.ToString();

                        // pa ceret
                        if(IsPaCeret(c12)) {
                            sb.Append("ꦉ");
                            i++;
                            continue;
                        }

                        // nga lelet
                        if(IsNgaLelet(c12)) {
                            sb.Append("ꦊ");
                            i++;
                            continue;
                        }

                        // aksara na mati ketemu aksara ca / ja
                        if(IsNaMatiKetemuCaJa(c12)) {
                            sb.Append(GetWyanjana("ny") + "꧀" + GetWyanjana(c2));
                            i++;
                            continue;
                        }
                    }

                    if(murda && !isMurdaAlreadyIncluded && IsConsonantsMurda(c)) {
                        sb.Append(GetMurda(c));
                        isMurdaAlreadyIncluded = true;
                    } else {
                        sb.Append(GetWyanjana(c));
                    }
                    
                    if(i == length - 1) {
                        sb.Append("꧀");
                    }
                    continue;
                }
                
                if(IsVowels(c)) {
                    if(i - 1 >= 0 && IsConsonants(str[i - 1])) {
                        sb.Append(GetSandhanganSwara(c));
                    } else {
                        sb.Append(GetWyanjana("h") + GetSandhanganSwara(c));
                    }

                    // Diphthong
                    if(i + 1 < length && IsVowelsA(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsA(str[i + 1])) {
                            sb.Append(GetSandhanganSwara("aa"));
                            i++;
                        } else if(IsVowelsWulu(str[i + 1])) {
                            sb.Append(GetSandhanganSwara("ai"));
                            i++;
                        } else if(IsVowelsSuku(str[i + 1])) {
                            sb.Append(GetSandhanganSwara("ao"));
                            i++;
                        }
                    } else if(i + 1 < length && IsVowelsWulu(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsWulu(str[i + 1])) {
                            sb.Append(GetSandhanganSwara("ii"));
                            i++;
                        } else {
                            sb.Append(GetWyanjana("y") + GetSandhanganSwara(str[i + 1]));
                            i++;
                        }
                    } else if (i + 1 < length && IsVowelsSuku(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsWulu(str[i + 1])) {
                            sb.Append(GetSandhanganSwara("uu"));
                            i++;
                        } else {
                            sb.Append(GetWyanjana("w") + GetSandhanganSwara(str[i + 1]));
                            i++;
                        }
                    } else if(i + 1 < length && IsVowelsTaling(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsA(str[i + 1])) {
                            sb.Append(GetWyanjana("y") + GetSandhanganSwara(str[i + 1]));
                            i++;
                        } else if(IsVowelsTalingTarung(str[i + 1])) {
                            sb.Append(GetWyanjana("y") + GetSandhanganSwara(str[i + 1]));
                            i++;
                        }
                    } else if(i + 1 < length && IsVowelsTalingTarung(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsTaling(str[i + 1])) {
                            sb.Append(GetWyanjana("w") + GetSandhanganSwara(str[i + 1]));
                            i++;
                        }
                    }
                    continue;
                }
                
                if(IsCharactersPada(c)) {
                     if(i - 2 >= 0) {
                        var cBefore = str[i - 2].ToString() + str[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append("꧀");
                            continue;
                        }
                    }
                    
                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append("꧀");
                            continue;
                        }
                    }

                    sb.Append(GetPada(c));
                    continue;
                }
                
                sb.Append(c);
            }

            return sb.ToString();
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

        private static bool IsCharactersPada(string s) {
            return pada.ContainsKey(s);
        }

        private static bool IsCharactersPada(char c) {
            return pada.ContainsKey(c.ToString());
        }

        private static int CountConsonantsBackward(string str, int pos) {
            int count = 0;

            for(int i = pos - 1; i >= 0; i--) {
                if(i - 1 >= 0) {
                    var c = str[i - 1].ToString() + str[i].ToString();
                    if(IsConsonants(c) && IsConsonantsSandhanganPanyigeg(c) && count >= 1) return count;
                    if(IsConsonants(c)) {
                        count++;
                        i--;
                        continue;
                    }
                }
                
                if(IsConsonants(str[i]) && IsConsonantsSandhanganPanyigeg(str[i]) && count >= 1) return count;
                if(!IsConsonants(str[i])) return count;
                count++;
            }

            return count;
        }
    }
}