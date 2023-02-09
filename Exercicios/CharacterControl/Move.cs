using UnityEngine;

public class Move : MonoBehaviour
{
	public Move(float speed, Vector3 direction)
	{
		Speed = speed;
		Direction = direction;
	}

	public float Speed { get; set; }

	public Vector3 Direction { get; set; }

	private void Update()
	{
		Translate(translation: Direction * Speed * Time.deltaTime);

	}

	void Translate(Vector3 translation)
	{
		transform.position = transform.position + translation;
	}
}
