using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float speed;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rigidbody.AddForce(other.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}
