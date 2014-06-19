using UnityEngine;
using System.Collections;

public class UEnemyController : MonoBehaviour {

	public AnimationCurve curveX = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0, 1));
	public AnimationCurve curveY = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0, 1));
	public AnimationCurve curveZ = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0, 1));
	public float lenghtX = 1f;
	public float lenghtY = 1f;
	public float lenghtZ = 1f;
	public float speedX=0.1f;
	public float speedY=0.1f;
	public float speedZ=0.1f;
	private float tempoCurva;
	public float startTime = 1f;
	public float repeatTime = 1f;
	public GameObject shot;
	public Transform shotSpawn;


	void Shoot () {

		 Instantiate ( shot, shotSpawn.position, Quaternion.identity);
	}
	void Update() {
		tempoCurva += Time.deltaTime;
		transform.localPosition = new Vector3(curveX.Evaluate(tempoCurva*speedX)*lenghtX, curveY.Evaluate(tempoCurva*speedY)*lenghtY,curveZ.Evaluate(tempoCurva*speedZ)*lenghtZ);
	}

	void Start () {
		InvokeRepeating ( "Shoot", startTime, repeatTime);  
	}
}