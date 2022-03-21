using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class sedcontroller : MonoBehaviour
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

    private bool vaso = false;
    private bool sorbo = false;


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
        //Debug.Log("sed elapsed time = " + elapsedTime);

        maxZzz = 86400;
        currentZzz = PlayerPrefs.GetInt("onCloseSed") - elapsedTime * (int)valueDecrease;
        zzzbar.SetMaxZzz(maxZzz);
        foo = currentZzz;

        valueDecrease = 4f; //esto es 2f que equivale a ciclo de 12 horas

        green = false;
        full = false;
        cyan = false;

        vaso = false;
        sorbo = false;


        animatedFoo = foo;
        velocidad = 3f * Time.deltaTime;

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
            //sound need decrese sting controller
            if (currentZzz == 43200)
            {
                FindObjectOfType<audioManager>().Play("need_yellow");
                //Debug.Log("amarillo sed");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 25920)
            {
                FindObjectOfType<audioManager>().Play("need_orange");
                //Debug.Log("orange sed");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 12960)
            {
                FindObjectOfType<audioManager>().Play("need_red");
                //Debug.Log("red sed");
                Invoke("Fuckshit", 3);
                thisShit = false;


            }
            if (currentZzz == 4320)
            {
                FindObjectOfType<audioManager>().Play("need_black");
                //Debug.Log("black sed");
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
            //Debug.Log("cyan sed");

        }
        else if (animatedFoo > 80000)
        {
            if (animatedFoo < 86400)
            {
                full = true;
                cyan = false;
                green = false;
                //Debug.Log("full sed");
            }

        }
        else if (animatedFoo < 80000)
        {
            if (animatedFoo > 43200)
            {
                green = true;
                full = false;
                cyan = false;
                //Debug.Log("green sed");
            }


        }


    }

    public void FixedUpdate()
    {
        if (foo<43200)
        {
            valueDecrease = 2f;
        }
        else if (foo<25920)
        {
            valueDecrease = 1f;
        }
        else if (foo < 12960)
        {
            valueDecrease = .5f;
        }

        if (foo>0)
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

        //control sound sting deoending on bar state
        if (cyan)
        {
            if (vaso)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                //Debug.Log("tamos cyan ocho");
                vaso = false;

            }            
            else if (sorbo)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                //Debug.Log("tamos cyan cuatro");
                sorbo = false;
            }
        }

        if (full)
        {
            if (vaso)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                //Debug.Log("tamos full ocho");
                vaso = false;
            }
            else if (sorbo)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                //Debug.Log("tamos full cuatro");
                sorbo = false;
            }
        }

        if (green)
        {
            if (vaso)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                //Debug.Log("tamos green ocho");
                vaso = false;
            }
            else if (sorbo)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                //Debug.Log("tamos green cuatro");
                sorbo = false;
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
        
        vaso = false;
        sorbo = false;
        canParticle = true;

    }


    public void Botella()
    {
        Debug.Log("Tomaste 1 botella de 500ml");

        animatedFoo = 86400;
        FindObjectOfType<audioManager>().Play("button_press");
        FindObjectOfType<audioManager>().Play("need_full");
        vaso = false;
        sorbo = false;

        particulaBoton.SetActive(true);
        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;

    }

    public void Vaso()
    {
        Debug.Log("Tomaste 1 vaso de agua");

        animatedFoo = foo + 21600;

        FindObjectOfType<audioManager>().Play("button_press");
        vaso = true;
        sorbo = false;

        canParticle = true;

    }

    public void Sorbo()
    {
        Debug.Log("Tomaste sorbo de agua");

        animatedFoo = foo + 7200;

        FindObjectOfType<audioManager>().Play("button_press");

        vaso = false;
        sorbo = true;

        canParticle = true;

    }

    //voids
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
        PlayerPrefs.SetInt("onCloseSed", currentZzz);

    }
}
