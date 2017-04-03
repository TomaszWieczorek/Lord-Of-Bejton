using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptBelki : MonoBehaviour {

    public Text tekstAI;
    public Image tloTekstAI;
    public Text misjaIlosc;
    private bool czyZasieg;
    void Update()
    {
        //jesli misja zaakceptowana i gracz znajduje sie w zasiegu to kwiat jest zniszczony 
        if (Input.GetKeyDown(KeyCode.E) && Gracz.misjaDrzewoZaakceptowana && czyZasieg)
        {
            Destroy(this.gameObject);
            Gracz.misjaDrzewoIlosc += 1; //ilosc belek powiekszona
            misjaIlosc.text = Gracz.misjaDrzewoIlosc.ToString();
            czyZasieg = false;
            if (Gracz.misjaDrzewoIlosc == 10)
            {
                Gracz.misjaDrzewoUdana = true;
                tloTekstAI.enabled = true;
                tekstAI.text = "Brawo! Zebrałeś wszystkie potrzebne belki! Zanieś je teraz do kowala";
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        tekstAI.text = "";
        tloTekstAI.enabled = false;
        czyZasieg = false;
    }
    void OnTriggerEnter(Collider col)
    {
        czyZasieg = true;
    }
}
