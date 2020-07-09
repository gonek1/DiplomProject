using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject instruction;
    int isOpenFirstTry;
    private void Awake()
    {
        isOpenFirstTry = PlayerPrefs.GetInt("first", 0);
        if (isOpenFirstTry == 0)
        {
            instruction.SetActive(true);
            PlayerPrefs.SetInt("first",1);
        }
    }
}
