using System;
using System.Collections.Generic;
using System.Text;

namespace JVTMPro.Utilities {
    /// <summary>
    /// Perkakas yang digunakan untuk memperbaiki kesalahan rendering teks aksara Jawa
    /// </summary>
    public static class JavaneseTextFixer {
        private static Dictionary<char, char> pasangan = new Dictionary<char, char>() {
            { 'ꦄ', '\xE000' },      // A
            { 'ꦅ', '\xE001' },      // I kawi
            { 'ꦆ', '\xE002' },      // I
            { 'ꦇ', '\xE003' },      // II
            { 'ꦈ', '\xE004' },       // U
            { 'ꦉ', '\xE005' },       // rê (pa cerek)
            { 'ꦊ', '\xE007' },       // lê (nga lelet)
            { 'ꦋ', '\xE008' },       // lö (nga lelet raswadi)
            { 'ꦌ', '\xE009' },       // E
            { 'ꦍ', '\xE00A' },       // Ê
            { 'ꦎ', '\xE012' },       // O
            { 'ꦏ', '\xE013' },       // ka - \xE014 full
            { 'ꦐ', '\xE015' },       // qa (ka sasak) - \xE016 full											
            { 'ꦑ', '\xE017' },       // ka murda
            { 'ꦒ', '\xE018' },       // ga
            { 'ꦓ', '\xE019' },       // ga murda
            { 'ꦔ', '\xE01A' },       // nga 
            { 'ꦕ', '\xE01B' },       // ca - \xE01C full, \xE01D short, \xE01E full short 
            { 'ꦖ', '\xE01F' },       // ca murda - \xE020 full, \xE021 short, \xE022 full short 
            { 'ꦗ', '\xE023' },       // ja - \xE024 full, \xE025 short, \xE026 full short 
            { 'ꦘ', '\xE027' },       // nya murda - \xE028 full, \xE029 short, \xE02A full short, \xE02B old 
            { 'ꦙ', '\xE02C' },       // ja mahaprana - \xE02D short, \xE02E alt short, \xE02F alt full, \xE030 alt full short
            { 'ꦚ', '\xE031' },       // nya - \xE032 full, \xE033 alt, \xE034 full short, \xE035 old
            { 'ꦛ', '\xE036' },       // tha - \xE037 full, \xE038 short, \xE039 full short
            { 'ꦜ', '\xE03A' },       // tha mahaprana - \xE03B full
            { 'ꦝ', '\xE03E' },       // dha - \xE03F full, \xE040 short, \xE041 full short
            { 'ꦞ', '\xE042' },       // dha mahaprana
            { 'ꦟ', '\xE043' },       // na murda
            { 'ꦠ', '\xE044' },       // ta - \xE045 full														
            { 'ꦡ', '\xE046' },       // ta murda - \xE047 full, \xE048 short, \xE049 full short
            { 'ꦢ', '\xE04A' },       // da - \xE04B short, \xE04C full, \xE04D alt short
            { 'ꦣ', '\xE04E' },       // da mahaprana
            { 'ꦤ', '\xE04F' },       // na - \xE050 full, \xE051 short, \xE052 full short
            { 'ꦥ', '\xE053' },       // pa - \xE054 alt
            { 'ꦦ', '\xE055' },       // pa murda - \xE056 alt
            { 'ꦧ', '\xE057' },       // ba - \xE058 short, \xE059 old
            { 'ꦨ', '\xE05A' },       // ba murda
            { 'ꦩ', '\xE05B' },       // ma murda - \xE05C full, \xE05D short, \xE05E full short
            { 'ꦪ', '\xE05F' },       // ya
            { 'ꦫ', '\xE060' },       // ra
            { 'ꦬ', '\xE061' },       // ra agung
            { 'ꦭ', '\xE062' },       // la - \xE064 full, \xE065 alt, \xE066 alt suku, \xE067 alt dirgha mendhut
            { 'ꦮ', '\xE068' },       // wa - \xE069 full, \xE06A short, \xE06B full short, \xE06C alt, \xE06D alt suku, \xE06E alt dirga mendhut  
            { 'ꦯ', '\xE06F' },       // sa murda 		
            { 'ꦰ', '\xE070' },       // sa mahaprana - \xE071 small, \xE072 medium, \xE073 large, \xE074 alt
            { 'ꦱ', '\xE075' },       // sa - \xE076 small
            { 'ꦲ', '\xE077' },       // ha - \xE078 alt
        };

        private static bool IsPasangan(char c) {
            return pasangan.ContainsValue(c);
        }

        private static Dictionary<char, char> fullShapePasangan = new Dictionary<char, char>() {
            { 'ꦏ', '\xE014' },       // ka
            { 'ꦐ', '\xE016' },       // qa (ka sasak) 
            { 'ꦕ', '\xE01C' },       // ca 
            { 'ꦖ', '\xE020' },       // ca murda
            { 'ꦗ', '\xE024' },       // ja
            { 'ꦘ', '\xE028' },       // nya murda
            { 'ꦚ', '\xE032' },       // nya
            { 'ꦛ', '\xE037' },       // tha
            { 'ꦜ', '\xE03B' },       // tha mahaprana
            { 'ꦝ', '\xE03F' },       // dha
            { 'ꦠ', '\xE045' },       // ta 											
            { 'ꦡ', '\xE047' },       // ta murda 
            { 'ꦢ', '\xE04C' },       // da 
            { 'ꦤ', '\xE050' },       // na
            { 'ꦩ', '\xE05C' },       // ma murda 
            { 'ꦭ', '\xE064' },       // la
            { 'ꦮ', '\xE069' },       // wa
        };

        private static char[] smallWyanjana = new char[] {
            'ꦅ', 'ꦈ', 'ꦉ', 'ꦊ', 'ꦋ', 'ꦌ', 'ꦍ', 'ꦎ', 'ꦑ', 'ꦔ', 'ꦕ',
            'ꦗ', 'ꦘ', 'ꦛ', 'ꦜ', 'ꦝ', 'ꦞ', 'ꦡ', 'ꦢ', 'ꦣ', 'ꦤ', 'ꦥ',
            'ꦦ', 'ꦨ', 'ꦩ', 'ꦫ', 'ꦮ', 'ꦰ', 'ꦱ', 'ꦒ', 'ꦯ'
        };

        private static char[] mediumWyanjana = new char[] {
            'ꦄ', 'ꦆ', 'ꦇ', 'ꦐ', 'ꦏ', 'ꦓ',
            'ꦠ', 'ꦧ', 'ꦪ', 'ꦭ', 'ꦲ'
        };

        private static char[] largeWyanjana = new char[] {
            'ꦖ', 'ꦚ', 'ꦟ', 'ꦬ',
        };

        private static char[] altWyanjana = new char[] {
            'ꦙ'
        };

        private static char[] altPasangan = new char[] {
            'ꦑ', 'ꦔ', 'ꦕ', 'ꦖ', 'ꦗ', 'ꦘ', 'ꦚ', 'ꦛ', 'ꦩ', 'ꦝ', 'ꦞ', 
            'ꦡ', 'ꦢ', 'ꦣ', 'ꦤ', 'ꦧ', 'ꦨ', 'ꦩ', 'ꦫ', 'ꦮ', 'ꦰ', 'ꦙ'
        };

        /// <summary>Memperbaiki kesalahan rendering teks aksara Jawa</summary>
        /// <param name="s">String teks yang akan diperbaiki</param>
        /// <returns>Hasil luaran perbaikan teks</returns>
        public static string Fix(string s)
        {
            var length = s.Length;
            var sb = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                var c = s[i];

                if(IsCakra(c)) {
                    bool isCakraAlt = false;
                    int cakraAltPos = -1;

                    bool isWyanjanaPasangan = false;
                    char wyanjanaKepasanganCakra = '\0';
                    int wyanjanaKepasanganCakraPos = -1;
                    
                    // find cakra's wyanjana and alt pos
                    for(int j = sb.Length - 1; j >= 0; j--) {
                        if(IsPasangan(sb[j])) {
                            isWyanjanaPasangan = true;
                            wyanjanaKepasanganCakraPos = j;
                            wyanjanaKepasanganCakra = GetWyanjanaFromPasangan(sb[j]);

                            if(i + 1 < length) {
                                var c2 = s[i + 1];

                                if(isWyanjanaPasangan && IsSuku(c2) && IsPasanganOnBelow(wyanjanaKepasanganCakra)) {
                                    isCakraAlt = true;
                                }
                            }

                            if(IsAlt(wyanjanaKepasanganCakra)) {
                                isCakraAlt = true;
                            }

                            if(isCakraAlt) {
                                cakraAltPos = j - 1;
                                if(cakraAltPos < 0) {
                                    cakraAltPos = 0;
                                }
                            }
                            break;
                        }
                        
                        if(IsWyanjana(sb[j])) {
                            wyanjanaKepasanganCakraPos = j;
                            wyanjanaKepasanganCakra = sb[j];

                            if(IsAlt(wyanjanaKepasanganCakra)) {
                                isCakraAlt = true;
                            }

                            if(isCakraAlt) {
                                cakraAltPos = j - 1;
                                if(cakraAltPos < 0) {
                                    cakraAltPos = 0;
                                }
                            }
                            break;
                        }
                    }

                    if(isCakraAlt) {
                        sb.Insert(cakraAltPos, '\xE114');
                        continue;
                    }

                    if(isWyanjanaPasangan && IsPasanganOnBelow(wyanjanaKepasanganCakra)) {
                        // replace pasangan with full shape pasangan
                        if(IsPasanganHasFullShape(wyanjanaKepasanganCakra)) {
                            sb.Remove(wyanjanaKepasanganCakraPos, 1);
                            sb.Insert(wyanjanaKepasanganCakraPos, GetFullShapePasangan(wyanjanaKepasanganCakra));
                        }

                        if(IsSmall(wyanjanaKepasanganCakra)) {
                            sb.Append('\xE118'); // small cakra for pasangan
                            continue;
                        }
                        
                        if(IsMedium(wyanjanaKepasanganCakra)) {
                            sb.Append('\xE119'); // medium cakra for pasangan
                            continue;
                        }
                        
                        if(IsLarge(wyanjanaKepasanganCakra)) {
                            sb.Append('\xE11A'); // large cakra for pasangan
                            continue;
                        }
                    }

                    if(IsSmall(wyanjanaKepasanganCakra)) {
                        sb.Append('\xE115');  // small cakra
                        continue;
                    }
                    
                    if(IsMedium(wyanjanaKepasanganCakra)) {
                        sb.Append('\xE116');  // medium cakra
                        continue;
                    } 
                    
                    if(IsLarge(wyanjanaKepasanganCakra)) {
                        sb.Append('\xE117');  // big cakra
                        continue;
                    }
                }

                if(IsPangkon(c)) {
                    if(i + 1 < length) {
                        var c2 = s[i + 1];
                        
                        if(IsWyanjana(c2)) {
                            sb.Append(GetPasangan(c2));
                            i++;
                            continue;
                        }
                    }
                }

                if(IsTaling(c)) {
                    int talingPos = -1;
                    for(int j = sb.Length - 1; j >= 0; j--) {
                        if(IsSandhanganSwara(sb[j])) {
                            talingPos = j + 1;
                            break;
                        }
                        
                        if(IsWyanjana(sb[j])) {
                            if(j - 1 >= 0){
                                if(IsCakraAlt(sb[j - 1])) {
                                    talingPos = j - 1;
                                    break;
                                }
                            } 

                            talingPos = j;
                            break;
                        }
                    }

                    if(talingPos != -1) {
                        sb.Insert(talingPos, c);
                        continue;
                    }
                }

                if(IsSuku(c)) {
                    if(sb.Length - 1 >= 0) {
                        var sbLastChar = sb[sb.Length - 1];

                        if(IsCakra(sbLastChar) && IsCakraSmall(sbLastChar)) {
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append('\xE11B'); // cakra + u small ꦫꦿꦸ
                            continue;
                        }

                        if(IsCakra(sbLastChar) && IsCakraMedium(sbLastChar)) {
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append('\xE11C'); // cakra + u medium ꦏꦿꦸ
                            continue;
                        }

                        if(IsCakra(sbLastChar) && IsCakraBig(sbLastChar)) {
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append('\xE11D'); // cakra + u big ꦚꦿꦸ
                            continue;
                        }
                    }
                }

                if(IsSuku(c) || IsDirgaMendhut(c) || IsCakraKeret(c) || IsPengkal(c)) { 
                    if(sb.Length - 1 >= 0) {
                        var sbLastChar = sb[sb.Length - 1];

                        if(IsPasangan(sbLastChar)) {
                            var sbLastCharWyanjana = GetWyanjanaFromPasangan(sbLastChar);

                            if(IsPasanganOnBelow(sbLastCharWyanjana)) {
                                // replace pasangan to full shape pasangan
                                if(IsPasanganHasFullShape(sbLastCharWyanjana)) {
                                    sb.Remove(sb.Length - 1, 1);
                                    sb.Append(GetFullShapePasangan(sbLastCharWyanjana));
                                }

                                if(IsSuku(c)) {
                                    sb.Append('\xE08F'); // suku for pasangan ꦏ꧀ꦏꦸ
                                    continue;
                                }
                                
                                if(IsDirgaMendhut(c)) {
                                    sb.Append('\xE090'); // dirga mendhut for pasangan ꦏ꧀ꦏꦹ
                                    continue;
                                }
                                
                                if(IsCakraKeret(c)) {
                                    sb.Append('\xE094'); // cakra keret for pasangan ꦏ꧀ꦏꦽ
                                    continue;
                                }
                                
                                if(IsPengkal(c)) {
                                    sb.Append('\xE098'); // pengkal for pasangan ꦏ꧀ꦏꦾ 
                                    continue;
                                }
                            }
                        }
                    }
                }

                // wulu
                if(IsWulu(c)) {
                    if(sb.Length - 2 >= 0) {
                        var sbLastChar = sb[sb.Length - 1];
                        var sbLastChar2 = sb[sb.Length - 2];

                        if(IsCecakTelu(sbLastChar2) && IsCakra(sbLastChar)) {
                            // remove cecak telu
                            sb.Remove(sb.Length - 2, 1);

                            if(i + 1 < length) {
                                var c2 = s[i + 1]; 

                                if(IsPanyangga(c2)) {
                                    sb.Append('\xE07E'); // ꦳ꦶꦀ
                                    i++;
                                    continue;
                                }

                                if(IsCecak(c2)) {
                                    sb.Append('\xE07F'); // ꦳ꦶꦁ
                                    i++;
                                    continue;
                                }
                            
                                if(IsLayar(c2)) {
                                    sb.Append('\xE080'); // ꦳ꦶꦂ
                                    i++;
                                    continue;
                                }
                            }
                            
                            sb.Append('\xE07D'); // ꦳ꦶ
                            continue;
                        }
                    }

                    if(i + 1 < length) {
                        var c2 = s[i + 1];
                        
                        if(IsPanyangga(c2)) {
                            sb.Append('\xE089'); // ꦶꦀ
                            i++;
                            continue;
                        }

                        if(IsCecak(c2)) {
                            sb.Append('\xE08A'); // ꦶꦁ
                            i++;
                            continue;
                        }

                        if(IsLayar(c2)) {
                            sb.Append('\xE08B'); // ꦶꦂ
                            i++;
                            continue;
                        }
                    }
                }

                // pepet
                if(IsPepet(c)) {
                    if(sb.Length - 2 >= 0) {
                        var sbLastChar = sb[sb.Length - 1];
                        var sbLastChar2 = sb[sb.Length - 2];

                        if(IsCecakTelu(sbLastChar2) && IsCakra(sbLastChar)) {
                            // remove cecak telu
                            sb.Remove(sb.Length - 2, 1);

                            if(i + 1 < length) {
                                var c2 = s[i + 1]; 

                                if(IsPanyangga(c2)) {
                                    sb.Append('\xE086'); // ꦳ꦼꦀ
                                    i++;
                                    continue;
                                }

                                if(IsCecak(c2)) {
                                    sb.Append('\xE087'); // ꦳ꦼꦁ
                                    i++;
                                    continue;
                                }
                            
                                if(IsLayar(c2)) {
                                    sb.Append('\xE088'); // ꦳ꦼꦂ
                                    i++;
                                    continue;
                                }
                            }
                            
                            sb.Append('\xE085'); // ꦳ꦼ
                            continue;
                        }
                    }
                    
                    if(i + 1 < length) {
                        var c2 = s[i + 1];
                        
                        if(IsPanyangga(c2)) {
                            sb.Append('\xE091'); // ꦼꦀ
                            i++;
                            continue;
                        }

                        if(IsCecak(c2)) {
                            sb.Append('\xE092'); // ꦼꦁ
                            i++;
                            continue;
                        }

                        if(IsLayar(c2)) {
                            sb.Append('\xE093'); // ꦼꦂ
                            i++;
                            continue;
                        }
                    }
                }

                if(IsWuluMelik(c)) {
                    if(sb.Length - 2 >= 0) {
                        var sbLastChar = sb[sb.Length - 1];
                        var sbLastChar2 = sb[sb.Length - 2];

                        if(i + 1 < length) {
                            var c2 = s[i + 1];

                            if(IsPanyangga(c2)) {
                                sb.Append('\xE082'); // ꦳ꦷꦀ
                                i++;
                                continue;
                            }

                            if(IsCecak(c2)) {
                                sb.Append('\xE083'); // ꦳ꦷꦁ
                                i++;
                                continue;
                            }
                        
                            if(IsLayar(c2)) {
                                sb.Append('\xE084'); // ꦳ꦷꦂ
                                i++;
                                continue;
                            }
                        }

                        sb.Append('\xE081'); // ꦳ꦷ
                        continue;
                    }

                    if(i + 1 < length) {
                        var c2 = s[i + 1];

                        if(IsPanyangga(c2)) {
                            sb.Append('\xE08C'); // ꦷꦀ
                            i++;
                            continue;
                        }

                        if(IsCecak(c2)) {
                            sb.Append('\xE08D'); // ꦷꦁ
                            i++;
                            continue;
                        }

                        if(IsLayar(c2)) {
                            sb.Append('\xE08E'); // ꦷꦂ
                            i++;
                            continue;
                        }
                    }
                }

                // cecak telu
                if(IsCecakTelu(c)) {
                    if(i + 1 < length) {
                        var c2 = s[i + 1];

                        if(IsPanyangga(c2)) {
                            sb.Append('\xE07A'); // ꦳ꦀ
                            i++;
                            continue;
                        }

                        if(IsCecak(c2)) {
                            sb.Append('\xE07B'); // ꦳ꦁ
                            i++;
                            continue;
                        }

                        if(IsLayar(c2)) {
                            sb.Append('\xE07C'); // ꦳ꦂ
                            i++;
                            continue;
                        }

                        if(IsWulu(c2)) {
                            if(i + 2 < length) {
                                var c3 = s[i + 2];

                                if(IsPanyangga(c3)) {
                                    sb.Append('\xE07E'); // ꦳ꦶꦀ
                                    i += 2;
                                    continue;
                                }

                                if(IsCecak(c3)) {
                                    sb.Append('\xE07F'); // ꦳ꦶꦁ
                                    i += 2;
                                    continue;
                                }
                            
                                if(IsLayar(c3)) {
                                    sb.Append('\xE080'); // ꦳ꦶꦂ
                                    i += 2;
                                    continue;
                                }
                            }
                            
                            sb.Append(c);
                            sb.Append('\xE07D'); // ꦳ꦶ
                            i++;
                            continue;
                        }

                        if(IsWuluMelik(c2)) {
                            if(i + 2 < length) {
                                var c3 = s[i + 2];

                                if(IsPanyangga(c3)) {
                                    sb.Append('\xE082'); // ꦳ꦷꦀ
                                    i += 2;
                                    continue;
                                }

                                if(IsCecak(c3)) {
                                    sb.Append('\xE083'); // ꦳ꦷꦁ
                                    i += 2;
                                    continue;
                                }
                            
                                if(IsLayar(c3)) {
                                    sb.Append('\xE084'); // ꦳ꦷꦂ
                                    i += 2;
                                    continue;
                                }
                            }

                            sb.Append(c);
                            sb.Append('\xE081'); // ꦳ꦷ
                            i++;
                            continue;
                        }

                        if(IsPepet(c2)) {
                            if(i + 2 < length) {
                                var c3 = s[i + 2]; 

                                if(IsPanyangga(c3)) {
                                    sb.Append('\xE086'); // ꦳ꦼꦀ
                                    i += 2;
                                    continue;
                                }

                                if(IsCecak(c3)) {
                                    sb.Append('\xE087'); // ꦳ꦼꦁ
                                    i += 2;
                                    continue;
                                }
                            
                                if(IsLayar(c3)) {
                                    sb.Append('\xE088'); // ꦳ꦼꦂ
                                    i += 2;
                                    continue;
                                }
                            }

                            sb.Append('\xE085'); // ꦳ꦼ
                            i++;
                            continue;
                        }
                    }
                }

                // wyanjana ai (ꦍ)
                if(IsWyanjanaAI(c)) {
                    if(i + 1 < length) {
                        var c2 = s[i + 1];

                        if(IsPanyangga(c2)) {
                            sb.Append('\xE00B'); // ꦍꦀ
                            i++;
                            continue;
                        }

                        if(IsCecak(c2)) {
                            sb.Append('\xE00C'); // ꦍ꦳
                            i++;
                            continue;
                        }

                        if(IsLayar(c2)) {
                            sb.Append('\xE00D'); // ꦍꦂ
                            i++;
                            continue;
                        }
                    
                        if(IsCecakTelu(c2)) {
                            if(i + 2 < length) {
                                var c3 = s[i + 2];

                                if(IsPanyangga(c3)) {
                                    sb.Append('\xE00F'); // ꦍ꦳ꦀ
                                    i += 2;
                                    continue;
                                }

                                if(IsCecak(c3)) {
                                    sb.Append('\xE010'); // ꦍ꦳ꦁ
                                    i += 2;
                                    continue;
                                }
                            
                                if(IsLayar(c3)) {
                                    sb.Append('\xE011'); // ꦍ꦳ꦂ
                                    i += 2;
                                    continue;
                                }
                            }
                            
                            sb.Append('\xE00E'); // ꦍ꦳
                            i++;
                            continue;
                        }
                    }
                }
                
                sb.Append(c);
            }

            return sb.ToString();
        }

        private static bool IsJavaUnicode(char c)
        {
            return c >= '\xA980' && c <= '\xA9DF';
        }

        private static bool IsWyanjana(char c)
        {
            return c >= '\xA984' && c <= '\xA9B2';
        }

        private static bool IsPangkon(char c)
        {
            return c == '꧀';
        }

        private static bool IsSandhanganSwara(char c) {
            return IsSuku(c) || IsDirgaMendhut(c) || IsTaling(c) || IsWulu(c) || IsWuluMelik(c) || IsPepet(c);
        }

        private static bool IsSuku(char c) {
            return c == 'ꦸ' || c == '\xE08F';
        }

        private static bool IsDirgaMendhut(char c) {
            return c == 'ꦹ' || c == '\xE090';
        }

        private static bool IsWulu(char c) {
            return c == 'ꦶ';
        }

        private static bool IsPepet(char c) {
            return c == 'ꦼ';
        }

        private static bool IsWuluMelik(char c) {
            return c == 'ꦷ';
        }

        private static bool IsTaling(char c) {
            return c == 'ꦺ' || c == 'ꦻ';
        }

        private static bool IsCecak(char c) {
            return c == 'ꦁ';
        }

        private static bool IsCecakTelu(char c) {
            return c == '꦳';
        }

        private static bool IsLayar(char c) {
            return c == 'ꦂ';
        }

        private static bool IsPanyangga(char c) {
            return c == 'ꦀ';
        }

        private static bool IsCakra(char c) {
            return c == 'ꦿ' || (c >= '\xE115' && c <= '\xE117');
        }

        private static bool IsCakraAlt(char c) {
            return c == '\xE114';
        }

        private static bool IsCakraSmall(char c) {
            return c == '\xE115';
        }

        private static bool IsCakraMedium(char c) {
            return c == '\xE116';
        }

        private static bool IsCakraBig(char c) {
            return c == '\xE117';
        }

        private static bool IsCakraKeret(char c) {
            return c == 'ꦽ';
        }

        private static bool IsPengkal(char c) {
            return c == 'ꦾ';
        }

        private static bool IsWyanjanaAI(char c) {
            return c == 'ꦍ';
        }

        private static bool IsSandhanganWyanjana(char c) {
            return c == 'ꦾ' || c == 'ꦿ' || c == 'ꦽ';
        }

        private static bool IsPasanganOnRight(char c) {
            return c == 'ꦲ' || c == 'ꦱ' || c == 'ꦥ' || c == 'ꦉ' || c == 'ꦦ' || c == 'ꦚ';
        }

        private static bool IsPasanganOnBelow(char c) {
            return IsWyanjana(c) && !IsPasanganOnRight(c);
        }

        private static bool IsPasanganHasFullShape(char c) {
            return fullShapePasangan.ContainsKey(c);
        }

        private static bool IsSmall(char c) {
            return Array.Exists(smallWyanjana, x => x == c);
        }

        private static bool IsMedium(char c) {
            return Array.Exists(mediumWyanjana, x => x == c);
        }

        private static bool IsLarge(char c) {
            return Array.Exists(largeWyanjana, x => x == c);
        }

        private static bool IsAlt(char c) {
            return Array.Exists(altWyanjana, x => x == c);
        }

        private static bool IsAltPasangan(char c) {
            return Array.Exists(altPasangan, x => x == c);
        }

        private static char GetWyanjanaFromPasangan(char c) {
            foreach(var pair in pasangan) {
                if(pair.Value == c) {
                    return pair.Key;
                }
            }

            return '\0';
        }

        private static char GetPasangan(char c) {
            return pasangan[c];
        }

        private static char GetFullShapePasangan(char c) {
            return fullShapePasangan[c];
        }
    }
}