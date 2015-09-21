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
		[SerializeField] private WheelCollider wheelCol;
		[SerializeField] private GameObject mesh;

        private bool m_Grounded;            // Whether or not the player is grounded.
        private Rigidbody m_Rigidbody;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private void Awake()
        {
            // Setting up references.
            m_Rigidbody = GetComponent<Rigidbody>();
			stickyAura.SetActive (false);
        }

		public void FixedUpdate()
		{
			float motor = m_MaxSpeed * Input.GetAxis("Horizontal");
			wheelCol.motorTorque = motor;

			Vector3 pos;
			Quaternion rot;
			wheelCol.GetWorldPose(out pos, out rot);
			
			mesh.transform.position = pos;
			mesh.transform.rotation = rot;
		}


		public void Move(float xrate,float yrate, bool crouch, bool jump)
        {
			float torque = m_MaxSpeed * xrate;
			wheelCol.motorTorque = torque;
			m_Rigidbody.velocity = wheelCol.attachedRigidbody.velocity;
        }
		public void engage(bool eng)
		{
			stickyAura.SetActive (eng);
			if(eng)
				transform.tag = "StickyAura";
			else
				transform.tag = "Player";
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
    }
}
