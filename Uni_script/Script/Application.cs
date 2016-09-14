using UnityEngine;
using System.Collections;

public class Application : MonoBehaviour
{
  private static Hashtable mKeyTable;//键盘事件代理
  //代理类
  public delegate void EventDelegate();

  void Awake()
  {
    mKeyTable = new Hashtable();
  }

  private static void registerEvent(string key, Hashtable table, EventDelegate opt)
  {
    EventDelegate originDel = (EventDelegate)table [key];
    if (originDel == null)
      {
        table.Add(key, opt);
      } else
        {
          originDel += opt;
          table.Add(key, originDel);
        }
  }

      //注册键盘事件代理
      public static void registerKeyEvent(string key, EventDelegate opt)
      {
        registerEvent(key, mKeyTable, opt);
      }

      // Use this for initialization
      void Start()
      {
    
      }
    
      // Update is called once per frame
      void Update()
      {
    
      }

      void OnGUI()
      {
        updateKeyEvent();
      }

      private static void updateKeyEvent()
      {
        foreach (DictionaryEntry de in mKeyTable)
          {
            if (Input.GetKeyUp((string)de.Key))
              {
                EventDelegate originDel = (EventDelegate)de.Value;
                originDel.Invoke();
              }
          }
      }

      
}
