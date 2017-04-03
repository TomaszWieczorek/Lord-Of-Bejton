using UnityEngine;
using System.Collections;

/**
 * Skkrypt powodujący usunięcie obiektu po upływie zadanego czasu.
 */
public class SamoZniszczenie : MonoBehaviour
{

    //Czas życia obiektu posiadającego ten skrypt.
    public float czasZycia = 1f;

    // Update is called once per frame
    void Update()
    {
        czasZycia -= Time.deltaTime;

        //Czy upłyną czas życia.
        if (czasZycia <= 0)
        {
            //Czas zycia upłyną usuń obiekt.
            Destroy(gameObject);
        }
    }

}
