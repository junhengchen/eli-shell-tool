using UnityEngine;
using System.Collections;

//挂在子弹上的脚本，发涩！
public class Bullet : MonoBehaviour
{
		public float speed = 5;
		public GameObject effect;
		public GameObject owner;

		void OnTriggerEnter (Collider other)
		{
				if (!other.gameObject.Equals (owner)) {
//						Destroy (other.gameObject);
						HurtBuff hurt = new HurtBuff ();
						hurt.execute (other.gameObject);
						Instantiate (effect, other.gameObject.transform.position, other.gameObject.transform.rotation);
				}
		
		}
}

