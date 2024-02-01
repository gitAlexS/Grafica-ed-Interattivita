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

    // Start is called before the first frame update
    void Start()
    {
        player2Text.text = "PLAYER 2 : " + player2Score;
    }

    // Update is called once per frame
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

            //la buca deve sparire
            Destroy(collider.gameObject);
            //extra
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
