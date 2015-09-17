using UnityEngine;
using System.Collections;

public class EnviroGear : MonoBehaviour {
	[SerializeField] private float rotrate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (rotrate * (Vector3.forward * -90));
	}
	void OnCollisionStay2D(Collision2D col)
	{
		Debug.Log (col.gameObject.name + "Hit me");
		if (col.gameObject.CompareTag ("StickyAura")) {
			col.gameObject.transform.RotateAround(gameObject.transform.position,(Vector3.forward * -90),rotrate*100);
		}
	}

}
