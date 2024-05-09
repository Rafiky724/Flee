using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private Vector3 spawn;

    //Portales
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;

    private bool inZone = false;

    //NEW
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();
        Physics.gravity *= gravity;

        if (GameController.Instance.portal1Complete)
        {
            Destroy(portal1);
        }
        if (GameController.Instance.portal2Complete)
        {
            Destroy(portal2);
        }
        if (GameController.Instance.portal3Complete)
        {
            Destroy(portal3);
        }
        if (GameController.Instance.portal4Complete)
        {
            Destroy(portal4);
        }

        if (GameController.Instance.portalActual == "Portal1")
        {

            spawn = new Vector3(-156.6f, 0.12f, 59f);

        }
        if (GameController.Instance.portalActual == "Portal2")
        {

            spawn = new Vector3(70.6f, 0.12f, 75.5f);

        }
        if (GameController.Instance.portalActual == "Portal3")
        {

            spawn = new Vector3(-6.5f, 0.12f, -131f);

        }
        if (GameController.Instance.portalActual == "Portal4")
        {

            spawn = new Vector3(-25.5f, 0.12f, 106f);

        }
        if (GameController.Instance.portalActual == "Inicio")
        {

            spawn = new Vector3(153f, 0.12f, -30f);

        }

        transform.position = spawn;

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

        if (inZone && Input.GetKeyDown(KeyCode.F) && GameController.Instance.llevaPila)
        {

            GameController.Instance.llevaPila = false;
            GameController.Instance.pilasPuestas += 1;

        }

        if (GameController.Instance.pilasPuestas == 4)
        {

            SceneManager.LoadScene("Creditos");

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

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Portal1") || other.CompareTag("Portal2") || other.CompareTag("Portal3") || other.CompareTag("Portal4")) && !GameController.Instance.llevaPila)
        {
            GameController.Instance.portalActual = other.tag;
            GameController.Instance.LoadScene(other.tag);

        }

        if (other.CompareTag("ZonaCarro"))
        {

            inZone = true;

        }

        if (other.CompareTag("Robot"))
        {

            anim.SetBool("death", true);
            Invoke("Restart", 4f);

        }

    }

    public void Restart()
    {

        SceneManager.LoadScene("inGame");

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("ZonaCarro"))
        {

            inZone = false;

        }

    }

}
