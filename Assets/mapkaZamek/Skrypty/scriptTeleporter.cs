using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptTeleporter : MonoBehaviour {
    
    public Text teksAI;
    public Image tloTekstAI;
    public AudioSource dzwiekMiasto;
    public bool przenies;
    void OnTriggerEnter(Collider col)
    {
        //Sprawdza czy gracz skonczyl tutorial i wyswietla ofpowiednia informacje
        if (col.tag == "Player" && !Gracz.firstGame)
        {
            tloTekstAI.enabled = true;
            teksAI.text = "Aby przenieść się na Zielone Pola, wciśnij F. Uważaj na różne stwory!";
        }
        if(Gracz.firstGame)
        {
            tloTekstAI.enabled = true;
            teksAI.text = "Najpierw ukończ tutorial!";
        }
        else if (!Gracz.misjaKwiatyUdana || !Gracz.misjaDrzewoUdana)
        {
            tloTekstAI.enabled = true;
            teksAI.text = "Najpierw wykonaj wszystkie misje na tej mapce!";
        }
    }

    //czysci podpowiedz
    void OnTriggerExit(Collider col)
    {
            tloTekstAI.enabled = false;
            teksAI.text = "";
    }

    void OnTriggerStay(Collider col)
    {
        //po kliknieciu F przenosi gracza na kolejna mapke
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !Gracz.firstGame && Gracz.misjaKwiatyUdana && Gracz.misjaDrzewoUdana)
        {
            //wyszukuje wszystkie elementy które mają być nie zniszczone po zmianie mapki i dodaje do tablicy, ktorej nastepnie nie niszczy
            GameObject[] elementy = GameObject.FindGameObjectsWithTag("obiektyNieNiszczone");
            foreach(GameObject gO in elementy)
            {
                DontDestroyOnLoad(gO);
            }
            DontDestroyOnLoad(col.gameObject);
            //wylacza dzwiek
            dzwiekMiasto.Stop();
            //przenosi gracza w odpowiednie miejsce na mapce
            tloTekstAI.enabled = false;
            teksAI.text = "";
            col.gameObject.transform.position = new Vector3(230, 10, 100);
            SceneManager.LoadSceneAsync("mapkaTrawa/mapka");
        }
        //if (col.tag == "Player" && przenies)
        //{
        //    SceneManager.LoadScene("mapkaTrawa/mapka");
        //}
    }
}
