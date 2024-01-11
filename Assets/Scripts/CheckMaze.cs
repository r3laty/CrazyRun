using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CheckMaze : MonoBehaviour
{
    [SerializeField] private Button checkButton;
    [SerializeField] private PlayableDirector playableDirector;
    private void Start()
    {
        checkButton.onClick.AddListener(AnimateThePassage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkButton.gameObject.SetActive(false);
        }
    }
    private void AnimateThePassage()
    {
        playableDirector.Play();
        checkButton.gameObject.SetActive(false);
    }
}
