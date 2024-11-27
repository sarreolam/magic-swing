using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private List<AudioSource> musicAudioSources = new List<AudioSource>();
    private List<AudioSource> sfxAudioSources = new List<AudioSource>();

    private static SoundManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializeVolumeSettings();


        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeChanged);
    }

    void Start()
    {

        CacheAudioSources();
        ApplyVolumes();
    }

    private void OnEnable()
    {

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {

        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        CacheAudioSources();

        if (musicVolumeSlider == null || sfxVolumeSlider == null)
        {
            musicVolumeSlider = FindObjectOfType<Slider>();
            sfxVolumeSlider = FindObjectOfType<Slider>();
        }
        ApplyVolumes();
    }

    private void InitializeVolumeSettings()
    {

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1f);
        }

        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void CacheAudioSources()
    {
        musicAudioSources.Clear();
        sfxAudioSources.Clear();


        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("MusicAudioSource");
        foreach (GameObject obj in musicObjects)
        {
            AudioSource source = obj.GetComponent<AudioSource>();
            if (source != null)
            {
                musicAudioSources.Add(source);
            }
        }


        GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("SfxAudioSource");
        foreach (GameObject obj in sfxObjects)
        {
            AudioSource source = obj.GetComponent<AudioSource>();
            if (source != null)
            {
                sfxAudioSources.Add(source);
            }
        }
    }

    private void OnMusicVolumeChanged(float value)
    {
        foreach (AudioSource source in musicAudioSources)
        {
            source.volume = value;
        }

        PlayerPrefs.SetFloat("musicVolume", value);
    }

    private void OnSfxVolumeChanged(float value)
    {

        foreach (AudioSource source in sfxAudioSources)
        {
            source.volume = value;
        }


        PlayerPrefs.SetFloat("sfxVolume", value);
    }

    private void ApplyVolumes()
    {

        float musicVolume = PlayerPrefs.GetFloat("musicVolume");
        float sfxVolume = PlayerPrefs.GetFloat("sfxVolume");

        if (musicVolumeSlider != null)
            musicVolumeSlider.value = musicVolume;
        if (sfxVolumeSlider != null)
            sfxVolumeSlider.value = sfxVolume;
        OnMusicVolumeChanged(musicVolume);
        OnSfxVolumeChanged(sfxVolume);
    }
}
