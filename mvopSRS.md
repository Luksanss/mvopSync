# SRS-SortAlg

### **Vizualizace sortovacích algoritmů**

- **Verze 0.1**
    - Inicializace projektu
- **Datum**: 13.2.2023
- **Autor**: Lukas Papariga

# Úvod

### 1.1 Účel

Určuje rozsah projektu.

### 1.2 Cílová skupina

Dokument je určen pro učitele a vývojáře.

### 1.3 Kontakty

Email: [template@gmail.com](mailto:template@gmail.com)

Telefon: 000 000 000

### 1.4 Odkazy na další dokumenty

Funkční specifikace

# **Celkový popis**

### 2.1 Produkt jako celek

Bude sloužit jako výukový nástroj.

### 2.2 Funkce

Vizualizace sortovacích algoritmů

### 2.3 Uživatelské skupiny

Není třeba rozdělovat uživatele na skupiny, všichni mají stejný přístup k funkcím

### 2.4 Provozní prostředí

počítač s operačním systémem Windows 10 nebo novější

### 2.5 Uživatelský prostředí

GUI Aplikace (WPF, klasická Windows aplikace)

# Požadavky na rozhraní

### 3.1 Uživatelská rozhraní

Operační systém Windows

# Vlastnosti systému

### 4.1 Vlastnost A

Uživatel si bude moct vybrat z katalogu algoritmů algoritmus jaký zrovna bude chtít vidět vizualizován.

Po vybrání algoritmu se mu zobrazí dodatečné informace přímo o vybraném algoritmu.

### 4.1.1 Popis a důležitost

Maximální důležitost, bez této funkce je program k ničemu.

### 4.1.2 Vstupy – Akce – Výsledek

Výběr z combobox → výběr algoritmu → program napíše vlastnosti algoritmu, nějaký obecný info o něm a objeví se tlačítko spustit → vlastnost B

## 4.2 Vlastnost B

Po spuštění zvoleného algoritmu začne program vizualizovat jednotlivá čísla pomocí sloupců (seřadí od nejvyššího sloupce po nejnižší).

### 4.2.1 Popis a důležitost

Maximální důležitost, bez této funkce je program k ničemu.

### 4.2.2 Vstupy – Akce – Výsledek

po kliknutí na tlačítko start začne program postupně vizualizovat sortování čísel → vlastnost C

## 4.3 Vlastnost C

uživatel si bude moct po dokončení sortování pomocí scroll-baru vrátit do určitých fází sortu

### 4.3.1 Popis a důležitost

Tato funkce bude přidána, až po naprogramování těch předtím.

### 4.3.2 Vstupy – Akce – Výsledek

Po dotřídění čísel bude moct uživatel si prohlídnout “historii” třídění. Neboli se vracet na individuální kroky algoritmu.

### 4.4 Funkční požadavky

Program je dělaný tak, že jdou poslat jedině funkční požadavky → nepřijímá žádný unikátní vstup od uživatelů

# Nefunkční požadavky

### 5.1 Výkonnost

Samotná interní implementace sortovacího algoritmu musí být ta nejoptimálnější – na čase záleží, aplikace bude uživateli ukazovat rychlost splnění sortování.

### 5.2 Bezpečnost

Aplikace nebude ukládat ani přijímat žádný dodatečný informace – bude se používat jedině to co je v aplikaci přeprogramované