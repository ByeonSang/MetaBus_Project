using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Info")]
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;

    [Space]
    [SerializeField] private Vector2 minDistance;
    [SerializeField] private Vector2 maxDistance;
    private void Update()
    {
        Vector2 pos = Vector2.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);

        pos.x = Mathf.Clamp(pos.x, minDistance.x, maxDistance.x);
        pos.y = Mathf.Clamp(pos.y, minDistance.y, maxDistance.y);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
