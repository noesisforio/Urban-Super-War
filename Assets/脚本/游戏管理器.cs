using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
public class 游戏管理器 : MonoBehaviour
{
    //全局变量
    public static int enemyDie_num;//死亡量
    public static int money_num=500;//钱
    public static int redBottle_num=5;//血瓶量
    public static int blueBottle_num = 5;//蓝瓶量
    public static int scrore_num;//蓝瓶量
    public static bool isDie = false;//是否死亡
    public static bool isMenuPause = false;//是否菜单暂停
    public static int Player1_MP_num = 0;///角色蓝量
    public static int Player2_MP_num = 0;///角色蓝量
    public int Player1_ES_num = 100;///角色护盾量

    //局部变量

    public GameObject Play1_button_ui;//玩家1的切换角色按钮
    public GameObject Play2_button_ui;//玩家2的切换角色按钮
    public GameObject Music_slider_ui;//音乐大小
    public GameObject menu_button_ui;//菜单按钮
    public Text scrore_ui;//分数UI
    public Text money_ui;//金钱UI
    public Text redBottle_ui;//血瓶量UI
    public Text blueBottle_ui;//蓝瓶量UI
    public static void reGlobalVar()
    {
        Time.timeScale = 1;
        游戏管理器.isDie = false;
        enemyDie_num = 0;
        isMenuPause = false;
        money_num=0;//钱
        redBottle_num=0;//血瓶量
        blueBottle_num=0;//蓝瓶量
        blueBottle_num=0;//蓝瓶量
}

    // 进入菜单（自定义方法）
    public void menu_open()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            游戏管理器.isMenuPause = true;
            menu_button_ui.SetActive(true);
        }
    }

    // 退出菜单（自定义方法）
    public void menu_exit()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            游戏管理器.isMenuPause = false;
            menu_button_ui.SetActive(false);
        }
    }

    // 重新开始（自定义方法）
    public void rePlay()
    {
        if (Time.timeScale == 0)
        {
            Debug.Log("重新游戏");
            reGlobalVar();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void rePlay_over()
    {
        Debug.Log("重新游戏");
        reGlobalVar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitMain_over()
    {
            Debug.Log("返回主界面");
            Time.timeScale = 1;
            游戏管理器.isDie = false;
            SceneManager.LoadScene(0);
    }
    // 返回主界面（自定义方法）
    public void exitMain()
    {
        if (Time.timeScale == 0)
        {
            Debug.Log("返回主界面");
            Time.timeScale = 1;
            游戏管理器.isDie = false;
            SceneManager.LoadScene(0);
        }
    }



    void Start()
    {
       // Music_slider_ui.GetComponent<Slider>().value = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //切换角色_键盘
        if (游戏管理器.isDie==false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)&& Play1_button_ui.GetComponent<Button>().interactable == true)
            {
                Play1_button_ui.GetComponent<Button>().onClick.Invoke();


            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && Play2_button_ui.GetComponent<Button>().interactable == true)
            {

                Play2_button_ui.GetComponent<Button>().onClick.Invoke();

            }
        }


        //开启菜单_键盘
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {

            Time.timeScale = 0;
            游戏管理器.isMenuPause = true;
            menu_button_ui.SetActive(true);

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            游戏管理器.isMenuPause = false;
            menu_button_ui.SetActive(false);
        }



        // 调节音乐
        gameObject.GetComponent<AudioSource>().volume=Music_slider_ui.GetComponent<Slider>().value ;


        scrore_ui.text = "" + scrore_num;
        money_ui.text = "" + money_num ;
        redBottle_ui.text = "" + redBottle_num;
        blueBottle_ui.text = "" + blueBottle_num;
    }
}

