
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Patrulha : MonoBehaviour
{
	enum curretEnemyState
	{
		Stopped,
		Patrolling
	}

	enum PatrolDirection
	{
		Left,
		Right,
	}


	[Serializable]
	struct PatrolData
	{
		public float PatrolDuration;
		public float MoveSpeed;
		public float MoveDirectionDuration;

	}

	PatrolDirection currentPatrolDirection;

	[SerializeField]
	curretEnemyState enemyState;

	[SerializeField] List<PatrolData> listPatrolData = new List<PatrolData>();

	float startPatrolTime;

	float directionChangeTime;
	private int typePatrol;

	public Text patrol;

	void Start()
	{
		enemyState = curretEnemyState.Stopped;
		currentPatrolDirection = PatrolDirection.Right;
		directionChangeTime = 0;
		
		listPatrolData.Add(new PatrolData()
		{
			PatrolDuration = Random.Range(2, 5),
			MoveSpeed = Random.Range(2, 8),
			MoveDirectionDuration = Random.Range(1.5f, 2.5f )
		});
		

		
	}

	private void AtualizaTexto()
	{
		patrol.text = $"Tempo: {listPatrolData[typePatrol].PatrolDuration} \n" +
					$"Direção: {currentPatrolDirection} \n" +
					$"Velocidade: {listPatrolData[typePatrol].MoveSpeed} ";
	}
		void Update()
	{
		switch (enemyState)
		{
			default:
			case curretEnemyState.Stopped:

				if (Input.GetKeyDown(KeyCode.Space))
				{
					enemyState = curretEnemyState.Patrolling;
					startPatrolTime = Time.time;
				}
				break;

			case curretEnemyState.Patrolling:

				if (Time.time > startPatrolTime + listPatrolData[typePatrol].PatrolDuration)
				{
					enemyState = curretEnemyState.Stopped;
					startPatrolTime = Time.time;
				}
				else
				{
					PatrolRoutine(listPatrolData[typePatrol]);
				}

				break;

			
		}

		AtualizaTexto();

	}

	private void PatrolRoutine(PatrolData patrolData)
	{
		directionChangeTime += Time.deltaTime;

		switch (currentPatrolDirection)
		{
			case PatrolDirection.Right:

				ChangePatrolDirection(patrolData, PatrolDirection.Left);

				Translate(new Vector3(patrolData.MoveSpeed * Time.deltaTime, 0, 0));

				break;

			case PatrolDirection.Left:

				ChangePatrolDirection(patrolData, PatrolDirection.Right);

				Translate(new Vector3(-patrolData.MoveSpeed * Time.deltaTime, 0, 0));
				break;
		}

	}

	private void ChangePatrolDirection(PatrolData patrolData, PatrolDirection newPatrolDirection)
	{
		if (directionChangeTime > patrolData.MoveDirectionDuration)
		{
			currentPatrolDirection = newPatrolDirection;
			directionChangeTime = 0;
		}

	}

	void Translate(Vector3 traslation)
	{
		transform.position = transform.position + traslation;
	}
}

