using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragbleView : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    private RectTransform _rectTransform;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private DragblePresenter _presenter;
    private bool _isFalling = true;

    public void OnDrag(PointerEventData eventData)
    {
        _presenter.CalculatePosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isFalling = true;
        _presenter.AllowToFall(true);
        SizeAnimatation(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isFalling = false;
        _presenter.AllowToFall(false);
        SizeAnimatation(true);
    }
    public void Initialize(DragblePresenter presenter, Vector2 rectPosition)
    {
        _presenter = presenter;
        _rectTransform.anchoredPosition = rectPosition;
        _presenter.AllowToFall(true);
    }
    public void ChangeVelocity(Vector2 newVelocity)
    {
        _rigidbody.velocity = newVelocity;
    }
    public void ChangePosition(Vector2 newPosition)
    {
        _rectTransform.anchoredPosition = newPosition;
    }
    public void SetSpeed(float speed)
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.y = speed;
        _rigidbody.velocity = velocity;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!_isFalling)
            return;

        if (_collider.IsTouchingLayers())
        {
            _presenter.AllowToFall(false);
            _isFalling = false;
        }
    }
    private void SizeAnimatation(bool isIncreased)
    {
        if (isIncreased)
            _rectTransform.localScale = new Vector3(1.1f, 1.1f, 1f);
        else
            _rectTransform.localScale = Vector3.one;

    }
}
