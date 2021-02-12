using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class morePlatformCreatorScirpt : MonoBehaviour
{
    [SerializeField]
    private Transform playerBullet;
    private float distanceBeforeNewPlatforms = 120f;
    private levelGenerator levelGenerator;
    private levelGeneratorPooling levelGeneratorPooling;

    [HideInInspector]
    public bool canShoot;
    private Button shootBtn;
    void Awake()
    {
        levelGenerator = GameObject.Find(Tags.LEVEL_GENERATOR_OBJ).GetComponent<levelGenerator>();
        levelGeneratorPooling = GameObject.Find(Tags.LEVEL_GENERATOR_OBJ).GetComponent<levelGeneratorPooling>();
        shootBtn = GameObject.Find(Tags.SHOOT_BUTTON_OBJ).GetComponent<Button>();
        shootBtn.onClick.AddListener(() => Shoot());
    }
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canShoot)
            {
                Vector3 bulletPos = transform.position;
                bulletPos.y += 1.5f;
                bulletPos.x += 1f;
                Transform newBullet = (Transform)Instantiate(playerBullet, bulletPos, Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
                newBullet.parent = transform;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            Vector3 bulletPos = transform.position;
            bulletPos.y += 1.5f;
            bulletPos.x += 1f;
            Transform newBullet = (Transform)Instantiate(playerBullet, bulletPos, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
            newBullet.parent = transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.MONSTER_BULLET_TAG || other.tag == Tags.BOUNDS_TAG)
        {
            gameplayController.instance.takeDamage();
            // inform game controller that the player has died 
            Destroy(gameObject);
        }
        if (other.tag == Tags.HEALTH_TAG)
        {
            // inform gameplay controller that we have collected a health 
            gameplayController.instance.incrementHealth();
            other.gameObject.SetActive(false);
        }

        if (other.tag == Tags.MORE_PLATFORMS_TAG)
        {
            Vector3 temp = other.transform.position;
            temp.x += distanceBeforeNewPlatforms;
            other.transform.position = temp;
            // levelGenerator.GenerateLevel(false);

            levelGeneratorPooling.PoolingPlatforms();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Tags.MONSTER_TAG)
        {
            gameplayController.instance.takeDamage();
            // inform game controller that the player has died
            Destroy(gameObject);
        }
    }
}
