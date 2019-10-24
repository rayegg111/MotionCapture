using UnityEngine;

public class Player : MonoBehaviour {

    public Animator ani;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ani.SetTrigger("跳舞觸發器");

        if (Input.GetKey(KeyCode.R))
        {
            ani.SetBool("跑步開關", true);
        }
        else
        {
            ani.SetBool("跑步開關", false);
        }
	}
}
