using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JavaneseToolkit
{
    public static class LatinToJavaANSIExtensions 
    {
        public static Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
            { "b", "b" },       // ba
            { "c", "c" },       // ca
            { "d", "f" },       // da
            { "dh", "d" },       // dha
            { "ḍ", "d" },       // dha
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
            { "ng", "z" },      // nga
            { "ny", "v" },       // nya
            { "ñ", "v" },       // nya
            { "ṇ", "!" },       // na murda
            { "p", "p" },       // pa
            { "p̣", "%" },       // pa murda
            { "r", "r" },       // ra
            { "s", "s" },       // sa
            { "ś", "$" },       // sa murda
            { "ṣ", "Ȱ" },       // sa mahaprana
            { "t", "t" },       // ta
            { "ṭ", "q" },       // tha
            { "v", "w+" },      // va rekan
            { "w", "w" },       // wa
            { "y", "y" },       // ya
            { "z", "j+" },      // za rekan
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

        private static string GetWyanjana(char c) {
            return wyanjana[c.ToString()];
        }

        private static string GetWyanjana(string s) {
            return wyanjana[s];
        }

        public static Dictionary<string, string> pasangan = new Dictionary<string, string>() {
            { "b", "B" },       // ba
            { "c", "C" },       // ca
            { "d", "F" },       // da
            { "dh", "D" },       // dha
            { "ḍ", "D" },       // dha
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
            { "ñ", "V" },       // nya
            { "p", "P" },       // pa
            { "p̣", "²" },       // pa murda
            { "r", "R" },       // ra
            { "s", "S" },       // sa
            { "ś", "$" },       // sa murda
            { "ṣ", "Ȱ" },       // sa mahaprana
            { "t", "T" },       // ta
            { "ṭ", "Q" },       // tha
            { "v", "W+" },      // va rekan
            { "w", "W" },       // wa
            { "y", "Y" },       // ya
            { "z", "J+" },      // za rekan
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

        private static string GetPasangan(char c) {
            return pasangan[c.ToString()];
        }

        private static string GetPasangan(string s) {
            return pasangan[s];
        }

        public static Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string>() {
            { "r", "]" },   // cakra
            { "y", "-" },   // pengkal
            { "ṛ", "}" },   // cakra keret
        };

        private static string GetSandhanganWyanjana(char c) {
            return sandhanganWyanjana[c.ToString()];
        }

        private static string GetSandhanganWyanjana(string s) {
            return sandhanganWyanjana[s];
        }

        public static Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string>() {
            { "r", "/" },
            { "h", "h" }, 
            { "ng", "=" },
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
            return s == "/" || s == "h" || s == "=";
        }

        public static Dictionary<string, string> sandhanganSwara = new Dictionary<string, string>() {
            { "a", "" },
            { "ô", "" },
            { "aa", "o"},
            { "ôô", "" },
            { "ā", "o" },
            { "i", "i" },
            { "ii", "»"},
            { "ī", "»"},
            { "u", "u" },
            { "uu", "×"},
            { "ū", "×"},
            { "e", "[" },
            { "è", "[" },
            { "é", "[" },
            { "ê", "e" },
            { "ě", "e" },
            { "o", "o" },
        };

        private static string GetSandhanganSwara(char c) {
            return sandhanganSwara[c.ToString()];            
        }

        private static string GetSandhanganSwara(string s) {
            return sandhanganSwara[s];            
        }

        public static Dictionary<string, string> pada = new Dictionary<string, string>() {
            { " ", "​" },
            { ".", "." },
            { ",", "," },
            { "-", "" },
        };

        private static string GetPada(char c) {
            return pada[c.ToString()];            
        }

        private static string GetPada(string s) {
            return pada[s];            
        }

        public static string LatinToJavaANSI(this string str) {
            var length = str.Length;
            var sb = new StringBuilder(length);

            for (var i = 0; i < length; i++)
            {
                var c = str[i];

                if(i + 1 < length) {
                    var s = str[i].ToString() + str[i + 1].ToString();
                    
                    if(IsConsonants(s)) {
                        i++;

                        if(IsConsonantsSandhanganPanyigeg(s)) {
                            if(i - 2 >= 0 && i + 1 < length) {
                                var cBefore = str[i - 2];
                                var cAfter = str[i + 1];

                                if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                                    sb.Append(GetSandhanganPanyigeg(s));
                                    continue;
                                }
                            }
                        }
                      
                        if(IsConsonants(s)) {
                            if(i - 3 >= 0) {
                                var cBefore = str[i - 3].ToString() + str[i - 2].ToString();

                                if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                                    sb.Append(GetPasangan(s));
                                } else {
                                    sb.Append(GetWyanjana(s));
                                
                                    if(i == length - 1) {
                                        sb.Append("\\");
                                    }
                                }

                                continue;
                            }
                            
                            if(i - 2 >= 0) {
                                var cBefore = str[i - 2];

                                if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                                    sb.Append(GetPasangan(s));
                                } else {
                                    sb.Append(GetWyanjana(s));
                                
                                    if(i == length - 1) {
                                        sb.Append("\\");
                                    }
                                }

                                continue;
                            }


                            sb.Append(GetWyanjana(s));
                            
                            if(i == length - 1) {
                                sb.Append("\\");
                            }
                            continue;
                        }  
                        
                        sb.Append(s);
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
                            sb.Append(GetPasangan(c));
                            continue;
                        }
                    }
                    
                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append(GetPasangan(c));
                            continue;
                        }
                    }

                    if(i + 1 < length && IsPaCeret(c.ToString() + str[i + 1].ToString())) {
                        sb.Append("x");
                        i++;
                        continue;
                    }

                    if(i + 1 < length && IsNgaLelet(c.ToString() + str[i + 1].ToString())) {
                        sb.Append("X");
                        i++;
                        continue;
                    }

                    sb.Append(GetWyanjana(c));
                    
                    if(i == length - 1) {
                        sb.Append("\\");
                    }
                    continue;
                }
                
                if(IsVowels(c)) {
                    if(i - 1 >= 0 && IsConsonants(str[i - 1])) {
                        if(IsVowelsTalingTarung(c)) {
                            sb.Insert(sb.Length - CountConsonantsBackward(str, i), "[");
                            sb.Append("o");
                        } else if(IsVowelsTaling(c)) {
                            sb.Insert(sb.Length - CountConsonantsBackward(str, i), "[");
                        } else {
                            sb.Append(GetSandhanganSwara(c));
                        } 

                        // Diphthong
                        if(i + 1 < length && IsVowelsA(c) && IsVowels(str[i + 1])) {
                            if(IsVowelsWulu(str[i + 1])) {
                                sb.Insert(sb.Length - CountConsonantsBackward(str, i), "{");
                                i++;
                                continue;
                            } else if(IsVowelsSuku(str[i + 1])) {
                                sb.Insert(sb.Length - CountConsonantsBackward(str, i), "{");
                                sb.Append("o");
                                i++;
                                continue;
                            }
                        }
                    } else {
                        if(IsVowelsTalingTarung(c)) {
                            sb.Append("[ao");
                        } else if(IsVowelsTaling(c)) {
                            sb.Append("[a");
                        } else {
                            sb.Append("a" + GetSandhanganSwara(c));
                        }
                    }

                    // Diphthong
                    if(i + 1 < length && IsVowelsA(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsA(str[i + 1])) {
                            sb.Append(GetSandhanganSwara("aa"));
                            i++;
                        } else if(IsVowelsWulu(str[i + 1])) {
                            sb.Insert(sb.Length - 1, "{");
                            i++;
                        } else if(IsVowelsSuku(str[i + 1])) {
                            sb.Insert(sb.Length - 1, "{");
                            sb.Append("o");
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
                            sb.Append(GetWyanjana("y") + GetSandhanganSwara("a"));
                            i++;
                        } else if(IsVowelsTalingTarung(str[i + 1])) {
                            sb.Append("[" + GetWyanjana("y") + "o");
                            i++;
                        }
                    } else if(i + 1 < length && IsVowelsTalingTarung(c) && IsVowels(str[i + 1])) {
                        if(IsVowelsTaling(str[i + 1])) {
                            sb.Append("[" + GetWyanjana("w"));
                            i++;
                        }
                    }
                    continue;
                }
                
                if(IsCharactersPada(c)) {
                     if(i - 2 >= 0) {
                        var cBefore = str[i - 2].ToString() + str[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append("\\");
                            continue;
                        }
                    }
                    
                    if(i - 1 >= 0) {
                        var cBefore = str[i - 1];

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(sb[sb.Length - 1])) {
                            sb.Append("\\");
                            continue;
                        }
                    }

                    sb.Append(GetPada(c));
                    continue;
                }
            }

            return sb.ToString();
        }

        private static bool IsConsonants(char c) {
            return wyanjana.ContainsKey(c.ToString());
        }

        private static bool IsConsonants(string s) {
            return wyanjana.ContainsKey(s);
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