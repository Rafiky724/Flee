using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLogic : MonoBehaviour
{

    public PlayerMovement playerMove;
    private float lastJumpTime; // Para almacenar el tiempo del último salto

    // Tiempo mínimo antes de cambiar de estado después de que la animación haya terminado
    public float minTimeBeforeChangeState = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        lastJumpTime = -minTimeBeforeChangeState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //playerMove.canJump = true;
        playerMove.changeState();
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.canJump = false;
    }

    public void OnJump()
    {
        lastJumpTime = Time.time; // Actualiza el tiempo del último salto
    }

    public bool CanChangeState()
    {
        return Time.time - lastJumpTime >= minTimeBeforeChangeState; // Comprueba si ha pasado suficiente tiempo desde el último salto
    }

}
