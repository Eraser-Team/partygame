using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FadeOut : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
 public Image image;
 
 public void OnPointerEnter(PointerEventData eventData)
    {
		GetComponent<Image>().color -= new Color(0f, 0f, 0f, 0.65f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
		GetComponent<Image>().color -= new Color(0f, 0f, 0f, -0.65f);
    }
}
