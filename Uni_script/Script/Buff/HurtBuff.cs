public class HurtBuff: IBuff
{
	public void execute (UnityEngine.GameObject gameobject)
	{
		AbstractCharacter charact = gameobject.GetComponent<AbstractCharacter>();
		if(charact!=null){
			charact.getLevel().Level--;
		}
	}
}