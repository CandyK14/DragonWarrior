using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        //Keep this object even when we go to new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate gameobjects
        else if (instance != null && instance != this)
            Destroy(gameObject);

        //Assign initial volumes
        UpdateVolumeFromPrefs();
    }
    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }

    private void UpdateVolumeFromPrefs()
    {
        int soundVolume = PlayerPrefs.GetInt("soundVolume", 100);
        int musicVolume = PlayerPrefs.GetInt("musicVolume", 100);

        soundSource.volume = soundVolume / 100f;
        musicSource.volume = musicVolume / 100f;
    }

    public void ChangeSoundVolume(int change)
    {
        ChangeVolume("soundVolume", change, soundSource);
    }

    public void ChangeMusicVolume(int change)
    {
        ChangeVolume("musicVolume", change, musicSource);
    }

    private void ChangeVolume(string volumeName, int change, AudioSource source)
    {
        int currentVolume = PlayerPrefs.GetInt(volumeName, 100);
        currentVolume = Mathf.Clamp(currentVolume + change, 0, 100);

        PlayerPrefs.SetInt(volumeName, currentVolume);
        source.volume = currentVolume / 100f;
    }
}