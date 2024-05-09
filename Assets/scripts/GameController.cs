using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    public bool portal1Complete = false;
    public bool portal2Complete = false;
    public bool portal3Complete = false;
    public bool portal4Complete = false;

    public string portalActual = "Inicio";

    public bool llevaPila = false;
    public int pilasPuestas = 0;

    public int nivel = 0;

    private void Awake()
    {
        if (GameController.Instance == null)
        {

            GameController.Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       

    }

    public void LoadScene(string nombrePortal)
    {

        if (nombrePortal == "Portal1")
        {
            portal1Complete = true;
            nivel += 1;
            SceneManager.LoadScene(nivel);
        }
        if (nombrePortal == "Portal2")
        {
            portal2Complete = true;
            nivel += 1;
            SceneManager.LoadScene(nivel);
        }
        if (nombrePortal == "Portal3")
        {
            portal3Complete = true;
            nivel += 1;
            SceneManager.LoadScene(nivel);
        }
        if (nombrePortal == "Portal4")
        {
            portal4Complete = true;
            nivel += 1;
            SceneManager.LoadScene(nivel);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("inGame");

    }

    public void ReturnToMainSceneAfterDelay()
    {
        Invoke("ReturnToMainScene", 1.5f);
    }

}
