using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public Text score, result;
    int punti = 0;
    bool vinto = false; //utilizzata per non far apparire 'GAME OVER' una volta toccato il finish

    // Start is called before the first frame update
    void Start()
    {
        result.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.y < -3 && !vinto)
        {
            result.text = "GAME OVER";
            score.text = ""; //scompare la scritta SCORE
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor" && !vinto)
        {
            punti++;
            score.text = "SCORE :" + punti;

            //extra
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
