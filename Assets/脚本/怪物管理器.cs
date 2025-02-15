using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 怪物管理器 : MonoBehaviour
{

    GameObject Player_now;///正在运行中的主角
    public GameObject tieTu;//怪物贴图
    public GameObject attackPoint;//攻击生成点
    public GameObject bullet;//子弹
    public GameObject redBottle;//血瓶
    public GameObject blueBottle;//蓝瓶
    public GameObject money;//钱
    public GameObject boom1;//钱
    public GameObject boom2;//钱
    public GameObject bigBoom;//钱
    public GameObject se;//声音




    public float speed;//移动速度
    public float attackTime;//攻击时间
    public float attackTime_max;//攻击时间上限
    public float attackTime_1=0;//攻击时间
    public float distance_num = 10f;//攻击距离
    public float enemy_HP_num = 100f;//血量
    bool isDie = false;//是否死亡
    public bool isRangedAttacks;
    public bool isRight;
    public bool isCreate=false;//血瓶是否生成
    bool isGo = true;
    public bool isBigBoom = false;


    // Start is called before the first frame update
    void Start()
    {
        Player_now = GameObject.FindWithTag("Player");
        if (GameObject.Find("玩家_贴图").GetComponent<SpriteRenderer>().flipX == false)
        {
            isRight = true;
        }
        if (GameObject.Find("玩家_贴图").GetComponent<SpriteRenderer>().flipX == true)
        {
            isRight = false;
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //碰撞
       

    }
    private void OnTriggerEnter2D(Collider2D trigger)//触发器
    {
        //=====================如果受到攻击=====================
  
            if (enemy_HP_num > 0)//如果敌人血量大于0
            {
                if (attackPoint.transform.localPosition.x == 4)
                {
                    Instantiate(boom1, new Vector3(trigger.gameObject.transform.position.x- 1.5f, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
                }
                else if (attackPoint.transform.localPosition.x == -4)
                {
                    Instantiate(boom1, new Vector3(trigger.gameObject.transform.position.x+1.5f, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
                }

            if (trigger.gameObject.tag == "攻击_主角1")
            {
                tieTu.GetComponent<Animator>().SetTrigger("受伤动画_敌人");//则运行受伤动画

                enemy_HP_num = enemy_HP_num - 5;//敌人血量-10
                游戏管理器.Player1_MP_num = 游戏管理器.Player1_MP_num + 1;//主角蓝量+1
                attackTime = 0;//敌人攻击计时清零（防止受伤的时候还能发射子弹）
                Destroy(trigger.gameObject);//销毁打在身上的子弹
                isGo = false;
            }

            if (trigger.gameObject.tag == "攻击_主角2")
            {
                tieTu.GetComponent<Animator>().SetTrigger("受伤动画_敌人");
                enemy_HP_num = enemy_HP_num - 30;
                游戏管理器.Player2_MP_num = 游戏管理器.Player2_MP_num + 1;//主角蓝量+10
                attackTime = 0;
                Instantiate(boom2, new Vector3(trigger.gameObject.transform.position.x, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
            }

            if (trigger.gameObject.tag == "大招_主角1")
            {
                tieTu.GetComponent<Animator>().SetTrigger("受伤动画_敌人");//则运行受伤动画
                Instantiate(boom2, this.gameObject.transform.position, Quaternion.identity);
                Instantiate(bigBoom, new Vector3(this.gameObject.transform.position.x + 2, this.gameObject.transform.position.y + 1, 0), Quaternion.identity);
                enemy_HP_num = enemy_HP_num - 50;//敌人血量-10
            }
            if (trigger.gameObject.tag == "大招子弹_主角1")
            {
                tieTu.GetComponent<Animator>().SetTrigger("受伤动画_敌人");//则运行受伤动画
                Instantiate(boom1, this.gameObject.transform.position, Quaternion.identity);
                enemy_HP_num = enemy_HP_num - 1.5f;//敌人血量-10
            }


            Invoke("GoTrue", 0.6f);

        }

        else if (enemy_HP_num <= 0)//如果敌人血量小于0
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;//关闭触碰器

            
  
            tieTu.GetComponent<Animator>().SetBool("死亡动画_敌人", true);//运行死亡动画
            Instantiate(boom2, this.gameObject.transform.position, Quaternion.identity);
            
            Destroy(trigger.gameObject);//销毁打在身上的子弹

            isDie = true;//开启死亡状态
        }


        if (trigger.gameObject.tag == "攻击_主角1_2")
        {
            
            Destroy(trigger.gameObject);//销毁打在身上的子弹
        }





    }




        void Update()
    {


        //=====================如果怪物没有死亡的话=====================

        if (!isDie)
        {

                //敌人自动旋转（看不懂就抄了代码）
                float angle = Vector3.Angle(transform.forward, Player_now.transform.position - transform.position);
                Vector3 v = Vector3.Cross(transform.forward, Player_now.transform.position - transform.position);
                if (v.y > 0)
                {
                    this.tieTu.GetComponent<SpriteRenderer>().flipX = false;//敌人左转
                    attackPoint.transform.localPosition = new Vector3(4, 0, 0);//攻击生成点为敌人左边

                }
                else
                {
                    this.tieTu.GetComponent<SpriteRenderer>().flipX = true;//敌人右转
                    attackPoint.transform.localPosition = new Vector3(-4, 0, 0);//攻击生成点为敌人右边
                };




            if (isGo == true)
            {

                //敌人角色的间距
                if (Vector3.Distance(transform.position, Player_now.transform.position) <= distance_num)//如果两者间距小于4
                {

                    tieTu.GetComponent<Animator>().SetBool("走路动画_敌人", false);//则停止走路动画

                    attackTime += Time.deltaTime;//并开始攻击计时
                    if (attackTime >= attackTime_max)//如果攻击计时数大于攻击计时数的最大值
                    {



                        tieTu.GetComponent<Animator>().SetTrigger("攻击动画_敌人");//则启动攻击动画
                        attackTime = 0;//攻击计时器清零

                        if (this.tieTu.GetComponent<SpriteRenderer>().flipX == false)
                        {
                            bullet.transform.localScale=new Vector3(-2, 2,0);
                        }
                        else if(this.tieTu.GetComponent<SpriteRenderer>().flipX == true)
                        {
                            bullet.transform.localScale = new Vector3(2, 2, 0);
                        }

                        Instantiate(bullet, attackPoint.transform.position, Quaternion.identity);//最后发射子弹
                        Instantiate(se, attackPoint.transform.position, Quaternion.identity);//最后发射子弹





                    }


                }


                else if ((Vector3.Distance(transform.position, Player_now.transform.position) > distance_num))//如果两者间距大于4
                {

                    tieTu.GetComponent<Animator>().SetBool("走路动画_敌人", true);//则开启走路动画

                    if (游戏管理器.isMenuPause == false)//如果没有打开菜单
                    {

                        this.gameObject.transform.position = Vector3.Lerp(transform.position, Player_now.transform.position, speed);//则敌人移动（否则就停止运行）
                    }



                }
            }


            





        }



        //=====================如果怪物死亡的话=====================
        else if (isDie)
        {
            
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;//关闭触碰器
            tieTu.GetComponent<SpriteRenderer>().sortingOrder = -1;//图层改为-1
            




            if (isCreate == false)//如果还没有开始掉落物品的判定
             {
                游戏管理器.scrore_num += 124;
                游戏管理器.Player1_MP_num = 游戏管理器.Player1_MP_num + 5;//主角蓝量+5
                游戏管理器.enemyDie_num = 游戏管理器.enemyDie_num+1;//敌人消灭数+1
                Debug.Log("你击毁了：" + 游戏管理器.enemyDie_num);//后台显示敌人消灭数
                var create_Random = Random.Range(0f, 100f);//扔骰子

                if (create_Random >= 80)//如果小于20
                {
                   
                    Debug.Log("掉落随机数为" + create_Random+",掉落了红瓶！");
                    Instantiate(redBottle, attackPoint.transform.position, Quaternion.identity);//则生成红瓶
                    isCreate = true;
                }

                else if (create_Random >= 60 &&create_Random<80) //如果大于20且小于等于40
                {
                    Debug.Log("掉落随机数为" + create_Random + ",掉落了蓝瓶！");
                    Instantiate(blueBottle, attackPoint.transform.position, Quaternion.identity);//则生成蓝瓶
                    isCreate = true;
                }

                else if(create_Random >= 10 & create_Random < 60) //如果大于40且小于等于60
                {
                    Debug.Log("掉落随机数为" + create_Random + ",掉落了金币！");
                    Instantiate(money, attackPoint.transform.position, Quaternion.identity);//则生成金币
                    isCreate = true;
                }

                else//如果以上判定都没过，则不掉落
                {
                    Debug.Log("掉落随机数为" + create_Random + ",可惜没有掉落！");
                    isCreate = true;
                }

            };
            
            Destroy(this.gameObject,1.5f);//1秒以内销毁自己
            
            
        }














        //====================================================

            ////如果对方切换到角色2
            //if (Player2.active == true)
            //{

            //    //敌人自动旋转
            //    float angle = Vector3.Angle(transform.forward, Player2.transform.position - transform.position);
            //    Vector3 v = Vector3.Cross(transform.forward, Player2.transform.position - transform.position);
            //    if (v.y > 0)
            //    {
            //        this.tieTu.GetComponent<SpriteRenderer>().flipX = false;
            //    }
            //    else
            //    {
            //        this.tieTu.GetComponent<SpriteRenderer>().flipX = true;
            //    };

            //    //敌人角色的间距
            //    if (Vector3.Distance(transform.position, Player2.transform.position) <= distance_num)//如果两者间距小于4
            //    {
            //        tieTu.GetComponent<Animator>().SetBool("走路动画_敌人", false);
            //    }

            //    else if ((Vector3.Distance(transform.position, Player2.transform.position) > distance_num))//如果两者间距大于4
            //    {
            //        tieTu.GetComponent<Animator>().SetBool("走路动画_敌人", true);
            //        this.gameObject.transform.position = Vector3.Lerp(transform.position, Player2.transform.position, speed);
            //    };
            //};
            //====================================================





    }
    private void GoTrue()
    {
        isGo=true;

    }
}
