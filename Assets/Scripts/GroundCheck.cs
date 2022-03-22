using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    
    void Start()
    {

    }

   
    void Update()
    {

    }

    public bool IsGround()
    {
        if(isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;
    }

    //Unity������Ă΂�郁�\�b�h
    //�e�I�u�W�F�N�g�ł���Player��Rigidbody2D������������A�Ăяo�����

    //OnTriggerEnter2D�F������ɐN��������
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true; //�n�ʂ�������ɓ���Ftrue
        }


    }

    //OnTriggerStay2D:������ɓ��葱���Ă�����
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    //OnTriggerExit2D�F���������o����
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }

    }

}
