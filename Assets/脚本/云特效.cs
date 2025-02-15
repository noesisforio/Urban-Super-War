using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 云特效 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("攻击点").transform.localPosition.x == 4)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.localPosition = new Vector3(-3.08f, -3.83f,0);

        }
        else if (GameObject.Find("攻击点").transform.localPosition.x == -4)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.localPosition = new Vector3(3.08f, -3.83f, 0);
        }
    }
}

