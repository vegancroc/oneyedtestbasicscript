using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upJumper : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private float resurrectionTime;

    [SerializeField]
    private float force;

    private SpriteRenderer sr;

    private Rigidbody2D rb;

    private float currentTime;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        rb = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!sr.enabled)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= resurrectionTime)
            {
                currentTime = 0;
                Appear();
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == playerTag && sr.enabled)
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
            soundManager.Instance.playFireSound(.5f);
            Disappear();
        }
    }

    void Appear()
    {
        sr.enabled = true;
        //GetComponent<BoxCollider2D>().enabled = true;
    }

    void Disappear()
    {
        sr.enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
    }

}
