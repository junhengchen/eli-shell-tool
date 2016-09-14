//升级buff
public class LevelUpBuff: IBuff
{
		private AbstractCharacter rival;//对手

		public LevelUpBuff (AbstractCharacter rival)
		{
				this.rival = rival;
		}

		public void execute (UnityEngine.GameObject gameobject)
		{
				AbstractCharacter charact = gameobject.GetComponent<AbstractCharacter> ();
				if (charact != null && rival != null) {
						charact.getLevel ().Level += rival.getLevel ().Level;
				}
		}
}