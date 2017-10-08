using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool crouch;
        float h;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()   //As a general rule, keep player input in Update(), and movement in FixedUpdate
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

             if (Input.GetMouseButtonDown(0))
            {
                m_Character.Fire();
            }
            // Read the inputs.

            crouch = Input.GetKey(KeyCode.LeftControl);

            h = CrossPlatformInputManager.GetAxis("Horizontal");
        }


        private void FixedUpdate()
        {
            
           
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

       
    }
}
