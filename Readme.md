## Ringkasan
Javanese TextMeshPro merupakan plugin Unity yang dibuat untuk memperluas kemampuan dari [TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html) 
sehingga mendukung pemrosesan teks aksara Jawa.

[Dokumentasi](https://javanese-textmeshpro.adityarahmanda.com/manual/introduction.html)

[![openupm](https://img.shields.io/npm/v/com.adityarahmanda.javanese-textmeshpro?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.adityarahmanda.javanese-textmeshpro/)

- [Fitur-Fitur](#fitur-fitur)
- [Prasyarat](#prasyarat)
- [Batasan](#batasan)
- [Instalasi melalui OpenUPM](#instalasi-melalui-openupm)
- [Essential dan Example Resources](#essential-dan-example-resources)

## Fitur-Fitur
### [Javanese Text](https://javanese-textmeshpro.adityarahmanda.com/manual/javanese_text.html)
Elemen teks yang digunakan untuk menampilkan teks aksara Jawa.

![Preview Javanese Text](https://javanese-textmeshpro.adityarahmanda.com/images/javanese-text.png)​

### [Javanese Button](https://javanese-textmeshpro.adityarahmanda.com/manual/javanese_button.html)
Elemen UI berupa tombol yang berisikan elemen teks [**Javanese Text (UI)**](https://javanese-textmeshpro.adityarahmanda.com/manual/javanese_text.html#javanese-text-ui) di dalamnya.

![Preview Javanese Button](https://javanese-textmeshpro.adityarahmanda.com/images/javanese-button.png)​

### [Javanese Input Field](https://javanese-textmeshpro.adityarahmanda.com/manual/javanese_input_field.html)
Elemen UI berupa *input field* yang mampu menerima masukan teks aksara Jawa.

![Preview Javanese Input Field](https://i.ibb.co/XLVMGQ8/demo-inputfield.gif)

### [Javanese Dropdown](https://javanese-textmeshpro.adityarahmanda.com/manual/javanese_dropdown.html)
Elemen UI berupa *dropdown* yang mampu menyajikan daftar pilihan beraksara Jawa.

![Preview Javanese Dropdown](https://i.ibb.co/16h1cvv/demo-dropdown.gif)

### [Jendela Transliterator](https://javanese-textmeshpro.adityarahmanda.com/manual/transliterator_window.html)
Jendela untuk melakukan transliterasi teks Latin-Jawa atau Jawa-Latin pada editor Unity.

![Preview Transliterator Window](https://i.ibb.co/gM2JBPR/demo-jendela-transliterator.gif)

## Prasyarat
| Prasyarat Minimum      | Keterangan |
| ----------- | ----------- |
| [Unity 2021.2.0f1](https://unity3d.com/unity/whats-new/2021.2.0) | Untuk dapat menggunakan plugin ini secara maksimal, dibutuhkan minimum **Unity 2021.2.0f1** karena baru pada versi inilah editor Unity mendukung pengetikan teks Unicode aksara Jawa. |
| [TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html) | Pada project Unity-mu, TextMeshPro sudah harus terpasang terlebih dahulu karena plugin ini bergantung padanya. Pemasangan TextMeshPro dapat dilakukan secara langsung melalui jendela Package Manager. |

## Batasan
[TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html) tidak membaca peletakan dan penggantian *glyph* (GPOS dan GSUB)[🡕](https://forum.unity.com/threads/needs-unicode-support.483802/#post-3148337) dari *font* aksara Jawa sehingga tidak mampu menampilkan teks aksara Jawa dengan benar.

Plugin Javanese TextMeshPro mengatasi permasalahan tersebut dengan memproses *font* aksara Jawa khusus yang memiliki tambahan *glyph* pada blok Unicode U+E000-U+E09F dan U+E100-U+E11D. Jangkauan blok tersebut sengaja dipilih karena termasuk dalam ranah blok [Private Use Area (PUA)](https://en.wikipedia.org/wiki/Private_Use_Areas#:~:text=In%20Unicode%2C%20a%20Private%20Use,characters%20by%20the%20Unicode%20Consortium.). Sedangkan pengaturan peletakan *glyph* dari *font* khusus yang digunakan oleh plugin ini sendiri, mengikuti peletakan *glyph* dari *font* [Ngayogyan](https://aksaradinusantara.com/fonta/nyk-ngayogyan.font). 

Oleh karena itu, untuk saat ini plugin ini hanya mendukung beberapa *font* terbatas saja yang meliputi *font* [Ngayogyan](https://aksaradinusantara.com/fonta/nyk-ngayogyan.font), [Ngayogyan Jejeg](https://aksaradinusantara.com/fonta/nyk-ngayogyan-jejeg.font) dan [Noto Sans (Custom)](https://github.com/adityarahmanda/javanese-textmeshpro/tree/master/Fonts/noto-sans.ttf). Semua *font* tersebut sudah tersedia di dalam *package* plugin ini.

## Instalasi melalui OpenUPM
1. Pada project Unity-mu, buka jendela **Project Settings**  melalui menu `Edit / Project Settings`dan tambahkan *scoped registry* sebagaimana berikut.

    ![Installation Step 1 - Add Package Scope](https://javanese-textmeshpro.adityarahmanda.com/images/add-package-scope.png)

    | Kolom | Keterangan                                |
    | ----- | ----------------------------------------- |
    | Name  | OpenUPM                                   |
    | URL   | `https://package.openupm.com`             |
    | Scope | `com.adityarahmanda.javanese-textmeshpro` |

2. Selanjutnya buka jendela **Package Manager** melalui menu `Windows / Package Manager` dan ubah scope menjadi **My Registry**. 

    ![Installation Step 2 - Open Package Manager](https://javanese-textmeshpro.adityarahmanda.com/images/open-package-manager.png)

3. Pilih *package* "Javanese TextMeshPro" dan tekan tombol **Install** dan tunggu hingga instalasi selesai.

    ![Installation Step 3 - Installing Package](https://javanese-textmeshpro.adityarahmanda.com/images/installing-package.png)

## Essential dan Example Resources
Untuk dapat menggunakan Javanese TextMeshPro, package [`JVTMP Essential Resources`](https://javanese-textmeshpro.adityarahmanda.com/manual/essential_resources.html) wajib diimpor terlebih dahulu. Jendela impor package [`JVTMP Essential Resources`]() akan muncul secara otomatis setelah instalasi plugin.

Package [`JVTMP Examples Resources`](https://javanese-textmeshpro.adityarahmanda.com/manual/examples_resources.html) juga dapat diimpor secara opsional untuk mempelajari bagaimana contoh penerapan langsung dari plugin ini di dalam game.