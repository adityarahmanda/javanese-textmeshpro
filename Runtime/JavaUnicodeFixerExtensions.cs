using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class JavaUnicodeFixerExtensions {
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

    // cakra test
    // ꦄꦿ ꦅꦿ ꦆꦿ ꦇꦿ ꦈꦿ ꦉꦿ ꦊꦿ ꦋꦿ ꦌꦿ ꦍꦿ ꦎꦿ ꦏꦿ
    // ꦐꦿ ꦑꦿ ꦒꦿ ꦓꦿ ꦔꦿ ꦕꦿ ꦖꦿ ꦗꦿ ꦘꦿ ꦙꦿ ꦚꦿ ꦛꦿ ꦜꦿ ꦝꦿ ꦞꦿ ꦟꦿ
    // ꦠꦿ ꦡꦿ ꦢꦿ ꦣꦿ ꦤꦿ ꦥꦿ ꦦꦿ ꦧꦿ ꦨꦿ ꦩꦿ ꦪꦿ ꦫꦿ ꦬꦿ ꦭꦿ  ꦮꦿ ꦯꦿ
    // ꦰꦿ ꦱꦿ ꦲꦿ

    // ꦤꦿꦸꦏꦿꦸꦚꦿꦸ
    // ꦏ꧀ꦔꦿꦏ꧀ꦠꦿꦏ꧀ꦪꦿꦏ꧀ꦱꦿ
    // ꦏ꧀ꦔꦿꦺꦴꦏ꧀ꦠꦿꦺꦴꦏ꧀ꦪꦿꦺꦴꦏ꧀ꦱꦿꦺꦴ
    // ꦏꦸꦏꦹꦏꦾꦏꦽ
    // ꦏ꧀ꦏꦸ ꦏ꧀ꦏꦹ ꦏ꧀ꦏꦾ ꦏ꧀ꦏꦽ
    // ꦏ꧀ꦤꦸꦏ꧀ꦤꦹꦏ꧀ꦤꦾꦏ꧀ꦤꦽ

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

    public static string JavaUnicodeFix(this string s)
    {
        var length = s.Length;
        var sb = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
            var c = s[i];

            // check next character
            if (i + 1 < length)
            {
                var c2 = s[i + 1];

                if (i + 2 < length) {
                    var c3 = s[i + 2];

                    if(IsPangkon(c2) && IsWyanjana(c3)) {
                        if(i + 3 < length) {
                            var c4 = s[i + 3];

                            if(IsCakra(c4)) {
                                if(i + 4 < length) {
                                    var c5 = s[i + 4];

                                    if(IsSuku(c5)) {
                                        sb.Append('\xE114'); // alt cakra
                                        sb.Append(c);

                                        if(IsPasanganOnBelow(c3) && IsPasanganHasFullShape(c3)) {
                                            sb.Append(GetFullShapePasangan(c3));
                                        } else {
                                            sb.Append(GetPasangan(c3));
                                        }

                                        sb.Append('\xE08F'); // suku for pasangan
                                        i += 4;
                                        continue;
                                    }

                                    if(IsTaling(c5)) {
                                        sb.Append(c5);

                                        if(IsAltPasangan(c3)) {
                                            sb.Append('\xE114'); // alt cakra 
                                            sb.Append(c);
                                            sb.Append(GetPasangan(c3));
                                        } else {
                                            if(IsPasanganOnBelow(c3)) {
                                                sb.Append(' ');
                                                sb.Append(c);

                                                if(IsPasanganHasFullShape(c3)) {
                                                    sb.Append(GetFullShapePasangan(c3));
                                                } else {
                                                    sb.Append(GetPasangan(c3));
                                                }

                                                if(IsSmall(c3)) {
                                                    sb.Append('\xE118'); // small cakra for pasangan
                                                }else if(IsMedium(c3)) {
                                                    sb.Append('\xE119'); // medium cakra for pasangan
                                                } else if(IsLarge(c3)) {
                                                    sb.Append('\xE11A'); // large cakra for pasangan
                                                }
                                            } else {
                                                sb.Append(c);
                                                sb.Append(' ');
                                                sb.Append(GetPasangan(c3));

                                                if(IsSmall(c3)) {
                                                    sb.Append('\xE115');  // small cakra
                                                } else if(IsMedium(c3)) {
                                                    sb.Append('\xE116');  // medium cakra
                                                } else if(IsLarge(c3)) {
                                                    sb.Append('\xE117');  // big cakra
                                                }
                                            }
                                        }

                                        i += 4;
                                        continue;
                                    }
                                }

                                if(IsAltPasangan(c3)) {
                                    sb.Append('\xE114'); // alt cakra 
                                    sb.Append(c);
                                    sb.Append(GetPasangan(c3));
                                } else {
                                    if(IsPasanganOnBelow(c3)) {
                                        sb.Append(' ');
                                        sb.Append(c);

                                        if(IsPasanganHasFullShape(c3)) {
                                            sb.Append(GetFullShapePasangan(c3));
                                        } else {
                                            sb.Append(GetPasangan(c3));
                                        }

                                        if(IsSmall(c3)) {
                                            sb.Append('\xE118'); // small cakra for pasangan
                                        }else if(IsMedium(c3)) {
                                            sb.Append('\xE119'); // medium cakra for pasangan
                                        } else if(IsLarge(c3)) {
                                            sb.Append('\xE11A'); // large cakra for pasangan
                                        }
                                    } else {
                                        sb.Append(c);
                                        sb.Append(' ');
                                        sb.Append(GetPasangan(c3));

                                        if(IsSmall(c3)) {
                                            sb.Append('\xE115');  // small cakra
                                        } else if(IsMedium(c3)) {
                                            sb.Append('\xE116');  // medium cakra
                                        } else if(IsLarge(c3)) {
                                            sb.Append('\xE117');  // big cakra
                                        }
                                    }
                                }

                                i += 3;
                                continue;
                            }
                            
                            if(IsSuku(c4) || IsDirgaMendhut(c4) || IsCakraKeret(c4) || IsWignyan(c4)) { 
                                sb.Append(c);

                                if(IsPasanganOnBelow(c3)) {
                                    if(IsPasanganHasFullShape(c3)) {
                                        sb.Append(GetFullShapePasangan(c3));
                                    } else {
                                        sb.Append(GetPasangan(c3));
                                    }

                                    if(IsSuku(c4)) {
                                        sb.Append('\xE08F'); // suku for pasangan
                                    } else if(IsDirgaMendhut(c4)) {
                                        sb.Append('\xE090'); // dirga mendhut for pasangan
                                    } else if(IsCakraKeret(c4)) {
                                        sb.Append('\xE094'); // cakra keret for pasangan
                                    } else if(IsWignyan(c4)) {
                                        sb.Append('\xE098'); // wignyan for pasangan
                                    }
                                } else {
                                    sb.Append(GetPasangan(c3));
                                    sb.Append(c4);
                                }

                                i += 3;
                                continue;
                            }
                            
                            // check taling
                            if(IsTaling(c4)) {
                                sb.Append(c4);
                                sb.Append(c);
                                sb.Append(GetPasangan(c3));
                                i += 3;
                                continue;
                            }
                        }

                        sb.Append(c);
                        sb.Append(GetPasangan(c3));
                        i += 2;
                        continue;
                    }

                    if(IsPangkon(c2) && IsTaling(c3)) {
                        sb.Append(c);
                        sb.Append(c2);
                        sb.Append(c3);
                        i += 2;
                        continue;
                    } 
                
                    if(IsSandhanganWyanjana(c2) && IsTaling(c3)) {
                        sb.Append(c3);
                        sb.Append(c);
                        sb.Append(c2);
                        i += 2;
                        continue;
                    }
                }

                if(IsTaling(c2)) {
                    sb.Append(c2);
                    sb.Append(c);
                    i++;
                    continue;
                }

                if(IsWulu(c) && IsPanyangga(c2)) {
                    sb.Append('\xE089');
                    i++;
                    continue;
                }

                if(IsWulu(c) && IsCecak(c2)) {
                    sb.Append('\xE08A');
                    i++;
                    continue;
                }

                if(IsWulu(c) && IsLayar(c2)) {
                    sb.Append('\xE08B');
                    i++;
                    continue;
                }

                if(IsPepet(c) && IsPanyangga(c2)) {
                    sb.Append('\xE091');
                    i++;
                    continue;
                }

                if(IsPepet(c) && IsCecak(c2)) {
                    sb.Append('\xE092');
                    i++;
                    continue;
                }

                if(IsPepet(c) && IsLayar(c2)) {
                    sb.Append('\xE093');
                    i++;
                    continue;
                }

                if(IsWuluMelik(c) && IsPanyangga(c2)) {
                    sb.Append('\xE08C');
                    i++;
                    continue;
                }

                if(IsWuluMelik(c) && IsCecak(c2)) {
                    sb.Append('\xE08D');
                    i++;
                    continue;
                }

                if(IsWuluMelik(c) && IsLayar(c2)) {
                    sb.Append('\xE08E');
                    i++;
                    continue;
                }

                if(IsCecakTelu(c) && IsPanyangga(c2)) {
                    sb.Append('\xE07A');
                    i++;
                    continue;
                }

                if(IsCecakTelu(c) && IsCecak(c2)) {
                    sb.Append('\xE07B');
                    i++;
                    continue;
                }

                if(IsCecakTelu(c) && IsLayar(c2)) {
                    sb.Append('\xE07C');
                    i++;
                    continue;
                }

                if(IsCecakTelu(c) && IsWulu(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsPanyangga(c3)) {
                            sb.Append('\xE07E');
                            i += 2;
                            continue;
                        }

                        if(IsCecak(c3)) {
                            sb.Append('\xE07F');
                            i += 2;
                            continue;
                        }
                    
                        if(IsLayar(c3)) {
                            sb.Append('\xE080');
                            i += 2;
                            continue;
                        }
                    }
                    
                    sb.Append(c);
                    sb.Append('\xE07D');
                    i++;
                    continue;
                }

                if(IsCecakTelu(c) && IsWuluMelik(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsPanyangga(c3)) {
                            sb.Append('\xE082');
                            i += 2;
                            continue;
                        }

                        if(IsCecak(c3)) {
                            sb.Append('\xE083');
                            i += 2;
                            continue;
                        }
                    
                        if(IsLayar(c3)) {
                            sb.Append('\xE084');
                            i += 2;
                            continue;
                        }
                    }

                    sb.Append(c);
                    sb.Append('\xE081');
                    i++;
                    continue;
                }

                if(IsCecakTelu(c) && IsPepet(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsPanyangga(c3)) {
                            sb.Append('\xE086');
                            i += 2;
                            continue;
                        }

                        if(IsCecak(c3)) {
                            sb.Append('\xE087');
                            i += 2;
                            continue;
                        }
                    
                        if(IsLayar(c3)) {
                            sb.Append('\xE088');
                            i += 2;
                            continue;
                        }
                    }

                    sb.Append('\xE085');
                    i++;
                    continue;
                }
            
                if(IsWyanjanaAI(c) && IsPanyangga(c2)) {
                    sb.Append('\xE00B');
                    i++;
                    continue;
                }

                if(IsWyanjanaAI(c) && IsCecak(c2)) {
                    sb.Append('\xE00C');
                    i++;
                    continue;
                }

                if(IsWyanjanaAI(c) && IsLayar(c2)) {
                    sb.Append('\xE00D');
                    i++;
                    continue;
                }
            
                if(IsWyanjanaAI(c) && IsCecakTelu(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsPanyangga(c3)) {
                            sb.Append('\xE00F');
                            i += 2;
                            continue;
                        }

                        if(IsCecak(c3)) {
                            sb.Append('\xE010');
                            i += 2;
                            continue;
                        }
                    
                        if(IsLayar(c3)) {
                            sb.Append('\xE011');
                            i += 2;
                            continue;
                        }
                    }
                    
                    sb.Append('\xE00E');
                    i++;
                    continue;
                }
            
                if(IsAlt(c) && IsCakra(c2)) {
                    sb.Append('\xE114'); // alt cakra
                    sb.Append(c);
                    i++;
                    continue;
                }

                if(IsSmall(c) && IsCakra(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsSuku(c3)) {
                            sb.Append(' ');
                            sb.Append(c);
                            sb.Append('\xE11B');  // small cakra + suku
                            i += 2;
                            continue;
                        }
                    }

                    sb.Append(' ');
                    sb.Append(c);
                    sb.Append('\xE115');  // small cakra
                    i++;
                    continue;
                }

                if(IsMedium(c) && IsCakra(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsSuku(c3)) {
                            sb.Append(' ');
                            sb.Append(c);
                            sb.Append('\xE11C');  // medium cakra + suku
                            i += 2;
                            continue;
                        }
                    }

                    sb.Append(' ');
                    sb.Append(c);
                    sb.Append('\xE116'); // medium cakra
                    i++;
                    continue;
                }

                if(IsLarge(c) && IsCakra(c2)) {
                    if(i + 2 < length) {
                        var c3 = s[i + 2];

                        if(IsSuku(c3)) {
                            sb.Append(' ');
                            sb.Append(c);
                            sb.Append('\xE11D');  // large cakra + suku
                            i += 2;
                            continue;
                        }
                    }

                    sb.Append(' ');
                    sb.Append(c);
                    sb.Append('\xE117');  // large cakra
                    i++;
                    continue;
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
    
    private static bool IsPangkon(char c)
    {
        return c == '\xA9C0';
    }

    private static bool IsWyanjana(char c)
    {
        return c >= '\xA984' && c <= '\xA9B2';
    }

    private static bool IsSuku(char c) {
        return c == 'ꦸ';
    }

    private static bool IsDirgaMendhut(char c) {
        return c == 'ꦹ';
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
        return c == 'ꦿ';
    }

    private static bool IsCakraKeret(char c) {
        return c == 'ꦽ';
    }

    private static bool IsWignyan(char c) {
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

    private static char GetPasangan(char c) {
        return pasangan[c];
    }

    private static char GetFullShapePasangan(char c) {
        return fullShapePasangan[c];
    }
}