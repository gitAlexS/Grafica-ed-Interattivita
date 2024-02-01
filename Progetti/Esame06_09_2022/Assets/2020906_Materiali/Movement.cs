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
    
    // Start is called before the first frame update
    void Start()
    {
        vetro = GameObject.FindGameObjectsWithTag("vetro");
        legno = GameObject.FindGameObjectsWithTag("legno");
    }

    // Update is called once per frame
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
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        */

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
