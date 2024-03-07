using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchCheck: MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
	public Text text;
	
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
	
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = new Color(0, 0.6f, 1, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.black;
    }
}