using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    public float speed = -0f;
    Animator animator;
    public float jumpPower = 0f;
    public float gravityPower = 0f;
    int MaxLine = 2;
    int MinLine = -2;
    float LineWidth = 1.0f;
    int targetLine = 0;
    float StunTime = 0.5f;
    float recoverTime = 0.0f;
    public int playerHitPoint = 3;
    bool IsStum()
    {
        return recoverTime > 0.0f;
    }
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
        if(IsStum() == true)
        {
            moveDirection.x = 0f;
            moveDirection.z = 0f;
            recoverTime -= Time.deltaTime;
        }
        if(IsStum() == false)
        {
        float movePowerZ = moveDirection.z + (speed * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(movePowerZ, 0f, speed);
        float ratioX = (targetLine * LineWidth - transform.position.x) / LineWidth;
        moveDirection.x = ratioX * speed;
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            if (controller.isGrounded && targetLine < MaxLine)
            {
                targetLine = targetLine + 1;
            }
        }
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            if (controller.isGrounded && targetLine > MinLine)
            {
                targetLine = targetLine - 1;
            }
        }
        moveDirection.y = moveDirection.y - gravityPower * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);
        animator.SetBool("run", moveDirection.z > 0f);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Robo")
        {
            Debug.Log("螺子娘はダメージを受けた！");
            recoverTime = StunTime;
            playerHitPoint--;
            animator.SetTrigger("damage");
            Destroy(hit.gameObject);
        }
    }
}