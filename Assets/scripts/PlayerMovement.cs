using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float velocity = 5.0f;
    public float roatVelocity = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float jumpForce = 8f;
    public bool canJump;

    public float gravity = 2;


    //NEW
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();
        Physics.gravity *= gravity;

    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * roatVelocity, 0);

        // Si el jugador está retrocediendo, reduce su velocidad
        float adjustedVelocity = (y < 0) ? velocity * 0.5f : velocity;

        transform.Translate(0, 0, y * Time.deltaTime * adjustedVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        if (canJump && !isJumping)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                anim.SetBool("jump", true);
                anim.SetBool("jumping", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isJumping = true;
                FindObjectOfType<JumpLogic>().OnJump();

            }
            //anim.SetBool("inFloor", true);

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
        if (FindObjectOfType<JumpLogic>().CanChangeState()) // Verifica si se puede cambiar de estado
        {
            anim.SetBool("inFloor", true);
            anim.SetBool("jumping", false);
            isJumping = false; // Marca que la animación de salto ha terminado
            canJump = true;
        }

    }
}
