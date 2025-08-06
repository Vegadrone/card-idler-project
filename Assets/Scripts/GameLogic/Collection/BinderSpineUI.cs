using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BinderSpineUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //[SerializeField] private Image spineImage;
    [SerializeField] private float hoverOffset = 10f;
    [SerializeField] private float hoverSpeed = 5f;

    public event Action<SetSO> OnClick;

    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private bool isHovering = false;
    private SetSO currentSet;

    public void Init(SetSO set)
    {
        currentSet = set;
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        Vector2 target = isHovering ? originalPosition + Vector2.up * hoverOffset : originalPosition;
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, target, Time.deltaTime * hoverSpeed);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"[BinderSpineUI - OnPointerClick] Clicked spine for set: {currentSet?.SetId}");
        OnClick?.Invoke(currentSet);
    }
}

