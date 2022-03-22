using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimationButton : MonoBehaviour
{
    [SerializeField] private Button animationButton;
    [SerializeField] private Image icon;
    
    public readonly UnityEvent<int> AnimationButtonClickEvent = new UnityEvent<int>();

    private AnimationData animationData;
    private int animationHash;
    
    private void Awake()
    {
        animationButton.onClick.AddListener(AnimationButtonClicked);
    }

    public void Setup(AnimationData data)
    {
        animationData = data;
        animationHash = Animator.StringToHash(animationData.triggerKey);
        icon.sprite = animationData.icon;
    }

    private void AnimationButtonClicked()
    {
        AnimationButtonClickEvent.Invoke(animationHash);
    }
}
