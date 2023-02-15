using UnityEngine;
using Random = UnityEngine.Random;

public class MoveObject : MonoBehaviour
{
	public float speed = 10.0f;
	private Vector3 direction;
	private int newDirection;
	private int oldDirection;
	private float timeSinceLastChange = 0.0f;
	public float minTimeBetweenChanges = 1.0f;

	private void Start()
	{
		direction = new Vector3(1, 0, 0);
		newDirection = 1;
	}

		/*
		objeto é movido na direção atual multiplicando a direção pelo tempo e pela velocidade. Também é verificado se o
		tempo desde a última mudança de direção excede o tempo mínimo entre mudanças. 
		*/

	private void Update()
	{
		

		transform.position += direction * speed * Time.deltaTime;
		timeSinceLastChange += Time.deltaTime;

		if (timeSinceLastChange >= minTimeBetweenChanges)
		{
			oldDirection = newDirection;
			Move(oldDirection);
			timeSinceLastChange = 0.0f;
		}
	}

		/* é verificado se o objeto colidiu com um obstáculo. Se for o caso, o tempo desde a última mudança de 
		direção é definido como o tempo mínimo entre mudanças para evitar que o objeto mude de direção imediatamente após a colisão.
		*/

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Obstacle"))
		{
			timeSinceLastChange = minTimeBetweenChanges; // Não altera a direção por um tempo minimo após a colisão
		}
	}

		/*A função Move é responsável por mudar a direção do objeto. Ele usa a classe Random do Unity para gerar um número aleatório de 1 a 4, que corresponde 
		a uma das quatro direções possíveis. Em seguida, a nova direção é comparada com a direção anterior para garantir que o 
		objeto não volte na mesma direção. Finalmente, a nova direção é mapeada em um vetor Vector3 correspondente e a direção do objeto é atualizada.
		*/

	private void Move(int oldDirection)
	{
		newDirection = Random.Range(1, 5);

		while (newDirection == oldDirection)
		{
			newDirection = Random.Range(1, 5);
		}
		Debug.Log(newDirection);
		switch (newDirection)
		{
			case 1:
				direction = new Vector3(1, 0, 0); // Direita
				break;
			case 2:
				direction = new Vector3(-1, 0, 0); // Esquerda
				break;
			case 3:
				direction = new Vector3(0, 0, 1); // Frente
				break;
			case 4:
				direction = new Vector3(0, 0, -1); // Tras
				break;
		}
	}
}

