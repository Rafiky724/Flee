using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;
    public float distancia = 20;

    public GameObject target;

    public float moveSpeed = 3f;
    public float rotationSpeed = 1f;

    public float run = 7;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        ComportamientoEnemigo();
    }

    void ComportamientoEnemigo()
    {
            cronometro += Time.deltaTime;

            if (cronometro >= 3)
            {
                rutina = Random.Range(0, 3);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                break;

            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;

            case 2:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;

            case 3:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 1f);
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        
                break;
            }
        
    }
}
