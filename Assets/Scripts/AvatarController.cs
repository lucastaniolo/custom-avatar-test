using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AvatarController : CustomColorRenderer
{
    [SerializeField] private Animator avatarAnimator;
    [SerializeField] private AnimationData[] animationsData;
    [SerializeField] private AnimationButtonPanel animationPanel;

    protected override Dictionary<CustomizableObjectType, int> ShaderIds { get; } =
        new Dictionary<CustomizableObjectType, int>
        {
            { CustomizableObjectType.Shirt, Shader.PropertyToID("_ShirtColor")},
            { CustomizableObjectType.Stamp, Shader.PropertyToID("_StampColor")}
        };
    
    protected override void Awake()
    {
        base.Awake();
        animationPanel.SetupButtons(animationsData);
        animationPanel.AnimationButtonClickEvent.AddListener(PlayAnimation);
    }
    
    private void PlayAnimation(int id) => avatarAnimator.SetTrigger(id);
}