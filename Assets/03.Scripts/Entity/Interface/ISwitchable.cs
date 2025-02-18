using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable
{
    public bool IsActive { get; }

    public void Activate(int idx = 0); // 외부에서 값을 넘겨받을 수 있게 만들어 줬습니다.
    public void Deactivate();
}
