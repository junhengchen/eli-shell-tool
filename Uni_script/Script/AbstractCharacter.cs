//角色接口
using UnityEngine;

public class AbstractCharacter:MonoBehaviour
{
		private CharacterLevel mLevel=new CharacterLevel();
		//设置角色等级
		public void setLevel (CharacterLevel level)
		{
				mLevel.Level--;
				if (mLevel.Level <= 0) {
						characterDie ();
				}
		}
		//获取角色等级信息
		public CharacterLevel getLevel ()
		{
				return mLevel;
		}
 
		protected virtual void characterDie ()
		{
				Destroy (gameObject);
		}
}