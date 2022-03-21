using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAllCanvas : MonoBehaviour
{
    public GameObject DisableThis1;
    public GameObject DisableThis2;
    public GameObject DisableThis3;
    public GameObject DisableThis4;
    public GameObject DisableThis5;
    public GameObject DisableThis6;

    // Start is called before the first frame update
    public void WhenButtonClicked()
    {
       
        DisableThis1.SetActive(false);
        DisableThis2.SetActive(false);
        DisableThis3.SetActive(false);
        DisableThis4.SetActive(false);
        DisableThis5.SetActive(false);
        DisableThis6.SetActive(false);



    }
}
