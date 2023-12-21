// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;
using System.Collections;

public class LadderController : MonoBehaviour {
	
	public float speed = 2.0f;
	
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
		
		controller.Move(moveDirection * Time.deltaTime);
	}
}
