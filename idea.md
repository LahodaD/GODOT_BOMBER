
Bomber

Úvod:
Bomber je klasická arkádová hra, ve které hráč ovládá postavičku, která musí shodit bomby, aby zničila překážky a soupeře. Cílem je zničit nepřátele.

Kickoff
Cíl hry: Zůstat poslední naživu. Zničit protihráče.

Hratelnost: Hra se bude ovládat pomocí šipek (tedy klávesnice). Hru je možné hrát jako singl player proti počítači, tak jak multi player proti až 4 hráčům.

Cílová platforma: Hra je určena pro PC platformu a bude vyvíjena v Godot 4.2

Hratelnost:
Hra bude kombinací akčního a strategického stylu, kde hráč bude muset rychle reagovat na situace a zároveň používat strategické přístupy k dosažení cíle.

Akční prvky: Hráč bude muset rychle pohybovat postavou a položit bomby na strategických místech, aby zničil nepřátel.

Strategické prvky: Kromě pouhého bombardování bude hráč muset strategicky plánovat své akce, vyhýbat se nepřátelům a přemýšlet o tom, jak využít terén a power-upy k dosažení vítězství.

Ovládání:
Hráč bude ovládat postavu pomocí šipek na klávesnici:

Hráč 1 (Šipky):
Šipka nahoru: Pohyb nahoru
Šipka dolů: Pohyb dolů
Šipka doleva: Pohyb doleva
Šipka doprava: Pohyb doprava
Klávesa pro položení bomby: Mezerník

Hráč 2 (WASD):
Klávesa W: Pohyb nahoru
Klávesa S: Pohyb dolů
Klávesa A: Pohyb doleva
Klávesa D: Pohyb doprava
Klávesa pro položení bomby: Klávesa E 

Hráč 3 (JIKL):
Klávesa J: Pohyb nahoru
Klávesa K: Pohyb dolů
Klávesa I: Pohyb doleva
Klávesa L: Pohyb doprava
Klávesa pro položení bomby: Klávesa O

Hráč 4 (NumPad):
Klávesa 8: Pohyb nahoru
Klávesa 2: Pohyb dolů
Klávesa 4: Pohyb doleva
Klávesa 6: Pohyb doprava
Klávesa pro položení bomby: Klávesa 0

Primárně bude hra vyvíjena jen pro dva hráče.
Ukázka, jak by mohly vypadat postavičky. Postavičky se budou lišit barvou.   

![player1](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/ec0f56a8-689d-4d21-8f9e-e6e347611252)
![player2](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/f450ab2a-df36-43d4-9fc8-842cbc3067e6)

Singleplayer:
V jednohráčovém režimu hráč bude bojovat proti umělé inteligenci, která bude kontrolovat nepřátele. Hra bude nabízet různé úrovně obtížnosti a postupně se zvyšující výzvy. Například počet nepřátel apd. (Primárně bude hra pouze jako multiplayer)
Multiplayer:
V multiplayer režimu hráči budou moci soutěžit proti sobě. Možnosti multiplayeru zahrnuje lokální multiplayer na jednom zařízení

Další prvky:
o	Power-upy: 
o	V herním světě se budou nacházet různé power-upy, které poskytnou hráči výhodu, jako je zvýšení rychlosti, silnější bomby nebo větší počet bomb. 
o	Power-upy by mohly vypadat nějak takto:

![boost_speed](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/1532f5a5-d53c-49a4-9bc7-95ed8d872998)
![boost_explosion](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/08c49a5b-91a6-4068-babf-259d7036e6ca)
![boost_additional_bomb](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/da66cbba-74f8-4573-99ec-c9b5c8679ec4)
       
Různorodé bloky: 
Hra bude obsahovat rozdílné bloky, které budou tvořit herní svět.
Překážky, které se dají/nedají zničit (vnější a vnitřní)
![indestructible_wall](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/26a60fdc-3a0f-4c75-b068-e92ce45c2280)
![destructible_wall](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/aa0a4e83-f155-4837-9cae-8399e77f3a0a)
![inner_walls](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/4fa3d407-cde1-4273-a571-bcfe9f5b9447)

Mechanismy hry
Pohyb postav:
Hráči budou moci pohybovat svou postavou po herní mapě pomocí šipek nebo kláves na klávesnici.
Pohyb bude omezen na čtvercovou mřížku.
Položení bomb:
Hráči budou moci položit bomby na volné pozice na herní mapě.
Omezený počet bomb, které hráč může položit současně.
Exploze bomb:
Bomba vytvoří explozi v horizontálním a vertikálním směru od svého umístění.
Exploze může poškodit hráče, nepřátele a prostředí v jejím dosahu. 

Princip mapy:
2D mapa v čtvercové mřížce:
Mapa bude mít formát čtvercové mřížky, kde každý čtvereček představuje jednotlivý herní políčko.
Velikost mapy bude předem definována a může se lišit v závislosti na konkrétní úrovni nebo nastavení hry.
Hráči budou moci pohybovat po této mřížce pouze horizontálně a vertikálně.

Překážky a volná místa:
Na mapě budou umístěny různé překážky, jako jsou zdi, bloky nebo propasti, které ovlivní pohyb hráčů a exploze bomb.
Mezi překážkami budou také volná místa, kde hráči mohou pohodlně pohybovat a bojovat.         

Generování mapy:
Mapy mohou být buď předdefinované pro každou úroveň, nebo mohou být generovány náhodně, což dodává hře variabilitu a nové výzvy.

![image](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/c51daba9-c436-49dd-9f6a-a78fea51f2cd)

Design bomby a výbuchů


![bomb_yellow](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/c5a8f161-5d37-4a46-916b-7c7baed83716)
![bomb_orange](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/2eaf02de-ff78-4008-82c9-fb309269f977)
![bomb_red](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/abd62b13-cf0e-4a7c-ae1e-cbf80518899e)
![bomb_signal](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/cbc026ec-908a-43f6-b24f-fa13801520b5)
![bomb_ready](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/c7dfc370-eaa0-4377-bd28-58d493bb43af)
![bomb_explosion](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/19600464-9b45-4868-b0ac-b79339339803)
  
Animace výbuchu bomby

![bomb](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/6a18ce07-7908-4dcc-8515-7d123f8ce50b)

Animace rozpadnutí cihel

![destroyed_wall](https://github.com/LahodaD/GODOT_BOMBER/assets/121507132/df447dd1-b14c-4f02-a1c5-8fe1873d5c3a)
                                  
Struktura hry:
1.	Úvodní obrazovka:
Po spuštění hry se objeví úvodní obrazovka s názvem hry a možnostmi, jako je "Hrát", "Nastavení", "Nápověda" a "Opustit".
Hráč může vybrat možnost "Hrát", aby začal novou hru Bomber.
2.	Volba počtu hráčů:
Po zvolení možnosti "Hrát" se hráči budou moci rozhodnout, kolik hráčů se bude účastnit hry. Možnosti mohou být 1 až 4 hráči.
Pokud hraje více hráčů, budou moci hrát na jednom počítači
3.	Výběr postav:
Každý hráč si vybere svou postavu, která může mít různé vlastnosti nebo vzhled.
Po výběru postav se hráči přesunou na obrazovku s výběrem úrovně.
4.	Výběr úrovně:
Hráči vyberou úroveň, na které chtějí hrát. Může jít o předem vytvořené úrovně nebo o náhodně generované úrovně.
Po výběru úrovně se hráči přesunou na herní obrazovku.
5.	Herní obrazovka:
Hra začíná a hráči se objeví na herní mapě, která je čtvercové mřížce.
Hráči mohou začít pohybem po mapě a položením bomb.
Cílem je přežít co nejdéle a zničit ostatní hráče pomocí bomb.
Power-upy se mohou objevit na mapě a hráči se mohou snažit je získat.
6.	Konec hry:
Hra končí, když zbývá pouze jeden hráč naživu.
Po ukončení hry se zobrazí výsledková obrazovka s informacemi o vítězi a skóre každého hráče.
Hráči se mohou vrátit na úvodní obrazovku a zvolit novou hru nebo ukončit hru.
