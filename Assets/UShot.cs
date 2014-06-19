using UnityEngine;
using System.Collections;

public class UShot : MonoBehaviour {

	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		Destroy ( gameObject, 2.0f );
		}
}
