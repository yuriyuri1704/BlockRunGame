using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    /// <summary>
    /// リジッドボディを取得する変数
    /// </summary>
    private Rigidbody2D rb;
    private bool isGround;
    [SerializeField] float upForce = 200f; //上方向にかける力

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void FixedUpdate()
    {
        Move();
        Jump();

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

    /// <summary>
    /// スペースキーでジャンプするメソッド
    /// </summary>
    private void Jump() 
    {
        if (isGround == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isGround = false;
                rb.AddForce(new Vector2(0, upForce)); //上に向かって力を加える
            }
        }
    }

    /// <summary>
    /// Groundタグのオブジェクトに触れたときisGroundをtrueにするメソッド
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") 
        {
            isGround = true; 
        }
    }

}