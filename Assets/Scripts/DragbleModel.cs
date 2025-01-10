using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragbleModel
{
    private readonly RectTransform _contentRect;

    public Action<Vector2> OnPositionChanged;
    public Action<float> OnSpeedChanged;

    private const float SPEED_OF_FALL = -300f;
    public DragbleModel(RectTransform contentRect)
    {
        _contentRect = contentRect;
    }
    public void CalculatePosition(PointerEventData eventData)
    {
        Vector2 newPosition = eventData.position;
        newPosition.x -= Screen.width / 2;
        newPosition.y -= Screen.height / 2;
        newPosition.x -= _contentRect.anchoredPosition.x;
        OnPositionChanged?.Invoke(newPosition);
    }
    public void AllowToFall(bool isAllowed)
    {
        if (isAllowed)
            SetSpeedOfFall(SPEED_OF_FALL);
        else
            SetSpeedOfFall(0f);
    }

    private void SetSpeedOfFall(float speed)
    {
        OnSpeedChanged?.Invoke(speed);
    }
}
