using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinPanel : MonoBehaviour
{
    
    public Text QuestionCountText;
    public Text ResultText;
    public GameObject[] stars;
    public static WinPanel instance;
    private void Awake()
    {
        instance = this;
    }
    public void EnablePanel(int starsCount, bool isWin, int questCount = 0)
    {
        for (int i = 0; i < starsCount; i++)
        {
            stars[i].SetActive(true);
        }
        ResultText.text = isWin ? "Победа":"Поражение";
        QuestionCountText.text = "Отвечено на "+ questCount+" /10 вопросов по теме";

        this.gameObject.SetActive(true);
    }
    public void DisablePanel()
    {
        foreach (var item in stars)
        {
            item.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
