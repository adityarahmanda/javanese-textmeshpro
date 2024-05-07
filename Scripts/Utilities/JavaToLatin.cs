using System;
using System.Collections.Generic;

namespace JVTMPro.Utilities
{
    public class JavaToLatin
    {
        private Dictionary<string, string> wyanjana = new Dictionary<string, string>() {
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

        private bool IsWyanjana(char c) {
            return IsWyanjana(c.ToString());
        }

        private bool IsWyanjana(string s) {
            return wyanjana.ContainsKey(s);
        }

        private Dictionary<string, string> rekan = new Dictionary<string, string>() { 
            { "ꦢ", "dz" },        // dz 
            { "ꦒ", "gh" },        // gha 
            { "ꦗ", "z" },        // za
            { "ꦥ", "f" },        // fa
            { "ꦮ", "v" },        // va
        };

        private bool IsRekan(char c) {
            return IsRekan(c.ToString());
        }

        private bool IsRekan(string s) {
            return rekan.ContainsKey(s);
        }

        private Dictionary<string, string> swara = new Dictionary<string, string>() { 
            { "ꦄ", "A" },        // a 
            { "ꦆ", "I" },        // i 
            { "ꦅ", "I" },        // i kawi
            { "ꦈ", "U" },        // u 
            { "ꦌ", "E" },        // e 
            { "ꦎ", "O" },        // o 
        };

        private bool IsSwara(char c) {
            return IsSwara(c.ToString());
        }

        private bool IsSwara(string s) {
            return swara.ContainsKey(s);
        }

        // diacritics swara
        private Dictionary<string, string> sandhanganSwara = new Dictionary<string, string> {
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

        private bool IsSandhanganSwara(char c) {
            return IsSandhanganSwara(c.ToString());
        }

        private bool IsSandhanganSwara(string s) {
            return sandhanganSwara.ContainsKey(s);
        }

        // diacritics swara
        private Dictionary<string, string> sandhanganWyanjana = new Dictionary<string, string> {
            { "ꦿ", "r" },       // cakra
            { "ꦽ", "r" },       // cakra kêrêt
            { "ꦾ", "y" },       // pengkal
        };

        private bool IsSandhanganWyanjana(char c) {
            return IsSandhanganWyanjana(c.ToString());
        }

        private bool IsSandhanganWyanjana(string s) {
            return sandhanganWyanjana.ContainsKey(s);
        }

        private Dictionary<string, string> sandhanganPanyigeg = new Dictionary<string, string> {
            { "ꦂ", "r" },        // layar (r)
            { "ꦁ", "ng" },       // cecak (ng)
            { "ꦃ", "h" },        // wigyan (h)            
            { "ꦀ", "ṁ" },          // panyangga (ṁ)
        };

        private bool IsSandhanganPanyigeg(char c) {
            return IsSandhanganPanyigeg(c.ToString());
        }

        private bool IsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg.ContainsKey(s);
        }

        // punctuations
        private Dictionary<string, string> pada = new Dictionary<string, string> {
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

        private bool IsPada(char c) {
            return IsPada(c.ToString());
        }

        private bool IsPada(string s) {
            return pada.ContainsKey(s);
        }

        /// <summary>Mentransliterasikan teks aksara Jawa menjadi huruf Latin</summary>
        /// <param name="text">Teks yang akan ditransliterasikan</param>
        /// <returns>Hasil luaran dari proses transliterasi</returns>
        public string Transliterate(string text) {
            var length = text.Length;
            List<string> output = new List<string>();

            for (int i = 0; i < length; i++) {
                var c = text[i];

                if(IsPangkon(c)) {
                    if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                        output.RemoveAt(output.Count - 1);
                        continue;
                    }
                }

                if(IsCecakTelu(c)) {
                    if(i - 1 >= 0 && IsRekan(text[i - 1])) {
                        if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                            output.RemoveAt(output.Count - 1);
                        }
                        output.RemoveAt(output.Count - 1);
                        output.Add(GetConsonantsRekan(text[i - 1]));
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
                        if(IsWyanjana(text[i - 1]) || (IsSandhanganWyanjana(text[i - 1]) && !IsCakraKeret(text[i - 1]))) {
                            if(output.Count - 1 >= 0 && output[output.Count - 1] == "a") {
                                output.RemoveAt(output.Count - 1);
                            }

                            output.Add(GetVowelsSandhanganSwara(c));
                            continue;
                        }

                        if(IsCecakTelu(text[i - 1])) {
                            if(i - 2 >= 0) {
                                if(IsWyanjana(text[i - 2]) || (IsSandhanganWyanjana(text[i - 2]) && !IsCakraKeret(text[i - 2]))) {
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
                
                if(IsSandhanganPanyigeg(c)) {
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
                
                if(IsWyanjana(c)) {
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

        private bool IsPaCeret(char c) { 
            return c == 'ꦉ'; 
        }

        private bool IsNgaLelet(char c) { 
            return c == 'ꦊ'; 
        }

        private bool IsNgaLeletRaswadi(char c) { 
            return c == 'ꦋ'; 
        }

        private bool IsPangkon(char c) {
            return c == '꧀';
        }

        private bool IsCakraKeret(char c){ 
            return c == 'ꦽ';
        }

        private bool IsTarung(char c) { 
            return c == 'ꦴ'; 
        }

        private bool IsCecakTelu(char c) { 
            return c == '꦳'; 
        }

        private string GetConsonantsWyanjana(char c) {
            return GetConsonantsWyanjana(c.ToString());
        }

        private string GetConsonantsWyanjana(string s) {
            return wyanjana[s];
        }

        private string GetConsonantsRekan(char c) {
            return GetConsonantsRekan(c.ToString());
        }

        private string GetConsonantsRekan(string s) {
            return rekan[s];
        }

        private string GetConsonantsSwara(char c) {
            return GetConsonantsSwara(c.ToString());
        }

        private string GetConsonantsSwara(string s) {
            return swara[s];
        }

        private string GetConsonantsSandhanganWyanjana(char c) {
            return GetConsonantsSandhanganWyanjana(c.ToString());
        }

        private string GetConsonantsSandhanganWyanjana(string s) {
            return sandhanganWyanjana[s];
        }

        private string GetConsonantsSandhanganPanyigeg(char c) {
            return GetConsonantsSandhanganPanyigeg(c.ToString());
        }

        private string GetConsonantsSandhanganPanyigeg(string s) {
            return sandhanganPanyigeg[s];
        }

        private string GetVowelsSandhanganSwara(char c) {
            return GetVowelsSandhanganSwara(c.ToString());
        }

        private string GetVowelsSandhanganSwara(string s) {
            return sandhanganSwara[s];
        }
        
        private string GetPunctuations(char c) {
            return GetPunctuations(c.ToString());
        }

        private string GetPunctuations(string s) {
            return pada[s];
        }
    }
}