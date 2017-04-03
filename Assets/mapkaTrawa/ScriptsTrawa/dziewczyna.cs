using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dziewczyna : MonoBehaviour
{

    public Text tekstAI;
    public Image tloTekstAI;
    public Text misjaIlosc;
    public Image tlomisjaIlosc;
    public Text misjaTresc;
    public Image tlomisjaTresc;
    private int rozmowaMisjaDziewczyna = 0;
    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.F) && (rozmowaMisjaDziewczyna == 0 || rozmowaMisjaDziewczyna == 1 || rozmowaMisjaDziewczyna == 2))
        {
            //pierwsza rozmowa
            if (!Gracz.misjaDziewczynaUdana && !Gracz.misjaDziewczynaZaakceptowana && !Gracz.czyPosiadaMisje)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Pomocy! Wśród drzew kręcą się złodzieje i chcą mnie okraść! Nie jestem pewna, ale chyba było ich 10! Zabij ich, a otrzymasz nagrodę! Ale uważaj na siebie, bo mają broń!\nMasz tu 10 potionów, aby się uleczyć wciśnij H. Potwierdź(e)";
                rozmowaMisjaDziewczyna = 0;
            }
            else if (Gracz.misjaDziewczynaIlosc == 10 && rozmowaMisjaDziewczyna == 1)//misja wykonana
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Dziękuję! Jesteś moim wybawcą!\nNazywam się Lisa. Chciałąbym odwdzieczyć Ci się jakoś, masz ochotę na kolację? \n Mam ochotę!(T)        Nie mam ochoty!(N)";
                tlomisjaTresc.enabled = false;
                misjaTresc.text = "";
                tlomisjaIlosc.enabled = false;
                misjaIlosc.text = "";
                rozmowaMisjaDziewczyna = 2;
                Gracz.misjaDziewczynaUdana = true;
                Gracz.czyPosiadaMisje = false;
                Gracz.iloscStrzal += 25;
            }//misja w trakcie
            else if (Gracz.misjaDziewczynaZaakceptowana && !Gracz.misjaDziewczynaUdana && rozmowaMisjaDziewczyna == 1)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Zabij wszystkich złodzieji";
            }
        }
        //potwierdzenie przyjecia misji
        if (Input.GetKeyDown(KeyCode.E) && rozmowaMisjaDziewczyna == 0 && !Gracz.czyPosiadaMisje && !Gracz.misjaDziewczynaZaakceptowana)
        {
            rozmowaMisjaDziewczyna = 1;
            tekstAI.text = "";
            tloTekstAI.enabled = false;
            Gracz.misjaDziewczynaZaakceptowana = true;
            Gracz.czyPosiadaMisje = true;
            Gracz.iloscPotionow = 10;
            tlomisjaTresc.enabled = true;
            misjaTresc.text = "Złodzieje:";
            tlomisjaIlosc.enabled = true;
            misjaIlosc.text = Gracz.misjaDziewczynaIlosc.ToString();
        }
        //koniec gry z happy end
        if(rozmowaMisjaDziewczyna==2 && Input.GetKeyDown(KeyCode.T) && Gracz.misjaDziewczynaUdana)
        {
            Gracz.happyEnd = true;
            SceneManager.LoadScene("koniecGry/koniec");
        }
        //koniec gry
        if (rozmowaMisjaDziewczyna == 2 && Input.GetKeyDown(KeyCode.N) && Gracz.misjaDziewczynaUdana)
        {
            Gracz.happyEnd = false;
            SceneManager.LoadScene("koniecGry/koniec");
        }
    }
    void OnTriggerExit(Collider col)
    {
        tekstAI.text = "";
        tloTekstAI.enabled = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
                tekstAI.text = "Aby rozpocząć rozmowę wciśnij F";
                tloTekstAI.enabled = true;
        }
    }
}
