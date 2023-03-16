using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotClose : MonoBehaviour
{
    private const string animBoolNameNum = "isOpen_Obj_5";
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isOpen = anim.GetBool(animBoolNameNum);

        if(isOpen)
        {
            this.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
