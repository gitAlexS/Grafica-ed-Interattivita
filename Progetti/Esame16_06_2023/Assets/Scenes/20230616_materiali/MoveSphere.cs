using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {

        /*      PRIMA SOLUZIONE
         *      
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.Translate(movement * speed * Time.deltaTime);

        */

        //  ALTERNATIVA CON ADDFORCE

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
