using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptMedyk : MonoBehaviour {

    public Text tekstAI;
    public Image tloTekstAI;
    public Text misjaIlosc;
    public Image tlomisjaIlosc;
    public Text misjaTresc;
    public Image tlomisjaTresc;
    public Text textRuch;
    public Image tloTextRuch;
    private int rozmowaMisjaKwiatki = 0;
    private bool zasieg = false;
    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.F) && (rozmowaMisjaKwiatki == 0 || rozmowaMisjaKwiatki == 1 || rozmowaMisjaKwiatki == 2) && !Gracz.firstGame)
        {
            //pierwsza rozmowa
            if (!Gracz.misjaKwiatyUdana && !Gracz.misjaKwiatyZaakceptowana && !Gracz.czyPosiadaMisje)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Pierwsza misja! Potrzebuję kilku kwiatów lilii aby stworzyć miksturę dla króla. Proszę przynieś mi ich 10. Możesz je znaleźć obok zamku w polu kukurydzy!\nPotwierdź(e)";
                rozmowaMisjaKwiatki = 0;
            }
            else if (Gracz.misjaKwiatyUdana && rozmowaMisjaKwiatki == 1)//misja wykonana
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Brawo! Misja wykonana! Dziekuje bardzo za kwiatki! W nagrodę otrzymujesz ode mnie 25 strzał! Słyszałem że Kowal potrzebuje pomocy. Możesz go znaleźć w zamku.";
                tlomisjaTresc.enabled = false;
                misjaTresc.text = "";
                tlomisjaIlosc.enabled = false;
                misjaIlosc.text = "";
                rozmowaMisjaKwiatki = 2;
                Gracz.czyPosiadaMisje = false;
                Gracz.iloscStrzal += 25;
                zasieg = false;
            }//misja w trakcie
            else if (!Gracz.czyPosiadaMisje && Gracz.misjaKwiatyUdana && rozmowaMisjaKwiatki == 2 && zasieg)
            {
                tekstAI.text = "Kowal Cię szukał! Znajdziesz go w zamku!";
                tloTekstAI.enabled = true;
                zasieg = false;
            }
            else if (Gracz.misjaKwiatyZaakceptowana && !Gracz.misjaKwiatyUdana && rozmowaMisjaKwiatki == 1)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Przynieś mi wszystkie kwiatki. Znajdują się na polu kukurydzy";
            }
            else if (Gracz.firstGame)
            {
                tekstAI.text = "Najpierw ukończ tutorial!";
                tloTekstAI.enabled = true;
            }
        }
        //potwierdzenie przyjecia misji
        if (Input.GetKeyDown(KeyCode.E) && rozmowaMisjaKwiatki == 0 && !Gracz.czyPosiadaMisje && !Gracz.misjaKwiatyZaakceptowana)
        {
            rozmowaMisjaKwiatki = 1;
            tekstAI.text = "";
            tloTekstAI.enabled = false;
            Gracz.misjaKwiatyZaakceptowana = true;
            Gracz.czyPosiadaMisje = true;
            tlomisjaTresc.enabled = true;
            misjaTresc.text = "Kwiatki:";
            tlomisjaIlosc.enabled = true;
            misjaIlosc.text = Gracz.misjaKwiatyIlosc.ToString();
        }
    }
    void OnTriggerExit(Collider col)
    {
        tekstAI.text = "";
        tloTekstAI.enabled = false;
        zasieg = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (!Gracz.firstGame)
            {
                tloTextRuch.enabled = false;
                textRuch.text = "";
            }
            if (!Gracz.misjaDrzewoZaakceptowana)
            {
                tekstAI.text = "Aby rozpocząć rozmowę wciśnij F";
                tloTekstAI.enabled = true;
            }
            zasieg = true;
        }
    }
}
