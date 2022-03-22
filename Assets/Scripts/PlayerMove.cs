using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�C���X�y�N�^�Őݒ�ł���悤�ɂ���
    [SerializeField] private float speed; //���x
    [SerializeField] private float jumpSpeed; //�W�����v���x
    [SerializeField] private float jumpHeight; //�W�����v���鍂��(�̐���������)
    [SerializeField] private float jumpLimitTime; //�W�����v��������
    [SerializeField] private float gravity; //�d��
    [SerializeField] private GroundCheck ground; //�ڒn����
    [SerializeField] private GroundCheck head; //�����Ԃ�������

    [SerializeField] private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;


    void Start()
    {
    }

    
    //FixedUpdate�F�������Z�̏����̑O�ɖ���Ă΂��
    void FixedUpdate()
    {
        //�ڒn����𓾂�
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //�L�[���͂��ꂽ��s������
        float horizontalkey = Input.GetAxis("Horizontal"); //�����̓���
        float verticalKey = Input.GetAxis("Vertical"); //�c���̓���
        float xSpeed = 0.0f;
        float ySpeed = -gravity; // �������Ȃ���Ώd�͂𓭂�����

        //�n�ʂɂ��Ă���Ƃ��ɃW�����v�o����悤�ɂ���
        if (isGround)
        {
            //������L�[��������Ă���Ƃ�
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed; //y����ݒ肵�����̂ɂ���
                jumpPos = transform.position.y; //�W�����v�����ʒu���L�^����
                isJump = true;
                jumpTime = 0.0f; //�W�����v���Ԃ����Z�b�g
            }
            else
            {
                isJump = false;
            }

        }
        else if(isJump)
        {
            //������������Ă��邩
            bool pushUpKey = verticalKey > 0;
            //��������ׂ鍂�����y���W�����ɂ��邩
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //�W�����v���Ԃ������Ȃ肷���Ă��Ȃ��� (��������>�W�����v���Ă��鎞��)
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed; //�㏸����
                jumpTime += Time.deltaTime; //�W�����v����Q�[�������Ԃ𑫂��đ���
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }


        if(horizontalkey > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
            xSpeed = speed; //�E���������琳�̑��x
        }
        else if(horizontalkey < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0);
            xSpeed = -speed; //�����������畉�̑��x
        }
        else
        {
            xSpeed = 0.0f; //���������Ă��Ȃ��Ƃ��̑��x��0�ɂ���
        }
        //Rigidbody2D.velocity:�����I�����𖳎����������G���W�����삪�o����
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
