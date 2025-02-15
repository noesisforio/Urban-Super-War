using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class 存档和读档 : MonoBehaviour
{
    public GameObject Play1;
    public void SaveGame()
    {
        Debug.Log("建立文件夹地址：" + Application.persistentDataPath);//后台输出地址
        if (!Directory.Exists(Application.persistentDataPath + "/game_SaveData"))//如果没有“game_SaveData”文件夹
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");//则创造“game_SaveData”文件夹
        }

        BinaryFormatter formatter = new BinaryFormatter();//设二进制类型的变量，名为formatter
        
        FileStream file = File.Create(Application.persistentDataPath + "game_SaveData/inventory.txt");//设文件类型的变量，名为File，等于.新创建出来的inventory.txt
        var json_file = JsonUtility.ToJson(Play1);//设一个json的变量，名为json_file，等于由Play1变量转换而来的json文件。
        
        formatter.Serialize(file, json_file);//将json文件导入到txt中
        
    }
    public void LoadGame()
    {

    }
        // Start is called before the first frame update
    }
