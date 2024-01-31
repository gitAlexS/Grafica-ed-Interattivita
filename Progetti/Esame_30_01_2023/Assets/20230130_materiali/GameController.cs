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

    // Start is called before the first frame update
    void Start()
    {
        pareti = GameObject.FindGameObjectsWithTag("Box");
    }

    // Update is called once per frame
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
                /*
                var material = pareti[i].GetComponent<Renderer>().material;
                c.a = material.color.a;
                material.color = c;
            */
                pareti[i].GetComponent<Renderer>().material.color = c;
            }
        }

    }

    public void ResetAttivato()
    {
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }
    
}
