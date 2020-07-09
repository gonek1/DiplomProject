using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider scrollbar;
    public AudioSource mainMusic;
    public Dropdown dropdown;
    public List<string> resolutions;
    private void Start()
    {
        Fill();
    }

    public void DropDown_IndexChanged(int x)
    {
        switch (x)
        {
            case 0: Screen.SetResolution(1920, 1080, true) ;
                break;
            case 1:
                Screen.SetResolution(1600, 900, true);
                break;
            case 2:
                Screen.SetResolution(1280, 1024, true);
                break;
        }
    }
    private void Fill()
    {
        dropdown.AddOptions(resolutions);
    }
    public void Scroll_IndexChanged()
    {
        mainMusic.volume = scrollbar.value;
    }
}
