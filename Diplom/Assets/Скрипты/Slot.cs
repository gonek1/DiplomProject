using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerClickHandler
{

    public Theme theme;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManagerMain.instance.StartGame(theme);
    }
}
