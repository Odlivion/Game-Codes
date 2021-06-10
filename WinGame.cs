using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    // Voittopaneli
    public GameObject winPanel;

    // Pause
    public static bool gameIsPaused;

    private void Update()
    {
        //ESCillä pääsee päävalikkoon
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pysäytetään kaikki musa
            AudioManager.instance.StopAll();
            // Peli käynnistyy
            Time.timeScale = 1;

            // Aloitetaan uusi Peli
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pysäytetään musat
        AudioManager.instance.StopAll();

        // Soitetaan loppufanfaari
        // AudioManager.instance.Play("Gamewin");

        // Näytetään pelihahmo 2 voittopaneli
        winPanel.SetActive(true);

        // Pysäytetään peli
        gameIsPaused = !gameIsPaused;
        PauseGame();

    }

    /// <summary>
    /// Tämä metodi pysäyttää pelin ja käynnistää pelin tarvittaessa
    /// </summary>

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
