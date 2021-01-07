using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalBooster : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private float horizontalForce;

    [SerializeField]
    private AudioSource audioSource;

    Rigidbody2D rb;

    private bool play;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>();
        //audioSource = GameObject.Find("windSound").GetComponent<AudioSource>();

        //Instance = this;
    }

    void Update()
    {
        if (play && !audioSource.isPlaying)
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
        Debug.Log("exit");
        play = false;
        audioSource.Stop();
    }


    void AddForce()
    {
        //rb.velocity = new Vector2(horizontalForce * Time.deltaTime * Vector2.left.x, rb.velocity.y);
        rb.AddForce(new Vector2(horizontalForce * Time.deltaTime * Vector2.left.x,0));
    }

}
