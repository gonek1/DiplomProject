using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Theme")]
public class Theme : ScriptableObject
{
    public string Name;
    public Question[] Questions;
}
