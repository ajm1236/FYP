using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
[System.Serializable]
public class Sound
{
    public string soundName;
    [Range(0f,1f)]
    public float volume = 1f;
    [Range(0f, 2f)]
    public float pitch = 1f;
    [Range(0f, 1f)]
    public float ranPit = 0.1f;
    [Range(0f, 1f)]
    public float ranVol = 0.1f;
    public AudioClip clip;
    public static float[] samples = new float[512];
    public AudioMixerGroup grouped;

    public bool isLoop = false;

    AudioSource a;

    public void SetSound(AudioSource source)
    {
        a = source;
        a.clip = clip;
        a.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        a.outputAudioMixerGroup = grouped;
        a.loop = isLoop;
    }

    public void Play()
    {
        a.pitch = pitch * (1 + Random.Range(-ranPit/2f, ranPit/2f));
        a.volume = volume * (1 + Random.Range(-ranVol/2f, ranVol/2f));
        a.Play();
    }
    public void Stop()
    {
        a.Stop();
    }
}

public class AudioController : MonoBehaviour
{

    //singleton
    public static AudioController controller;
    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if(controller != null)
        {
            if(controller != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            controller = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            //alows me to see all the sounds playing as gameobjects in hierarchy
            GameObject sound = new GameObject("Sound_" + i + "_" + sounds[i].soundName);
            sound.transform.SetParent(this.transform);
            sounds[i].SetSound(sound.AddComponent<AudioSource>());
        }

    }

    public void Boombox(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].soundName == name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
    public void ByeBoombox(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].soundName == name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

}
