using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Key : MonoBehaviour,IPointerClickHandler
{
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
    public string KeyChar;
    public Text KeyCharText;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManagerMain.instance.SendChar(KeyChar);
    }
    public void OnEnable()
    {
        KeyCharText.text = KeyChar.ToUpper();
        KeyCharText.fontSize = 64;
    }
}
