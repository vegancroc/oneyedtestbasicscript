using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuButton : MonoBehaviour
{
    private bool isClicked;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float clickTime;

    void Awake()
    {
        anim.SetBool("isClicked", false);
    }

    void Start()
    {
        anim.SetBool("isClicked", false);
    }

    void Update()
    {
        anim.SetBool("isClicked", isClicked);
        //Debug.Log(anim.GetBool("isClicked"));
        if (isClicked)
        {
            Invoke("isClickedFalse", clickTime);
        }
    }

    public void isClickedTrue()
    {
        isClicked = true;
    }

    void isClickedFalse()
    {
        isClicked = false;
    }

}
