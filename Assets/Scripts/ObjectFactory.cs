using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private RectTransform _contentRect;

    public DragblePresenter CreateObject(DragbleObject config)
    {
        GameObject gameObject = Instantiate(config.prefab, transform.parent);
        DragbleView view = gameObject.GetComponent<DragbleView>();
        DragbleModel model = new DragbleModel(_contentRect);
        DragblePresenter presenter = new DragblePresenter(model, view);
        view.Initialize(presenter, config.rectPosition);
        return presenter;
    }
}
