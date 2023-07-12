using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IMovable
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private Vector2 moveVector;
    [SerializeField] private TMP_Text startText;

    private Camera mainCamera;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if (!GameController.Instance.IsStart())
            {
                _rigidbody2D.AddForce(new Vector3(350, 0, 0));
                mainCamera.GetComponent<Rigidbody2D>().AddForce(new Vector3(350, 0, 0));
                _rigidbody2D.gravityScale = 1;
                startText.SetText("");
                GameController.Instance.StartGame();
            }

            Move(_rigidbody2D, moveVector);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contactCount > 0 && !collision.collider.CompareTag("Coin"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Move(Rigidbody2D rigidbody2D, Vector2 moveVector)
    {
        Debug.Log("Move");
        rigidbody2D.AddForce(moveVector);
    }
}
