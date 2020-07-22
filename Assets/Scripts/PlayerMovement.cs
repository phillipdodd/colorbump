using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;

    private Vector2 movementDir;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        movementDir.x = Input.GetAxisRaw("Horizontal");
        movementDir.y = Input.GetAxisRaw("Vertical");

        if (anim)
        {
            //anim.SetFloat("Horizontal", rb.velocity.x);
            //anim.SetFloat("Vertical", rb.velocity.y);
            anim.SetFloat("Speed", rb.velocity.sqrMagnitude);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = movementDir * movementSpeed;
    }
}