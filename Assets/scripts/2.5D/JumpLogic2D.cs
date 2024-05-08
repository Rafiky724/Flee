using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLogic2D : MonoBehaviour
{
    public PlayerMove2D playerMove;
    private float lastJumpTime; // Para almacenar el tiempo del �ltimo salto

    // Tiempo m�nimo antes de cambiar de estado despu�s de que la animaci�n haya terminado
    public float minTimeBeforeChangeState = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        lastJumpTime = -minTimeBeforeChangeState; // Inicializar el �ltimo tiempo de salto para asegurarse de que la primera animaci�n de salto cambie el estado inmediatamente
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
        lastJumpTime = Time.time; // Actualiza el tiempo del �ltimo salto
    }

    public bool CanChangeState()
    {
        return Time.time - lastJumpTime >= minTimeBeforeChangeState; // Comprueba si ha pasado suficiente tiempo desde el �ltimo salto
    }


}
