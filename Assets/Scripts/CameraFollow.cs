using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 10f;
    public Transform target;
    public float godViewOrthographicSize = 35f;
    public Transform levelTransform;
    public KeyCode toggleGodViewKey = KeyCode.Q;
    public float godViewZoomSpeed = 2.5f;
    public float playerZoomSpeed = 5f;

    private bool godViewMode = false;
    private float previousOrthographicSize;
    private Vector3 previousCameraPosition;

    private void Start()
    {
        // Initialize previousOrthographicSize to default value
        previousOrthographicSize = Camera.main.orthographicSize;
        previousCameraPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleGodViewKey))
        {
            godViewMode = !godViewMode; // toggle god view mode

            if (godViewMode)
            {
                // Save current camera position
                previousCameraPosition = transform.position;
            }
        }

        if (godViewMode)
        {
            // Switch to god view mode
            float currentOrthographicSize = Camera.main.orthographicSize;
            Camera.main.orthographicSize = Mathf.Lerp(
                currentOrthographicSize,
                godViewOrthographicSize,
                godViewZoomSpeed * Time.deltaTime
            );
            Vector3 levelCenter = levelTransform.position;
            levelCenter.z = -50f;

            // Move camera towards level center
            transform.position = Vector3.Lerp(
                transform.position,
                levelCenter,
                godViewZoomSpeed * Time.deltaTime
            );
        }
        else if (target)
        {
            // Follow the target
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -50f);
            transform.position = Vector3.Slerp(
                transform.position,
                newPos,
                playerZoomSpeed * Time.deltaTime
            );
            float currentOrthographicSize = Camera.main.orthographicSize;
            Camera.main.orthographicSize = Mathf.Lerp(
                currentOrthographicSize,
                previousOrthographicSize,
                playerZoomSpeed * Time.deltaTime
            );
        }
    }
}
