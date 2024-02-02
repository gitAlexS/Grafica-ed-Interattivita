using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
