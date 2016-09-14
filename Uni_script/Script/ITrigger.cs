using UnityEngine;

public interface ITrigger
{
	void onEnterCollider(Collider other);
	void onExitCollider(Collider other);
}