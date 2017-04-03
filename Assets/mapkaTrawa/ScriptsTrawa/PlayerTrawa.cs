using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTrawa : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasExit;
    public Canvas canvasOptions;
    public Canvas canvasAutors;
    public Canvas canvasNowaGra;
    public Canvas canvasSterowanie;
    public AudioSource dzwiekMenu;
    public AudioSource dzwiekTrawa;
    public Text playerHp;
    public Text iloscPotionow;
    public Text tekstAI;
    public Text iloscStrzal;
    public Text misjaIlosc;
    public Image tloTekstAI;
    public KeyCode keyMenu = KeyCode.M;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //aktualizuje hp gracza
        playerHp.text = Gracz.playerHP.ToString();
        iloscPotionow.text = Gracz.iloscPotionow.ToString();

        //wysweitlanie menu
        if ((Input.GetKeyDown(keyMenu) || Input.GetKeyDown(KeyCode.Escape)) && !scriptMenuWgrze.widoczneMenu)
        {
            canvasMenu.enabled = true;
            canvasExit.enabled = false;
            canvasOptions.enabled = false;
            canvasAutors.enabled = false;
            canvasNowaGra.enabled = false;
            canvasSterowanie.enabled = false;
            scriptMenuWgrze.widoczneMenu = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Gracz.soundMenu) dzwiekMenu.Play();
            dzwiekTrawa.Pause();
            Time.timeScale = 0.0f;
        }
        else if ((Input.GetKeyDown(keyMenu) || Input.GetKeyDown(KeyCode.Escape)) && scriptMenuWgrze.widoczneMenu)
        {
            canvasMenu.enabled = false;
            canvasExit.enabled = false;
            canvasOptions.enabled = false;
            canvasAutors.enabled = false;
            canvasNowaGra.enabled = false;
            canvasSterowanie.enabled = false;
            scriptMenuWgrze.widoczneMenu = false;
            dzwiekMenu.Pause();
            if (Gracz.soundMenu) dzwiekTrawa.Play();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.H) && Gracz.misjaDziewczynaZaakceptowana && Gracz.iloscPotionow>0)
        {
            Gracz.playerHP += 20;
            if (Gracz.playerHP > 100)
                Gracz.playerHP = 100;
            Gracz.iloscPotionow--;
        }

        iloscStrzal.text = Gracz.iloscStrzal.ToString();
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "dziewczyna")
        {
            tekstAI.text = "";
            tloTekstAI.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "pocisk2")
        {
            Gracz.playerHP = Gracz.playerHP - 10;
            if(Gracz.playerHP==0)
            {
                Gracz.misjaDziewczynaIlosc = 0;
                Gracz.misjaDziewczynaUdana = false;
                Gracz.misjaDziewczynaZaakceptowana = false;
                SceneManager.LoadScene("mapkaTrawa/mapka");
                Gracz.playerHP = 100;
            }
            Destroy(col);
        }
    }
}