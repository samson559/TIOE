using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class GearGuyCtrl1 : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching xratement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
		[SerializeField] private GameObject stickyAura;
		//[SerializeField] private WheelCollider wheelCol;
		//[SerializeField] private Transform mesh;

        private bool m_Grounded;
		private bool engaged;

            // Whether or not the player is grounded.
		private float groundDist;
        private Rigidbody m_Rigidbody;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private Transform m_GroundCheck;
        private void Awake()
        {
			groundDist = gameObject.GetComponent<Collider> ().bounds.extents.y;
            // Setting up references.
            m_Rigidbody = GetComponent<Rigidbody>();
			stickyAura.SetActive (false);
        }

		public void FixedUpdate()
		{
			m_Grounded = Physics.Raycast(transform.position,Vector3.down,groundDist+.1f);
			
			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			/*

			*/

		}


		public void Move(float xrate,float yrate, bool crouch, bool jump)
        {
			// If the player should jump...
			if (m_Grounded && jump&&transform.parent==null)
			{
				// Add a vertical force to the player.
				m_Grounded = false;
				m_Rigidbody.AddForce(new Vector3(0f, m_JumpForce,0));
			}
            //float moveHorizontal = Input.GetAxis ("Horizontal");
            //float moveVertical = Input.GetAxis ("Vertical");
            //transform.Rotate (xrate * Vector3.forward);
            m_Rigidbody.AddForce(Vector3.right * xrate * m_MaxSpeed);
            /*
			if (!engaged)
				m_Rigidbody.AddForce (Vector3.right * xrate * m_MaxSpeed);
			else
				transform.Rotate (Vector3.forward * m_MaxSpeed);
            */
        }
		public void engage(bool eng)
		{
			engaged = eng;
			stickyAura.SetActive (eng);
			if(eng)
				transform.tag = "StickyAura";
			else
            {
                transform.tag = "Player";
                transform.SetParent(null);
                m_Rigidbody.useGravity = true;
            }
        }
        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        void OnCollisionStay(Collision coll)
        {
            //if the player is touching a gear and "engaged" parent to the gear and kill velocity
            if (coll.gameObject.tag == "gear" && stickyAura.active == true)
            {
                //Debug.Log("grip");
                transform.SetParent(coll.transform);
                m_Rigidbody.useGravity = false;
                m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.angularVelocity = Vector3.zero;
            }
        }
        //deparent from gears
        void OnCollisionExit(Collision coll)
        {
            if (coll.gameObject.tag == "gear")
            {
                transform.SetParent(null);
                m_Rigidbody.useGravity = true;
            }
        }
    }
}
