using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private float fallTime;

    [SerializeField]
    private float resurrectionTime;

    private BoxCollider2D bxCol;
    private Animator anim;

    void Start()
    {
        bxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        if (bxCol.isTrigger)
        {
            Invoke("appearPlatform", resurrectionTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            Invoke("disappearPlatform", fallTime);
        }
    }

    void disappearPlatform()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
        bxCol.isTrigger = true;
        anim.SetBool("isTrigger", true);
    }

    void appearPlatform()
    {
        this.gameObject.layer = LayerMask.NameToLayer("obstacle");
        anim.SetBool("isTrigger", false);
        bxCol.isTrigger = false;
    }
    
}
