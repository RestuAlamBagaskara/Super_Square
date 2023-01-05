using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            musicSource.clip = musicClips[0];
            musicSource.Play();
        }
        else if (scene.buildIndex == 1)
        {
            musicSource.clip = musicClips[1];
            musicSource.Play();
        }
    }

    public void PlaySfx(int clip)
    {
        sfxSource.PlayOneShot(sfxClips[clip]);
    }
}
