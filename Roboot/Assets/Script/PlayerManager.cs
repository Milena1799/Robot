using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Rigidbody2D rb;

    float speed; //Velocidad enb X a la que me muevo
    [SerializeField] float maxSpeed; //velocidad de desplazamiento máxima

    float desplX;


    bool alive = true;

    bool facingRight = true;

    [SerializeField] float jumpForce;

    [SerializeField] float distanciaSuelo;

    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        maxSpeed = 3.5f;

        jumpForce = 8.5f;
        distanciaSuelo = 0.05f;
    
}

    // Update is called once per frame
    void Update()
    {
        
        desplX = Input.GetAxis("Horizontal");

        if (alive)
        {
            Correr();
            Girar();
            Agacharse();
            Rodar();
        }

    }

        private void FixedUpdate()
        {
            if (alive)
            {
                Caminar();
                Saltar();
                
            }

        }
        /* void Flip()
        {
            //Cambiamos el valor de booleana, poniendo su valor
            mirandoDerecha = !mirandoDerecha;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        */
        void Caminar()
        {
            rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
            speed = rb.velocity.x;
            speed = Mathf.Abs(speed);
            animator.SetFloat("Caminar", speed);
        }
        void Girar()
        {
            if (desplX < 0 && facingRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facingRight = false;
            }
            else if (desplX > 0 && !facingRight)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facingRight = true;
            }
        }

        void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("TocarSuelo") )
        {
            rb.AddForce(new Vector2(0f, 1f) * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Saltar");
        }

      

        Debug.DrawRay(transform.position, Vector2.down * distanciaSuelo, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaSuelo); //detecta el suelo

        if (hit.collider != null)
        {

            animator.SetBool("TocarSuelo", true);
        }
        else
        {
            animator.SetBool("TocarSuelo", false);
        }
    }

        void Correr()
        {
            speed = rb.velocity.x;
            if (Input.GetKeyDown(KeyCode.LeftControl) && Mathf.Abs(speed) > 0)
            {
                animator.SetBool("Correr", true);
                maxSpeed = 6.5f;
            }

            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("Correr", false);
                maxSpeed = 4f;
            }

        }
        void Agacharse()
        {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            {

                animator.SetBool("Agacharse", true);
            }


        else if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                animator.SetBool("Agacharse", false);
            }

        }

        void Rodar()
            {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            animator.SetBool("Rodar", true);
        }


        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Rodar", false);
        }
    }

    
}
