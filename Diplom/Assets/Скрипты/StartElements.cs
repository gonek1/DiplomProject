using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartElements : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(1, 2)]public float scale;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= scale;
    }
}
