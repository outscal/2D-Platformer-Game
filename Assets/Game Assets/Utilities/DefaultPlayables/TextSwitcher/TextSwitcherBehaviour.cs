using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class TextSwitcherBehaviour : PlayableBehaviour
{
    public Color color = Color.white;
    public int fontSize = 14;
    public string text;
}
