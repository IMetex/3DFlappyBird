using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    Rigidbody2D rb2;
    public float fishSpeed;

    private int angle;
    private int maxAngle = -20;
    private int minAngle = 60;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb2.velocity = new Vector2(rb2.velocity.x, fishSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, fishSpeed);
        }

        if (rb2.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (rb2.velocity.y < -2.5f)
        {
            if (angle > minAngle)
            {
                angle -= 2;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}