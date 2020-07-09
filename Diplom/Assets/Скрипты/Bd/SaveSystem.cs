using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SaveThemes(Theme[] themes)
    {
        int x1 = ReturnCount(themes[0]);
        int x2 = ReturnCount(themes[1]);
        int x3 = ReturnCount(themes[2]);
        int x4 = ReturnCount(themes[3]);
        int x5 = ReturnCount(themes[4]);
        int x6 = ReturnCount(themes[5]);
        Debug.Log(x1);
        Debug.Log(x2);
        Debug.Log(x3);
        Debug.Log(x4);
        Debug.Log(x5);
        Debug.Log(x6);
        PlayerPrefs.SetInt("1", x1);
        PlayerPrefs.SetInt("2", x2);
        PlayerPrefs.SetInt("3", x3);
        PlayerPrefs.SetInt("4", x4);
        PlayerPrefs.SetInt("5", x5);
        PlayerPrefs.SetInt("6", x6);
    }
    public static int[] ReturnThemeFeel()
    {
        int[] themes = {
            PlayerPrefs.GetInt("1"),
            PlayerPrefs.GetInt("2"),
            PlayerPrefs.GetInt("3"),
            PlayerPrefs.GetInt("4"),
            PlayerPrefs.GetInt("5"),
            PlayerPrefs.GetInt("6"),};
        return themes;
    }
    public static int ReturnCount(Theme theme)
    {
        int x = 0;
        for (int i = 0; i < theme.Questions.Length; i++)
        {
            if (theme.Questions[i].isAnswered)
            {
                x++;
            }
        }
        return x; 
    }
   
     public static void Save(string Name)
    {
        PlayerPrefs.SetString("name",Name);
    }
    public static string LoadPlayerName()
    { 
        return PlayerPrefs.GetString("name","Тимур");
    }
}
