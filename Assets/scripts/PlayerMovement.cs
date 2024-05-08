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

    public bool aux;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * roatVelocity, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocity);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        Debug.Log(canJump);

        if (canJump)
        {

            Debug.Log("asds");

            if (Input.GetKeyDown(KeyCode.Space))
            {

                anim.SetBool("jump", true);
                anim.SetBool("jumping", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

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

        anim.SetBool("inFloor", true);
        anim.SetBool("jumping", false);

    }
}
