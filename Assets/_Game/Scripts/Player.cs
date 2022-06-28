using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bulletPrefabs;
    public GameObject zombiePrefabs;
    public int weaponType;

    public GameObject laser;
    public float laserLastTime;

    public float zombieDistanceFromPlayer;
    public float spawnSeconds;
    public float rotateSpeed;
    private float rotateY;
    
    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            if (weaponType == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(ShootLaser());
                }
            }
            else if (weaponType == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    rotateY = playerTransform.rotation.eulerAngles.y;
                    SpawnBullet(rotateY);
                }
            }
        }
    }

    IEnumerator ShootLaser()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(laserLastTime);
        laser.SetActive(false);
    }

    private void SpawnBullet(float rotateY)
    {
        GameObject newBullet = Instantiate(bulletPrefabs) as GameObject;
        newBullet.transform.position = new Vector3(Mathf.Sin(Mathf.PI * rotateY / 180), 1.2f, Mathf.Cos(Mathf.PI * rotateY / 180));
        newBullet.GetComponent<Bullet>().vectorDirection = new Vector3(Mathf.Sin(Mathf.PI * rotateY / 180), 0f, Mathf.Cos(Mathf.PI * rotateY / 180));
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.GetHit();
    }
}