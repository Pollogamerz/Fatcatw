using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataqueabuela : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemigo"))
        {
            Debug.Log("Jugador da�ado por el enemigo");
        }
    }
}
