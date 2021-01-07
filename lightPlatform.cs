using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightPlatform : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            //cm.Follow = this.transform;
            player.transform.parent = this.transform;
        }
    }

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == playerTag)
    //    {
    //        //cm.Follow = player.transform;
    //        player.transform.parent = null;
    //    }
    //}

}
