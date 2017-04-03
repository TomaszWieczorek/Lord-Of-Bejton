using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptTablicaLucznicza : MonoBehaviour {
    
    public GameObject miejsceStrzalu;
    public Text tekstAI;
    public Text iloscStrzal;
    public Image tloTekstAI;
    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.F) && !Gracz.czyPosiadaMisje && !Gracz.firstGame)
        {
            col.transform.position = miejsceStrzalu.transform.position;
            Gracz.czyBierzeUdzialWTurnieju = true;
            tloTekstAI.enabled = true;
            tekstAI.text = "Życzymy powodzenia! Aby rozpocząć wciśnij F";
        }
    }
    void OnTriggerExit(Collider col)
    {
        tekstAI.text = "";
        tloTekstAI.enabled = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Gracz.czyPosiadaMisje)
        {
            tloTekstAI.enabled = true;
            tekstAI.text = "Posiadasz aktualnie misje. Przyjdź jak ją zakończysz!";
        }
        if (col.tag == "Player" && !Gracz.czyPosiadaMisje && !Gracz.firstGame)
        {
            tloTekstAI.enabled = true;
            tekstAI.text = "Aby wziąć udział w turnieju wciśnij F.";
        }
        if (col.tag == "Player" && !Gracz.czyPosiadaMisje && Gracz.firstGame)
        {
            tloTekstAI.enabled = true;
            tekstAI.text = "Najpierw ukończ tutorial.";
        }
    }
}
