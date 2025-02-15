using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BOSS管理器 : MonoBehaviour
{
    public GameObject attackPoint;
    public GameObject attackPoint2;

    public GameObject bombPoint1;
    public GameObject bombPoint2;
    public GameObject bombPoint3;
    public GameObject bombPoint4;

    public GameObject bullet;
    public GameObject bulletUp;
    public GameObject bulletSe;
    public GameObject boom1;
    public GameObject boom2;
    public GameObject bigBoom;
    public GameObject bulletSe3;
    public GameObject bulletSe4;
    public GameObject enemy_HP_UI;//血量
    public GameObject success_ui;//血量
    public float attackTime;
    public float bombTime;
    public float intTime;
    public float intTime_max=10;
    public float enemy_HP_num = 100f;//血量
    public bool isDie=false;
    // Start is called before the first frame update
    void Start()
    {
        if (isDie = true)
        {
            游戏管理器.scrore_num += 1240;
        }

    }

    private void OnTriggerEnter2D(Collider2D trigger)//触发器
    {
        //=====================如果受到攻击=====================


            if (trigger.gameObject.tag == "攻击_主角1")
            {
            Instantiate(boom2, trigger.gameObject.transform.position, Quaternion.identity);

            enemy_HP_num = enemy_HP_num - 5;//敌人血量-10

                游戏管理器.Player1_MP_num = 游戏管理器.Player1_MP_num + 1;//主角蓝量+1
                attackTime = 0;//敌人攻击计时清零（防止受伤的时候还能发射子弹）
                Destroy(trigger.gameObject);//销毁打在身上的子弹
            }

        if (trigger.gameObject.tag == "攻击_主角2")
        {
            enemy_HP_num = enemy_HP_num - 30;
            游戏管理器.Player2_MP_num = 游戏管理器.Player2_MP_num + 1;//主角蓝量+10
            attackTime = 0;
            Instantiate(boom2, new Vector3(trigger.gameObject.transform.position.x, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
            Instantiate(boom2, new Vector3(trigger.gameObject.transform.position.x+3, trigger.gameObject.transform.position.y + 3, 0), Quaternion.identity);
        }


        if (trigger.gameObject.tag == "大招_主角1")
            {

                Instantiate(boom2, this.gameObject.transform.position, Quaternion.identity);
                Instantiate(bigBoom, this.gameObject.transform.position, Quaternion.identity);
                enemy_HP_num = enemy_HP_num - 50;//敌人血量-10
            }
            if (trigger.gameObject.tag == "大招子弹_主角1")
            {

                Instantiate(boom2, trigger.gameObject.transform.position, Quaternion.identity);
                enemy_HP_num = enemy_HP_num - 1.5f;//敌人血量-10
            }


            Invoke("GoTrue", 0.6f);

        }

        // Update is called once per frame
        void Update()
    {

        enemy_HP_UI.GetComponent<Slider>().value = enemy_HP_num / 1500f;

        if (enemy_HP_num >0)
        {
            intTime += Time.deltaTime;//并开始攻击计时
            if (intTime >= intTime_max)//如果攻击计时数大于攻击计时数的最大值
            {
                var create_Random = Random.Range(0f, 100f);//扔骰子

                
                if (create_Random <= 30)//如果小于20
                {
                    GetComponent<Animator>().SetTrigger("射击");//则启动攻击动画
                    intTime = 0;
                }
                else if (create_Random>30 && create_Random <= 60)//如果小于20)
                {
                    GetComponent<Animator>().SetTrigger("万箭齐发");//则启动攻击动画
                    intTime = 0;
                }
                else if (create_Random > 60 && create_Random <= 100)//如果小于20)
                {
                    GetComponent<Animator>().SetTrigger("大炮");//则启动攻击动画
                    intTime = 0;
                }
                Debug.Log(create_Random);
            }




            if (attackPoint.active == true)
            {
                attackTime += Time.deltaTime;
                if (attackTime >= 0.06)
                {

                    Instantiate(bullet, attackPoint.transform.position, new Quaternion(0, 0, 0, 0));
                    Instantiate(bullet, attackPoint2.transform.position, new Quaternion(00, 0, 0, 0));
                    Instantiate(bulletSe, attackPoint.transform.position, new Quaternion(0, 0, 0, 0));

                    attackTime = 0;
                }
            }


            if (bombPoint1.active == true)
            {

                bombTime += Time.deltaTime;
                if (bombTime >= 0.5)
                {

                    Instantiate(bulletUp, bombPoint1.transform.position, new Quaternion(0, 0, 0, 0));
                    Instantiate(bulletUp, bombPoint2.transform.position, new Quaternion(0, 0, 0, 0));
                    Instantiate(bulletUp, bombPoint3.transform.position, new Quaternion(0, 0, 0, 0));
                    Instantiate(bulletUp, bombPoint4.transform.position, new Quaternion(0, 0, 0, 0));
                    bombTime = 0;
                }
            }
        }
        
        else if (enemy_HP_num <= 0)
        {
            isDie = true;
            GetComponent<Animator>().SetBool("死亡",true);//则启动攻击动画
            success_ui.active = true;
        }



    }

}
