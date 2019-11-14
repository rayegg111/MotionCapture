using UnityEngine;

public class lady : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rig;

    [Header("速度"), Range(0f, 50f)]
    public float speed = 10f;

    [Header("動畫控制器")]
    public string aniWalk = "走路";
    public string aniJump = "跳躍";
    public string aniAtk =  "攻擊";
    public string aniHurt = "受傷";
    public string aniDie =  "死亡";
    


    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
        Attack();
    }

    // 修飾詞 傳回類型 方法名稱 (參數) { 敘述 }
    // void 為無傳回類型
    /// <summary>
    /// 走路
    /// </summary>
    void Walk()
    {
        ani.SetBool(aniWalk, Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);
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
    }
    /// <summary>
    /// 死亡
    /// </summary>
    void Die()
    {
        ani.SetBool(aniDie, true);
    }
}
