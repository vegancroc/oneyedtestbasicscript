using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    [SerializeField]
    private Transform targetA, targetB;

    [SerializeField]
    private float speed;

    [SerializeField]
    private string playerTag;

    Vector3 moveDirection = Vector3.up;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (transform.position.y >= targetA.position.y)
        {
            moveDirection = Vector3.down;
        }
        else if(transform.position.y <= targetB.position.y)
        {
            moveDirection = Vector3.up;
        }

        transform.Translate(moveDirection * Time.deltaTime * speed);
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
