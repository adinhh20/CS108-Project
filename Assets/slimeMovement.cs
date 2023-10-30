using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
        jumpForce = 60f;
        isJumping = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Jump");

    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            jumpSoundEffect.Play();
            rb.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

}
