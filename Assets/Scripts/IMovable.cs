using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovable
{
    public void Move(Rigidbody2D rigidbody2D, Vector2 moveVector);
}
