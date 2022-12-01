using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelaScript : MonoBehaviour
{
    public GameObject GatoBola;
    public int rutine;
    public float chronometer;
    public Quaternion angle;
    public float grade;

    void Start()
    {
        GatoBola = GameObject.Find("Player");
    }

    void Update()
    {
        Enemie_Behavior();
    }

    public void Enemie_Behavior()
    {
        if (Vector3.Distance(transform.position, GatoBola.transform.position) > 2)
        {
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                rutine = Random.Range(0, 2);
                chronometer = 0;
            }

            switch (rutine)
            {
                case 0:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    rutine++;
                    break;

                case 1:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;
            }
        }

        else
        {
            var lookPos = GatoBola.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
    }
}
