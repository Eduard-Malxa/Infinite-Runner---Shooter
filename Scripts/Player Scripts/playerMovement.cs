using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Transform checkPosition;
    public LayerMask groundLayer;
    public float speed = 6f;
    public float jumpPower = 10f;
    public float jumpPowerExtra = 7f;
    private playerAnimations animScript;
    private bool startMoveBool = false;
    bool checkIfGrounded;
    bool canSecondJump;
    private BGScript bGScript;
    private morePlatformCreatorScirpt playerCanShoot;
    private Button jumpBtn;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animScript = GetComponent<playerAnimations>();
        bGScript = GameObject.Find(Tags.BACKGROUND_GAME_OBJ).GetComponent<BGScript>();
        playerCanShoot = GetComponent<morePlatformCreatorScirpt>();
        jumpBtn = GameObject.Find(Tags.JUMP_BUTTON_OBJ).GetComponent<Button>();
        jumpBtn.onClick.AddListener(() => Jump());
    }

    void Update()
    {
        if (startMoveBool)
        {
            movePlayer();
            jumpPowerVoid();
            checkGround();
            if (checkIfGrounded)
            {
                animScript.runAnim();
            }
            else if (!checkIfGrounded)
            {
                animScript.jumpAnim();
            }
        }

        StartCoroutine(startMove());
    }


    void movePlayer()
    {
        rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, 0f);
    }

    void checkGround()
    {
        checkIfGrounded = Physics.OverlapSphere(checkPosition.position, 0.3f, groundLayer).Length > 0;
    }

    void jumpPowerVoid()
    {

        if (Input.GetKeyDown(KeyCode.Space) && checkIfGrounded)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, 0f);
            canSecondJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !checkIfGrounded && canSecondJump)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPowerExtra, 0f);
            animScript.jumpAnimSecond();
            canSecondJump = false;
        }

    }
    public void Jump()
    {

        if (checkIfGrounded)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, 0f);
            canSecondJump = true;
        }
        else if (!checkIfGrounded && canSecondJump)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPowerExtra, 0f);
            animScript.jumpAnimSecond();
            canSecondJump = false;
        }

    }

    IEnumerator startMove()
    {
        yield return new WaitForSeconds(1.5f);
        startMoveBool = true;
        bGScript.isScrollMaterialBG = true;
        playerCanShoot.canShoot = true;
        gameplayController.instance.canCountScore = true;
    }
}
