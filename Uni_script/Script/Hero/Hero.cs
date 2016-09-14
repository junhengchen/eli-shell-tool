using UnityEngine;
using System.Collections;

public class Hero : AbstractCharacter
{
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		protected override void characterDie ()
		{
				Destroy (gameObject);
		}
}

