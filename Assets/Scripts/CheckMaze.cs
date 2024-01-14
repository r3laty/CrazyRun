using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CheckMaze : MonoBehaviour
{
    [SerializeField] private Button checkButton;
    [SerializeField] private PlayableDirector timeline;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject character;
    public void EndOfCheck()
    {
        cameraController.enabled = true;
        character.GetComponent<Movement>().enabled = true;
        character.GetComponent<Jumping>().enabled = true;
    }
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
        timeline.Play();
        checkButton.gameObject.SetActive(false);

        cameraController.enabled = false;
        character.GetComponent<Movement>().enabled = false;
        character.GetComponent<Jumping>().enabled = false;
    }
}
