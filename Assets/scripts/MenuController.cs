using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Iniciar()
    {

        SceneManager.LoadScene("Tutorial");

    }

    public void Creditos()
    {

        SceneManager.LoadScene("Creditos");

    }

    public void Salir()
    {

        Application.Quit();

    }

}
