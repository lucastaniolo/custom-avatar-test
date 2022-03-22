using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class HueChangedEvent : UnityEvent<float> { }

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private Slider hueSlider;
    [SerializeField] private Image hueBackground;

    [HideInInspector] public HueChangedEvent HueChangedEvent = new HueChangedEvent();
    
    private void Awake()
    {
        var colors = new[] { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta, Color.red };
        var newTexture = new Texture2D(colors.Length, 1);
        newTexture.SetPixels(colors);
        newTexture.Apply();

        hueBackground.sprite = Sprite.Create(newTexture,
            new Rect(Vector2.zero, new Vector2(colors.Length, 1)),
            Vector2.one * 0.5f);

        hueSlider.onValueChanged.AddListener(HueChangedEvent.Invoke);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpdateSlider(float hue) => hueSlider.SetValueWithoutNotify(hue);
}