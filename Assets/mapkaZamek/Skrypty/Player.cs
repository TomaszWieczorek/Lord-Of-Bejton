using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasExit;
    public Canvas canvasOptions;
    public Canvas canvasAutors;
    public Canvas canvasNowaGra;
    public Canvas canvasSterowanie;
    public AudioSource dzwiekMenu;
    public AudioSource strzalaLeci;
    public AudioSource dzwiekMiasto;
    public Text playerHp;
    public Text tekstAI;
    public Text iloscStrzal;
    public Text misjaIlosc;
    public Image tloTekstAI;
    public GameObject strzala;
    public Transform strzalaMiejsce;
    public int sila;
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
        //wysweitlanie menu
        if ((Input.GetKeyDown(keyMenu) || Input.GetKeyDown(KeyCode.Escape)) && !scriptMenuWgrze.widoczneMenu && !Gracz.czyBierzeUdzialWTurnieju && Gracz.czyWyswietlacMenu)
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
            if(Gracz.soundMenu)dzwiekMenu.Play();
            dzwiekMiasto.Pause();
            Time.timeScale = 0.0f;
        }
        else if ((Input.GetKeyDown(keyMenu) || Input.GetKeyDown(KeyCode.Escape)) && scriptMenuWgrze.widoczneMenu && !Gracz.czyBierzeUdzialWTurnieju)
        {
            canvasMenu.enabled = false;
            canvasExit.enabled = false;
            canvasOptions.enabled = false;
            canvasAutors.enabled = false;
            canvasNowaGra.enabled = false;
            canvasSterowanie.enabled = false;
            scriptMenuWgrze.widoczneMenu = false;
            dzwiekMenu.Pause();
            if (Gracz.soundMenu) dzwiekMiasto.Play();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
        }
        //strzal z luku
        if (Input.GetMouseButtonDown(0) && !scriptMenuWgrze.widoczneMenu)
        {
            if(Gracz.iloscStrzal>0 && scriptTurniejLuczniczy.iloscStrzalowTurniej>-1)
            Fire();
        }
        //jesli nei beirze udzialu w turnieju to aktual9zuje sie liczba strzal ogolnie
        if (!Gracz.czyBierzeUdzialWTurnieju)
            iloscStrzal.text = Gracz.iloscStrzal.ToString();
        else //jesli bierze to tylko dane o turnieju sie zmieniaja
        {
            misjaIlosc.text = Gracz.iloscPunktowTurnieju.ToString();
            iloscStrzal.text = scriptTurniejLuczniczy.iloscStrzalowTurniej.ToString();
        }
        //aby zbieral po jednej strzale -> scriptStrzalaWbita
        Gracz.zebranaStrzala = false;
    }
    void Fire()
    {
        // tworzymy strzala z prefabu, dodajac pozycje zadeklarowana
        var strzalaKopia = (GameObject)Instantiate(
                strzala,
                strzalaMiejsce.position,
                strzalaMiejsce.rotation);
        // dodajemy ruch do strzaly w przod
        strzalaKopia.GetComponent<Rigidbody>().velocity = strzalaKopia.transform.up * sila;
        //dzwiek strzalu
        strzalaLeci.Play();
        //aktualizujemy ilosc strzal jesli nie bierze udzialu w turnieju
        if(!Gracz.czyBierzeUdzialWTurnieju)
            Gracz.iloscStrzal--;
    }
    void onTriggerExit(Collider col)
    {
        if (col.tag == "medyk" || col.tag == "kwiatZolty" || col.name == "tablicaZasieg" || col.tag == "kowal")
        {
            tekstAI.text = "";
            tloTekstAI.enabled = false;
        }
    }
}