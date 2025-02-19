using UnityEngine;

public class Stack : MonoBehaviour
{
    Color[] colors =
    {
        Color.red,
        Color.yellow,
        Color.green,
        Color.blue,
        Color.cyan
    };

    const float originScale = 5f;
    const float errorMargin = 0.1f;

    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pingpongDist;

    private float time = 0f;
    private GameObject curBlock;
    private GameObject prevBlock;

    private float curParentY;

    private bool isIgnore;

    public int StackCount { get; private set; }

    private void Start()
    {
        isIgnore = false;

        StackCount = -2;
        curBlock = null;
        curParentY = transform.position.y;
        SpawnBlock(0, 0, originScale);
        SpawnBlock(0, 1, originScale);
    }

    private void Update()
    {
        if (isIgnore)
            return;

        time += Time.deltaTime;

        ApplyMove();
        if (!DropBlock())
            isIgnore = true;
        Vector2 nextPosition = new Vector2(transform.position.x, curParentY - StackCount);
        transform.position = Vector2.Lerp(transform.position, nextPosition, Time.deltaTime * 5f);

        if (isIgnore)
        {
            curBlock.AddComponent<Rigidbody2D>().AddForce(Vector2.one * 500f);
            prevBlock.AddComponent<Rigidbody2D>().AddForce(Vector2.one * -500f);
        }
    }


    private GameObject SpawnBlock(float posX, float posY, float scale, bool isSlice = false)
    {
        Vector2 newPos = new Vector2(posX, posY);
        Vector3 newScale = new Vector3(scale, 1f, 1f);

        GameObject newBlock = Instantiate(blockPrefab, newPos, Quaternion.identity);
        newBlock.transform.parent = transform;
        newBlock.transform.localPosition = newPos;
        newBlock.transform.localScale = newScale;

        if (isSlice == false)
        {
            prevBlock = curBlock;
            curBlock = newBlock;

            StackCount++;
        }

        SetColor(newBlock.GetComponent<SpriteRenderer>());


        return newBlock;
    }

    private void ApplyMove()
    {
        float posX = Mathf.PingPong(time * moveSpeed, pingpongDist);
        curBlock.transform.position =
            new Vector2(
                posX - pingpongDist / 2f,
                curBlock.transform.position.y
            );
    }

    private bool DropBlock()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float distance = (curBlock.transform.localPosition.x - prevBlock.transform.localPosition.x);
            bool isLeft = (distance < 0);
            distance = Mathf.Abs(distance);

            if (distance > errorMargin)
            {
                float sliceDeathWidth;
                if (distance > prevBlock.transform.localScale.x)
                    sliceDeathWidth = prevBlock.transform.localScale.x;
                else
                    sliceDeathWidth = distance;

                sliceDeathWidth *= (isLeft ? -1 : 1);
                float sliceLifeWidth = curBlock.transform.localScale.x - Mathf.Abs(sliceDeathWidth);

                if (sliceLifeWidth <= 0)
                {
                    Debug.Log("GameOver");
                    return false;
                }

                float prevWidth = (isLeft) ? -prevBlock.transform.localScale.x : prevBlock.transform.localScale.x;
                float prevEndPoint = prevBlock.transform.localPosition.x + (prevWidth / 2f);
                float deathPivotX = prevEndPoint + (sliceDeathWidth / 2);

                GameObject newSliceBlock = SpawnBlock(deathPivotX, curBlock.transform.localPosition.y, sliceDeathWidth, true);
                newSliceBlock.AddComponent<Rigidbody2D>();
                newSliceBlock.AddComponent<BoxCollider2D>();
                newSliceBlock.name = "Slice";
                newSliceBlock.tag = "Slice";

                float lifePivotX = (isLeft) ? prevEndPoint + (sliceLifeWidth / 2) : prevEndPoint - (sliceLifeWidth / 2);

                curBlock.transform.localPosition = new Vector3(lifePivotX, curBlock.transform.localPosition.y, curBlock.transform.localPosition.z);
                curBlock.transform.localScale = new Vector3(sliceLifeWidth, 1f, 1f);

                SpawnBlock(lifePivotX, curBlock.transform.localPosition.y + 1, sliceLifeWidth);
            }
            else
            {
                Transform prevTrans = prevBlock.transform;
                Transform curTrans = curBlock.transform;

                curBlock.transform.localPosition = new Vector3(prevTrans.localPosition.x, prevTrans.localPosition.y + 1f, prevTrans.localPosition.z);
                SpawnBlock(curTrans.localPosition.x, curTrans.localPosition.y + 1f, curTrans.localScale.x);
            }

        }
        return true;
    }

    private void SetColor(SpriteRenderer sr)
    {
        int count = StackCount + 2;
        sr.color = colors[count % colors.Length];
    }
}
