using UnityEngine;
using UnityEngine.Events;

public class CustomizationPanel : MonoBehaviour
{
    [SerializeField] private ColorPicker colorPicker;

    public static readonly UnityEvent<CustomPayload> ColorPickedEvent = new UnityEvent<CustomPayload>();

    private CustomPayload currentPayload;
    
    private void Awake()
    {
        CustomizeButton.CustomizeButtonClickEvent.AddListener(OnCustomizeButtonClicked);
        colorPicker.HueChangedEvent.AddListener(NotifyColorPicked);
    }

    private void OnCustomizeButtonClicked(CustomPayload payload)
    {
        colorPicker.UpdateSlider(payload.Hue);
        colorPicker.gameObject.SetActive(payload.IsSelected);
        currentPayload = payload;
    }

    private void NotifyColorPicked(float hue)
    {
        currentPayload.Hue = hue;
        ColorPickedEvent.Invoke(currentPayload);
    }
}
