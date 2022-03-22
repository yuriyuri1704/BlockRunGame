using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //インスペクタで設定できるようにする
    [SerializeField] private float speed; //速度
    [SerializeField] private float jumpSpeed; //ジャンプ速度
    [SerializeField] private float jumpHeight; //ジャンプする高さ(の制限をする)
    [SerializeField] private float jumpLimitTime; //ジャンプ制限時間
    [SerializeField] private float gravity; //重力
    [SerializeField] private GroundCheck ground; //接地判定
    [SerializeField] private GroundCheck head; //頭をぶつけた判定

    [SerializeField] private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;


    void Start()
    {
    }

    
    //FixedUpdate：物理演算の処理の前に毎回呼ばれる
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalkey = Input.GetAxis("Horizontal"); //横軸の入力
        float verticalKey = Input.GetAxis("Vertical"); //縦軸の入力
        float xSpeed = 0.0f;
        float ySpeed = -gravity; // 何もしなければ重力を働かせる

        //地面についているときにジャンプ出来るようにする
        if (isGround)
        {
            //上方向キーが押されているとき
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed; //y軸を設定したものにする
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f; //ジャンプ時間をリセット
            }
            else
            {
                isJump = false;
            }

        }
        else if(isJump)
        {
            //上方向を押しているか
            bool pushUpKey = verticalKey > 0;
            //自分が飛べる高さよりy座標が下にいるか
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎていないか (制限時間>ジャンプしている時間)
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed; //上昇する
                jumpTime += Time.deltaTime; //ジャンプするゲーム内時間を足して測る
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
            xSpeed = speed; //右を押したら正の速度
        }
        else if(horizontalkey < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0);
            xSpeed = -speed; //左を押したら負の速度
        }
        else
        {
            xSpeed = 0.0f; //何も押していないときの速度を0にする
        }
        //Rigidbody2D.velocity:物理的挙動を無視した物理エンジン操作が出来る
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
