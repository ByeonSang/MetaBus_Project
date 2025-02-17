using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool _ShuttingDown = false;
    private static object _Lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            // 게임 종료 시 Object 보다 싱글톤의 OnDestroy 이벤트 콜이 먼저 발생 될 수 있습니다.
            // 그래서 예외체크를 반드시 해줘야됩니다. ( null 체크 )
            if(_ShuttingDown)
            {
                Debug.Log($"[Singleton] Instance {typeof(T)} already destroyed. Returning null.");
                return null;
            }

            // Thread Safe : 유니티는 기본적으로 싱글스레드이지만 필수, 도전 기능을 다 만들게 되면 추후 멀티스레드 사용할 수 있는 상황이 있을 수 도 있으니 
            // 미리 스레드 세이프존을 만들었습니다. 하지만 완전한 세이프존은 아님
            lock (_Lock)
            {
                if(instance == null )
                {
                    // 게임 씬에서 해당 싱글톤있는지 체크
                    instance = (T)FindObjectOfType(typeof(T));

                    if(instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString();

                        DontDestroyOnLoad(singletonObject);
                    }
                    
                    // 만약 현재 싱글톤이 최상위 객체가 있으면 최상위 객체를 삭제X
                    if(instance.transform.root != null)
                        DontDestroyOnLoad(instance.transform.root.gameObject);
                }
            }

            return instance;
        }
    }
}
