using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaGato : MonoBehaviour
{
    public float vida = 100;
    public Image barraDevida;

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        barraDevida.fillAmount = vida / 100;
    }
}
