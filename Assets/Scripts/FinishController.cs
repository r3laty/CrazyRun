using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
        }
    }
}
