using UnityEngine;
using System.Collections;

public class EnviroGear : MonoBehaviour {
	[SerializeField] private float rotrate;
	private Transform gearTrans;
	float radius;
	// Use this for initialization
	void Start () {
		radius = gameObject.GetComponent<Collider> ().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (rotrate * (Vector3.left * -90));
	}
	void OnCollisionStay(Collision col)
	{

		if (col.gameObject.CompareTag ("StickyAura")) {
		
			/*
			gearTrans = col.gameObject.transform;
			gearTrans.Rotate (-rotrate * (Vector3.forward * -90));
			gearTrans.RotateAround (transform.position, Vector3.back, 360 * rotrate);
			*/
		}

	}
    /*
	void OnCollisionEnter(Collision col)
	{
		Debug.Log (col.gameObject.transform.name+","+transform.name);
		if (col.gameObject.CompareTag ("StickyAura")) {
			col.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			col.gameObject.transform.SetParent (transform);
			//	gearTrans = col.gameObject.transform;
		}
	}
	void OnCollisionExit(Collision col)
	{
		Debug.Log ("leaving");
		if(col.gameObject.CompareTag("Player")){
		col.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		col.gameObject.transform.SetParent (null);
		}
		//gearTrans = null;
	}
    */

}
