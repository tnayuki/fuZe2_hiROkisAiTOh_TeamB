using UnityEngine;
using System.Collections;

public class RandomWalk : MonoBehaviour {
	[SerializeField] Transform baseTransform = null;
	[SerializeField] float randomRange = 5.0f;
	[SerializeField] float time_sec = 1.0f;
	[SerializeField] iTween.EaseType easeType =  iTween.EaseType.linear;
	[SerializeField] bool execute = false;	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( execute ) {
			randomWalk();
			execute = false;
		}
	}
	
	void randomWalk() {
		Vector3 pos = new Vector3( random(), random(), random() ) + baseTransform.position;
		iTween.MoveTo(gameObject, iTween.Hash("position", baseTransform.position + pos, "time", time_sec, "easetype", easeType));
	}
	
	float random() {
		return Random.Range( -randomRange, randomRange );
	}
}
