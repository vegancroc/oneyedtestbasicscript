using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timingPlatform : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private float togglePlatformTime;

    private BoxCollider2D bxCol;

    private SpriteRenderer sr;

    private Rigidbody2D rb;

    private float currentTime;

    private float gravityScale;

    private bool enable;

    void Start()
    {
        bxCol = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        gravityScale = rb.gravityScale;

        enable = true;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= togglePlatformTime)
        {
            currentTime = 0;
            TogglePlatform();
        }
    }

    void TogglePlatform()
    {
        enable = !enable;

        if (enable)
        {
            sr.enabled = true;
            bxCol.isTrigger = false;
            rb.gravityScale = gravityScale;
            this.gameObject.layer = LayerMask.NameToLayer("obstacle");
        }

        else
        {
            sr.enabled = false;
            bxCol.isTrigger = true;
            rb.gravityScale = 0;
            this.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

}
