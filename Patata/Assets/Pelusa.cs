using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Pelusa : MonoBehaviour
{
    public float walkSpeed = 3f;

    Rigidbody2D rb;
    public enum WalkableDicrection { Right, Left }

    private WalkableDicrection _walkDirection;

    public WalkableDicrection WalkDirection
    {
        get { return _walkDirection; }
        set { 
            if(_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkableDicrection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }else if(value == WalkableDicrection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }

            _walkDirection = value; }


    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(walsSpeed * Vector2.right, rb.velocity.y);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
