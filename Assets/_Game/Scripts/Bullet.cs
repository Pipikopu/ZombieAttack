using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 vectorDirection = new Vector3(0, 0, 0);
    public Transform bulletTransform;
    public float speed;

    public float borderX;
    public float borderZ;

    private bool isOutX;
    private bool isOutZ;
    // Update is called once per frame
    void Update()
    {
        bulletTransform.transform.position += vectorDirection * speed * Time.deltaTime;

        isOutX = (Mathf.Abs(bulletTransform.transform.position.x) > borderX);
        isOutZ = (Mathf.Abs(bulletTransform.transform.position.z) > borderZ);

        if (isOutX || isOutZ)
        {
            Destroy(gameObject);
        }
    }
}
