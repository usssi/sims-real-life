using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class player : MonoBehaviour
{

    public int maxZzz = 86400;
    public int currentZzz;

    public ZzzBarra zzzbar;
    public Image fill;
    public Image logo;
    public Image fondo;

    public float foo;
    private float valueDecrease;

    public float animatedFoo;
    private float velocidad;

    private bool green = false;
    private bool full = false;
    private bool cyan = false;

    private bool ocho = false;
    private bool seis = false;
    private bool cuatro = false;
    private bool dos = false;

    private bool thisShit;

    public GameObject particulaGod;
    public GameObject particulaBoton;
    private bool canParticle;

    public GameObject timeManager;
    private int elapsedTime;

    public TextMeshProUGUI burbujaText;


    void Start()
    {
        elapsedTime = timeManager.GetComponent<timeTest1>().timeElapsed;
        //Debug.Log("zzz elapsed time = " + elapsedTime);

        maxZzz = 86400;
        currentZzz = PlayerPrefs.GetInt("onCloseZzz")-elapsedTime;//esto deberia ser igual a su player pref on close restando el time elapsed
        zzzbar.SetMaxZzz(maxZzz);
        foo = currentZzz;

        valueDecrease = 1f; //esto deberia ser 1f que equivale a 1 segundo irl

        green = false;
        full = false;
        cyan = false;
        
        ocho = false;
        seis = false;
        cuatro = false;
        dos = false;

        animatedFoo = foo;
        velocidad = 3f * Time.deltaTime;

        thisShit = true;


        canParticle = false;

    }

    private void Update()
    {
        //Debug.Log("close time this session = " + PlayerPrefs.GetInt("savedTime"));

        //cyan controler    
        if (animatedFoo > 86400)
        {
            //Debug.Log("foo mayor");
            fill.color = Color.cyan;
            logo.color = Color.cyan;
            fondo.color = Color.cyan;
        }

        if (thisShit)
        {
            //sound need decrese sting controller
            if (currentZzz == 43200)
            {
                FindObjectOfType<audioManager>().Play("need_yellow");
                //Debug.Log("amarillo zzz");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 25920)
            {
                FindObjectOfType<audioManager>().Play("need_orange");
                //Debug.Log("orange zzz");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 12960)
            {
                FindObjectOfType<audioManager>().Play("need_red");
                //Debug.Log("red zzz");
                Invoke("Fuckshit", 3);
                thisShit = false;


            }
            if (currentZzz == 4320)
            {
                FindObjectOfType<audioManager>().Play("need_black");
                //Debug.Log("black zzz");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
        }
        

        //sting sound need fill controller
        if (animatedFoo > 86400)
        {
            cyan = true;
            full = false;
            green = false;
            //Debug.Log("cyan zzz");           

        }
        else if (animatedFoo > 80000)
        {
            if (animatedFoo < 86400)
            {
                full = true;
                cyan = false;
                green = false;
                //Debug.Log("full zzz");
            }
            
        }
        else if (animatedFoo < 80000)
        {
            if (animatedFoo > 43200)
            {
                green = true;
                full = false;
                cyan = false;
                //Debug.Log("green zzz");
            }
            

        }
        

    }

    public void FixedUpdate()
    {

        if (foo > 0)
        {
            foo -= valueDecrease * Time.fixedDeltaTime;
            animatedFoo -= valueDecrease * Time.fixedDeltaTime;
        }

        float target = animatedFoo;

        float delta = target - foo;
        delta *= velocidad;

        foo += (int)delta;

        currentZzz = (int)foo;
        zzzbar.SetZzz(currentZzz);

        burbujaText.text = currentZzz.ToString() + "/86400";

    }

    private void LateUpdate()
    {

        //control sound sting deoending on bar state
        if (cyan)
        {
            if (ocho)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                Debug.Log("tamos cyan ocho");
                ocho = false;
               
            }
            else if (seis)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                Debug.Log("tamos cyan seis");
                seis = false;

            }
            else if (cuatro)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                Debug.Log("tamos cyan cuatro");
                cuatro = false;
            }
            else if (dos)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                Debug.Log("tamos cyan dos");
                dos = false;
            }
        }

        if (full)
        {
            if (ocho)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                Debug.Log("tamos full ocho");
                ocho = false;
            }
            else if (seis)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                Debug.Log("tamos full seis");
                seis = false;
            }
            else if (cuatro)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                Debug.Log("tamos full cuatro");
                cuatro = false;
            }
            else if (dos)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                Debug.Log("tamos full dos");
                dos = false;
            }
        }

        if (green)
        {
            if (ocho)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                Debug.Log("tamos green ocho");
                ocho = false;
            }
            else if (seis)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                Debug.Log("tamos green seis");
                seis = false;
            }
            else if (cuatro)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                Debug.Log("tamos green cuatro");
                cuatro = false;
            }
            else if (dos)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                Debug.Log("tamos green dos");
                dos = false;
            }
        }

        //control particula de barra
        if (animatedFoo > 80000)
        {
            if (canParticle)
            {
                //Debug.Log("parcitula activada");
                particulaGod.SetActive(true);
                Invoke("DesactivarParticula", 1);
            }

        }
        else if (animatedFoo < 80000)
        {
            //Debug.Log("parcitula desactivada");
            particulaGod.SetActive(false);
        }

    }


    //botones
    public void RestartButton()
    {
        animatedFoo = 86400;
        FindObjectOfType<audioManager>().Play("button_press");
        FindObjectOfType<audioManager>().Play("need_full");
        ocho = false;
        seis = false;
        cuatro = false;
        dos = false;

        canParticle = true;


    }

    public void DoceHoras()
    {
        Debug.Log("Dormiste 12 horas");

        animatedFoo = 86400;
        FindObjectOfType<audioManager>().Play("button_press");
        FindObjectOfType<audioManager>().Play("need_full");
        ocho = false;
        seis = false;
        cuatro = false;
        dos = false;

        particulaBoton.SetActive(true);
        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;

    }
    public void OchoHoras()
    {
        Debug.Log("Dormiste 8 horas");
        animatedFoo += 43200;
        FindObjectOfType<audioManager>().Play("button_press");
        ocho = true;
        seis = false;
        cuatro = false;
        dos = false;

        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;

    }
    public void SeisHoras()
    {
        Debug.Log("Dormiste 6 horas");

        animatedFoo += 21600;
        FindObjectOfType<audioManager>().Play("button_press");
        ocho = false;
        seis = true;
        cuatro = false;
        dos = false;

        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;


    }
    public void CuatroHoras()
    {
        Debug.Log("Dormiste 4 horas");

        animatedFoo += 14400;
        FindObjectOfType<audioManager>().Play("button_press");
        ocho = false;
        seis = false;
        cuatro = true;
        dos = false;

        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;


    }
    public void DosHoras()
    {
        Debug.Log("Dormiste 2 horas");

        animatedFoo += 7200;
        FindObjectOfType<audioManager>().Play("button_press");
        ocho = false;
        seis = false;
        cuatro = false;
        dos = true;

        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;

    }

    void Fuckshit()
    {
        thisShit = true;
    }

    void DesactivarParticulaBoton()
    {
        particulaBoton.SetActive(false);

    }

    void DesactivarParticula()
    {
        particulaGod.SetActive(false);
        canParticle = false;
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetInt("onCloseZzz", currentZzz);

    }
}