using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    private Rigidbody2D body = null;
    private Animator anim = null;

    public float fallTargetTime = 0.0f;
    public float numKeyFrames = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        anim.speed = 0;

        numKeyFrames = (Random.Range(0, numKeyFrames - 1) / 10);
        anim.Play("trash", 0, numKeyFrames);

        fallTargetTime = Random.Range(5.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        fallTargetTime -= Time.deltaTime;
        if (fallTargetTime <= 0.0f) {
            body.gravityScale = 0.0f;
            body.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Timer.singleton.score += 100.0f;  
        AudioManager.singleton.Play("ItemPickup");
        Destroy(gameObject);
    }
}
