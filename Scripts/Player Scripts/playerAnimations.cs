using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    private Animation playerAnim;
    void Start()
    {
        playerAnim = GetComponent<Animation>();
    }
    public void jumpAnim()
    {
        playerAnim.Play(Tags.ANIMATION_JUMP);
    }
    public void jumpAnimSecond()
    {
        playerAnim.Play(Tags.ANIMATION_IDLE);
    }
    public void runAnim()
    {
        playerAnim.Play(Tags.ANIMATION_RUN);
    }


}
