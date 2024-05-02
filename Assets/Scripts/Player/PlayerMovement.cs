using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rb;
    

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    //Fonction réservé pour l'update de la physique uniquement
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,collisionLayers);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement);
    }
    //Fonction update pour tout ce qui n'est pas physique
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
        if(isJumping )
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping=false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if(_velocity >0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }
    //Fonction qui permet de dessiner un cercle autour du gizmo de la détection de collision pour le saut
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
    }
}
