using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transliterator : MonoBehaviour
{
    Dictionary<string, string> letters = new Dictionary<string, string>() {
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

    Dictionary<string, string> letterRekans = new Dictionary<string, string> {
        { "ꦲ꦳", "ḥa" },
        { "ꦏ꦳", "kha" },
        { "ꦢ꦳", "dza" },
        { "ꦱ꦳", "sya" },
        { "ꦥ꦳", "fa" },
        { "ꦗ꦳", "za" },
        { "ꦒ꦳", "gha" },
        { "ꦔ꦳", "'a" },
    };

    Dictionary<string, string> letterSwara = new Dictionary<string, string> {
        { "ꦄ", "A" },      //swara-A
        { "ꦅ", "I" },      //I-Kawi -- archaic
        { "ꦆ", "I" },      //I
        { "ꦇ", "I" },     //Ii -- archaic
        { "ꦈ", "U" },      //U
        { "ꦌ", "E" },      //E
        { "ꦍ", "Ai" },     //Ai
        { "ꦎ", "O" },      //O
    };

    Dictionary<string, string> diacriticsWyanjana = new Dictionary<string, string>() {
        { "ꦿ", "ra"},
        { "ꦾ", "ya"},
        { "ꦽ", "rê"},
    };

    Dictionary<string, string> diacriticsSwara = new Dictionary<string, string>() {
        { "ꦴ", "aa"},
        { "ꦶ", "i"},
        { "ꦷ", "ii" }, 
        { "ꦸ", "u"},
        { "ꦹ", "uu" }, 
        { "ꦺ", "e"},
        { "ꦼ", "ê"},
        { "ꦻ", "ai" }, 
    };

    Dictionary<string, string> diacriticsSigeg = new Dictionary<string, string>() {
        { "ꦀ", "m"},
        { "ꦁ", "ng"},    // sigeg ng/ŋ
        { "ꦂ", "r"},
        { "ꦃ", "h"}
    };

    Dictionary<string, string> numbers = new Dictionary<string, string> {
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

    Dictionary<string, string> specialCharacters = new Dictionary<string, string>() {
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

    public string JavaToLatin(string input) {
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
}
