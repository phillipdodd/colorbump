using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform followObject;
    public float speed;
    public float followDistance;
    public bool constrainToX = false;

    private Rigidbody2D rb;
    private float angleOffset = 90f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = followObject.transform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg + angleOffset;
        rb.rotation = angle;

        float distanceFromTarget = Vector2.Distance(targetPos, transform.position);
        if (distanceFromTarget > followDistance)
        {
            Vector2 dir = (targetPos - (Vector2)transform.position).normalized;
            if (constrainToX)
            {
                rb.velocity = new Vector2(dir.x, 0) * speed;
            } 
            else
            {
                rb.velocity = dir * speed;
            }
        } else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
