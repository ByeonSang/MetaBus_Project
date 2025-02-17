using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Info")]
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;

    private void Update()
    {
        Vector2 pos = Vector2.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
