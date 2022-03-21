using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class cleanController : MonoBehaviour
{

    public int maxZzz = 86400;
    public int currentZzz;

    public ZzzBarra zzzbar; //esto controla el gradient y el slider
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

    private bool dientes;
    private bool manos;

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
             

        //Debug.Log("clean elapsed time = " + elapsedTime);


        maxZzz = 86400;
        currentZzz = PlayerPrefs.GetInt("onCloseClean") - elapsedTime * (int)valueDecrease;
        zzzbar.SetMaxZzz(maxZzz);
        foo = currentZzz;

        valueDecrease = .5f; //esto deberia ser .5f que equivale a ciclo de 48 horas

        green = false;
        full = false;
        cyan = false;

        dientes = false;
        manos = false;
        


        animatedFoo = foo;
        velocidad = 3f* Time.deltaTime;

        thisShit = true;


        canParticle = false;

    }

    private void Update()
    {
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
            if (currentZzz == 43200)
            {
                FindObjectOfType<audioManager>().Play("need_yellow");
                //Debug.Log("amarillo higiene");
                Invoke("Fuckshit",3);
                thisShit = false;

            }
            if (currentZzz == 25920)
            {
                FindObjectOfType<audioManager>().Play("need_orange");
                //Debug.Log("orange higiene");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 12960)
            {
                FindObjectOfType<audioManager>().Play("need_red");
                //Debug.Log("red higiene");
                Invoke("Fuckshit", 3);
                thisShit = false;


            }
            if (currentZzz == 4320)
            {
                FindObjectOfType<audioManager>().Play("need_black");
                //Debug.Log("black higiene");
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
            //Debug.Log("cyan higiene");

        }
        else if (animatedFoo > 80000)
        {
            if (animatedFoo < 86400)
            {
                full = true;
                cyan = false;
                green = false;
                //Debug.Log("full higiene");
            }

        }
        else if (animatedFoo < 80000)
        {
            if (animatedFoo > 43200)
            {
                green = true;
                full = false;
                cyan = false;
                //Debug.Log("green higiene");
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

        

        //Debug.Log(foo);

        currentZzz = (int)foo;
        zzzbar.SetZzz(currentZzz);

        burbujaText.text = currentZzz.ToString() + "/86400";



    }

    private void LateUpdate()
    {

        //control sound sting depending on bar state
        if (cyan)
        {
            if (dientes)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                Debug.Log("tamos cyan dientes");
                dientes = false;

            }
            else if (manos)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                Debug.Log("tamos cyan manos");
                manos = false;

            }
           
        }

        if (full)
        {
            if (manos)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                Debug.Log("tamos full manos");
                manos = false;
            }
            else if (dientes)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                Debug.Log("tamos full dientes");
                dientes = false;
            }
           
        }

        if (green)
        {
            if (manos)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                Debug.Log("tamos green manos");
                manos = false;
            }
            else if (dientes)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                Debug.Log("tamos green dientes");
                dientes = false;
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

        dientes = false;
        manos = false;
        canParticle = true;

    }

    public void Ducha()
    {
        Debug.Log("Te duchaste o bañaste");

        animatedFoo = 86400;

        FindObjectOfType<audioManager>().Play("button_press");
        FindObjectOfType<audioManager>().Play("need_full");
        
        particulaBoton.SetActive(true);
        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;

        dientes = false;
        manos = false;


        //Invoke("DisableFoo", 3f);



    }

    public void Dientes()
    {
        Debug.Log("Te lavaste los dientes");

        animatedFoo = foo + 21600;

        FindObjectOfType<audioManager>().Play("button_press");
        dientes = true;
        manos = false;

        canParticle = true;


        //Invoke("DisableFoo", 3f);


    }

    public void Manos()
    {
        Debug.Log("Te lavaste las manos");

        animatedFoo = foo + 7200;

        FindObjectOfType<audioManager>().Play("button_press");

        dientes = false;
        manos = true;

        canParticle = true;


        //Invoke("DisableFoo", 3f);

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
        PlayerPrefs.SetInt("onCloseClean", currentZzz);


    }
}

