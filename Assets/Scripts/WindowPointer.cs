using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class WindowPointer : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    [SerializeField] private Sprite arrow;
    [SerializeField] private Sprite cross;
    private Vector3 targetPosition;
    public Transform pointerRectTransform;
    public Transform goalPlanet;
    public Transform player;
    private Image pointerImage;
    public List<Transform> backupGoals;
    private void Awake()
    {
        targetPosition = goalPlanet.position;
        pointerImage = transform.Find("Pointer").GetComponent<Image>();

    }
    private void Update()
    {
        //Debug.Log("target Pos " + targetPosition);
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = player.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);


        float borderSize = 70f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;
        //Debug.Log("IsOffScreen "+isOffScreen);
        if (goalPlanet != null)
        {
            if (isOffScreen)
            {
                pointerImage.sprite = arrow;
                Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
                if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
                if (cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
                if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
                if (cappedTargetScreenPosition.y >= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;
                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
            else
            {
                pointerImage.sprite = cross;
                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
        }
        else
        {
            if (backupGoals.Count > 0)
            {
                if (backupGoals[0] != null)
                {
                    goalPlanet = backupGoals[0];
                    targetPosition = backupGoals[0].position;
                }
                backupGoals.RemoveAt(0);
            }
        }
    }

}


