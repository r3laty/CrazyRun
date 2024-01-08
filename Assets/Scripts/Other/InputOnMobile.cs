using UnityEngine;

public class InputOnMobile : MonoBehaviour
{
    [SerializeField] private float minSwipeLength = 100;
    [SerializeField] private float maxVerticalOffset = 50;

    private Vector2 _fingerDownPosition;
    private Vector2 _fingerUpPosition;
    private void Update()
    {
        DetectSwipe();
    }
    private void DetectSwipe()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }
    }
    private void CheckSwipe()
    {
        float swipeLength = Mathf.Abs(_fingerUpPosition.x - _fingerDownPosition.x);
        float verticalOffset = Mathf.Abs(_fingerUpPosition.y - _fingerDownPosition.y);

        if (swipeLength >= minSwipeLength && verticalOffset <= maxVerticalOffset)
        {
            if (_fingerUpPosition.x > _fingerDownPosition.x)
            {
                Debug.Log("Свайп вправо");
            }
        }
    }
}
