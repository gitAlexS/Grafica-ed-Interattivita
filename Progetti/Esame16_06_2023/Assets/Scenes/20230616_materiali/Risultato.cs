using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Risultato : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    // Update is called once per frame
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
