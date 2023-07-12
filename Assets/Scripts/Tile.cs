using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    [SerializeField] private Vector3 shift;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject trapPrefab;

    private void Start()
    {
        Instantiate(coinPrefab, transform.position + new Vector3(Random.Range(-6, 7),Random.Range(-3, 4), 0), transform.rotation);
        
        int trapCount = GameController.Instance.score + 1 > 5 ? 5 : GameController.Instance.score + 1;
        for (int i = 0; i < trapCount; i++)
        {
            Instantiate(trapPrefab, transform.position + new Vector3(Random.Range(-6, 7),Random.Range(-2, 3), 0), transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Instantiate(tilePrefab, transform.position + shift, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
