using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    private AudioSource source;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1.0f;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;
    public bool loop = false;
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1+Random.Range(-randomVolume/2f, randomVolume/2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f)); 
        source.Play();
    }
    public void Stop()
    {
        
        source.Stop();
    }
}
public class AudioManager : MonoBehaviour
{   
    [SerializeField]
    Sound[] sounds;

    //apenas instaciar como um unico compoment
    public static AudioManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    /*public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }*/
    private void Start()
    {
        for( int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
            
        }
    }
    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.Equals(_name))
            {
                sounds[i].Play();
                return;
            }
        }
        // no find the song
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }
    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.Equals(_name))
            {
                sounds[i].Stop();
                return;
            }
        }
        // no find the song
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }
}
