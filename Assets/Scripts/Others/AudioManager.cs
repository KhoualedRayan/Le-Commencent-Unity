using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static AudioManager instance;
    public AudioMixerGroup soundEffectMixer;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de AudioManager dans la scène.");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            //On passe à la musique suivante
            PlayNextSound();
        }
    }
    private void PlayNextSound()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        //On crée un empty game object temporaire 
        GameObject tempGo = new GameObject("TempAudio");
        tempGo.transform.position = pos;
        //On lui rajoute une audio source
        AudioSource audioSource = tempGo.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        //On joue le son puis on détruit le game object
        audioSource.Play();
        Destroy(tempGo,clip.length);
        return audioSource;
    }
}
