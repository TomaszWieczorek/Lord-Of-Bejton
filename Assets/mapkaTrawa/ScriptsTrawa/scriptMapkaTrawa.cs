using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Scripting;


public class scriptMapkaTrawa : MonoBehaviour {

    public Text PlayerNick;
    public Text iloscStrzal;
    public Text playerHP;
    public Image tloTekstAI;
    public Text tekstAI;
    public Image tlomisjaIlosc;
    public Text misjaIlosc;
    public Image tlomisjaTresc;
    public Text misjaTresc;
    public AudioSource musicTrawa;
    public AudioSource musicMenu;

    void Start()
    {
        PlayerNick.text = Gracz.playerNick;
        if (Gracz.iloscStrzal > 50)
        {
            iloscStrzal.text = Gracz.iloscStrzal.ToString();
        }
        else
        {
            Gracz.iloscStrzal = 50;
            iloscStrzal.text = Gracz.iloscStrzal.ToString();
        }
        playerHP.text = Gracz.playerHP.ToString();
        tloTekstAI.enabled = false;
        tlomisjaTresc.enabled = false;
        tlomisjaIlosc.enabled = false;
        tekstAI.text = "";
        misjaTresc.text = "";
        misjaIlosc.text = "";
        if (Gracz.soundMiasto) musicTrawa.Play();
        musicMenu.Pause();
    }
}
