using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 子弹_主角大招 : MonoBehaviour
{
    public bool isRight;

    // Start is called before the first frame update
    void Start() 
        {
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            this.gameObject.transform.Translate(new Vector3(1f, 0, 0));
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(-1f, 0, 0));
        }
            
        


    }
}

