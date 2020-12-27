using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class exciting_programming{

	public static IEnumerator DoMove(this MonoBehaviour mono, Transform trans, Vector3 target, float time, Action callback) {
		Vector3 distance = target - trans.position;
		for (float f = time; f >= 0.0f; f -= Time.deltaTime) {
			//just like call update()
			trans.Translate(distance * Time.deltaTime);
			//Debug.Log (Time.deltaTime);
			yield return null;
		};
		callback ();
	}

	public static Transform DoMove(this Transform transform, Vector3 target, float time)
	{
		MonoBehaviour mono = transform.GetComponents<MonoBehaviour> () [0];
		mono.StartCoroutine (mono.DoMove(transform, target, time, () => {
			MonoBehaviour.print("end of moving it!");
		}));
		return transform;
	}
}

public class DoMoveIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DoMove (new Vector3 (2.0f, -2.0f, 2.0f), 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}