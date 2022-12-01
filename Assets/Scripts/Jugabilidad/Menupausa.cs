using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour
{
    public GameObject menuDePausa;
    private bool menuOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           menuOn = !menuOn;
        }

        if (menuOn==true)
        {
            menuDePausa.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            menuDesactivado();
        }
    }

    public void Continuar()
    {
        menuDesactivado();
        menuOn = false;
    }

    public void volveralinicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    private void menuDesactivado()
    {
        menuDePausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
