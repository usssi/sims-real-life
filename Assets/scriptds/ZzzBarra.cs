using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZzzBarra : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image logo;
    public Image fondo;


    public void SetMaxZzz(int zzz)
    {
        slider.maxValue = zzz;
        slider.value = zzz;

        fill.color = gradient.Evaluate(1f);
        logo.color = gradient.Evaluate(1f);
        fondo.color = gradient.Evaluate(1f);

    }

    public void SetZzz(int zzz)
    {
        slider.value = zzz;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        logo.color = gradient.Evaluate(slider.normalizedValue);
        fondo.color = gradient.Evaluate(slider.normalizedValue);

    }
}
