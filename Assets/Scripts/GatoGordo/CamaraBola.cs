using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBola : MonoBehaviour
{
    public GameObject GatoBola;
    public GameObject Referencia;
    public Vector3 distancia;
    void Start()
    {
        distancia = transform.position - GatoBola.transform.position;
    }

    void LateUpdate()
    {
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
        transform.position = GatoBola.transform.position + distancia;
        transform.LookAt(GatoBola.transform.position);

        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        Referencia.transform.eulerAngles = copiaRotacion;
    }
}
