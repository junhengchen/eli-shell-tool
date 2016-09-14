using UnityEngine;
using System.Collections;

public class SenceAliveModel : MonoBehaviour
{
		private GameObject player;
		// Use this for initialization
		private int playerLevel;

		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				player = GameObject.Find (Const.PLAY);
		}

		public int getPlayerLevel ()
		{
				if (player != null) {
						AbstractCharacter character = player.GetComponent<AbstractCharacter> ();
						if (character != null) {
								return character.getLevel ().Level;
						}
				}
				return 0;
		}
}

