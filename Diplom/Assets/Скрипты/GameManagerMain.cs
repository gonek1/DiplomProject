using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMain : MonoBehaviour
{
    public MoneySystem moneySystem;
    public Button SaveChanges;
    public InputField Name;
    public Player player;
    public Text[] themesTexts;
    public Theme[] allThemes;
    public Image[] themePictures;
    public GameObject FullAnswerPanel;
    public Text TimerText;
    public Key[] Keys;
    public GameObject ThemeChoice;
    public GameObject GameField;
    public static GameManagerMain instance;
    public Text QuestionText;
    public Text AnswerTextUI;
    int index = 0;
    public string CurrentAnswer;
    public WinPanel WinPanel;
    public string Answer; // Текс ответа    
    public string Question; // Текст вопроса
    Theme CurrentTheme;
    public GameObject cell;
    public Transform content;
    public GameObject warningPanel;
    private void Awake()
    {
        
        instance = this;
        SaveChanges.onClick.AddListener(() => SavePlayer());
    }
    public void SendChar(string KeyChar)
    {
        if (content.childCount>=12)
        {
            return;
        }
        var _cell = Instantiate(cell, content);
        _cell.GetComponentInChildren<Text>().text = KeyChar.ToUpper();
        
       
        Answer += KeyChar;
    }
    public void StartGame(Theme theme)
    {
        if (moneySystem.CanPlayGame())
        {
            CurrentTheme = theme;
            LoadNextQuestion();
            GameField.SetActive(true);
        }
        else
        {
            moneySystem.ShowPanel();
        }
        
       
    }
    public void CheckAnswer()
    {
        if (Answer.ToUpper() == CurrentAnswer.ToUpper())
        {
            
            CurrentTheme.Questions[index].isAnswered = true;
            SaveSystem.SaveThemes(allThemes);
            WinPanel.EnablePanel(2,true, QuestCount());
            StopAllCoroutines();
        }
        else
        {
            warningPanel.SetActive(true);
        }
    }
    public void ClearAnswer()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        Answer = string.Empty;
    }
    public void LoadNextQuestion()
    {
        ClearAnswer();
        if (!moneySystem.CanPlayGame())
        {
            WinPanel.instance.DisablePanel();
            GameField.SetActive(false);
            return;
        }
        
        StopAllCoroutines();
        if (QuestCount()==10)
        {
            FullAnswerPanel.SetActive(true);
            return;
        }
        StartCoroutine(Timer());
        List<int> test = new List<int>();
        for (int i = 0; i < CurrentTheme.Questions.Length; i++)
        {
            if (CurrentTheme.Questions[i].isAnswered == false)
            {
                test.Add(i);
            }
        }
        int x = test[UnityEngine.Random.Range(0, test.Count)];
        index = x;
        CurrentAnswer = CurrentTheme.Questions[x].Answer;
        Question = CurrentTheme.Questions[x].Name;
        QuestionText.text = Question;
        moneySystem.MinusEnergy();
    }
    IEnumerator Timer()
    {
        int sec = 60;
        TimerText.text = sec.ToString();
        while (sec>0)
        {
            yield return new WaitForSeconds(1);
            sec--;
            TimerText.text = sec.ToString();
        }
        if (sec<=0)
        {
            WinPanel.EnablePanel(0,false, QuestCount());
            StopAllCoroutines();
        }
    }
    public int QuestCount()
    {
        int x = 0;
        for (int i = 0; i < CurrentTheme.Questions.Length; i++)
        {
            if (CurrentTheme.Questions[i].isAnswered == true)
            {
                x++;
            }
        }
        return x;
    }
    public void RenderThemeFillAmount()
    {
        int[] count  = SaveSystem.ReturnThemeFeel();
        for (int i = 0; i < allThemes.Length; i++)
        {
            themesTexts[i].text = allThemes[i].Name + ":" + count[i] + "/ 10";
            themePictures[i].fillAmount = (float)count[i] / 10;
        }
        //for (int i = 0; i < allThemes.Length; i++)
        //{
        //    int x = 0;
        //    foreach (var item in allThemes[i].Questions)
        //    {
        //        if (item.isAnswered)
        //        {
        //            x++;
        //        }
        //    }
        //    themesTexts[i].text = allThemes[i].Name + ":" + x + "/ 10";
        //    themePictures[i].fillAmount =(float) x / 10;
        //}
    }
    public void SavePlayer()
    {
        player.player_name = Name.text;
        SaveSystem.Save(player.player_name);
    }
    public void LoadData()
    {
        string  name = SaveSystem.LoadPlayerName();
        player.player_name = name;
        Name.text =player.player_name;
    }
    public void Quit()
    {
        Application.Quit();
    }
    

}


