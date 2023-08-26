using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	int selectwaypoint;
	private Transform target;
	private int wavepointIndex = 0;
	public Transform body;
	private Enemy enemy;
	public float speed = 5;
	void Start()
	{
		selectwaypoint = Random.RandomRange(0, 2);



		enemy = GetComponent<Enemy>();
		if (selectwaypoint == 0)
		{
			target = Waypoints.points[0];
		}
		if (selectwaypoint == 1)
		{
			target = watpointssecond.points[0];


		}
	}

	void Update()
	{
		
			Vector3 dir = target.position - transform.position;
			transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

			if (Vector3.Distance(transform.position, target.position) <= 0.4f)
			{
				GetNextWaypoint();
			}


			// Smoothly rotate towards the target point.

			var targetRotation = Quaternion.LookRotation(target.transform.position - body.transform.position);


			body.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);


			enemy.speed = enemy.startSpeed;
		
	}

	void GetNextWaypoint()
	{
		if (selectwaypoint == 0)
		{

			if (wavepointIndex >= Waypoints.points.Length - 1)
			{
				EndPath();
				return;
			}

			wavepointIndex++;
			target = Waypoints.points[wavepointIndex];
		}
		else if (selectwaypoint == 1)
		{
			if (wavepointIndex >= watpointssecond.points.Length - 1)
			{
				EndPath();
				return;
			}

			wavepointIndex++;
			target = watpointssecond.points[wavepointIndex];

		}
	}

	void EndPath()
	{
		if (PlayerStats.Lives > 0)
		{
			PlayerStats.Lives--;
			castleeffect.instance.playeffect();
		}
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
