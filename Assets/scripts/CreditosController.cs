using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReturnToMainScene", 30f);
    }


    public void ReturnToMainScene()
    {

        SceneManager.LoadScene("Menu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
