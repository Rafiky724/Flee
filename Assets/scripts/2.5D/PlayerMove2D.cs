using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    public float velocity = 5.0f;
    public float roatVelocity = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float jumpForce = 8f;
    public bool canJump;
    public float gravity = 2;

    // Para controlar si la animación de salto está en curso
    public bool isJumping;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();
        Physics.gravity *= gravity;

    }

    void FixedUpdate()
    {
        // Ajustamos la dirección del movimiento en función de la orientación del personaje
        float adjustedVelocity = facingRight ? velocity : -velocity;
        transform.Translate(0, 0, x * Time.deltaTime * adjustedVelocity);
    }

    // Update is called once per frame
    public void Update()
    {
        x = Input.GetAxis("Horizontal");

        if (x > 0 && !facingRight)
        {
            Flip();
        }
        else if (x < 0 && facingRight)
        {
            Flip();
        }

        anim.SetFloat("velY", x);

        if (canJump && !isJumping) // Solo permite saltar si no está saltando ya
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("jump", true);
                anim.SetBool("jumping", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isJumping = true; // Marca que la animación de salto está en curso
                FindObjectOfType<JumpLogic2D>().OnJump(); // Llama a la función OnJump() en JumpLogic2D
            }
        }
        else
        {
            isFalling();
        }
    }

    public void isFalling()
    {
        anim.SetBool("inFloor", false);
        anim.SetBool("jump", false);
    }

    public void changeState()
    {
        if (FindObjectOfType<JumpLogic2D>().CanChangeState()) // Verifica si se puede cambiar de estado
        {
            anim.SetBool("inFloor", true);
            anim.SetBool("jumping", false);
            isJumping = false; // Marca que la animación de salto ha terminado
            canJump = true;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
