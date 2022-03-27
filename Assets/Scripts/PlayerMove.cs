using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    private void Update()
    {
        Move();

    }

    /// <summary>
    /// 矢印キーで左右に移動するメソッド
    /// </summary>
    private void Move()
    {
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

}
