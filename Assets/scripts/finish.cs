using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{

    private AudioSource finisheffect;
    private bool lvlcom=false;

    // Start is called before the first frame update
    private void Start()
    {
        finisheffect =GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="player" && !lvlcom)
        {
            finisheffect.Play();
            lvlcom = true;
            Invoke("completelvl", 2f);
                   
        }
    }

    private void completelvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
