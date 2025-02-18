using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable
{
    public bool IsActive { get; }

    public void Activate(int idx = 0); // �ܺο��� ���� �Ѱܹ��� �� �ְ� ����� ����ϴ�.
    public void Deactivate();
}
