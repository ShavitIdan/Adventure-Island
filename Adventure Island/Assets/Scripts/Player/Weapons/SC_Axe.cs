using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Axe : MonoBehaviour
{
    private float speed = 5f;
    private float lifeTime = 5f;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Shoot(float direction)
    {
        transform.localScale = new Vector3(direction, 1, 1);
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector3(speed * direction, 5f, 0));
        StartCoroutine(DeactivateLogic());
    }

    private IEnumerator DeactivateLogic()
    {
        yield return new WaitForSeconds(lifeTime);
        DeactivateObject();
    }

    private void DeactivateObject()
    {
        this.gameObject.SetActive(false);
    }

    public void Initilize(float newSpeed, float newLifeTime)
    {
        speed = newSpeed;
        lifeTime = newLifeTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            DeactivateObject();
        }

        if (collision.gameObject.tag == "Ground")
        {
            DeactivateObject();
        }
    }
}
