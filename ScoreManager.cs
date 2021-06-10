using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Reseptipalojen lukumäärä
    private int KeyAmount;

    // Canavaksessa oleva tekstilaatikko, joka näyttää kerätyt avaimet
    [SerializeField]
    private Text KeyCounterText;

    // Oven suojacollideri
    public GameObject RightWallProtection;

    // pelin loppucolliderin suoja
    //public GameObject RightWall;

    private void Awake()
    {
        // Nollataan avainten laskuri pelin alussa
        KeyAmount = 0;
    }

    private void Update()
    {
        // Tulostetaan kerättyjen reseptipalojen lukumäärä konsoliin
        KeyCounterText.text = KeyAmount.ToString() + " / 6";

        // Tutkitaan onko avaimia kerätty tarpeeksi
        if (KeyAmount == 6)
        {
            // Poistetaan suojan collaideri
            RightWallProtection.SetActive(false);
        }
    }
    /// <summary>
    /// Metodi kasvattaa avain laskuria yhdellä
    /// </summary>

    public void AddKey()
    {
        KeyAmount++;
    }
}

