using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Tooltip("—сылка на персонажа, вокруг которого нужно вращать камеру")][SerializeField] private Transform target;
    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private float rotationSpeed = 0.5f;

    [Tooltip("—сылка на GraphicRaycaster вашего Canvas")][SerializeField] private GraphicRaycaster raycaster;

    public void CheckAround()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!IsPointerOverUIObject(touch.position))
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    cinemachine.Follow = null;

                    float deltaX = touch.deltaPosition.x;

                    RotateCamera(deltaX);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                cinemachine.Follow = target;
            }
        }

    }
    private void Update()
    {
        CheckAround();
    }

    private void RotateCamera(float delta)
    {
        Vector3 offset = transform.position - target.position;

        Quaternion rotation = Quaternion.Euler(0, delta * rotationSpeed, 0);

        offset = rotation * offset;

        transform.position = target.position + offset;

        transform.LookAt(target.position);
    }
    private bool IsPointerOverUIObject(Vector2 touchPosition)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
