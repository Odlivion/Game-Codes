﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Käynnistettävän Scenen nimi (Eka taso)
    public string startLevel;

    public void NewGame()
    {
        // Jos AudioManager on olemassa, niin soita taustamusa, muussa tapauksessa älä tee mitää
        if (AudioManager.instance != null) AudioManager.instance.Play("Background");

        // Aloitetaan uusi peli
        SceneManager.LoadScene(startLevel);
    }

    public void QuitGame()
    {
        // Lopettaa pelin
        Application.Quit();
    }
}
