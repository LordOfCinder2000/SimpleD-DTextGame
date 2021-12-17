using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [SerializeField] string storyTitle;
    [SerializeField] Sprite storyImage;
    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }
    public string GetTitleStory()
    {
        return storyTitle;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public Sprite GetStateImage()
    {
        return storyImage;
    }
}
