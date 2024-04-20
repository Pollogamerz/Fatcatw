using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] float velocity;
    Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        //Solo controlas el tuyo, este es mi personaje?, si no me salgo, así para que cada quien controle el suyo
        if (base.IsOwner == false)
            return;

        //De manera local para cambiar el color
        if (Input.GetKeyDown(KeyCode.C))
        {
            Color newColor = Random.ColorHSV();
            _renderer.material.color = newColor;
            CambiarColorServidorRPC(newColor);
        }

        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");

        transform.Translate(translation: inputDirection * velocity * Time.deltaTime);
    }

    [ServerRpc] //La función se ejecuta en el lado del servidor
    void CambiarColorServidorRPC(Color _color)
    {
        CambiarColorRPC(_color);
    }

    [ObserversRpc] //La función se ejecuta en todos los clientes
    void CambiarColorRPC(Color _color)
    {
        _renderer.material.color = _color;
    }
}