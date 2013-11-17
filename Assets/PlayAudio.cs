using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

	void DoPlayAudio(float value) {

		audio.volume = value;
		if( !audio.isPlaying ) {
			audio.Play();
		}		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
