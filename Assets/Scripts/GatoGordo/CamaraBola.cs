using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Transporting;

public class CamaraBola : NetworkBehaviour
{
    public GameObject GatoBola;
    public Vector3 distancia;
    public float distanciaMaxima = 5f;
    public float suavizado = 0.1f;

    private Vector3 velocidadSuavizado;

    void Start()
    {
        distancia = transform.position - GatoBola.transform.position;
    }

    void LateUpdate()
    {
        if (base.IsOwner == false)
        {
            distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
        Vector3 nuevaPosicion = GatoBola.transform.position + distancia;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, nuevaPosicion - transform.position, out hit, distanciaMaxima))
        {
            nuevaPosicion = hit.point;
        }

        transform.position = Vector3.SmoothDamp(transform.position, nuevaPosicion, ref velocidadSuavizado, suavizado);

        transform.LookAt(GatoBola.transform.position);
    }

        }
}