using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private float upForce;

    Rigidbody2D rb;

    [SerializeField]
    private AudioSource audioSource;

    private bool play;

    //public static booster Instance;

    //public bool boosted;

    void Start()
    { 
        rb = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>();
        //audioSource = GameObject.Find("windSound").GetComponent<AudioSource>();
        //Instance = this;
    }

    void Update()
    {
        if (play && !audioSource.isPlaying && audioSource.clip != null)
        {
            audioSource.Play();
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
            play = true;
            //boosted = true;
            AddForce();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (audioSource.clip != null)
        { 
            play = false;
            audioSource.Stop();
        }
        
    }

    void AddForce()
    { 
        rb.AddForce(new Vector2(0, Vector2.up.y + upForce * Time.deltaTime));
    }

}
