using UnityEngine;

public class CharacterControl : MonoBehaviour
{
	[SerializeField] public Move ToMove;
	private void Start()
	{
		ToMove.Speed = 1.5f;
		ToMove.Direction = Vector3.zero;
	}

	private void Update()
	{
		Action();
	}

	private void Action()
	{
		ToMove.Direction = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
		{
			ToMove.Direction += Vector3.forward;
		}

		if (Input.GetKey(KeyCode.S))
		{
			ToMove.Direction += Vector3.back;
		}

		if (Input.GetKey(KeyCode.A))
		{
			ToMove.Direction += Vector3.left;
		}

		if (Input.GetKey(KeyCode.D))
		{
			ToMove.Direction += Vector3.right;
		}
	}
}

