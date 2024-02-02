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

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
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
