using UnityEngine;

[ExecuteInEditMode]
public class Rings : ImageEffectBase {
	public Vector2 center = new Vector2(0, 0);
	public float turningRadius = 1.0f;
	public float turningSpeed = 1.0f;
	public Color color = new Color(1, 1, 1, 1);

	void OnRenderImage(RenderTexture source, RenderTexture destination) {
		material.SetVector("_Center", center);
		material.SetFloat("_TurningSpeed", turningSpeed);
		material.SetFloat("_TurningRadius", turningRadius);
		material.SetColor("_Color", color);

		Graphics.Blit(source, destination, material);
	}
}
