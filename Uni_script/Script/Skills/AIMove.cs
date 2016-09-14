using UnityEngine;
using System.Collections;

//从巡逻模式切换到追逐模式的技能
public class AIMove : AbstractAI
{
		public Transform[] points;
		private int destPoint;
		private NavMeshAgent agent;
		private MoveState currState = MoveState.PROCAL;
		public GameObject player;
	  
		public enum MoveState
		{
				PROCAL,
				CAPTURE
		}

		// Use this for initialization
		void Start ()
		{
				agent = GetComponent<NavMeshAgent> ();
				procalGo ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (currState == MoveState.CAPTURE) {
						if (player != null)
								agent.SetDestination (player.transform.position);
				} else {
						if (agent.remainingDistance < 1f) {
								//Debug.Log("agent.remainingDistance <.5f " + agent.remainingDistance);
								procalGo ();
						} else {
								//Debug.Log("agent.remainingDistance " + agent.remainingDistance);
						}
				}
		}

		void procalGo ()
		{
				if (points.Length == 0) {
						return;
				}
		    
				//Debug.Log("GO TO POS: "+destPoint);
				agent.destination = points [destPoint].position;
		    
				destPoint = (destPoint + 1) % points.Length;
		}

		public override void onEnterCollider (Collider other)
		{
				currState = MoveState.CAPTURE;
		}

		public override void onExitCollider (Collider other)
		{
				currState = MoveState.PROCAL;
		}
}

