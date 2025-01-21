using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
	[SerializeField] private float speed;

	private FixedJoystick fixedJoystick;
	private Rigidbody rigidBody;
	private Animator animator;

	private void OnEnable()
	{
		fixedJoystick = FindObjectOfType<FixedJoystick>();
		rigidBody = gameObject.GetComponent<Rigidbody>();
		animator = gameObject.GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		if (fixedJoystick == null || rigidBody == null || animator == null)
		{
			Debug.LogError("Things are broken");
			return;
		}

		float xVal = fixedJoystick.Horizontal;
		float yVal = fixedJoystick.Vertical;

		Vector3 movement = new Vector3(xVal, 0, yVal);
		rigidBody.velocity = movement * speed;

		float currentSpeed = rigidBody.velocity.magnitude;
		animator.SetFloat("Speed", currentSpeed);

		if (xVal != 0 || yVal != 0)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
		}
	}
}
