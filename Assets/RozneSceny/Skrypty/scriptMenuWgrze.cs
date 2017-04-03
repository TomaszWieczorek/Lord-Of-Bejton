using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptMenuWgrze : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasExit;
    public Canvas canvasOptions;
    public Canvas canvasAutors;
    public Canvas canvasNowaGra;
    public Canvas canvasSterowanie;
    public Button btnOptionsSoundYesNo;
    public AudioSource musicMenu;
    public AudioSource musicGra;
    public Sprite zdjecieTak;
    public Sprite zdjecieNie;
    public Slider sliderSound;
    public static bool widoczneMenu = false; //zmienna informujaca czy menu jest widoczne

    void Awake()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
        musicMenu.Stop();
    }
    public void btnExitToMenu_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = true;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnExitToMenuNo_Click()
    {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnExitToMenuYes_Click()
    {
        SceneManager.LoadScene("Menu/menu");
    }
    public void btnContinueGame_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
        widoczneMenu = false;
        musicMenu.Stop();
        if(Gracz.soundMiasto) musicGra.Play();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }
    public void btnBackToMenu_Click()
    {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnNowaGra_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = true;
        canvasSterowanie.enabled = false;
    }
    public void btnNowaGraNo_Click()
    {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnNowaGraYes_Click()
    {
        Debug.Log("Nowa gra");
    }
    public void btnOptions_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = true;
        canvasAutors.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnBackToOptions_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasAutors.enabled = false;
        canvasOptions.enabled = true;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnOptionsAutors_Click()
    {
        canvasAutors.enabled = true;
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = false;
    }
    public void btnOptionsKeys_Click()
    {
        canvasAutors.enabled = false;
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasNowaGra.enabled = false;
        canvasSterowanie.enabled = true;
    }
    //wlaczenie i wylaczenie muzyki
    public void btnOptionsSoundYesNo_Click()
    {
        if (Gracz.soundMenu == true)
        {
            musicMenu.Pause();
            Gracz.soundMenu = false;
            Gracz.soundMiasto = false;
            btnOptionsSoundYesNo.image.sprite = zdjecieNie;
        }
        else
        {
            musicMenu.Play();
            Gracz.soundMenu = true;
            Gracz.soundMiasto = true;
            btnOptionsSoundYesNo.image.sprite = zdjecieTak;
        }
    }
    //przypisanie glosnosci do zmiennej
    public void sliderSound_Change()
    {
        Gracz.sliderSoundValue = sliderSound.value / 100;
        musicMenu.volume = Gracz.sliderSoundValue;
        musicGra.volume = Gracz.sliderSoundValue;
    }
}
