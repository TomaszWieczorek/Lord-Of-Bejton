using UnityEngine;
using System.Collections;

public class scriptPaczkaStrzal : MonoBehaviour {

    void OnTriggerStay(Collider col)
    {
        //dodawanie losowej ilosc strzal
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !Gracz.zebranaStrzala)
        {
            int ilosc = Random.Range(1, 11);
            Gracz.iloscStrzal += ilosc; 
            Destroy(gameObject);
            Gracz.zebranaStrzala = true;
        }
    }
}
