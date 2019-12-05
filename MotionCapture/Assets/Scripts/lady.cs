using UnityEngine;

public class lady : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rig;

    [Header("速度"), Range(0f, 50f)]
    public float speed = 10f;
    [Header("旋轉"), Range(0f, 100f)]
    public float rotate = 5f;
    [Header("血量"), Range(100, 500)]
    public int hp = 100;

    [Header("動畫控制器")]
    public string aniWalk = "走路";
    public string aniJump = "跳躍";
    public string aniAtk  = "攻擊";
    public string aniHurt = "受傷";
    public string aniDie  = "死亡";

    // 屬性 可以設定權限 取得 get、設定 set
    // 修飾詞 類型 名稱 { 取得 設定 }
    public int MyProperty { get; set; }

    public bool isAttack
    {
        get
        {
            return ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"); //傳回
        }
    }
    public bool isHurt
    {
        get
        {
            return ani.GetCurrentAnimatorStateInfo(0).IsName("受傷"); //傳回
        }
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        print("攻擊：" + isAttack);
        print("受傷：" + isHurt);
        if (isAttack || isHurt) return; //跳出

        Attack();
        Rotate();
    }

    private void FixedUpdate()
    {
        if (isAttack || isHurt) return; //跳出

        Walk();
        Jump();
    }

    // 觸發事件：碰到勾選 IsTrigger 碰撞器開始時候執行一次
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);

        if (other.tag == "陷阱")
        {
            Hurt();
        }
    }

    // 修飾詞 傳回類型 方法名稱 (參數) { 敘述 }
    // void 為無傳回類型
    /// <summary>
    /// 走路
    /// </summary>
    void Walk()
    {
        ani.SetBool(aniWalk, Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
        //rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);

        //transform.forward (0,0,1)
        //transform.right   (1,0,0)
        //transform.up      (0,1,0)
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed + transform.right * Input.GetAxisRaw("Horizontal") * speed);
    }

    /// <summary>
    /// 旋轉
    /// </summary>
    private void  Rotate()
    {
        float x = Input.GetAxis("Mouse X");  // 滑鼠左右，左 -1、右 1
        //Time.deltatime 一幀的時間
        transform.Rotate(0, x * rotate * Time.deltaTime, 0);
    }
    
    /// <summary>
    /// 跳躍
    /// </summary>
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger(aniJump);
        }
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    void Attack() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger(aniAtk);
        }
    }
    /// <summary>
    /// 受傷
    /// </summary>
    void Hurt()
    {
        ani.SetTrigger(aniHurt);
        hp -= 20;
        if (hp <= 0) Die();
    }
    /// <summary>
    /// 死亡
    /// </summary>
    void Die()
    {
        ani.SetBool(aniDie, true);

        //this 此腳本
        //enabled 啟動
        this.enabled = false;
    }
}
