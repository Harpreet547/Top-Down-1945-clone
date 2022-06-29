using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		if(target == null) target = GameObject.FindGameObjectWithTag("Player"); 
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (Time.deltaTime * interpVelocity * targetDirection.normalized); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

		}
	}
}