using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 2f, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            StartCoroutine(Jump(2f));
            rb.velocity = new Vector3(0, 20f, 0);
            
        }
    }

    IEnumerator Jump(float duration)
    {
        rb.velocity = new Vector3(0, -10f, 0);
        yield return new WaitForSeconds(duration);
    }
}
