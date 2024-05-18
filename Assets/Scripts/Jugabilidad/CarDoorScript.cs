using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDoorScript : MonoBehaviour
{
    public Transform door;
    public float doorSpeed = 1f;
    public bool isUnlocked = true;
    public bool permanentlyOpen = false; // Nueva variable
    public Transform openTransform;
    public Transform closeTransfom;
    Vector3 targetPosition;
    float time;


    void Start()
    {
        targetPosition = closeTransfom.position;
    }

    void Update()
    {
        if (isUnlocked && door.position != targetPosition)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, time);
            time += Time.deltaTime * doorSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isUnlocked)
        {
            targetPosition = openTransform.position;
            time = 0;
            if (permanentlyOpen)
            {
                isUnlocked = false; // Bloquea la puerta en su posición abierta permanentemente
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isUnlocked && !permanentlyOpen)
        {
            targetPosition = closeTransfom.position;
            time = 0;
        }
    }
}
