using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractbleObject : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   
   [TextArea()] [SerializeField] string text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        UiManager.instance.ShowToolTip(transform.position,text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UiManager.instance.HideToolTip();
    }
}
