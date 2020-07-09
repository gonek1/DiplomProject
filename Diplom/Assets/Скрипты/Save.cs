using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    int x = 100;
    int x1 = 100;
    int x2 = 100;
    int x3= 100;
    int x4= 100;
    int x5= 100;
    int x6= 100;
    int x7 = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("test", x);
        PlayerPrefs.SetInt("test1", x1);
        PlayerPrefs.SetInt("test2", x2);
        PlayerPrefs.SetInt("test3", x3);
        PlayerPrefs.SetInt("test4", x4);
        PlayerPrefs.SetInt("test5", x5);
        PlayerPrefs.Save();
        x1 = PlayerPrefs.GetInt("test");
        Debug.Log(x1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
