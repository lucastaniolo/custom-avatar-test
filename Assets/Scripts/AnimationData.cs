using UnityEngine;

[CreateAssetMenu(fileName = "AnimationData", menuName = "ScriptableObjects/AnimationData", order = 1)]
public class AnimationData : ScriptableObject
{
    public Sprite icon;
    public string triggerKey;
}