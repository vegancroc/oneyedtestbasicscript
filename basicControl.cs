using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class basicControl : MonoBehaviour
{
    #region Field
    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private Animator anim;

    private float jumpSpeed;

    private bool turned;

    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float maxJumpValue;

    [SerializeField]
    private float increasingAmount;

    [SerializeField]
    private LayerMask obstacleLayer;

    [SerializeField]
    private Transform playerPosition1;

    [SerializeField]
    private Transform playerPosition2;

    [SerializeField]
    private GameObject sweatEffect;

    [SerializeField]
    private CinemachineVirtualCamera cinemachineCam;

    #endregion

    #region Methods
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalSpeed += 5;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontalSpeed -= 5;
        }
#endif


        Control();
    }

    void FixedUpdate()
    {
        if (turned)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void Control()
    {

        anim.SetFloat("jumpSpeed", jumpSpeed);
        anim.SetBool("isGround", checkGrounded());

        if (jumpSpeed > maxJumpValue - 1 && checkGrounded())
        {
            sweatEffect.gameObject.SetActive(true);
        }
        else
        {
            sweatEffect.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0) && checkGrounded() && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(horizontalSpeed, jumpSpeed);
        }
        else if (Input.GetMouseButton(0))
        {
            checkLeftRight();
            if (jumpSpeed <= maxJumpValue)
            {
                jumpSpeed += increasingAmount;
            }
        }
        else
        {
            jumpSpeed = 0;
        }
    }

    Vector3 getScreenToWorld(Vector3 position)
    {
        return Camera.main.ScreenToWorldPoint(position);
    }

    void checkLeftRight()
    {
        if (Input.mousePosition.x < Screen.width / 2)
        {
            turned = true;
            if (horizontalSpeed < 0)
            {

            }
            else
            { 
                horizontalSpeed *= -1;
            }
            Debug.Log("Left click" + " " + Input.mousePosition);
        }

        else
        {
            turned = false; 
            horizontalSpeed = Mathf.Abs(horizontalSpeed);
            Debug.Log("Right click" + " " + Input.mousePosition);
        }
    }

    bool checkGrounded()
    {
        if (Physics2D.OverlapArea(playerPosition1.position,playerPosition2.position,obstacleLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    #endregion


}
