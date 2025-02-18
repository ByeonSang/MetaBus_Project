using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pingpongDist;

    private float time = 0f;
    private GameObject currentBlock;

    private void Start()
    {
        currentBlock = null;

        SpawnBlock();
        SpawnBlock();
    }

    private void Update()
    {
        time += Time.deltaTime;

        ApplyMove();
    }


    private bool SpawnBlock()
    {
        Vector3 prevBlockPos;
        prevBlockPos = (currentBlock == null) ? transform.position : currentBlock.transform.localPosition;
        prevBlockPos.y += 1f;
        currentBlock = Instantiate(blockPrefab, prevBlockPos, Quaternion.identity);
        return true;
    }

    private void ApplyMove()
    {
        float posX = Mathf.PingPong(time*moveSpeed, pingpongDist);
        currentBlock.transform.position = 
            new Vector2(
                posX - pingpongDist/2f,
                currentBlock.transform.localPosition.y
            );

    }
}
