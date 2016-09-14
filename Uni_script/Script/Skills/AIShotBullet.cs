using UnityEngine;
using System.Collections;

//AI 射击的技能--一旦进入范围并且Player强度高于AI就会attack
public class AIShotBullet : AbstractAI
{
		public float bulletGapTime = 1f;
		private float timer;
		public GameObject bullet;
		private ShotState currState = ShotState.IDLE;
		private GameObject rival;

		public enum ShotState
		{
				IDLE,
				ATTACTING
		}

		// Update is called once per frame
		void Update ()
		{
				if (currState == ShotState.ATTACTING && rival != null) {
						if (checkShouldShoot ()) {
								attack ();
						}
				} else if (rival == null) {
						currState = ShotState.IDLE;
				}
		}

		private bool checkShouldShoot ()
		{
				AbstractCharacter thisCharacter = GetComponent<AbstractCharacter> ();
				if (thisCharacter != null) {
						return thisCharacter.getLevel ().Level <= 
								rival.GetComponent<AbstractCharacter> ().getLevel ().Level;
				}
				return false;
		}

		private void attack ()
		{
				timer += Time.deltaTime;
				Vector3 direction = rival.transform.position - transform.position;
				Ray ray = new Ray (transform.position, direction);
				RaycastHit shootHit;
				if (Physics.Raycast (ray, out shootHit) && timer >= bulletGapTime) {
						//Debug.Log("Hit name: " + shootHit.transform.gameObject.name);
						if (shootHit.transform.gameObject.tag.Equals ("Player")) {
								Shoot ();
						}
				}
		}

		private void Shoot ()
		{
				timer = 0;
				Instantiate (bullet,
		             transform.position,
		             transform.rotation * Quaternion.Euler (new Vector3 (90, 0, 0)));
		}

		public override void onEnterCollider (Collider other)
		{
				if (other.gameObject == null || !other.gameObject.name.Equals (Const.PLAY)) {
						return;
				}
				currState = ShotState.ATTACTING;
				this.rival = other.gameObject;
		}

		public override void onExitCollider (Collider other)
		{
				if (other.gameObject == null || !other.gameObject.name.Equals (Const.PLAY)) {
						return;
				}
				this.rival = null;
				currState = ShotState.IDLE;
		}
}

