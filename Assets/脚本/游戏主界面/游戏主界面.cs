using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class 游戏主界面 : MonoBehaviour
{

    public void playGame()
    {
        游戏管理器.reGlobalVar();
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        {
            Application.Quit();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
