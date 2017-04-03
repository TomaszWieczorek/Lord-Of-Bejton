using UnityEngine;
using System.Collections;

public class scriptStrzalaWbita : MonoBehaviour {

    public static GameObject[] strzalyTurniej = new GameObject[10];
    public static int i = 0;
    public AudioClip strzalaNiszczona;
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag != "Player")
        {
            if (!Gracz.czyBierzeUdzialWTurnieju)
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else 
            {
                //zmienna aby mozna bylo usunac strzaly z turnieju po zakonczeniu go
                strzalyTurniej[i] = this.gameObject;
                //po uderzeniuw  odpowiednia tablice odpowiednia ilosc punktow jest dodawana
                if (col.collider.tag == "turniejZolty")
                {
                    Gracz.iloscPunktowTurnieju += 25;
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else if (col.collider.tag == "turniejCzerwony")
                {
                    Gracz.iloscPunktowTurnieju += 20;
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else if (col.collider.tag == "turniejNiebieski")
                {
                    Gracz.iloscPunktowTurnieju += 15;
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else if (col.collider.tag == "turniejCzarny")
                {
                    Gracz.iloscPunktowTurnieju += 10;
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else if (col.collider.tag == "turniejBialy")
                {
                    Gracz.iloscPunktowTurnieju += 5;
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else
                {
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                i++;
            }
        }
        //strzaly sa niszczone gdy trafia np w medyka lub kowala
        if (col.collider.tag == "strzalyNiszczone")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(strzalaNiszczona, col.transform.position);
            Gracz.iloscStrzal++;
        }
    }
    void OnTriggerStay(Collider col)
    {
        //zbieranie strzal
        if(col.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !Gracz.zebranaStrzala)
        {
            Gracz.iloscStrzal++;
            Destroy(gameObject);
            Gracz.zebranaStrzala = true;
        }
    }
}
