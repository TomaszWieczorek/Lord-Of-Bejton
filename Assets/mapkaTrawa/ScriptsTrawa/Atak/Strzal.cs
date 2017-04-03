using UnityEngine;
using System.Collections;

public class Strzal : MonoBehaviour
{

    //Zasieg strzalu
    public float zasieg = 100.0f;
    //Co ile mozna wykonac strzal
    public float czekaj = 2f;
    //Odliczanie do kolejnego strzalu.
    public float odliczanieDoStrzalu = 0f;

    //Obiekt pocisku.
    public GameObject pociskPrefab;
    //Obrarzenie jakie zadaje strzal (ile punktow zdrowia zabiera).
    public float obrazenia = 20.0f;

    // Update is called once per frame
    void Update()
    {
        //Zmniejszanie licznika do kolejnego strzalu/odliczanie do strzalu.
        if (odliczanieDoStrzalu < czekaj)
        {
            odliczanieDoStrzalu += Time.deltaTime;
        }

        //Strzal nastepuje jezeli przycisk myszy jest ciagle wcisniety oraz jezeli odliczanie
        //do kolejnego strzalu jest rowne zero(mozna strzelac).
        if (Input.GetMouseButton(0) && odliczanieDoStrzalu >= czekaj)
        {
            //Strzal zostal oddany ustawienie ponownego odliczania.
            odliczanieDoStrzalu = 0;
            Gracz.iloscStrzal--;

            /*Ray (promien) pozwala na pobranie kierunku w ktorym skierowana jest kamera
		     - Camera.main.transform.position - promien wychodzacy besposrednio/centralnie z celownika (slodka ekranu).
			 - Camera.main.transform.forward - pozycja w kierunku ktorej skierowana jest kamera.
			*/
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //Pobranie informacji w co zostal oddany strzal.
            RaycastHit hitInfo;

            //Sprawdzenie czy promien w cos trafil czy obiekt (hitInfo) mieszczacy sie w zakresie (range)
            // w cos trafiły.
            if (Physics.Raycast(ray, out hitInfo, zasieg))
            {
                //Pobranie informacji o trafionym obiekcie.
                Vector3 hitPoint = hitInfo.point;
                //Pobranie trafionego obiektu.
                GameObject go = hitInfo.collider.gameObject;

                //Debug.Log("Hit Object: "+go.name);//Nazwa trafionego obiektu
                //Debug.Log("Hit Point: "+hitPoint);//Wspolrzedne trafionego obiektu.

                //Zadanie obrazenia trafionemu obiektowi.
                hit(go);

                if (pociskPrefab != null)
                {//Czy mamy przypisany obiekt pocisku.

                    /*Odpowiada za utworzenie obiektu pocisku w momencie trafienia celu.
					 *  Tworzy kulke na obiekcie.
					 * - pociskPrefab - obiekt kulki.
					 * - hitPoint - pozycja trafienia i pozycja na jakiej zostanie utworzony pocisk.
					 * - Quaternion.identity - o ile ma zostac obrucony pocisk (Quaternion.identity = bez zmian)
					 */
                    Instantiate(pociskPrefab, hitPoint, Quaternion.identity);

                }

            }
        }
    }

    //Funkcja odpowiedzialna za zmniejszenie punktu zdrowia
    void hit(GameObject go)
    {
        //Zadawanie obrarzen obiektowi.
        //Pobranie od trafionego obiektu atrybutu zdrowia.
        Zdrowie zdrowie = go.GetComponent<Zdrowie>();
        //Sprawdzenie czy trafiony obiekt ma atrybut zdrowia.
        if (zdrowie != null)
        {
            //Jezeli trafiony obiekt posiada atrybut zdrowia to zadawane jest obrarzenie.
            zdrowie.otrzymaneObrazenia(obrazenia);
        }
    }
}
