using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; //Pour la musique
    [SerializeField] AudioSource SFXSource; //Pour les effets sonores

    public AudioClip backgroundMusic; //Morceau du niveau
    public AudioClip damageSFX; 
	public AudioClip finishSFX; 
    public AudioClip coffreSFX;
    public AudioClip cleSFX;
    public AudioClip doorSFX;
    public AudioClip coinsSFX;
    public AudioClip clockSFX;
    public AudioClip arrowSFX;
    void Start()
    {
		if(musicSource != null){ //Si une musique de fond a été définie, on la joue
			musicSource.clip = backgroundMusic; //Joue la musique de fond
			musicSource.Play();
		}
    }

	//Permet de jouer un effet sonore
    public void PlaySFX(AudioClip clip)
    {
        Debug.Log("Play");
		SFXSource.PlayOneShot(clip);
    }
	
	public void StopMusic(){
		musicSource.Stop();
	}
}
