using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{

	public float minDistance = 1.0f;
	public float maxDistance = 4.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;

	public float dis_ray;

	// Use this for initialization
	void Awake()
	{
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}

	// Update is called once per frame
	void Update()
	{

		Vector3 desiredCameraPos = transform.TransformPoint(dollyDir * maxDistance);
		RaycastHit hit;

		if (Physics.Linecast(transform.position, desiredCameraPos, out hit))
		{
			Debug.DrawLine(transform.position, desiredCameraPos);
			distance = Mathf.Clamp((hit.distance * dis_ray), minDistance, maxDistance);
			Debug.Log("hit");
		}
		else
		{
			distance = maxDistance;
		}

		transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}