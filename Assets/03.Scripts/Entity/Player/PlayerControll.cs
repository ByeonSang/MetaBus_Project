using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private PlayerMovement Movement { get; set; }

    public PlayerControll()
    {
        Movement = new PlayerMovement();
    }
}
