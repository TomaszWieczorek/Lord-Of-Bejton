using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptTutorial : MonoBehaviour
{
    public void Tutorial(Text textRuch, Image tloTextRuch)
    {
        if (Gracz.tutorialKroki == 0)
        {
            tloTextRuch.enabled = true;
            textRuch.text = "Witaj w grze Lord of Bejton! Przeprowadzę Cię teraz przez tutorial!\nAby poruszyć się w przód wciśnij W...";
            Gracz.tutorialKroki = 1;
        }
        if (Input.GetKeyUp(KeyCode.W) && Gracz.tutorialKroki == 1)
        {
            textRuch.text = "Aby poruszyć się w tył wciśnij S...";
            Gracz.tutorialKroki = 2;
        }
        if (Input.GetKeyUp(KeyCode.S) && Gracz.tutorialKroki == 2)
        {
            textRuch.text = "Aby poruszyć się w lewo wciśnij A...";
            Gracz.tutorialKroki = 3;
        }
        if (Input.GetKeyUp(KeyCode.A) && Gracz.tutorialKroki == 3)
        {
            textRuch.text = "Aby poruszyć się w prawo wciśnij D...";
            Gracz.tutorialKroki = 4;
        }
        if (Input.GetKeyUp(KeyCode.D) && Gracz.tutorialKroki == 4)
        {
            textRuch.text = "Aby podskoczyć wciśnij SPACJA...";
            Gracz.tutorialKroki = 5;
        }
        if (Input.GetKeyUp(KeyCode.Space) && Gracz.tutorialKroki == 5)
        {
            textRuch.text = "Aby biec sprintem przytrzymaj LEWY SHIFT oraz klawisz kierunku...";
            Gracz.tutorialKroki = 6;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && Gracz.tutorialKroki == 6)
        {
            Gracz.iloscStrzal = 10;
            textRuch.text = "Na poczatek gry dostaniesz " + Gracz.iloscStrzal + " strzał. Aby strzelić kliknij lewy klawisz myszy...";
            Gracz.tutorialKroki = 7;
        }
        if (Input.GetMouseButtonDown(0) && Gracz.tutorialKroki == 7 && Gracz.iloscStrzal > 1)
        {
            textRuch.text = "Posiadasz jeszcze " + (Gracz.iloscStrzal-1) + " strzał. Aby strzelić kliknij lewy klawisz myszy...";
        }
        if (Input.GetMouseButtonDown(0) && Gracz.tutorialKroki == 7 && Gracz.iloscStrzal == 1)
        {
            textRuch.text = "Myśle że już wiesz jak to działa. Przed Tobą leży strzała, aby ją zebrać kliknij E będąc w jej zasięgu...";
            Gracz.tutorialKroki = 8;
        }
        if (Input.GetKeyDown(KeyCode.E) && Gracz.tutorialKroki == 8)
        {
            textRuch.text = "Medyk Cię szuka. Aby dostać się do niego popatrz na znak! Życzymy przyjemnej gry!";
            Gracz.tutorialKroki = 9;
        }
        if (Input.GetKeyDown(KeyCode.W) && Gracz.tutorialKroki == 9)
        {
            Gracz.firstGame = false;
        }
    }
}
