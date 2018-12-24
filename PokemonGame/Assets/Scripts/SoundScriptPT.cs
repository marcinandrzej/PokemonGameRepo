using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    DAMAGE = 0,
    DESTROY = 1,
    HEAL = 2,
    SWAP = 3,
    TRANSFORM = 4,
    UNDO = 5
};

public class SoundScriptPT : MonoBehaviour
{
    public List<AudioClip> audioClips;
	// Use this for initialization
	void Start ()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().playOnAwake = false;
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundLevelPT");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(Sounds sound)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClips[(int)sound]);
    }
}
