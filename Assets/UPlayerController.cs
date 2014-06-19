using UnityEngine;
using System.Collections;
[System.Serializable]
public class Done_Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class UPlayerController : MonoBehaviour
{
	public Done_Boundary boundary;
	public float speed;
	public float tilt;
	public Transform shotSpawn;
	public GameObject bullet;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float moveHorizontal=0f;
		float moveVertical=0f;

		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		//if ( (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Time.time > nextFire) Shoot();

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.velocity = movement * speed;
		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}
	void Shoot(){
		Instantiate(bullet, shotSpawn.position, Quaternion.identity );
		nextFire = Time.time + fireRate;
	}
}

