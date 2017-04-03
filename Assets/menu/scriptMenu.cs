using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour {
    
    public Canvas canvasMenu;
    public Canvas canvasExit;
    public Canvas canvasOptions;
    public Canvas canvasAutors;
    public Canvas canvasPlayerName;
    public Canvas canvasKeys;
    public Button btnLoadGame;
    public Button btnOptionsSoundYesNo;
    public InputField inputFieldPlayerNick;
    public AudioSource musicMenu;
    public Sprite zdjecieTak;
    public Sprite zdjecieNie;
    public Slider sliderSound;

    void Awake () {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        btnLoadGame.enabled = false;
        canvasAutors.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
	}
    void Update()
    {
        //aby na escape sie cofac w menu
        if (Input.GetKeyDown(KeyCode.Escape) && canvasAutors.enabled)
        {
            canvasMenu.enabled = true;
            canvasExit.enabled = false;
            canvasOptions.enabled = false;
            canvasAutors.enabled = false;
            canvasPlayerName.enabled = false;
            canvasKeys.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && (canvasAutors.enabled || canvasKeys.enabled))
        {
            canvasMenu.enabled = false;
            canvasExit.enabled = false;
            canvasOptions.enabled = true;
            canvasAutors.enabled = false;
            canvasPlayerName.enabled = false;
            canvasKeys.enabled = false;
        }
    }
    public void btnExit_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = true;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
    }
    public void btnExitNo_Click()
    {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
    }
    public void btnExitYes_Click()
    {
        Application.Quit();
    }
    public void btnStartGame_Click()
    {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasPlayerName.enabled = true;
        canvasKeys.enabled = false;
    }
    public void btnPlayerNameConfirm_Click()
    {
        Gracz.playerNick = inputFieldPlayerNick.text;
        Gracz.playerHP = 100;
        Gracz.firstGame = true;
        SceneManager.LoadScene("mapkaZamek/zamek");
    }
    public void btnBackToMenu_Click()
    {
        canvasMenu.enabled = true;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasAutors.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
    }

    public void btnOptions_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = true;
        canvasAutors.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
    }
    public void btnBackToOptions_Click()
    {
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasAutors.enabled = false;
        canvasOptions.enabled = true;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
    }
    public void btnOptionsAutors_Click()
    {
        canvasAutors.enabled = true;
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = false;
    }
    public void btnOptionsKeys_Click()
    {
        canvasAutors.enabled = false;
        canvasMenu.enabled = false;
        canvasExit.enabled = false;
        canvasOptions.enabled = false;
        canvasPlayerName.enabled = false;
        canvasKeys.enabled = true;
    }
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
    public void sliderSound_Change()
    {
        Gracz.sliderSoundValue = sliderSound.value / 100;
        musicMenu.volume = Gracz.sliderSoundValue;
    }
}
