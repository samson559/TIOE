﻿using UnityEngine;
using System.Collections;

public class EnviroGear : MonoBehaviour {
	[SerializeField] private float rotrate;
	private Transform gearTrans;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (rotrate * (Vector3.left * -90));
	}
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.CompareTag ("StickyAura")) {
			gearTrans = col.gameObject.transform;
			gearTrans.Rotate (-rotrate * (Vector3.forward * -90));
			gearTrans.RotateAround (transform.position, Vector3.back, 360 * rotrate);
		}

	}
	void OcCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("StickyAura")) {
			gearTrans = col.gameObject.transform;
		}
	}
	void OcCollisionExit(Collision col)
	{
		gearTrans = null;
	}

}
