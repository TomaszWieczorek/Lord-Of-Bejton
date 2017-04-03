using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptWejscieNaPole : MonoBehaviour {

    public Text tekstAI;
    public Image tloTekstAI;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Gracz.misjaKwiatyZaakceptowana && !Gracz.misjaKwiatyUdana )
        {
            tloTekstAI.enabled = true;
            tekstAI.text = "Aby zebrać kwiatka kliknij E";
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            tloTekstAI.enabled = false;
            tekstAI.text = "";
        }
    }
}
