using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasMailColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noMailColor = new Color32(1, 1, 1, 1);
    [SerializeField] private float destroyDelay = 0.5f;
    
    private bool hasMail;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Nooo, my van");
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mail") && !hasMail)
        {
            Debug.Log("Mail picked up");
            hasMail = true;
            spriteRenderer.color = hasMailColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.gameObject.CompareTag("mailDelivered") && hasMail)
        {
            Debug.Log("Mail Delivered");
            hasMail = false;
            spriteRenderer.color = noMailColor;
        }
    }

}
