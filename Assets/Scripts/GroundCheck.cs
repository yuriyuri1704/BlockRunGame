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

    //Unity側から呼ばれるメソッド
    //親オブジェクトであるPlayerにRigidbody2Dがある条件より、呼び出される

    //OnTriggerEnter2D：判定内に侵入した時
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true; //地面が判定内に入る：true
        }


    }

    //OnTriggerStay2D:判定内に入り続けていた時
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    //OnTriggerExit2D：判定内から出た時
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }

    }

}
