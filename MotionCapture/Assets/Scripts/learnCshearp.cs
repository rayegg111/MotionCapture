using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnCshearp : MonoBehaviour
{
    //欄位
    [Header ("分數")]                    // 標題
    [Range (0, 100)]                     // 範圍
    [Tooltip ("最低分數為0，最高為100")] // 提示
    public int score = 100;              // 整數
    [Header ("速度") , Range(0.5f, 5f), Tooltip("最低速度為0.5，最高為5")]
    public float speed = 0.8f;           // 浮點數
    [Header ("血量")]
    public string HP = "血量";           // 字串
    [Header ("任務")]
    public bool misson = true;           // 布林值 (true or false)

    //Unity 常用欄位
    [Header("二維")]
    public Vector2 V2 = new Vector2(10, 10);
    [Header("三維")]
    public Vector3 V3 = new Vector3(5, 5, 5);

    [Header("顏色")]
    public Color color = new Color(0.5f, 0.2f, 0.1f);
    public Color red = Color.red;
    
    //(非靜態類別)欄位，可放相對應物件
    [Header(""),Tooltip("物件座標")]
    public Transform objops;
    [Tooltip("攝影機")]
    public Camera cam;
    [Tooltip("燈光")]
    public Light lig;
    //靜態類別，不能宣告成欄位
    //public Debug deb;

    private void Start()
    {
        //非靜態類別
        //Camera.depth = 10f; //錯誤寫法
        cam.depth = 10f;

        //靜態類別
        Debug.Log ("TEST");
    }
}
