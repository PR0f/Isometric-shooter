using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed = 4;
    [SerializeField]
    float animationSpeed = 1;
    public Animator animator;
    private GameObject shootPoint;
    public GameObject Bullet;

    private Vector2 animationDirection;
    private float knockbackCount=0;
    Vector3 knockbackDirection;

    public GameObject Sprite;


    public Material material;
    bool getDamage = false;
    private GameObject sound;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        shootPoint = GameObject.Find("shootPoint");
        sound = GameObject.Find("Sound");



        shootPoint.AddComponent<BulletRifle>();
        shootPoint.AddComponent<LaserRifle>();
        shootPoint.GetComponent<LaserRifle>().init(shootPoint);

    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        animationDirection = transform.forward * y + transform.right * -x;
        animationDirection = animationDirection.normalized * animationSpeed;

        Methods.lookAt2D(transform, transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("forward", 2);
            rb.velocity = transform.forward * speed * 2;
        }
        else
        {
            Vector3 vel = new Vector3(x, y, 0);
            rb.velocity = vel.normalized * speed;

            animator.SetFloat("forward", animationDirection.y);
            animator.SetFloat("right", animationDirection.x);

            if (Input.GetMouseButton(1))
            {
                UIController.setEnergy(UIController.getEnergy() - 0.6f);
                if (UIController.getEnergy() > 0)
                {
                    shootPoint.GetComponent<BulletRifle>().shoot(shootPoint, transform);
                    if (sound != null)
                        sound.transform.GetChild(1).GetComponent<AudioSource>().Play();
                }
            }
            else if (Input.GetMouseButton(0))
            {
                UIController.setEnergy(UIController.getEnergy() - 0.6f);
                if (UIController.getEnergy() > 0)
                {
                    shootPoint.GetComponent<LaserRifle>().shoot(shootPoint, transform);
                    if (sound != null)
                        sound.transform.GetChild(0).GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                shootPoint.GetComponent<LaserRifle>().enableLaser(false);
                UIController.setEnergy(UIController.getEnergy() + 0.4f);
            }

            if (UIController.getEnergy() <= 0)
                shootPoint.GetComponent<LaserRifle>().enableLaser(false);
        }

        if(knockbackCount > 0)
        {
            rb.AddForce(knockbackDirection.normalized * 400f);
            knockbackCount -= Time.deltaTime;
        }

        
    }


    private void FixedUpdate()
    {
        Color color;
        float pulse = Mathf.Abs(Mathf.Sin(Time.time*2)) / 2.0f + 0.3f;
        if (!getDamage)
            color = new Color(pulse , pulse, pulse);
        else
            color = new Color(0.5f, 0, 0);

        material.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            knockbackDirection = transform.position - collision.transform.position;
            knockbackCount = 0.3f;
            Invoke("afterDamage", 0.4f);
            getDamage = true;
            UIController.setHealth(UIController.getHealth() - 10);

        }
    }

    void afterDamage()
    {
        getDamage = false;
    }

}