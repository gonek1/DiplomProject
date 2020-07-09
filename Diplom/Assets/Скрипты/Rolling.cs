using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rolling : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Range(-50,-1)]public int speed;
    bool isEnter;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }
    void Update()
    {
        
        if (isEnter)
        {
            Roll();
        }
    }
    void Roll()
    {
        transform.Rotate(new Vector3(0, 0, speed));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }
}
