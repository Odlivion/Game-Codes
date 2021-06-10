using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeys : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    /// <summary>
    /// Jos pelihahmo törmäsi avaimeen, kasvatetaan laskuria ja tuhotaan avain lopuksi.
    /// ScoreManager huolehtii pisteiden kasvattamisesta
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.AddKey();
            Destroy(gameObject);
        }
    }
}