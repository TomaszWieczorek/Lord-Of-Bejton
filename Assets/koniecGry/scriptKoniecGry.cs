using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class scriptKoniecGry : MonoBehaviour {

    public Canvas canvasMenu;
    public Canvas canvasKoniec;
    public Canvas milosne;
    public Canvas normalne;
    public Text koniecGry;
    public Text koniecGryNaglowek;
    public AudioSource happyEnd;
    public AudioSource normalEnd;

    void Start ()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //odpowiednie tlo w zaleznosci ktore wybrał gracz
        if (Gracz.happyEnd)
        {
            milosne.enabled = true;
            normalne.enabled = false;
            koniecGryNaglowek.color = Color.white;
            koniecGry.color = Color.white;
            koniecGry.text = "Kolacja przebiegła bardzo korzystnie, oboje przypadli sobie do gustu, czego efektem po kilku miesiącach był ślub Lorda z Lisą. Nasi bohaterowie żyli długo i szczęśliwie i mieli gromadkę dzieci! \n";
            koniecGryNaglowek.text = "THE HAPPY END";
            happyEnd.Play();
        }
        else
        {
            normalne.enabled = true;
            milosne.enabled = false;
            koniecGryNaglowek.color = Color.black;
            koniecGry.color = Color.white;
            koniecGry.text = "Lord odmówił kolacji, a Lisa niestety została zabita przez złodzieji. Lord wmówił sobie, że to jego wina. Jego honor nie mógł ponieść takiej porażki, więc niestety popełnił samobójstwo kilka dni później...";
            koniecGryNaglowek.text = "THE END";
            normalEnd.Play();
        }
        canvasKoniec.enabled = false;
	}
    public void btnExit_Click()
    {
        canvasKoniec.enabled = true;
        canvasMenu.enabled = false;
    }
    public void btnExitTak()
    {
        Application.Quit();
    }
    public void btnExitMenu()
    {
        SceneManager.LoadScene("menu/menu");
        //reset zmiennych
        Gracz.playerHP = 100;
        Gracz.playerNick = "Player";
        Gracz.firstGame = true;
        Gracz.tutorialKroki = 0;
        Gracz.czyPosiadaMisje = false;
        Gracz.misjaKwiatyIlosc = 0;
        Gracz.misjaKwiatyZaakceptowana = false;
        Gracz.misjaKwiatyUdana = false;
        Gracz.misjaDrzewoIlosc = 0;
        Gracz.misjaDrzewoZaakceptowana = false;
        Gracz.misjaDrzewoUdana = false;
        Gracz.misjaDziewczynaIlosc = 0;
        Gracz.misjaDziewczynaZaakceptowana = false;
        Gracz.misjaDziewczynaUdana = false;
        Gracz.zebranaStrzala = false;
        Gracz.iloscStrzal = 0;
        Gracz.happyEnd = false;
    }
}
