using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemcollector : MonoBehaviour
{
    private int apples = 0;
    private int melons = 0;

    [SerializeField] private Text apples_text;
    [SerializeField] private Text melons_text;
    [SerializeField] private AudioSource collecteffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            collecteffect.Play();
            Destroy(collision.gameObject);
            apples++;
            apples_text.text = "apples: " + apples;
        }
        if (collision.gameObject.CompareTag("melon"))
        {
            collecteffect.Play();
            Destroy(collision.gameObject);
            melons++;
            melons_text.text = "melons: " + melons;
        }
    }
}
