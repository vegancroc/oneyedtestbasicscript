using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class movingGround : MonoBehaviour
{
    //Rigidbody2D rb;

    [SerializeField]
    private Transform myObj1;

    [SerializeField]
    private Transform myObj2;

    [SerializeField]
    private float movingSpeed;

    [SerializeField]
    private string playerTag;

    //[SerializeField]
    //private CinemachineVirtualCamera cm;

    private bool movingRight = true;

    private GameObject player;

    void Start()
    { 
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void FixedUpdate()
    { 
        if (transform.position.x < myObj1.position.x)
        {
            movingRight = true;
        }
        else if (transform.position.x > myObj2.position.x)
        {
            movingRight = false;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + movingSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y);

        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            //cm.Follow = this.transform;
            player.transform.parent = this.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            //cm.Follow = player.transform;
            player.transform.parent = null;
        }
    }
}
