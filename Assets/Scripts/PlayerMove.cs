using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    /// <summary>
    /// ���W�b�h�{�f�B���擾����ϐ�
    /// </summary>
    private Rigidbody2D rb;
    private bool isGround;
    [SerializeField] float upForce = 200f; //������ɂ������

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
    /// ���L�[�ō��E�Ɉړ����郁�\�b�h
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
    /// �X�y�[�X�L�[�ŃW�����v���郁�\�b�h
    /// </summary>
    private void Jump() 
    {
        if (isGround == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isGround = false;
                rb.AddForce(new Vector2(0, upForce)); //��Ɍ������ė͂�������
            }
        }
    }

    /// <summary>
    /// Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�isGround��true�ɂ��郁�\�b�h
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