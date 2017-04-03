using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptTurniejLuczniczy : MonoBehaviour {
    
    public Text tekstAI;
    public Text iloscStrzal;
    public Image tloTekstAI;
    public Text misjaIlosc;
    public Image tlomisjaIlosc;
    public Text misjaTresc;
    public Image tlomisjaTresc;
    private int krokiTurnieju=0;
    public static int iloscStrzalowTurniej;
    private int ilosc;
    void Start () {
        krokiTurnieju = 0;
	}
	void Update () {
        if (Gracz.czyBierzeUdzialWTurnieju)
        {
            #region poczatek turnieju
            if (Input.GetKeyDown(KeyCode.E) && krokiTurnieju == 0)
            {
                Debug.Log("XXX");
                tekstAI.text = "";
                tloTekstAI.enabled = false;

                iloscStrzalowTurniej = 10;
                krokiTurnieju = 1;

                tlomisjaTresc.enabled = true;
                misjaTresc.text = "Punkty";
                tlomisjaIlosc.enabled = true;

                scriptStrzalaWbita.i = 0;
            }
            #endregion
            #region strzelanie
            if (krokiTurnieju == 1 && Input.GetMouseButtonDown(0) && iloscStrzalowTurniej >= 0)
            {
                iloscStrzalowTurniej=iloscStrzalowTurniej-1;
            }
            #endregion
            #region Koniec gry
            if (krokiTurnieju == 1 && Input.GetMouseButtonDown(0) && iloscStrzalowTurniej == -1)
            {
                tloTekstAI.enabled = true;
                tekstAI.text = "Zdobyles " + Gracz.iloscPunktowTurnieju.ToString() + "Pkt! Gratulujemy!\nNa tablicy zobaczysz czy pobiłeś rekord! Wciśnij Z!";
                if (Gracz.iloscPunktowTurnieju > Gracz.rekordTurniej)
                {
                    GameObject.Find("textNajlepszyStrzelec").GetComponent<TextMesh>().text = Gracz.iloscPunktowTurnieju.ToString() + "pkt - " + Gracz.playerNick;
                }
            }
            #endregion
            #region Wyjscie z turnieju
            if (Input.GetKeyDown(KeyCode.Z))
            {
                iloscStrzal.text = Gracz.iloscStrzal.ToString();
                misjaIlosc.text = "";
                tlomisjaIlosc.enabled = false;
                misjaTresc.text = "";
                tlomisjaTresc.enabled = false;
                tekstAI.text = "";
                tloTekstAI.enabled = false;
                GameObject player = GameObject.Find("FPSController");
                player.transform.position = new Vector3(417, 15, 90);
                Gracz.czyBierzeUdzialWTurnieju = false;
                krokiTurnieju = 0;
                Gracz.czyWyswietlacMenu = false;

                foreach (GameObject go in scriptStrzalaWbita.strzalyTurniej)
                {
                    Destroy(go);
                }
            }
            #endregion
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Gracz.czyBierzeUdzialWTurnieju && krokiTurnieju == 0)
        {
            tloTekstAI.enabled = true;
            tekstAI.text = "Życzymy powodzenia! Aby rozpocząć wciśnij E!";
            Gracz.czyWyswietlacMenu = false;
        }
    }
}

