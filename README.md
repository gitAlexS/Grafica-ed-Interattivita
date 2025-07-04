Grafica-ed-Interattivita
Questa repository contiene gli esami del corso di Grafica ed Interattività dell'Università Degli
Studi Di Salerno.
Struttura della Repository
La repository è organizzata come segue:
• Progetti/ : Contiene le cartelle relative a ciascun esame, organizzate per data.
Esami
Di seguito una descrizione dettagliata di ciascun esame presente nella cartella Progetti .
Esame //
Descrizione: Questo progetto sembra essere un gioco basato sulla fisica in Unity, dove una
sfera si muove su una piattaforma e interagisce con oggetti di vetro e legno. L'obiettivo è
raggiungere un punto finale evitando di cadere.
Script Analizzati:
• Camera.cs : Questo script gestisce il movimento della telecamera, facendola seguire la
sfera principale con un offset definito. Assicura che la visuale sia sempre centrata sul
giocatore.
• GameController.cs : Questo script è attualmente vuoto, ma è probabile che fosse
destinato a gestire la logica di gioco generale, come il punteggio, lo stato del gioco
(vittoria/sconfitta) o la generazione di elementi.
• Movement.cs : Questo script controlla il movimento della sfera tramite le frecce
direzionali e gestisce le interazioni con gli oggetti. In particolare, al tocco della barra
spaziatrice, scambia i materiali tra gli oggetti con tag "vetro" e "legno". Se la sfera cade
sotto una certa soglia Y, il gioco termina. Quando la sfera collide con un oggetto "vetro",
il colore dell'oggetto cambia casualmente. Se collide con un oggetto "Finish", il
giocatore vince.
Esame //
Descrizione: Questo progetto è un gioco per due giocatori in cui ognuno controlla una sfera
e deve attraversare un percorso evitando delle "buche" che riducono il punteggio.
L'obiettivo è raggiungere il traguardo con il punteggio più alto.
Script Analizzati:
• Player.cs : Controlla il movimento del Giocatore  (frecce direzionali) e gestisce
l'interazione con le "buche" (tag "buca") e il traguardo (tag "Finish"). Ogni volta che il
Giocatore  entra in una buca, il suo punteggio diminuisce e la buca scompare. Al
raggiungimento del traguardo, determina il vincitore o il pareggio in base al punteggio
dell'altro giocatore.
• Player.cs : Simile a Player.cs , ma controlla il movimento del Giocatore  (tasti W, A,
S, D) e gestisce le sue interazioni con le buche e il traguardo. Anche per il Giocatore , il
punteggio diminuisce all'entrata in una buca e la buca scompare. Al raggiungimento del
traguardo, determina il vincitore o il pareggio in base al punteggio dell'altro giocatore.
Esame //
Descrizione: Questo progetto è un semplice esempio di movimento di un oggetto
(probabilmente una sfera o un cubo) in un ambiente D utilizzando Unity. L'oggetto si
muove in base all'input dell'utente tramite i tasti direzionali.
Script Analizzati:
• Movement.cs : Questo script gestisce il movimento dell'oggetto a cui è attaccato.
Utilizza Input.GetAxis("Horizontal") e Input.GetAxis("Vertical") per ottenere l'input
dell'utente dai tasti direzionali (o WASD, a seconda della configurazione di Unity) e
sposta l'oggetto di conseguenza. La velocità di movimento è controllata dalla variabile
speedmove .
Esame //
Descrizione: Questo progetto sembra essere un gioco in cui una sfera si muove su una
piattaforma e deve raccogliere punti toccando il
pavimento e raggiungere un traguardo. Il gioco tiene traccia del punteggio e dello stato di
vittoria/sconfitta.
Script Analizzati:
• Gameplay.cs : Questo script gestisce la logica di gioco principale. Controlla il punteggio
( punti ), lo stato di vittoria ( vinto ), e visualizza il testo del punteggio e del risultato
(WIN/GAME OVER) sull'interfaccia utente. Se la sfera cade sotto una certa soglia Y, il
gioco termina. Quando la sfera collide con un oggetto con tag "Floor", il punteggio viene
incrementato e il colore della sfera cambia casualmente. Se la sfera entra in un trigger
con tag "Finish", il gioco viene vinto.
• MoveSphere.cs : Questo script controlla il movimento della sfera tramite l'applicazione
di forze (Rigidbody) in base all'input delle frecce direzionali. Gestisce anche le collisioni
con gli oggetti con tag "Traguardo" e "Floor", chiamando i metodi appropriati negli
script Risultato e ScoreManager (quest'ultimo non analizzato in dettaglio qui, ma
presumibilmente gestisce il punteggio).
• Risultato.cs : Questo script è responsabile della visualizzazione del risultato finale
(WIN/GAME OVER) su un elemento UI di tipo Text. Contiene metodi pubblici hasWon() e
gameOver() per aggiornare il testo del risultato.
Esame //
Descrizione: Questo progetto sembra essere un gioco in cui una palla deve evitare di cadere
nella lava, rappresentata da un trigger. Il giocatore ha un numero limitato di vite e, una volta
esaurite, il gioco termina. La piattaforma su cui si muove la palla può essere controllata.
Script Analizzati:
• Gameplay.cs : Questo script gestisce la logica di gioco principale, inclusa la gestione
delle vite del giocatore e lo stato di GAME OVER. Il giocatore inizia con un certo numero
di vite ( count ), rappresentate da RawImage nell'interfaccia utente. Quando la palla
(oggetto con questo script) entra in collisione con un oggetto con tag "lava" (trigger),
una vita viene persa e la palla viene riposizionata all'origine. Se le vite si esauriscono,
viene visualizzato "GAME OVER" e la palla viene disattivata. Include anche una funzione
Resetta() per ricaricare la scena.
• PlatformMovement.cs : Questo script controlla il movimento di una piattaforma. La
piattaforma si muove verticalmente (su e giù) in base all'input delle frecce direzionali
sinistra e destra. La velocità di movimento è definita dalla variabile speed .
Esame //
Descrizione: Questo progetto sembra essere un gioco in cui il giocatore controlla una sfera
e deve interagire con una cassa per far apparire delle monete, che poi deve raccogliere per
incrementare il punteggio. L'obiettivo è raccogliere tutte le monete.
Script Analizzati:
• GameController.cs : Questo script gestisce la logica di gioco principale. Si occupa della
distruzione di una cassa (tag "Cassa") e della generazione di un numero specificato di
monete ( qtaMonete ) in posizioni casuali. Inoltre, gestisce l'incremento del punteggio
( count ) quando una moneta viene raccolta e aggiorna il testo del punteggio
sull'interfaccia utente. Include una funzione Resetta() per ricaricare la scena.
• Movemnet.cs : Questo script controlla il movimento della sfera del giocatore tramite
l'applicazione di forze (Rigidbody) in base all'input delle frecce direzionali. Gestisce le
collisioni con la cassa (tag "Cassa"), chiamando il metodo distruggiCassa() nel
GameController per far apparire le monete. Inoltre, gestisce l'interazione con le monete
(trigger), chiamando il metodo incrementaCount() nel GameController per aggiornare il
punteggio.
Esame //
Descrizione: Questo progetto è un gioco in cui il giocatore controlla una sfera e deve
raggiungere un traguardo evitando di cadere. Il gioco include una telecamera che segue la
sfera e gestisce lo stato di vittoria o sconfitta.
Script Analizzati:
• Camera.cs : Questo script gestisce il movimento della telecamera, facendola seguire la
sfera ( sphere ) con un offset definito. Assicura che la visuale sia sempre centrata sul
giocatore.
• GameController.cs : Questo script gestisce lo stato di vittoria o sconfitta del gioco.
Contiene metodi win() e gameOver() che aggiornano un elemento UI di tipo Text per
visualizzare il messaggio appropriato.
• Movement.cs : Questo script controlla il movimento della sfera tramite l'applicazione di
forze (Rigidbody) in base all'input delle frecce direzionali. Se la sfera cade sotto una
certa soglia Y, il gioco termina chiamando il metodo gameOver() nel GameController . Se
la sfera entra in un trigger con tag "Finish", il gioco viene vinto chiamando il metodo
win() nel GameController .
Esame //
Descrizione: Questo progetto sembra essere un gioco in cui una sfera rimbalza in un
ambiente D. L'obiettivo è contare i rimbalzi della sfera contro le pareti e, ogni  rimbalzi,
cambiare il colore delle pareti. Il gioco include anche una funzione per resettare la scena.
Script Analizzati:
• GameController.cs : Questo script gestisce il conteggio dei rimbalzi della sfera e
l'aggiornamento del punteggio sull'interfaccia utente. Ogni  rimbalzi, cambia il colore
delle pareti (oggetti con tag "Box") in un colore casuale. Include anche una funzione
ResetAttivato() per ricaricare la scena.
• Gameplay.cs : Questo script è attaccato alla sfera e rileva le collisioni con gli oggetti con
tag "Box". Quando una collisione con una parete avviene, chiama il metodo
ContaRimbalzi() nel GameController per incrementare il conteggio dei rimbalzi.
