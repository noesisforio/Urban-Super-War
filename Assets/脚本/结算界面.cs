using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 结算界面 : MonoBehaviour
{
    public Text scrore_ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrore_ui.text = "" + 游戏管理器.scrore_num;
    }
}
