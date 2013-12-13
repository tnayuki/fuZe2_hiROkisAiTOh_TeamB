using UnityEngine;

public class PlayAudio : MonoBehaviour {

	void FirePlayAudio(float value) {
		if(!audio.isPlaying) {
			audio.Play();
		}		
	}
	
}
