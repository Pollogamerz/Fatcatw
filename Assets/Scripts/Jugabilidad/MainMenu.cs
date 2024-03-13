using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void volveralinicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
