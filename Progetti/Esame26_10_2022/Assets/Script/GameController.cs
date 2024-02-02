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
    // Start is called before the first frame update
    void Start()
    {
        cassa = GameObject.FindGameObjectWithTag("Cassa");
    }

    // Update is called once per frame
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
