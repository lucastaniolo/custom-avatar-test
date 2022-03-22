using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CustomizeButton : MonoBehaviour
{
    [SerializeField] private CustomPayload customPayload;
    [SerializeField] private Button customizeButton;
    [SerializeField] private Image background;
    [SerializeField] private Color selectedColor;

    public static readonly UnityEvent<CustomPayload> CustomizeButtonClickEvent = new UnityEvent<CustomPayload>();

    private void Awake()
    {
        customizeButton.onClick.AddListener(ChangeAvatarColorButtonClicked);
        CustomizeButtonClickEvent.AddListener(UpdateSelection);
    }

    private void UpdateSelection(CustomPayload payload)
    {
        if (customPayload == payload) return;

        customPayload.Deselect();
        UpdateView();
    }

    private void ChangeAvatarColorButtonClicked()
    {
        CustomizeButtonClickEvent.Invoke(customPayload.ToggleSelection());
        UpdateView();
    }
    
    private void UpdateView() => background.color = customPayload.IsSelected ? selectedColor : Color.white;
}