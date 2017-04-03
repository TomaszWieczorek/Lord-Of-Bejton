using UnityEngine;
using System.Collections;

public class Gracz : MonoBehaviour {
    //dane gracza
    public static int playerHP=100;
    public static string playerNick = "Player";
    //dzwiek
    public static bool soundMiasto = true;
    public static bool soundMenu = true;
    public static float sliderSoundValue;
    //tutorial
    public static bool firstGame = true;
    public static int tutorialKroki = 0;
    //misje
    public static bool czyPosiadaMisje = false;
    //misja do medyka
    public static int misjaKwiatyIlosc = 0;
    public static bool misjaKwiatyZaakceptowana = false;
    public static bool misjaKwiatyUdana = false;
    //misja od kowala
    public static int misjaDrzewoIlosc = 0;
    public static bool misjaDrzewoZaakceptowana = false;
    public static bool misjaDrzewoUdana = false;
    //misja od dziewczyny
    public static int misjaDziewczynaIlosc = 0;
    public static bool misjaDziewczynaZaakceptowana = false;
    public static bool misjaDziewczynaUdana = false;
    //strzaly
    public static bool zebranaStrzala;
    public static int iloscStrzal = 0;
    //potiony
    public static int iloscPotionow = 0;
    //turniej
    public static int iloscPunktowTurnieju;
    public static int rekordTurniej = 130;
    public static bool czyBierzeUdzialWTurnieju = false;
    public static bool czyWyswietlacMenu = true;
    //zakonczenie
    public static bool happyEnd = false;
}
