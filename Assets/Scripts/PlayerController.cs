using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	float gravity = -60.8f;
	public float speed;
	public Boundary boundary;

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical")*speed;

		if (moveVertical == 0.0f)
			moveVertical = gravity * Time.deltaTime*speed;

		Vector3 movement = new Vector3 (moveHorizontal*speed, 0.0f, moveVertical);
		// apply user movement
		GetComponent<Rigidbody>().velocity = movement;

		// check position limits
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);
	}
}