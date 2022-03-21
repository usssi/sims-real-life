using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float timeToWait = 0.5f;
    public GameObject tipWindow;


    public void OnPointerEnter(PointerEventData eventData) 
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
    }

    private void ShowMesage()
    {
        tipWindow.gameObject.SetActive(true);

        FindObjectOfType<audioManager>().Play("burbuja");
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        ShowMesage();
    }

}
