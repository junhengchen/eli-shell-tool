using UnityEngine;
using System.Collections;

//main move controller
public class HeroMovement : MonoBehaviour
{
		private float speed = 10.0F;
		private float rotationSpeed = 100.0F;

		void Awake ()
		{

		}
 
		void Update ()
		{
				move ();
		}

		private void move ()
		{
				float translation = Input.GetAxis ("Vertical") * speed;
				float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				transform.Translate (0, 0, translation);
				transform.Rotate (0, rotation, 0);
		}
}
