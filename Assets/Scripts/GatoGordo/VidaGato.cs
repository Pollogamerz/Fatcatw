using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaGato : MonoBehaviour
{
    public float vida = 100;
    public Image barraDevida;
    public GameObject gameOverPanel;
    public Button respawnButton;

    private Vector3 initialPosition;

    void Start()
    {
        // Guarda la posici�n inicial del personaje
        initialPosition = transform.position;

        // Aseg�rate de que el panel de "Game Over" est� desactivado
        gameOverPanel.SetActive(false);

        // A�ade un listener al bot�n de "Reaparecer"
        respawnButton.onClick.AddListener(Respawn);
    }

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        barraDevida.fillAmount = vida / 100;

        if (vida <= 0)
        {
            ShowGameOverPanel();
        }
    }

    void ShowGameOverPanel()
    {
        // Muestra el panel de "Game Over"
        gameOverPanel.SetActive(true);
    }

    void Respawn()
    {
        // Restaura la vida
        vida = 100;

        // Oculta el panel de "Game Over"
        gameOverPanel.SetActive(false);

        // Restaura la posici�n inicial del personaje
        transform.position = initialPosition;
    }
}