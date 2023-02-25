using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils; 

public class WindowPointer : MonoBehaviour
{
    private Vector3 targetPosition;
    public Transform pointerRectTransform;
    public Transform goalPlanet;
    public Transform player;
    private void Awake()
    {
        targetPosition = goalPlanet.position;
    }
    private void Update()
    {
        Debug.Log("target Pos " + targetPosition);
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = player.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
