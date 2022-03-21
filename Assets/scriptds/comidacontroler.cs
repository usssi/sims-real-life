using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class comidacontroler : MonoBehaviour
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

    private bool desayuno = false;
    private bool fruta = false;


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
        //Debug.Log("comida elapsed time = " + elapsedTime);

        maxZzz = 86400;
        currentZzz = PlayerPrefs.GetInt("onCloseHambre") - elapsedTime * (int)valueDecrease;
        zzzbar.SetMaxZzz(maxZzz);
        foo = currentZzz;

        valueDecrease = 2f * Time.deltaTime; //esto deberia ser 1f que equivale a 1 segundo irl

        green = false;
        full = false;
        cyan = false;

        desayuno = false;
        fruta = false;


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
                //Debug.Log("amarillo hambre");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 25920)
            {
                FindObjectOfType<audioManager>().Play("need_orange");
                //Debug.Log("orange hambre");
                Invoke("Fuckshit", 3);
                thisShit = false;

            }
            if (currentZzz == 12960)
            {
                FindObjectOfType<audioManager>().Play("need_red");
                //Debug.Log("red hambre");
                Invoke("Fuckshit", 3);
                thisShit = false;


            }
            if (currentZzz == 4320)
            {
                FindObjectOfType<audioManager>().Play("need_black");
                //Debug.Log("black hambre");
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
            //Debug.Log("cyan hambre");

        }
        else if (animatedFoo > 80000)
        {
            if (animatedFoo < 86400)
            {
                full = true;
                cyan = false;
                green = false;
                //Debug.Log("full hambre");
            }

        }
        else if (animatedFoo < 80000)
        {
            if (animatedFoo > 43200)
            {
                green = true;
                full = false;
                cyan = false;
                //Debug.Log("green hambre");
            }


        }


    }


    public void FixedUpdate()
    {
        if (foo < 43200)
        {
            valueDecrease = 1f * Time.deltaTime;
        }
        else if (foo < 25920)
        {
            valueDecrease = .5f * Time.deltaTime;
        }
        else if (foo < 12960)
        {
            valueDecrease = .25f * Time.deltaTime;
        }

        if (foo > 0)
        {
            foo -= valueDecrease;
            animatedFoo -= valueDecrease;
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
            if (desayuno)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                //Debug.Log("tamos cyan desayuno");
                desayuno = false;

            }
            else if (fruta)
            {
                FindObjectOfType<audioManager>().Play("need_cyan");
                //Debug.Log("tamos cyan fruta");
                fruta = false;
            }
        }

        if (full)
        {
            if (desayuno)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                //Debug.Log("tamos full desayuno");
                desayuno = false;
            }
            else if (fruta)
            {
                FindObjectOfType<audioManager>().Play("need_full");
                //Debug.Log("tamos full fruta");
                fruta = false;
            }
        }

        if (green)
        {
            if (desayuno)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                //Debug.Log("tamos green desayuno");
                desayuno = false;
            }
            else if (fruta)
            {
                FindObjectOfType<audioManager>().Play("need_fill");
                //Debug.Log("tamos green fruta");
                fruta = false;
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

        desayuno = false;
        fruta = false;
        canParticle = true;

    }


    public void Cena()
    {
        Debug.Log("Cenaste o Almorzaste");

        animatedFoo = 86400;
        FindObjectOfType<audioManager>().Play("button_press");
        FindObjectOfType<audioManager>().Play("need_full");
        desayuno = false;
        fruta = false;

        particulaBoton.SetActive(true);
        Invoke("DesactivarParticulaBoton", 1);

        canParticle = true;

    }

    public void Desayuno()
    {
        Debug.Log("Tomaste desayuno o merienda");

        animatedFoo = foo + 21600;

        FindObjectOfType<audioManager>().Play("button_press");
        desayuno = true;
        fruta = false;

        canParticle = true;


    }

    public void Fruta()
    {
        Debug.Log("Comiste fruta o aperitivo");

        animatedFoo = foo + 7200;

        FindObjectOfType<audioManager>().Play("button_press");

        desayuno = false;
        fruta = true;

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
        PlayerPrefs.SetInt("onCloseHambre", currentZzz);

    }

}
