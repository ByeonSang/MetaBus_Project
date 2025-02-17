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
            // ���� ���� �� Object ���� �̱����� OnDestroy �̺�Ʈ ���� ���� �߻� �� �� �ֽ��ϴ�.
            // �׷��� ����üũ�� �ݵ�� ����ߵ˴ϴ�. ( null üũ )
            if(_ShuttingDown)
            {
                Debug.Log($"[Singleton] Instance {typeof(T)} already destroyed. Returning null.");
                return null;
            }

            // Thread Safe : ����Ƽ�� �⺻������ �̱۽����������� �ʼ�, ���� ����� �� ����� �Ǹ� ���� ��Ƽ������ ����� �� �ִ� ��Ȳ�� ���� �� �� ������ 
            // �̸� ������ ���������� ��������ϴ�. ������ ������ ���������� �ƴ�
            lock (_Lock)
            {
                if(instance == null )
                {
                    // ���� ������ �ش� �̱����ִ��� üũ
                    instance = (T)FindObjectOfType(typeof(T));

                    if(instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString();

                        DontDestroyOnLoad(singletonObject);
                    }
                    
                    // ���� ���� �̱����� �ֻ��� ��ü�� ������ �ֻ��� ��ü�� ����X
                    if(instance.transform.root != null)
                        DontDestroyOnLoad(instance.transform.root.gameObject);
                }
            }

            return instance;
        }
    }
}
