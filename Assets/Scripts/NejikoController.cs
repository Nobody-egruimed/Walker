using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour
{
    // Start is called before the first frame update

    //1.プレイヤーのキー入力を受け取る
    //2.キー入力の方向に移動する
    //3.移動方向に合わせてアニメーションを再生する
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    public float speed = -0f;
    Animator animator;
    public float jumpPower = 0f;
    public float gravityPower = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y =jumpPower;
            }
        }
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            moveDirection.z = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            moveDirection.z = 0.0f;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * 3f, 0);
        moveDirection.y = moveDirection.y - gravityPower * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection);
        animator.SetBool("run", moveDirection.z > 0f);
    }
}
