using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonPickup : MonoBehaviour
{
    public float bobMaxTime = 0.0f;
    private float bobTargetTime;

    private Rigidbody2D body = null;

    public float moveSpeed = 0.0f;
    private Vector2 moveVector = new Vector2(0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        bobTargetTime = bobMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        bobTargetTime -= Time.deltaTime;
            if (bobTargetTime <= 0.0f) {
                moveVector.y *= -1;
                bobTargetTime = bobMaxTime;
            }

            body.MovePosition(body.position + moveVector * moveSpeed * Time.deltaTime);
    }
}
