using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptKowal : MonoBehaviour {

    public Text tekstAI;
    public Image tloTekstAI;
    public Text misjaIlosc;
    public Image tlomisjaIlosc;
    public Text misjaTresc;
    public Image tlomisjaTresc;
    private int rozmowaMisjaDrzewo = 0;
    private bool zasieg = false;
    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.F) && (rozmowaMisjaDrzewo == 0 || rozmowaMisjaDrzewo == 1 || rozmowaMisjaDrzewo == 2)  && (Gracz.misjaKwiatyUdana || !Gracz.misjaKwiatyUdana))
        {
            //pierwsza rozmowa
            if (!Gracz.misjaDrzewoUdana && !Gracz.misjaDrzewoZaakceptowana && !Gracz.czyPosiadaMisje && Gracz.misjaKwiatyUdana)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "O nie! W piecu temperatura spada! Potrzebuję jak najszybciej drzewa! Proszę przynieś mi 10 klocków drewna!\nPotwierdz(e)";
                rozmowaMisjaDrzewo = 0;
            }
            //misja wykonana
            else if (Gracz.misjaDrzewoUdana && rozmowaMisjaDrzewo == 1 && Gracz.misjaKwiatyUdana)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "W ostatniej chwili, bo prawie juz zgasło! Wielkie dzięki! W nagrodę otrzymujesz ode mnie 25 strzał! Pytała o Ciebie pewna dziewczyna, możesz ją znaleźć na Zielonych Polach. Idź do teleportu!.";
                tlomisjaTresc.enabled = false;
                misjaTresc.text = "";
                tlomisjaIlosc.enabled = false;
                misjaIlosc.text = "";
                Gracz.czyPosiadaMisje = false;
                Gracz.iloscStrzal += 25;
                rozmowaMisjaDrzewo = 2;
                zasieg = false;
            }
            //misja w trakcie
            else if (Gracz.misjaDrzewoZaakceptowana && !Gracz.misjaDrzewoUdana && rozmowaMisjaDrzewo == 1 && Gracz.misjaKwiatyUdana)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Przynieś mi wszystkie klocki! Pośpiesz się!";
            }
            else if (!Gracz.czyPosiadaMisje && !Gracz.misjaKwiatyUdana)
                tekstAI.text = "Medyk Cię szukał. Idź do niego!";
            else if (!Gracz.czyPosiadaMisje && Gracz.misjaKwiatyUdana && Gracz.misjaDrzewoUdana && zasieg)
            {
                tekstAI.text = "Dziewczyna Cię szukała! Znajdziesz ją na Zielonych Polach!";
                zasieg = false;
            }
            else if (Gracz.misjaKwiatyZaakceptowana && (!Gracz.misjaKwiatyUdana || Gracz.misjaKwiatyUdana) && !Gracz.misjaDrzewoUdana)
                tekstAI.text = "Aktulanie posiadasz inną misję. Przyjdź jak zakończysz tamtą!";
        }
        //potwierdzenie przyjecia misji
        if (Input.GetKeyDown(KeyCode.E) && rozmowaMisjaDrzewo == 0 && !Gracz.czyPosiadaMisje && !Gracz.misjaDrzewoZaakceptowana && Gracz.misjaKwiatyUdana)
        {
            rozmowaMisjaDrzewo = 1;
            tekstAI.text = "";
            tloTekstAI.enabled = false;
            Gracz.misjaDrzewoZaakceptowana = true;
            Gracz.czyPosiadaMisje = true;
            tlomisjaTresc.enabled = true;
            misjaTresc.text = "Klocki:";
            tlomisjaIlosc.enabled = true;
            misjaIlosc.text = Gracz.misjaDrzewoIlosc.ToString();
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
        if(col.tag == "Player")
        {
            tloTekstAI.enabled = true;
            tekstAI.text = "Aby rozpocząć rozmowę wciśnij F";
            zasieg = true;
        }
    }
}
