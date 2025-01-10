using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DragbleObjectsConfig", menuName = "Scriptable Objects/DragbleObjectsConfig")]
public class DragbleObjectsConfig : ScriptableObject
{
    public List<DragbleObject> dragbleObjects;
}

[Serializable]
public class DragbleObject
{
    public Vector2 rectPosition;
    public GameObject prefab;
}
