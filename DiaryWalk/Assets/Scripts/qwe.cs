using UnityEngine;
using System.Collections;

public class qwe : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	public float velocity;
	public float accelaration;


	// Update is called once per frame
	void Update()
	{
		MoveToTarget();
	}

	public void MoveToTarget()
	{
		
		target = GameObject.Find("Player").transform;

		velocity = (velocity + Time.deltaTime);
		
		float distance = Vector3.Distance(target.position, transform.position);
		
		if (distance <= 8f)
		{
			this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
												   transform.position.y + (direction.y * velocity));
		}
		
		else
		{
			velocity = 0.0f;
		}
	}
}