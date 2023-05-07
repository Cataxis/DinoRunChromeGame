using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;

    private Rigidbody2D dinoRB;
    private Animator dinoAnimator;

    private bool gameOver = false;

    void Start()
    {
        dinoRB = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (!gameOver)
        {
            bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
            dinoAnimator.SetBool("IsGrounded", isGrounded);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    dinoRB.AddForce(Vector2.up * upForce);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            GameManager.Instance.ShowGameOverScreen();
            dinoAnimator.SetTrigger("Die");
        }
    }
}
