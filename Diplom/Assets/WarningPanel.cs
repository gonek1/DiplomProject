using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(TurnOffPanel());
    }
    IEnumerator TurnOffPanel()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

}
