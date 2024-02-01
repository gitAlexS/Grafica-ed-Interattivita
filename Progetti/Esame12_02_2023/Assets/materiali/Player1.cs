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


    // Start is called before the first frame update
    void Start()
    {
        player1Text.text = "PLAYER 1 : " + player1Score;
    }

    // Update is called once per frame
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

            //la buca deve sparire
            Destroy(collider.gameObject);

            //extra
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
