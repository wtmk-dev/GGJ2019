using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    [SerializeField]
    private AudioClip aClip;

    private AudioSource audioSource;

    private IEnumerator playNextSong;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() {
        GameController.OnScreenChange += ScreenChanged;
    }

    void OnDisable() {
        GameController.OnScreenChange -= ScreenChanged;
    }

    private void ScreenChanged( Screen gameScreen ){
        if( gameScreen == Screen.Game ){
            audioSource.clip = aClip;
            audioSource.loop = false;
            audioSource.Play();
        
            playNextSong = PlayNextSongRutine( audioSource.clip.length );
		    StartCoroutine( playNextSong );

        }
    }

    private IEnumerator PlayNextSongRutine( float timeToWait ){

		float elapsed = 0;
		do{
			elapsed += Time.deltaTime;
			yield return null;
		}while( elapsed < timeToWait );

		GameController.EndGame();
	}

}
