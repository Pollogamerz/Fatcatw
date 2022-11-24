using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capadelJugador;
    public Transform jugador;
    public float velocidad;
    bool estarAlerta;
    void Start()
    {
        
    }

    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capadelJugador);

        if(estarAlerta == true)
        {
            //transform.LookAt(jugador);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
        Gizmos.color = Color.red;
    }

}
