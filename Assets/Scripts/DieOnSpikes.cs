using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnSpikes : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            losePanel.SetActive(true);
        }
    }
    public void OnYesButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnNoButton()
    {
        Application.Quit();
    }
}
