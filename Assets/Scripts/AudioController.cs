using UnityEngine;
using UnityEngine.Audio;

//make class need audio and customizable in editor
[RequireComponent(typeof(AudioSource))]
[System.Serializable]
public class Sound
{
    // variables for sound effect name and associated data
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
    public static float[] samples = new float[512]; //for pontential work with different frequencies
    public AudioMixerGroup grouped; //audiomixer needed for the volume slider in settings
    public bool isLoop = false; //looping the sound effect/music
    AudioSource a; //the sound effect asset

    //sets the sound effect's different parameters
    public void SetSound(AudioSource source)
    {
        a = source;
        a.clip = clip;
        a.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        a.outputAudioMixerGroup = grouped;
        a.loop = isLoop;
    }

    //A different play that can include random variables to make it so repetitive sounds dont sound the same every time
    public void Play()
    {
        a.pitch = pitch * (1 + Random.Range(-ranPit/2f, ranPit/2f));
        a.volume = volume * (1 + Random.Range(-ranVol/2f, ranVol/2f));
        a.Play();
    }
    //stops the sound
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
    Sound[] sounds; // array of sound effects

    // destroys audiocontroller if there is an instance of it that is not associated with this class
    // also allows for same audiocontroller to remain between scenes
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

    //assigning the sound effects 
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

    //plays the sound effects that are to be played
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
    //stops the sound effects that are to be played
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
