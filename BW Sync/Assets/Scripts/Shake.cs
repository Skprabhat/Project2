using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;
    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
        camAnim.SetTrigger("Shake 3");
        camAnim.SetTrigger("Shake 7");
        camAnim.SetTrigger("Shake 11");
        camAnim.SetTrigger("Shake TT1");
        camAnim.SetTrigger("Shake TT2");
        camAnim.SetTrigger("Shake TT3");
    }
}
