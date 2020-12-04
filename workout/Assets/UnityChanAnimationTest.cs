using UnityEngine;

public class UnityChanAnimationTest : MonoBehaviour
{

    public bool animater_switch = true;

    Animator animator;
    public GameObject[] weapon;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < weapon.Length; i++)
        {
            if (i == number)
            {
                weapon[i].SetActive(true);
            }
            else
            {
                weapon[1].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //前進
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * 0.1f;
            animator.SetBool("is_running", true);
        }
        else
        {
            animator.SetBool("is_running", false);
        }

        //左右回転
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -1, 0);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0);
        }

        // 反転 
        if(Input.GetKey("s"))
        {
            transform.Rotate(0, 2, 0);
        }

        if (animater_switch) {

            //攻撃2
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("is_attack1", true);
            }
            else
            {
                animator.SetBool("is_attack1", false);
            }

            //攻撃２
            if (Input.GetMouseButtonDown(1))
            {
                animator.SetBool("is_attack2", true);
            }
            else
            {
                animator.SetBool("is_attack2", false);
            }
        }

        if (Input.GetKey("1"))
        {
            number = (number + 1) % weapon.Length;
            
            for (int i = 0; i < weapon.Length; i++)
            {
                if (i == number)
                {
                    weapon[i].SetActive(true);
                }
                else
                {
                    weapon[i].SetActive(false);
                }
            }
        }
    }
}