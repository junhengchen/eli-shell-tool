using UnityEngine;
using System.Collections;

public class Swallow : MonoBehaviour
{
	public float speed = 10;
	public GameObject effect;
	public GameObject owner;
	
	void OnTriggerEnter (Collider other)
	{
		if (!other.gameObject.Equals (owner)) {
			//						Destroy (other.gameObject);
			AbstractCharacter rival=other.gameObject.GetComponent<AbstractCharacter>();
			if(rival!=null){
				LevelUpBuff upLevel = new LevelUpBuff (rival);
				upLevel.execute (other.gameObject);
				Instantiate (effect, other.gameObject.transform.position, other.gameObject.transform.rotation);
			}

		}
		
	}
}