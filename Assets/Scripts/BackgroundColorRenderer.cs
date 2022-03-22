using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorRenderer : CustomColorRenderer
{
    protected override Dictionary<CustomizableObjectType, int> ShaderIds { get; } = 
        new Dictionary<CustomizableObjectType, int>
        {
            {CustomizableObjectType.Background, Shader.PropertyToID("_BaseColor")}
        };
}