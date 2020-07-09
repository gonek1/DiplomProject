using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New question")]
public class Question : ScriptableObject
{
    [TextArea]
    public string Name;
    public bool isAnswered;
    public string Answer;
}
