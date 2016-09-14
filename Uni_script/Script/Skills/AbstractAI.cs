using UnityEngine;
using System.Collections;

public abstract class AbstractAI : MonoBehaviour,ITrigger
{
		public Collider alarmEnterCollider;
		public Collider alarmExitCollider;
		 
		void OnTriggerEnter (Collider other)
		{
				if (other.Equals (alarmEnterCollider)) {
						Debug.Log ("done!");
						onEnterCollider (other);
				}
		}

		void OnTriggerExit (Collider other)
		{
				if (other.Equals (alarmExitCollider)) {
						Debug.Log ("done!");
						onExitCollider (other);
				}
		}
		
		public abstract void onEnterCollider (Collider other);

		public abstract void onExitCollider (Collider other);
}

