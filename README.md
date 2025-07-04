# Grafica-ed-Interattivita

Questa repository contiene gli esami del corso di Grafica ed Interattività dell'Università Degli Studi Di Salerno.

## Struttura della Repository

La repository è organizzata come segue:

- `Progetti/`: Contiene le cartelle relative a ciascun esame, organizzate per data.

## Esami

Di seguito una descrizione dettagliata di ciascun esame presente nella cartella `Progetti`.




### Esame 06/09/2022

**Descrizione:** Questo progetto sembra essere un gioco basato sulla fisica in Unity, dove una sfera si muove su una piattaforma e interagisce con oggetti di vetro e legno. L'obiettivo è raggiungere un punto finale evitando di cadere.

**Script Analizzati:**

- **`Camera.cs`**: Questo script gestisce il movimento della telecamera, facendola seguire la sfera principale con un offset definito. Assicura che la visuale sia sempre centrata sul giocatore.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class Camera : MonoBehaviour
  {
      public Transform p;
      public Vector3 offset;
      void Update()
      {
          transform.position = p.position + offset;
      }
  }
  ```

- **`GameController.cs`**: Questo script è attualmente vuoto, ma è probabile che fosse destinato a gestire la logica di gioco generale, come il punteggio, lo stato del gioco (vittoria/sconfitta) o la generazione di elementi.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class GameController : MonoBehaviour
  {
      void Start()
      {
          
      }

      void Update()
      {
          
      }

      private void OnCollisionEnter(Collision collision)
      {
          
      }
  }
  ```

- **`Movement.cs`**: Questo script controlla il movimento della sfera tramite le frecce direzionali e gestisce le interazioni con gli oggetti. In particolare, al tocco della barra spaziatrice, scambia i materiali tra gli oggetti con tag "vetro" e "legno". Se la sfera cade sotto una certa soglia Y, il gioco termina. Quando la sfera collide con un oggetto "vetro", il colore dell'oggetto cambia casualmente. Se collide con un oggetto "Finish", il giocatore vince.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class Movement : MonoBehaviour
  {
      public Text text;
      public int speed = 1;
      bool haVinto = false;
      private GameObject[] vetro;
      private GameObject[] legno;
      
      void Start()
      {
          vetro = GameObject.FindGameObjectsWithTag("vetro");
          legno = GameObject.FindGameObjectsWithTag("legno");
      }

      void Update()
      {
          if (Input.GetKey(KeyCode.LeftArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.left * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
          }
          if (Input.GetKeyDown(KeyCode.Space))
          {
              var mat = legno[0].gameObject.GetComponent<Renderer>().material;
              var mat2 = vetro[0].gameObject.GetComponent<Renderer>().material;

              for(int i = 0; i < legno.Length; i++)
              {
                  vetro[i].GetComponent<Renderer>().material = mat;
              }
              for (int j = 0; j < vetro.Length; j++)
              {
                  legno[j].GetComponent<Renderer>().material = mat2;
              }
          }

          if(transform.position.y < -30 && !haVinto)
          {
              text.text = "GAME OVER";    
          }
      }

      void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.tag == "vetro")
          {
              Color color = new Color(Random.value, Random.value, Random.value);
              collision.gameObject.GetComponent<Renderer>().material.color = color;

          }
          if (collision.gameObject.tag == "Finish" && !haVinto)
          {
              haVinto = true;
              text.text = "WIN";
          }
      }
  }
  ```




### Esame 12/02/2023

**Descrizione:** Questo progetto è un gioco per due giocatori in cui ognuno controlla una sfera e deve attraversare un percorso evitando delle "buche" che riducono il punteggio. L'obiettivo è raggiungere il traguardo con il punteggio più alto.

**Script Analizzati:**

- **`Player1.cs`**: Controlla il movimento del Giocatore 1 (frecce direzionali) e gestisce l'interazione con le "buche" (tag "buca") e il traguardo (tag "Finish"). Ogni volta che il Giocatore 1 entra in una buca, il suo punteggio diminuisce e la buca scompare. Al raggiungimento del traguardo, determina il vincitore o il pareggio in base al punteggio dell'altro giocatore.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class Player1 : MonoBehaviour
  {
      public int speedmove = 1;
      public Text player1Text;
      public GameObject player2 = new GameObject();
      public int player1Score = 10;
      public bool arrivatoPlayer1 = false;

      void Start()
      {
          player1Text.text = "PLAYER 1 : " + player1Score;
      }

      void Update()
      {
          if (Input.GetKey(KeyCode.UpArrow))
          {
              transform.Translate(Vector3.forward * speedmove * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.DownArrow))
          {
              transform.Translate(Vector3.back * speedmove * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.LeftArrow))
          {
              transform.Translate(Vector3.left * speedmove * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              transform.Translate(Vector3.right * speedmove * Time.deltaTime);
          }
      }

      void OnTriggerEnter(Collider collider)
      {
          if (collider.gameObject.tag == "buca")
          {
              player1Score--;
              player1Text.text = "PLAYER 1 : " + player1Score;
              Destroy(collider.gameObject);
              Color newColor = new Color(Random.value, Random.value, Random.value);
              GetComponent<Renderer>().material.color = newColor;
          }

          if (collider.gameObject.tag == "Finish")
          {
              if (!player2.GetComponent<Player2>().arrivatoPlayer2)
              {
                  arrivatoPlayer1 = true;
                  if (player1Score >= player2.GetComponent<Player2>().player2Score)
                  {
                      player1Text.text = "WIN";
                  }
                  if(player1Score < player2.GetComponent<Player2>().player2Score)
                  {
                      player1Text.text = "DRAW";
                  }
              }
              else
              {
                  if (player1Score >= player2.GetComponent<Player2>().player2Score)
                  {
                      player1Text.text = "DRAW";
                  }
                  if (player1Score < player2.GetComponent<Player2>().player2Score)
                  {
                      player1Text.text = "LOSE";
                  }
              }
          }
      }
  }
  ```

- **`Player2.cs`**: Simile a `Player1.cs`, ma controlla il movimento del Giocatore 2 (tasti W, A, S, D) e gestisce le sue interazioni con le buche e il traguardo. Anche per il Giocatore 2, il punteggio diminuisce all'entrata in una buca e la buca scompare. Al raggiungimento del traguardo, determina il vincitore o il pareggio in base al punteggio dell'altro giocatore.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class Player2 : MonoBehaviour
  {
      public int speedmove = 1;
      public Text player2Text;
      public int player2Score = 10;
      public bool arrivatoPlayer2 = false;
      public GameObject player1 = new GameObject();

      void Start()
      {
          player2Text.text = "PLAYER 2 : " + player2Score;
      }

      void Update()
      {
          if (Input.GetKey(KeyCode.W))
          {
              transform.Translate(Vector3.forward * speedmove * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.S))
          {
              transform.Translate(Vector3.back * speedmove * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.A))
          {
              transform.Translate(Vector3.left * speedmove * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.D))
          {
              transform.Translate(Vector3.right * speedmove * Time.deltaTime);
          }
      }

      void OnTriggerEnter(Collider collider)
      {
          if (collider.gameObject.tag == "buca")
          {
              player2Score--;
              player2Text.text = "PLAYER 2 : " + player2Score;
              Destroy(collider.gameObject);
              Color newColor = new Color(Random.value, Random.value, Random.value);
              GetComponent<Renderer>().material.color = newColor;
          }

          if (collider.gameObject.tag == "Finish")
          {
              if (!player1.GetComponent<Player1>().arrivatoPlayer1)
              {
                  arrivatoPlayer2 = true;
                  if (player2Score >= player1.GetComponent<Player1>().player1Score)
                  {
                      player2Text.text = "WIN";
                  }
                  if (player2Score < player1.GetComponent<Player1>().player1Score)
                  {
                      player2Text.text = "DRAW";
                  }
              }
              else
              {
                  if (player2Score >= player1.GetComponent<Player1>().player1Score)
                  {
                      player2Text.text = "DRAW";
                  }
                  if (player2Score < player1.GetComponent<Player1>().player1Score)
                  {
                      player2Text.text = "LOSE";
                  }
              }
          }
      }
  }
  ```




### Esame 15/06/2020

**Descrizione:** Questo progetto è un semplice esempio di movimento di un oggetto (probabilmente una sfera o un cubo) in un ambiente 3D utilizzando Unity. L'oggetto si muove in base all'input dell'utente tramite i tasti direzionali.

**Script Analizzati:**

- **`Movement.cs`**: Questo script gestisce il movimento dell'oggetto a cui è attaccato. Utilizza `Input.GetAxis("Horizontal")` e `Input.GetAxis("Vertical")` per ottenere l'input dell'utente dai tasti direzionali (o WASD, a seconda della configurazione di Unity) e sposta l'oggetto di conseguenza. La velocità di movimento è controllata dalla variabile `speedmove`.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class Movement : MonoBehaviour
  {
      public int speedmove = 1;
      void Start()
      {
          
      }

      void Update()
      {
          float horizontal = Input.GetAxis("Horizontal");
          float vertical = Input.GetAxis("Vertical");

          Vector3 movement = new Vector3(horizontal, 0f, vertical);

          transform.Translate(movement * speedmove * Time.deltaTime);
      }
  }
  ```




### Esame 16/06/2023

**Descrizione:** Questo progetto sembra essere un gioco in cui una sfera si muove su una piattaforma e deve raccogliere punti toccando il 


pavimento e raggiungere un traguardo. Il gioco tiene traccia del punteggio e dello stato di vittoria/sconfitta.

**Script Analizzati:**

- **`Gameplay.cs`**: Questo script gestisce la logica di gioco principale. Controlla il punteggio (`punti`), lo stato di vittoria (`vinto`), e visualizza il testo del punteggio e del risultato (WIN/GAME OVER) sull'interfaccia utente. Se la sfera cade sotto una certa soglia Y, il gioco termina. Quando la sfera collide con un oggetto con tag "Floor", il punteggio viene incrementato e il colore della sfera cambia casualmente. Se la sfera entra in un trigger con tag "Finish", il gioco viene vinto.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class Gameplay : MonoBehaviour
  {
      public Text score, result;
      int punti = 0;
      bool vinto = false;

      void Start()
      {
          result.text = "";
      }

      void Update()
      {
          if (gameObject.transform.position.y < -3 && !vinto)
          {
              result.text = "GAME OVER";
              score.text = "";
          }
      }

      void OnCollisionEnter(Collision collision)
      {
          if(collision.gameObject.tag == "Floor" && !vinto)
          {
              punti++;
              score.text = "SCORE :" + punti;
              Color newColor = new Color(Random.value, Random.value, Random.value, 1f);
              GetComponent<Renderer>().material.color = newColor;
          }
      }

      private void OnTriggerEnter(Collider other)
      {
          if (other.gameObject.tag == "Finish" && !vinto)
          {
              result.text = "WIN";
              vinto = true;
              score.text = "FINAL SCORE :" + punti;
          }
      }
  }
  ```

- **`MoveSphere.cs`**: Questo script controlla il movimento della sfera tramite l'applicazione di forze (Rigidbody) in base all'input delle frecce direzionali. Gestisce anche le collisioni con gli oggetti con tag "Traguardo" e "Floor", chiamando i metodi appropriati negli script `Risultato` e `ScoreManager` (quest'ultimo non analizzato in dettaglio qui, ma presumibilmente gestisce il punteggio).
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class MoveSphere : MonoBehaviour
  {
      public float speed = 5f;

      void Update()
      {
          if (Input.GetKey(KeyCode.UpArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.DownArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.back * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.LeftArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.left * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              GetComponent <Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
          }
      }

      void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.tag == "Traguardo")
          { 
              FindObjectOfType<Risultato>().hasWon();
          }
          if (collision.gameObject.tag == "Floor")
          {
              FindObjectOfType<ScoreManager>().IncrementaScore();
          }
      }
  }
  ```

- **`Risultato.cs`**: Questo script è responsabile della visualizzazione del risultato finale (WIN/GAME OVER) su un elemento UI di tipo Text. Contiene metodi pubblici `hasWon()` e `gameOver()` per aggiornare il testo del risultato.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class Risultato : MonoBehaviour
  {
      public Text text;

      void Start()
      {
          Update();
      }

      void Update()
      {
          text.text = "" + text;
      }

      public void hasWon()
      {
          text.text = "WIN";
          Update();
      }

      public void gameOver()
      {
          text.text = "GAME OVER";
          Update();
      }
  }
  ```




### Esame 22/03/2023

**Descrizione:** Questo progetto sembra essere un gioco in cui una palla deve evitare di cadere nella lava, rappresentata da un trigger. Il giocatore ha un numero limitato di vite e, una volta esaurite, il gioco termina. La piattaforma su cui si muove la palla può essere controllata.

**Script Analizzati:**

- **`Gameplay.cs`**: Questo script gestisce la logica di gioco principale, inclusa la gestione delle vite del giocatore e lo stato di GAME OVER. Il giocatore inizia con un certo numero di vite (`count`), rappresentate da `RawImage` nell'interfaccia utente. Quando la palla (oggetto con questo script) entra in collisione con un oggetto con tag "lava" (trigger), una vita viene persa e la palla viene riposizionata all'origine. Se le vite si esauriscono, viene visualizzato "GAME OVER" e la palla viene disattivata. Include anche una funzione `Resetta()` per ricaricare la scena.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;
  using UnityEngine.SceneManagement;

  public class Gameplay : MonoBehaviour
  {
      public RawImage[] vite;
      public int count = 3;
      public Text text;

      void Start()
      {
       
      }

      void Update()
      {
          
      }

      private void OnTriggerEnter(Collider collider)
      {
          if(collider.gameObject.tag == "lava")
          {
              count--;
              if (count >= 0)
              {
                  
                  Destroy(vite[count]);
                  transform.position = new Vector3(0, 0, 0);
              }
              else
              {                
                  text.text = "GAME OVER";
                  gameObject.SetActive(false);
              }  
          }
      }

      public void Resetta()
      {
          SceneManager.LoadScene("SampleScene");
      }
  }
  ```

- **`PlatformMovement.cs`**: Questo script controlla il movimento di una piattaforma. La piattaforma si muove verticalmente (su e giù) in base all'input delle frecce direzionali sinistra e destra. La velocità di movimento è definita dalla variabile `speed`.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class PlatformMovement : MonoBehaviour
  {
      public float speed = 1.0f;
      void Start()
      {
          
      }

      void Update()
      {
          if (Input.GetKey(KeyCode.LeftArrow))
          {
              transform.Translate(Vector3.up * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              transform.Translate(Vector3.down * speed * Time.deltaTime);
          }
      }
  }
  ```




### Esame 26/10/2022

**Descrizione:** Questo progetto sembra essere un gioco in cui il giocatore controlla una sfera e deve interagire con una cassa per far apparire delle monete, che poi deve raccogliere per incrementare il punteggio. L'obiettivo è raccogliere tutte le monete.

**Script Analizzati:**

- **`GameController.cs`**: Questo script gestisce la logica di gioco principale. Si occupa della distruzione di una cassa (tag "Cassa") e della generazione di un numero specificato di monete (`qtaMonete`) in posizioni casuali. Inoltre, gestisce l'incremento del punteggio (`count`) quando una moneta viene raccolta e aggiorna il testo del punteggio sull'interfaccia utente. Include una funzione `Resetta()` per ricaricare la scena.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;
  using UnityEngine.SceneManagement;

  public class GameController : MonoBehaviour
  {
      public Text text;
      private GameObject cassa;
      public int qtaMonete;
      public GameObject moneta;
      private int count;
      void Start()
      {
          cassa = GameObject.FindGameObjectWithTag("Cassa");
      }

      void Update()
      {
          
      }

      public void distruggiCassa()
      {
          Destroy(cassa);
          for(int i = 0; i < qtaMonete; i++)
          {
              Instantiate(moneta, new Vector3(Random.Range(-2.4f,2.4f), 0.1f, Random.Range(-2.4f,2.4f)), Quaternion.Euler(90f,0f,0f));
          }
      }

      public void incrementaCount(Collider moneta)
      {
          count++;
          text.text = "Score :" + count;
          Destroy(moneta.gameObject);
      }

      public void Resetta()
      {
          SceneManager.LoadScene("SampleScene");
      }
  }
  ```

- **`Movemnet.cs`**: Questo script controlla il movimento della sfera del giocatore tramite l'applicazione di forze (Rigidbody) in base all'input delle frecce direzionali. Gestisce le collisioni con la cassa (tag "Cassa"), chiamando il metodo `distruggiCassa()` nel `GameController` per far apparire le monete. Inoltre, gestisce l'interazione con le monete (trigger), chiamando il metodo `incrementaCount()` nel `GameController` per aggiornare il punteggio.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class Movemnet : MonoBehaviour
  {
      public int speed;
      private GameController controller;
      void Start()
      {
          controller = GameObject.FindObjectOfType<GameController>();
      }

      void Update()
      {
          if (Input.GetKey(KeyCode.LeftArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.left * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.UpArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.DownArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.back * speed * Time.deltaTime);
          }
      }

     void OnCollisionEnter(Collision collision)
      {
          if(collision.gameObject.tag == "Cassa")
          {
              controller.distruggiCassa();
          }
      }

      private void OnTriggerEnter(Collider other)
      {
          controller.incrementaCount(other);
      }
  }
  ```




### Esame 27/01/2022

**Descrizione:** Questo progetto è un gioco in cui il giocatore controlla una sfera e deve raggiungere un traguardo evitando di cadere. Il gioco include una telecamera che segue la sfera e gestisce lo stato di vittoria o sconfitta.

**Script Analizzati:**

- **`Camera.cs`**: Questo script gestisce il movimento della telecamera, facendola seguire la sfera (`sphere`) con un offset definito. Assicura che la visuale sia sempre centrata sul giocatore.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class Camera : MonoBehaviour
  {
      public GameObject sphere;
      public Vector3 offset;
      void Start()
      {

      }

      void Update()
      {
          transform.position = sphere.transform.position + offset;
      }
  }
  ```

- **`GameController.cs`**: Questo script gestisce lo stato di vittoria o sconfitta del gioco. Contiene metodi `win()` e `gameOver()` che aggiornano un elemento UI di tipo Text per visualizzare il messaggio appropriato.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class GameController : MonoBehaviour
  {
      public Text text;

      void Start()
      {
          
      }

      void Update()
      {
          
      }

      public void win(Collider collision)
      {
          if(collision.gameObject.tag == "Finish")
          {
              text.text = "WIN";
          }
      }

      public void gameOver()
      {
          text.text = "GAME OVER";
      }
  }
  ```

- **`Movement.cs`**: Questo script controlla il movimento della sfera tramite l'applicazione di forze (Rigidbody) in base all'input delle frecce direzionali. Se la sfera cade sotto una certa soglia Y, il gioco termina chiamando il metodo `gameOver()` nel `GameController`. Se la sfera entra in un trigger con tag "Finish", il gioco viene vinto chiamando il metodo `win()` nel `GameController`.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class Movement : MonoBehaviour
  {
      public int speed;
      private GameController controller;
      bool haVinto = false;

      void Start()
      {
          controller = GameObject.FindObjectOfType<GameController>();
      }

      void Update()
      {
          if (Input.GetKey(KeyCode.LeftArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.left * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.UpArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
          }
          if (Input.GetKey(KeyCode.DownArrow))
          {
              GetComponent<Rigidbody>().AddForce(Vector3.back * speed * Time.deltaTime);
          }

          if(transform.position.y < -3 && !haVinto)
          {
              controller.gameOver();
          }
      }

      private void OnTriggerEnter(Collider other)
      {
          if (!haVinto)
          {
              haVinto = true;
              controller.win(other);
          }
            
      }
  }
  ```




### Esame 30/01/2023

**Descrizione:** Questo progetto sembra essere un gioco in cui una sfera rimbalza in un ambiente 3D. L'obiettivo è contare i rimbalzi della sfera contro le pareti e, ogni 10 rimbalzi, cambiare il colore delle pareti. Il gioco include anche una funzione per resettare la scena.

**Script Analizzati:**

- **`GameController.cs`**: Questo script gestisce il conteggio dei rimbalzi della sfera e l'aggiornamento del punteggio sull'interfaccia utente. Ogni 10 rimbalzi, cambia il colore delle pareti (oggetti con tag "Box") in un colore casuale. Include anche una funzione `ResetAttivato()` per ricaricare la scena.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;
  using UnityEngine.SceneManagement;

  public class GameController : MonoBehaviour
  {
      private int count = 0;
      public Text punteggio;
      private GameObject[] pareti;

      void Start()
      {
          pareti = GameObject.FindGameObjectsWithTag("Box");
      }

      void Update()
      {

      }

      public void ContaRimbalzi()
      {
          count++;
          punteggio.text = "Rimbalzi: " + count;

          Color c = new Color(Random.value, Random.value, Random.value,0.5f);

          if (count % 10 == 0)
          {
              for (int i = 0; i < pareti.Length; i++)
              {
                  pareti[i].GetComponent<Renderer>().material.color = c;
              }
          }
      }

      public void ResetAttivato()
      {
          SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
      }
      
  }
  ```

- **`Gameplay.cs`**: Questo script è attaccato alla sfera e rileva le collisioni con gli oggetti con tag "Box". Quando una collisione con una parete avviene, chiama il metodo `ContaRimbalzi()` nel `GameController` per incrementare il conteggio dei rimbalzi.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;

  public class Gameplay : MonoBehaviour
  {
      private GameController gigi;

      void Start()
      {
          gigi = GameObject.FindObjectOfType<GameController>();
      }

      void Update()
      {

      }

      public void OnCollisionEnter(Collision collision)
      {
          if (collision.collider.CompareTag("Box"))
              gigi.ContaRimbalzi();
      }
  }
  ```


