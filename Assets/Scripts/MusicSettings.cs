using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSettingsSlider;
    [SerializeField] private AudioSource musicSource;

    private float _musicAndSoundsVolume = 0.5f;
    private void Start()
    {
        musicSource.volume = _musicAndSoundsVolume;
        musicSettingsSlider.value = _musicAndSoundsVolume;
    }

    private void Update()
    {
        musicSource.volume = musicSettingsSlider.value;
    }
}
