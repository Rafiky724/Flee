using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLogic : MonoBehaviour
{

    public PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerMove.canJump = true;
        playerMove.changeState();
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.canJump = false;
    }

}
