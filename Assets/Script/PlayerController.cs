using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;

    public float speed = 5f;
    public float JumpForce = 200f;

    private int jumpCount = 0;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    public void Move()
    {

        float x = Input.GetAxis("Horizontal");
        if(x!=0)
        {
            //设置播放移动动画
            transform.localScale=new Vector3(x>0? 1: -1,1,1);
            transform.Translate(new Vector3(x*speed * Time.deltaTime,0,0));
        }else
        {
            //停止播放移动动画
        }
    }
    public void Jump()
    {

        Debug.Log(isGround);
        if (isGround)
        {
            jumpCount = 0;
        }
        //二段跳
        if((isGround||jumpCount<2)&&Input.GetButtonDown("Jump"))
        {
            float currentVerticalVelocity = rBody.velocity.y;
            float forceToCancelFall = -currentVerticalVelocity * rBody.mass;
            rBody.AddForce(Vector2.up * forceToCancelFall,ForceMode2D.Impulse);
            Debug.Log("Jump");
            rBody.AddForce(Vector2.up * JumpForce);
            jumpCount++;
            //播放跳跃动画

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground")
        {
            isGround = false;
            //结束跳跃动画
        }
    }
}
