# FunSpecs pro aplikaci Porovnání sortovacících algoritmů

- mvopFunSpecs.md
- ver. 0.0.1
    - inicializace dokumentu
- vytvořeno: 5. 3. 2023
- autor: Lukas Papariga 



# 1. Úvod

- dokument popisuje funkční specifikace aplikace Porovnání sortovacících algoritmů
- dokument je určen pro vývojáře aplikace a pro uživatele aplikace
- dokument souvisí s dokumentem [SRS](mvopSRS.md)

# 2. Scénáře

## 2.1 Využití aplikace

- Aplikace bude určena pro uživatele, kteří se zajímají o sortovací algoritmy a jejich výkon
    - tedy pro vývojáře, studenty, učitele, ...
- Aplikace bude umožňovat uživateli porovnat výkon sortovacích algoritmů na různých datasetech (uživatel si bude moct v aplikaci vybrat velikost datasetu, samotné data aplikace generuje sama)

## 2.2 Typy uživatelů

- bude jenom jeden uživatel, aplikace nebude mít žádné uživatelské účty -> aplikace bude veškeré data lokálně

## 2.3 Detaily, motivace, příklady

- Aplikace bude mít design inspirovaný designem Apple -> bude mít co nejvíce "rounded corners", tady je příklad: [Apple Design](https://miro.medium.com/max/8192/1*oBIEr0OSVLqPtKwpc3Hy9Q.jpeg)
- Aplikace bude mít jednoduchý a přehledný design, který bude uživateli příjemný
- Aplikace bude mít jednoduché a intuitivní ovládání
    - bude mít co nejmenší počet tlačítek a co nejméně textu
- tady je přibližné rozvržení aplikace: [Rozvržení aplikace](MG_0904.HEIC)
    - jak je na obrázku vidět aplikace má pár tlačítek, které jsou vždy vidět
    - toto bude jediné rozhraní aplikace - aplikace nebude otevírat další okna

## 2.4 Vymezení rozsahu

- Jediný vstup co aplikace bere je velikost datasetu a výběr z katalogu dostupných sortovacích algoritmů
    - Aplikace nebude brát specifický datasety od uživatele
    - Aplikace nebude brát specifické algoritmy od uživatele
    - Aplikace nebude brát specifické počty opakování sortování od uživatele
- Aplikace bude generovat data sama
- Cílem aplikace je výkonnost, spolehlivost a přehlednost, tedy se jakékoliv nepotřebné funkce vyhýbáme a vše co je potřeba je implementováno

## 2.5 Na co se nebude klást důraz z pohledu výkonnosti (neprioritní)

- cílem aplikace je srovnat výkon sortovacích algoritmů, tedy veškerá snaha půjde na optimalizaci výkonu sortovacích algoritmů a férovou generaci datasetů
- aplikace by měla vyjít velmi jednoduchá, tedy by neměla být složitá ani velká, tedy by neměla být náročná na výkon
- nebude kladen důraz na rychlost spouštění aplikace a rychlost načtení datasetů
- nebude kladen důraz na přehlednost kódu, tedy kód bude psán tak, aby byl co nejrychlejší a nejefektivnější, nikoliv aby byl přehledný a čitelný
- nebude kladen důraz na velký počet sortovacích algoritmů, tedy aplikace bude obsahovat pouze několik sortovacích algoritmů, které jsou nejčastěji používané a nejvíce se hodí pro porovnání výkonu

# 3 Celková hrubá architektura

## 3.1 Pracovní tok

1. Uživatel spustí aplikaci
2. Uživatel vybere z katalogů jaký sortovací algoritmus chce použít
3. Aplikace zobrazí nějaké informace o algoritmu => uživatel si může přečíst co algoritmus dělá a jak funguje
4. Aplikace zobrazí komplexitu algoritmu => uživatel si může přečíst jaký je výkon algoritmu (zobrazuje pomocí "bigO notation")
4.1. Uživatel může kliknout na tlačítko přidat okno -> aplikace uvnitř existujícího okna přidá další "obrazovku", ve které bude vykreslován průběh daného algoritmu
4.2. uživatel si vybere jaký alogoritmus bude používat jeho přidané okno
5. Klikne na tlačítko "dataset" a vybere velikost datasetu (small, medium, large) -> aplikace sama vygeneruje dataset
6. Uživatel vyber delay (rychlost animace vizualizace sortování) -> aplikace vyzulizuje pomocí sloupců různých výšek, které reprezentují velikost čísel vygenerovaných datasetu -> zobrazuje je v oknu -> každy krok alogoritmu je zobrazený pomocí animace (přemístění sloupce na jiné místo)
7. Aplikace bude postupně sortovat dataset pomocí zvoleného algoritmu
8. Aplikace bude ukazovat výkon sortovacího algoritmu (čas, který algoritmus trval na seřazení datasetu)
9. Po dokončení sortování uživatel bude vidět seřazené sloupce a bude mít možnost se posunout v čase zpět a vidět jak se dataset sortoval
10. Uživatel může kliknout na tlačítko "reset" a aplikace se vrátí do původního stavu

## 3.3 Všechny detaily: obrazovky, okna, tisky, chybové zprávy, logování

- Aplikace bude mít jediné okno, které bude obsahovat všechny potřebné prvky
- Aplikace bude mít katalog pro výběr sortovacích algoritmů
- Aplikace bude mít katalog pro výběr velikosti datasetu
- Aplikace bude mít katalog pro výběr delay (rychlost animace)
- Aplikace bude mít tlařítko přídat okno
- Aplikace bude mít místo pro zobrazení informací o algoritmu
- Aplikace bude mít místo pro zobrazení aktuální verze aplikace
- Aplikace bude mít místo pro zobrazení komplexity algoritmu
- Aplikace bude mít místo pro zobrazení trvání sortování
- Aplikace bude mít v sobě N počet oken pro zobrazení sortování (N > 0 a maximální počet závisí na velikosti monitoru)
- Aplikace bude mít tlačítko reset

- Aplikace neukládá žadné data -> žádné logování

- Chybové hlášky se budou zobrazovat uprostřed nahoře v okně
    - chybové hlášky se budou zobrazovat v červené barvě
    - chybové hlášky se budou zobrazovat po dobu dokud uživatel nenapraví chybu
    - možné chyby:
        - uživatel nevybral sortovací algoritmus
        - uživatel nevybral velikost datasetu
        - uživatel nevybral delay
        - uživatel nevybral algoritmus pro přidané okno
        - uživatel nevybral velikost datasetu pro přidané okno

## 3.4 Všechny dohodnuté principy

- Aplikace bude vytvořena pomocí jazyka C#
- Aplikace bude vytvořena pomocí frameworku WPF
- Aplikace bude využívat rounded corners design
- Aplikace bude využívat flat design
- Aplikace bude hezká a jednoduchá s velmi málou šancí na chybu uživatele
- Aplikace bude mít jednoduché a přehledné uživatelské rozhraní
- Aplikace bude mít vnitřeně implementované sortovací algoritmy s nejvíce optimální komplexitou pro daný algoritmus
- Aplikace bude umět generovat datasety o velikosti small, medium, large. Datasety budou generováný férově, tak aby byly co nejvíce férový pro daný algoritmus
- Aplikace bude mít v sobě N počet oken pro zobrazení sortování (N > 0 a maximální počet závisí na velikosti monitoru)

# 4. Otevřené otázky

## 1.1 Části, na kterých se zatím nedosáhlo shody

- barevný design aplikace není ještě definitivně určen
- zatím nevím jaký modul bude použit pro vykreslování sloupců
- zatím nevím jaký modul bude použit pro animaci sloupců
- zatím nevím jaký modul bude použit pro generování datasetu





