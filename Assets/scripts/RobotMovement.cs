using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

        ani = GetComponent<Animator>();
        //target = GameObject.Find("Player");

    }

    public void ComportamientoEnemigo()
    {
        //Debug.Log(target);


        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 3)
            {

                rutina = Random.Range(0, 3);
                cronometro = 0;

            }
            switch (rutina)
            {

                case 0:
                    ani.SetBool("walk", false);
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
                    ani.SetBool("walk", true);
                    break;

            }

        }
        else
        {

            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            ani.SetBool("walk", false);

            ani.SetBool("run", true);
            transform.Translate(Vector3.forward * 6 * Time.deltaTime);

        }



    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }
}
