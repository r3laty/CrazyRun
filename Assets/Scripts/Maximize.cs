using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maximize : MonoBehaviour
{
    private Vector2 _touchStartPos1;
    private Vector2 _touchStartPos2;
    private float _initialDistance;

    [SerializeField] private float pinchZoomSpeed = 0.5f;
    private void Update()
    {
        DetectPinchZoom();
    }
    private void DetectPinchZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                _touchStartPos1 = touch1.position;
                _touchStartPos2 = touch2.position;
                _initialDistance = Vector2.Distance(_touchStartPos1, _touchStartPos2);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float pinchAmount = currentDistance - _initialDistance;

                if (Mathf.Abs(pinchAmount) > pinchZoomSpeed)
                {
                    if (pinchAmount > 0)
                    {
                        Debug.Log("Жест увеличение");
                    }
                    else
                    {
                        Debug.Log("Жест уменьшение");
                    }

                    _initialDistance = currentDistance;
                }
            }
        }
    }
}
