using System.Collections.Generic;
using UnityEngine;

public abstract class CustomColorRenderer : MonoBehaviour
{
    [SerializeField] private Renderer meshRenderer;

    protected abstract Dictionary<CustomizableObjectType, int> ShaderIds { get; }

    protected virtual void Awake()
    {
        CustomizationPanel.ColorPickedEvent.AddListener(UpdateColor);
    }

    private void UpdateColor(CustomPayload payload)
    {
        if (ShaderIds.TryGetValue(payload.CustomizableObjectType, out var id))
        {
            Color.RGBToHSV(meshRenderer.material.GetColor(id), out _, out var s, out var v);
            meshRenderer.material.SetColor(id, Color.HSVToRGB(payload.Hue, s, v));
        }
    }
}