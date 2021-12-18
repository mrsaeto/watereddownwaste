using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    private Vector2 moveVector = Vector2.zero;
    public float moveSpeed = 0.0f;

    private float bobMaxTime = 0.0f;
    private float bobTargetTime;

    public float fallTargetTime = 0.0f;
    private bool falling = true;

    private Rigidbody2D body = null;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        moveVector = new Vector2(0.0f, 0.5f);

        bobMaxTime = Random.Range(1.0f, 4.0f);
        bobTargetTime = bobMaxTime;

        fallTargetTime = Random.Range(5.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling) {
            bobTargetTime -= Time.deltaTime;
            if (bobTargetTime <= 0.0f) {
                moveVector.y *= -1;
                bobTargetTime = bobMaxTime;
            }

            body.MovePosition(body.position + moveVector * moveSpeed * Time.deltaTime);
        } else {
            fallTargetTime -= Time.deltaTime;
            if (fallTargetTime <= 0.0f) {
                body.gravityScale = 0.0f;
                body.velocity = Vector2.zero;
                falling = false;
            }
        }
    }
}
