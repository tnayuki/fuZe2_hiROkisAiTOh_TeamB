using UnityEngine;
using System.Collections;

public class CameraTremble : MonoBehaviour {

	[SerializeField]
	private Vector2 m_amount;

	[SerializeField]
	private float m_cycleSpeed;

	[SerializeField]
	private float m_cycleOffset;

	public void FireTremble(float strength) {
		Tremble(0.5f, strength);
	}

	public void Tremble(float sec = 0.5f, float strength = 1.0f) {
		StartCoroutine(_Tremble(sec, strength));
	}

	private IEnumerator _Tremble(float sec, float strength) {

		float tStart = Time.time;

		while( Time.time - tStart < sec ) {
			float t = 1.0f - ((Time.time - tStart) / sec);
			float x = Mathf.Sin (Time.time * m_cycleSpeed) * m_amount.x * t * strength;
			float y = Mathf.Sin ((Time.time + m_cycleOffset) * m_cycleSpeed) * m_amount.y * t * strength;
			
			transform.localPosition = new Vector3(x,y,transform.position.z);
			yield return new WaitForEndOfFrame();
		}

		transform.localPosition = Vector3.zero;
	}
}
