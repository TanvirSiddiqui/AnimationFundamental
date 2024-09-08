using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    private Animator bladeAnim;
    bool isRotating;
    void Start()
    {
        bladeAnim = gameObject.GetComponent<Animator>();
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                bladeAnim.SetBool("StartRotation", true);
                isRotating = true;
            }

        }else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                bladeAnim.SetBool("StartRotation", false);
                isRotating = false;
            }
        }
    }
}
