using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    Rigidbody2D rb2D;
    public IObjectPool<GameObject> pool;
    TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(trailRenderer == null)
        {
            trailRenderer = GetComponent<TrailRenderer>();
        }
        trailRenderer.emitting = true;

        if(rb2D == null)
        {
            rb2D = GetComponent<Rigidbody2D>();
        }
        rb2D.velocity = transform.right * 20f;
    }

    private void OnDisable()
    {
        rb2D.velocity = Vector2.zero;
        trailRenderer.Clear();
        trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Je regarde si je me déplace à moins que 0.1m/s
        if(rb2D.velocity.magnitude <= 1f)
        {
            pool.Release(gameObject);
        }
    }
}
