using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeRotation : MonoBehaviour, IDragHandler
{
    [SerializeField] private float sensitivity = 50f;
    [SerializeField] private Transform rotationTarget;
    [SerializeField] private CanvasScaler scaler;
    
    private float scaledSensitivity;

    private void Awake()
    {
        scaledSensitivity = sensitivity * scaler.referenceResolution.x / Screen.width;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rotationTarget.eulerAngles += new Vector3(0, -eventData.delta.x * scaledSensitivity * Time.deltaTime, 0);
    }
}
