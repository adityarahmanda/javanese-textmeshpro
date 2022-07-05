using System;
using System.Collections.Generic;

namespace JVTMPro.Utilities
{
    public class LatinToJava
    {
        private Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
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

        private bool IsWyanjana(string s) { 
            return wyanjana.ContainsValue(s); 
        }

        private bool IsWyanjana(char c) { 
            return IsWyanjana(c.ToString());
        }

        private bool IsWyanjanaPasanganInRight(string wyanjana) { 
            return wyanjana == "ꦥ" || wyanjana == "ꦥ꦳" || wyanjana == "ꦲ" || wyanjana == "ꦏ꧀ꦱ" || wyanjana == "ꦰ" || wyanjana == "ꦱ" || wyanjana == "ꦦ"; 
        }

        private bool IsWyanjanaPasanganInRight(char wyanjana) { 
            return IsWyanjanaPasanganInRight(wyanjana.ToString());
        }

        private bool IsWyanjanaPasanganInBelow(string wyanjana) { 
            return IsWyanjana(wyanjana) && !IsWyanjanaPasanganInRight(wyanjana); 
        }

        private bool IsWyanjanaPasanganInBelow(char wyanjana) { 
            return IsWyanjanaPasanganInBelow(wyanjana.ToString()); 
        }
        
        private string GetWyanjana(char c) {
            return wyanjana[c.ToString()];
        }

        private string GetWyanjana(string s) {
            return wyanjana[s];
        }

        private Dictionary<string, string> swara = new Dictionary<string, string>() {
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
        
        private string GetSwara(char c) {
            return swara[c.ToString()];
        }

        private string GetSwara(string s) {
            return swara[s];
        }

        private Dictionary<string, string> murda = new Dictionary<string, string>() {
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

        private string GetMurda(char c) {
            return GetMurda(c.ToString());
        }

        private string GetMurda(string s) {
            return murda[s];
        }

        private Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string>() {
            { "r", "ꦿ" },   // cakra
            { "ṛ", "ꦽ" },   // cakra keret
            { "y", "ꦾ" },   // pengkal
        };

        private string GetSandhanganWyanjana(char c) {
            return sandhanganWyanjana[c.ToString()];
        }

        private string GetSandhanganWyanjana(string s) {
            return sandhanganWyanjana[s];
        }

        private Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string>() {
            { "r", "ꦂ" },
            { "h", "ꦃ" }, 
            { "ng", "ꦁ" },
        };

        private string GetSandhanganPanyigeg(char c) {
            return sandhanganPanyigeg[c.ToString()];
        }

        private string GetSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg[s];
        }

        private bool IsSandhanganPanyigeg(char c) {
            return IsSandhanganPanyigeg(c.ToString());
        }

        private bool IsSandhanganPanyigeg(string s) {
            return s == "ꦁ" || s == "ꦃ" || s == "ꦂ";
        }

        private Dictionary<string, string> sandhanganSwara = new Dictionary<string, string>() {
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

        private string GetSandhanganSwara(char c) {
            return sandhanganSwara[c.ToString()];            
        }

        private string GetSandhanganSwara(string s) {
            return sandhanganSwara[s];            
        }

        private Dictionary<string, string> pada = new Dictionary<string, string>() {
            { " ", "​" },
            { ".", "꧉" },
            { ",", "꧈" },
            { "-", "" },
        };

        private string GetPada(char c) {
            return pada[c.ToString()];            
        }

        private string GetPada(string s) {
            return pada[s];            
        }

        /// <summary>Mentransliterasikan teks huruf Latin menjadi aksara Jawa</summary>
        /// <param name="text">Teks yang akan ditransliterasikan</param>
        /// <param name="murda">
        /// Saat bernilai true, aksara murda yang khususnya digunakan dalam penulisan nama, gelar, 
        /// atau tempat dalam penulisan aksara Jawa akan diturutsertakan dalam proses transliterasi.
        /// </param>
        /// <param name="dirga">
        /// Saat bernilai true, vokal rangkap 'ai', 'au', 'aa', 'ii', dan 'uu' akan dikonversikan menjadi 
        /// sandangan swara dirga.
        /// </param>
        /// <param name="ignoreSpace">
        /// Saat bernilai true, spasi dari kolom masukan akan diabaikan dalam proses transliterasi. 
        /// Sebaliknya saat bernilai false, spasi akan dikonversikan menjadi zero width space (spasi tak nampak).
        /// </param>
        /// <returns>Hasil luaran dari proses transliterasi</returns>
        public string Transliterate(string text, bool murda = false, bool dirga = false, bool ignoreSpace = true) {
            int length = text.Length;
            List<string> output = new List<string>();
            bool isMurdaAlreadyIncluded = false;
            bool isAlreadyStacked = false;

            for (int i = 0; i < length; i++)
            {
                var c = text[i];

                if(i + 1 < length) {
                    var c2 = text[i + 1];
                    var c12 = c.ToString() + c2.ToString();
                    
                    if(IsConsonants(c12)) {
                        i++;

                        if(c12 == c12.ToUpper()) {
                            c12 = c12.ToLower();
                        }

                        if(IsConsonantsSandhanganPanyigeg(c12)) {
                            isAlreadyStacked = false;

                            if(i - 2 >= 0 && i + 1 < length) {
                                var cBefore = text[i - 2];
                                var cAfter = text[i + 1];

                                if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                                    output.Add(GetSandhanganPanyigeg(c12));
                                    continue;
                                }
                            }

                            if(i - 2 >= 0 && i == length - 1) {
                                var cBefore = text[i - 2];

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
                        var cBefore = text[i - 1];
                        var cAfter = text[i + 1];

                        if(IsVowels(cBefore) && !IsVowels(cAfter)) {
                            isSandhanganPanyigeg = true;
                        }
                    }

                    if(i - 1 >= 0 && i == length - 1) {
                        var cBefore = text[i - 1];

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
                        var cBefore = text[i - 2].ToString() + text[i - 1].ToString();

                        if(IsConsonants(cBefore) && !IsSandhanganPanyigeg(output[output.Count - 1])) {
                            isSandhanganWyanjana = true;
                        }
                    }

                    if(i - 1 >= 0) {
                        var cBefore = text[i - 1];

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
                        var c2 = text[i + 1];

                        // change ia, iu, ie, iê, io to iya, iyu, iye, iyê, iyo
                        if(IsVowelsWulu(c) && IsVowels(c2) && !IsVowelsWulu(c2)) {
                            text = text.Substring(0, i + 1) + "y" + text.Substring(i + 1);
                            length = text.Length;
                        }

                        // change ua, ui, ue, uê, uo to uwa, uwi, uwe, uwê, uwo
                        if(IsVowelsSuku(c) && IsVowels(c2) && !IsVowelsSuku(c2)) {
                            text = text.Substring(0, i + 1) + "w" + text.Substring(i + 1);
                            length = text.Length;
                        }

                        // change ea to eya
                        if(IsVowelsTaling(c) && IsVowelsA(c2)) {
                            text = text.Substring(0, i + 1) + "y" + text.Substring(i + 1);
                            length = text.Length;
                        }

                        // change eo to eyo
                        if(IsVowelsTaling(c) && IsVowelsTalingTarung(c2)) {
                            text = text.Substring(0, i + 1) + "y" + text.Substring(i + 1);
                            length = text.Length;
                        }
                        
                        // change oa to owa
                        if(IsVowelsTalingTarung(c) && IsVowelsA(c2)) {
                            text = text.Substring(0, i + 1) + "w" + text.Substring(i + 1);
                            length = text.Length;
                        }
                        
                        // change oe to owe
                        if(IsVowelsTalingTarung(c) && IsVowelsTaling(c2)) {
                            text = text.Substring(0, i + 1) + "w" + text.Substring(i + 1);
                            length = text.Length;
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
                                var cBefore = text[i - 1];
                                
                                if(cBefore == 'l' && !IsPangkon(lastOutputChar)) {
                                    output.RemoveAt(output.Count - 1); // pop pangkon
                                    output.RemoveAt(output.Count - 1); // pop aksara la
                                    output.Add("ꦊ"); // replace them with nga lelet
                                    continue;
                                }
                            }
                        }

                        if(i - 1 >= 0) {
                            var cBefore = text[i - 1];
                            
                            // check pa ceret
                            if(cBefore == 'r') {
                                output.RemoveAt(output.Count - 1); // pop pangkon
                                output.RemoveAt(output.Count - 1); // pop aksara la
                                output.Add("ꦉ"); // replace them with pa ceret
                                continue;
                            }
                        }
                    }            
                    
                    if(i - 1 >= 0 && IsConsonants(text[i - 1])) {
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

                    // dirga
                    if(dirga && i + 1 < length && IsVowels(text[i + 1])) {
                        var c2 = text[i + 1];

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

        private bool IsConsonants(char c) {
            return wyanjana.ContainsKey(c.ToString());
        }

        private bool IsConsonants(string s) {
            return wyanjana.ContainsKey(s);
        }

        private bool IsConsonantsMurda(char c) {
            return IsConsonantsMurda(c.ToString());
        }

        private bool IsConsonantsMurda(string s) {
            return murda.ContainsKey(s);
        }

        private bool IsConsonantsSandhanganPanyigeg(char c) {
            return sandhanganPanyigeg.ContainsKey(c.ToString());
        }

        private bool IsConsonantsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg.ContainsKey(s);
        }

        private bool IsConsonantsSandhanganWyanjana(char c) {
            return sandhanganWyanjana.ContainsKey(c.ToString());
        }

        private bool IsConsonantsSandhanganWyanjana(string s) {
            return sandhanganWyanjana.ContainsKey(s);
        }

        private bool IsConsonantsPasanganOnRight(string s) {
            return s == "h" || s == "s" || s == "p" || s == "p̣" || s == "ny" || s == "ñ";
        }

        private bool IsConsonantsPasanganOnRight(char c) {
            return IsConsonantsPasanganOnRight(c.ToString());
        }

        private bool IsConsonantsPasanganOnBelow(string s) {
            return IsConsonants(s) && !IsConsonantsPasanganOnRight(s);
        }

        private bool IsConsonantsPasanganOnBelow(char c) {
            return IsConsonants(c.ToString()) && !IsConsonantsPasanganOnRight(c.ToString());
        }

        private bool IsPaCeret(string s) {
            return s[0] == 'r' && IsVowelsPepet(s[1]);
        }
        
        private bool IsNgaLelet(string s) {
            return s[0] == 'l' && IsVowelsPepet(s[1]);
        }

        private bool IsNaMatiKetemuCaJa(string s) {
            return s[0] == 'n' && s[1] == 'c' || s[0] == 'n' && s[1] == 'j';
        }

        private bool IsVowels(char c) {
            return sandhanganSwara.ContainsKey(c.ToString());
        }

        private bool IsVowels(string s) {
            return sandhanganSwara.ContainsKey(s);
        }

        private bool IsVowelsA(string s) {
            return s == "a" || s == "ô";
        }

        private bool IsVowelsA(char c) {
            return IsVowelsA(c.ToString());
        }

        private bool IsVowelsPepet(string s) {
            return s == "ê" || s == "ě";
        }

        private bool IsVowelsPepet(char c) {
            return IsVowelsPepet(c.ToString());
        }

        private bool IsVowelsWulu(string s) {
            return s == "i";
        }

        private bool IsVowelsWulu(char c) {
            return IsVowelsWulu(c.ToString());
        }

        private bool IsVowelsSuku(string s) {
            return s == "u";
        }

        private bool IsVowelsSuku(char c) {
            return IsVowelsSuku(c.ToString());
        }

        private bool IsVowelsTaling(string s) {
            return s == "e" || s == "é" || s == "è";
        }

        private bool IsVowelsTaling(char c) {
            return IsVowelsTaling(c.ToString());
        }

        private bool IsVowelsTalingTarung(string s) {
            return s == "o";
        }

        private bool IsVowelsTalingTarung(char c) {
            return IsVowelsTalingTarung(c.ToString());
        }

        private bool IsPangkon(string s) {
            return s == "꧀";
        }

        private bool IsPangkon(char c) {
            return IsPangkon(c.ToString());
        }

        private bool IsVowelsSwara(string s) {
            return swara.ContainsKey(s);
        }

        private bool IsVowelsSwara(char c) {
            return IsVowelsSwara(c.ToString());
        }

        private bool IsCharactersPada(string s) {
            return pada.ContainsKey(s);
        }

        private bool IsCharactersPada(char c) {
            return pada.ContainsKey(c.ToString());
        }

        private bool IsCakra(string s) {
            return s == "ꦿ";
        }

        private bool IsCakra(char c) {
            return IsCakra(c.ToString());
        }
    }
}
