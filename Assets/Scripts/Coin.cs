using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue;
    [SerializeField] private float lifeTimeChase;
    
    [SerializeField] private float attractorStrength = 0.01f;
    [SerializeField] private float attractorRange = 5f;
    
    private bool active;

    private void FixedUpdate()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attractorRange);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                active = true;
                transform.position = Vector3.Lerp(transform.position, hitCollider.transform.position, attractorStrength);
                attractorStrength = attractorStrength + Vector3.Distance(transform.position, hitCollider.transform.position) / 100 < 0.035f 
                    ? attractorStrength + Vector3.Distance(transform.position, hitCollider.transform.position) / 100
                    : 0.035f;

                if (active)
                    StartCoroutine(LifeTimeChase());
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameController.Instance.PickUpCoin(coinValue);
            Destroy(gameObject);
        }
    }

    IEnumerator LifeTimeChase()
    {
        yield return new WaitForSeconds(lifeTimeChase);
        enabled = false;
    }
}
