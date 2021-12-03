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

    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        maxSpeed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        {
            desplX = Input.GetAxis("Horizontal");

            Girar();
        }

    }
        private void FixedUpdate()
        {
            if (alive)
            {
                Caminar();
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
            animator.SetFloat("SpeedX", speed);
            print(speed);
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
 
}
