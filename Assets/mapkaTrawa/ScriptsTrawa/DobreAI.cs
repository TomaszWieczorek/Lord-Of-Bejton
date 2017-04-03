using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DobreAI : MonoBehaviour
{

    //Predkosc obrotu przeciwnika.
    public float predkoscObrotu = 6.0f;

    //Gładki obrót przeciwnika
    public bool gladkiObrot = true;


    //Prędkość poruszania się przeciwnika.
    public float predkoscRuchu = 5.0f;
    //Odległość na jaką widzi przeciwnik.
    public float zasiegWzroku = 30f;
    //Odstęp w jakim zatrzyma się obiekt wroga od gracza.
    public float odstepOdGracza = 2f;
    public GameObject pocisk;
    public Transform miejscePocisk;

    private Transform mojObiekt;
    private Transform gracz;
    private bool patrzNaGracza = false;
    private Vector3 pozycjaGraczaXYZ;
    private Vector3 yT;

    public Text tekstAI;
    public Image tloTekstAI;
    public Text misjaIlosc;

    private int ktory;


    // Use this for initialization
    void Start()
    {
        mojObiekt = transform;
        //Rigidbody pozwala aby na obiekt oddziaływała fizyka.
        
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //Pobranie obiektu gracza.
        gracz = GameObject.FindWithTag("Player").transform;

        //Pobranie pozycji gracza.
        pozycjaGraczaXYZ = new Vector3(gracz.position.x, mojObiekt.position.y, gracz.position.z);

        //Pobranie dystansu dzielącego wroga od obiektu gracza.
        float dist = Vector3.Distance(mojObiekt.position, gracz.position);

        patrzNaGracza = false; //Wróg nie patrz na gracza bo jeszcze nie wiadomo czy jest w zasięgu wzroku.

        //Sprawdzenie czy gracz jest w zasięgu wzroku wroga.
        if (dist <= zasiegWzroku && dist > odstepOdGracza && !isDead())
        {
            patrzNaGracza = true;//Gracz w zasiegu wzroku wiec na neigo patrzymy

            //Teraz wykonujemy ruch wroga.
            //Vector3.MoveTowards - pozwala na zdefiniowanie nowej pozycji gracza oraz wykonanie animacji.
            //Pierwszy parametr obecna pozycja drógi parametr pozycja do jakiej dążymy (czyli pozycja gracza).
            //Trzeci parametr określa z jaką prędkością animacja/ruch ma zostać wykonany.
            mojObiekt.position = Vector3.MoveTowards(mojObiekt.position, pozycjaGraczaXYZ, predkoscRuchu * Time.deltaTime);

        }
        else if (dist <= odstepOdGracza && !isDead())
        { //Jeżeli wróg jest tuż przy graczu to niech ciągle na niego patrzy mimo że nie musi się już poruszać.
            patrzNaGracza = true;
        }

        //Jeżeli obiekt jeszcze ma punkty zdrowia to na nas patrzy, podąża za nami.
        if (!isDead())
        {
            patrzNaMnie();
        }
        else
        {

            GetComponent<Rigidbody>().freezeRotation = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            
            ktory = int.Parse(gameObject.name);
            if(tablicaAI.ai[ktory])
            {
                Gracz.misjaDziewczynaIlosc++;
                misjaIlosc.text = Gracz.misjaDziewczynaIlosc.ToString();
                tablicaAI.ai[ktory] = false;
            }
        }
    }


    //Wróg może nie mieć potrzeby sie pruszać bo jest blisko gracza ale niech się obraca w jego stronę.
    void patrzNaMnie()
    {
        if (gladkiObrot && patrzNaGracza == true)
        {
            //Quaternion.LookRotation - zwraca quaternion na podstawie werktora kierunku/pozycji. 
            //Potrzebujemy go aby obrócić wroga w stronę gracza.
            Quaternion rotation = Quaternion.LookRotation(pozycjaGraczaXYZ - mojObiekt.position);
            //Obracamy wroga w stronę gracza.
            mojObiekt.rotation = Quaternion.Slerp(mojObiekt.rotation, rotation, Time.deltaTime * predkoscObrotu);
            mojObiekt.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine("poczekaj");

        }
        else if (!gladkiObrot && patrzNaGracza == true)
        { //Jeżeli nei chcemy gładkiego obracania się wroga tylko błyskawicznego obrotu.

            //Błyskawiczny obrót wroga.
            transform.LookAt(pozycjaGraczaXYZ);
        }
    }

    /**
	 * Funkcja zwraca informację czy obiekt jeszcze posiada punkty zdrowia.
	 */
    bool isDead()
    {
        Zdrowie h = gameObject.GetComponent<Zdrowie>();
        if (h != null)
        {
            return h.czyMartwy();
        }
        return false;
    }
    
    void Fire()
    {
    // tworzymy strzala z prefabu, dodajac pozycje zadeklarowana
        var pociskKopia = (GameObject)Instantiate(
                pocisk,
                miejscePocisk.position,
                miejscePocisk.rotation);
        // dodajemy ruch do strzaly w przod
        pociskKopia.GetComponent<Rigidbody>().velocity = pociskKopia.transform.forward * 30;
        Destroy(pociskKopia, 3.0f);
        StopCoroutine("poczekaj"); //zatrzymujemy courtime jest okej 
    }

   IEnumerator  poczekaj()
    {
      //  Debug.Log("strzelam co 3 sekundy");
        yield return new WaitForSeconds(2);
        Fire();
    }

}
