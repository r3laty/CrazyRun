using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time = 45;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private GameObject losePanel;

    private float _timeLeft = 0f;
    private bool _timerOn = false;

    private void Start()
    {
        _timeLeft = time;
        _timerOn = true;
    }

    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
            }
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            timerText.gameObject.SetActive(false);
            losePanel.SetActive(true);
        }

        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = seconds.ToString() + " сек.";
    }
}
