using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deatheffect;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            die();
        }
    }

    private void die()
    {
        deatheffect.Play();
        rb.bodyType=RigidbodyType2D.Static; 
        anim.SetTrigger("death");
    }

    private void startagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
