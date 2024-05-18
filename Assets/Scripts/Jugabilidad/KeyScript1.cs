using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript1 : MonoBehaviour
{
    public CarDoorScript CarToMove;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CarToMove.isUnlocked = true;
        }

        Destroy(gameObject);
    }

}