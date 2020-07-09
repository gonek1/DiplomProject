using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    
    [SerializeField] GameObject tooltip;
    public static UiManager instance;
    private void Awake()
    {
        instance = this;
        
    }
   public void ShowToolTip(Vector3 position,string text)
    {
        tooltip.SetActive(true);
        tooltip.GetComponentInChildren<Text>().text = text;
        tooltip.transform.position = position;
    }
   public void HideToolTip()
    {
        tooltip.SetActive(false);
    }
}
