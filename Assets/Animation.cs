using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    public List<GameObject> weapons; // Список оружия
    private int currentWeaponIndex = 0; // Индекс текущего оружия
    void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }

        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            SwitchWeapon(1);
        }
        else if (scroll < 0f)
        {
            SwitchWeapon(-1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Attack1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Attack2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Attack3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Attack360();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Rage();
        }
    }
    void SwitchWeapon(int direction)
    {
        weapons[currentWeaponIndex].SetActive(false);

        currentWeaponIndex += direction;

        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        else if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Count - 1;
        }

        weapons[currentWeaponIndex].SetActive(true);
    }

    void Attack1()
    {
        animator.SetTrigger("Attack1");
        StartCoroutine(ResetToIdle());
    }
    void Attack2()
    {
        animator.SetTrigger("Attack2");
        StartCoroutine(ResetToIdle());
    }
    void Attack3()
    {
        animator.SetTrigger("Attack3");
        StartCoroutine(ResetToIdle());
    }
    void Attack360()
    {
        animator.SetTrigger("Attack360");
        StartCoroutine(ResetToIdle());
    }
    void Rage()
    {
        animator.SetTrigger("Rage");
        StartCoroutine(ResetToIdle());
    }

    private IEnumerator ResetToIdle()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetTrigger("Idle");
    }
}
