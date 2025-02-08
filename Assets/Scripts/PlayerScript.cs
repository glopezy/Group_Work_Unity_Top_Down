using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator animator;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    [SerializeField] private float moveSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void FixedUpdate()
    {
        
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //si hay movimiento avisamos al animador de que estamos andando
        if (horizontal != 0f || vertical != 0)
        {
            animator.SetBool("isWalking", true);

        }
        //limitador de velocidad diagonal
        if (horizontal != 0 && vertical != 0)
        {

            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        //la idea es que esto se guarde antes de actualizar la direccion actual,
        //para que el personaje se quede mirando en la ultima dirección en la que andó,
        //pero aún no he conseguido hacerlo
        animator.SetFloat("LastInputX", animator.GetFloat("InputX"));
        animator.SetFloat("LastInputY", animator.GetFloat("InputY"));

        //velocidad y floats direccionales actuales para el animador
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        animator.SetFloat("InputX", horizontal);
        animator.SetFloat("InputY", vertical);

        //update de variables de animador cuando se termina el movimiento
        if (horizontal == 0 && vertical == 0)
        {
            
            
            animator.SetBool("isWalking", false);

        }
        

        
    }
}
