using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Scripting;

public class scriptMiasto : MonoBehaviour {

    public Text PlayerNick;
    public Text iloscStrzal;
    public Text textRuch;
    public Image tloTextRuch;
    public Text playerHP;
    public Image tloTekstAI;
    public Image tlomisjaIlosc;
    public Image tlomisjaTresc;
    public GameObject tutorial;
    public AudioSource musicMiasto;
    scriptTutorial sc;
    void Start () {
        //po wejsciu w mapke ustawia dane gracza
        PlayerNick.text = Gracz.playerNick;
        iloscStrzal.text = Gracz.iloscStrzal.ToString();
        playerHP.text = Gracz.playerHP.ToString();
        tloTextRuch.enabled = false;
        tloTekstAI.enabled = false;
        tlomisjaTresc.enabled = false;
        tlomisjaIlosc.enabled = false;
        //odtwarza muzyke miasta
        if(Gracz.soundMiasto) musicMiasto.Play();
    }
	void Update () {
        //jesli pierwsze uruchomienie to wlacza sie tutorial
        if (Gracz.firstGame)
        {
            sc = tutorial.GetComponent<scriptTutorial>();
            sc.Tutorial(textRuch,tloTextRuch);
        }
    }
}
