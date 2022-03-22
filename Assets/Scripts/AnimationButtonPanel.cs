using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationButtonPanel : MonoBehaviour
{
    [SerializeField] private AnimationButton buttonPrefab;

    // Unnecessarily complex bubbling
    public readonly UnityEvent<int> AnimationButtonClickEvent = new UnityEvent<int>();

    private readonly List<AnimationButton> buttons = new List<AnimationButton>();
    
    public void SetupButtons(AnimationData[] animations)
    {
        for (var i = 0; i < animations.Length; i++)
        {
            buttons.Add(Instantiate(buttonPrefab, transform));
            buttons[i].Setup(animations[i]);
            buttons[i].AnimationButtonClickEvent.AddListener(AnimationButtonClickEvent.Invoke);
        }
    }
}
