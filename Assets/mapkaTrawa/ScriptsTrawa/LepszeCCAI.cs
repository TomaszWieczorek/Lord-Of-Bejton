using UnityEngine;
using System.Collections;

public class LepszeCCAI : MonoBehaviour
{
    //Obiekt odpowiedzialny za ruch gracza.
    public CharacterController characterControler;
    //Obiekt gracza.
    private Transform gracz;
    //Obiekt wroga.
    private Transform mojObiekt;

    //Prędkość obracania się przeciwnika..
    public float predkoscObrotu = 4.0f;
    //Prędkość poruszania się przeciwnika.
    public float predkoscRuchu = 5.0f;
    //Zasięg wzroku przeciwnika.
    public float zasieg = 30.0f;

    public GameObject strzala;
    public Transform strzalaMiejsce;



    //Aktualna wysokosc skoku.
    public float aktualnaWysokoscSkoku = 0f;
    //Odstęp w jakim zatrzyma się obiekt wroga od gracza.
    public float odstepOdGracza = 2f;

    //Wrog typu duch (latajacy).
    public bool czyDuch;

    
    void Start()
    {
        characterControler = GetComponent<CharacterController>();
        mojObiekt = transform;
        GameObject go = GameObject.FindWithTag("Player");
        gracz = go.transform;
    }

    
    void Update()
    {

        //Pobranie dystansu dzielącego wroga od obiektu gracza.
        float dystans = Vector3.Distance(mojObiekt.position, gracz.position);

        //Jeżeli dystans jaki dzieli obiekt wroga od obiektu gracza mieści się w zakresie widzenia wroga to 
        //obiekt wroga zaczyna poruszać się w kierunku gracza.
        //Obiekt wroga zatrzyma się przed graczem w zadanym odstępie.
        if (dystans < zasieg && dystans > odstepOdGracza)
        {

            
            Vector3 graczPoz = new Vector3(gracz.position.x, gracz.position.y, gracz.position.z);

            //Funkcja Quaternion.Slerp (spherical linear interpolation)
            // pozwala obracać obiekt w zadanym kierunku z zadaną prędkością.
            mojObiekt.GetComponent<Renderer>().material.color = Color.red;
            mojObiekt.rotation = Quaternion.Slerp(mojObiekt.rotation, Quaternion.LookRotation(graczPoz - mojObiekt.position), predkoscRuchu * Time.deltaTime);



            //Aby uniknąć latania przeciwnika wymuszamy pozostanie na ziemi.
            if (!characterControler.isGrounded)
            {//Jezeli jestesmy w powietrzu(skok)
                aktualnaWysokoscSkoku += Physics.gravity.y * Time.deltaTime;
            }
            Debug.Log(characterControler.isGrounded);

            if (!czyDuch)
            {
                //Tworzymy wektor odpowiedzialny za ruch.
                //x - odpowiada za ruch lewo/prawo,
                //y - odpowiada za ruch góra/dół,
                //z - odpowiada za ruch przód/tył.
                Vector3 ruch = new Vector3(mojObiekt.forward.x, aktualnaWysokoscSkoku, mojObiekt.forward.z);
                //Ruch wroga.
                characterControler.Move(ruch * predkoscRuchu * Time.deltaTime);
            }
            else
            {
                //Tryb ducha przenika przez obiekty np drzewa 
                mojObiekt.position += mojObiekt.forward * predkoscRuchu * Time.deltaTime;
            }

        }

    }
    bool isDead()
    {
        Zdrowie h = gameObject.GetComponent<Zdrowie>();
        if (h != null)
        {
            return h.czyMartwy();
        }
        return false;
    }
}