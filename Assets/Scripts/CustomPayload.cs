using System;

public enum CustomizableObjectType
{
    Shirt,
    Stamp,
    Background
}

[Serializable]
public class CustomPayload
{
    public CustomizableObjectType CustomizableObjectType;
    public float Hue { get; set; }
    public bool IsSelected { get; private set; }

    public CustomPayload ToggleSelection()
    {
        IsSelected = !IsSelected;
        return this;
    }

    public void Deselect() => IsSelected = false;
}