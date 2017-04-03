using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptKwiatZolty : MonoBehaviour {

    public Text tekstAI;
    public Image tloTekstAI;
    public Text misjaIlosc;
    private bool czyZasieg;
	void Update () {
        //jesli misja zaakceptowana i gracz znajduje sie w zasiegu to kwiat jest zniszczony  
	     if (Input.GetKeyDown(KeyCode.E) && Gracz.misjaKwiatyZaakceptowana && czyZasieg)
        {
            Destroy(this.gameObject);
            Gracz.misjaKwiatyIlosc += 1; //ilosc kwiatow powiekszona
            czyZasieg = false; //aby nei zebrac kilku naraz jednym klawiszem
            misjaIlosc.text = Gracz.misjaKwiatyIlosc.ToString();
            if (Gracz.misjaKwiatyIlosc == 10) //
            {
                Gracz.misjaKwiatyUdana = true;
                tloTekstAI.enabled = true;
                tekstAI.text = "Brawo! Zebrałeś wzystkie potrzebne kwiatki! Zanieś je teraz do medyka";
            }
        }
	}
    void OnTriggerEnter(Collider col)
    {
        czyZasieg = true;
    }
    void OnTriggerExit(Collider col)
    {
        tekstAI.text = "";
        tloTekstAI.enabled = false;
        czyZasieg = false;
    }
}
