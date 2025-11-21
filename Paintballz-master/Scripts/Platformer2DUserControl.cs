
using UnityEngine;
using UnityEngine.UI;
using CnControls;

// Just in case so no "duplicate definition" stuff shows up
namespace UnityStandardAssets.Copy._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private GrenadeLauncher gLauncher;
        
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            gLauncher = GetComponent<GrenadeLauncher>();
        }
        
        private void Update()
        {
			
        }
        
        private void FixedUpdate()
        {
			//Get Moving Joystick Axis
            float h = CnInputManager.GetAxis("Horizontal");
			float v = CnInputManager.GetAxis("Vertical");

			//Get Shooting Joystick Axis
			float h2 = CnInputManager.GetAxis("Horizontal2");
			float v2 = CnInputManager.GetAxis("Vertical2");

            // Pass all parameters to the character control script.
            m_Character.Move(h, v); //move
            
			m_Character.Shoot(h2, v2); //shoot

            m_Character.Dodge(h, v); //dodge

            gLauncher.Launch(h2, v2);


        }
    }
}

