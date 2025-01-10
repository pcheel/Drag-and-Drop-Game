using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragblePresenter : IDisposable
{
    private readonly DragbleModel _model;
    private readonly DragbleView _view;

    public DragblePresenter(DragbleModel model, DragbleView view)
    {
        _model = model;
        _view = view;
        _model.OnPositionChanged += ChangeRectPosition;
        _model.OnSpeedChanged += SetSpeed;
    }
    public void CalculatePosition(PointerEventData eventData)
    {
        _model.CalculatePosition(eventData);
    }
    public void ChangeRectPosition(Vector2 newPosition)
    {
        _view.ChangePosition(newPosition);
    }
    public void AllowToFall(bool isAllowed)
    {
        _model.AllowToFall(isAllowed);
    }
    public void SetSpeed(float speed)
    {
        _view.SetSpeed(speed);
    }
    public void Dispose()
    {
        _model.OnPositionChanged -= ChangeRectPosition;
        _model.OnSpeedChanged -= SetSpeed;
    }

}
