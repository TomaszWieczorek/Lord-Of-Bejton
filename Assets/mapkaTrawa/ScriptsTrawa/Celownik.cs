using UnityEngine;
using System.Collections;

public class Celownik : MonoBehaviour
{




    /* Pod tą zmienną podstawiamy obrazek*/
    public Texture2D crosshairTexture;
    /*Pozycja naszego celownika.*/
    public Rect position;
    /** Czy wyświetlić celownik.*/
    public bool widoczny = true;

    // Use this for initialization
    void Start()
    {

        //Ustawienie pozycji dla celownika.
        position = new Rect(
            (Screen.width - crosshairTexture.width) / 2,
            (Screen.height - crosshairTexture.height) / 2,
            crosshairTexture.width, crosshairTexture.height);
    }

    // Update is called once per frame
    void OnGUI()
    {
        //Czy pokazać celownik.
        if (widoczny == true)
        {
            //Rysowanie celownika.
            GUI.DrawTexture(position, crosshairTexture);
        }


    }
}