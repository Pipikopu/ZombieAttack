using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Vector3 vectorDirection = new Vector3(0, 0, 0);
    public Transform zombieTransform;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        zombieTransform.transform.position += vectorDirection * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Laser")
        {
            GameManager.instance.ChangeScore();
        }
        Destroy(gameObject);
    }
}
