using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Header("Move Settings")]
    private float speed = 0f;
    private Vector2 mov;
    private Rigidbody2D rb;

    [Header("Shoot Settings")]

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float offset;
    public float startTimeBtwShoots;
    private float timeBtwShoots;

    [Header("UI")]
    private int mineralAmmount = 0;
    public Text mineralText;

    

    //private float verticalMovement;
    //private float horizontalMovement;

    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mineralText.text = mineralAmmount.ToString() + "/3";
    }

    public void ChangeScore(int delta)
    {
        score += delta;
    }

    void Update()
    {
        //verticalMovement = Input.GetAxis("Vertical");

        //if (verticalMovement != 0F)
        //{
        //    transform.Translate(transform.up * speed * verticalMovement * Time.deltaTime, Space.World);
        //}

        //horizontalMovement = Input.GetAxis("Horizontal");

        //if (horizontalMovement != 0F)
        //{
        //    transform.Translate(transform.right * speed * horizontalMovement * Time.deltaTime, Space.World);
        //}


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Move(x, y);
        Rotate();


        if (timeBtwShoots <= 0F)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
                timeBtwShoots = startTimeBtwShoots;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }

    public void Move(float x, float y)
    {
        mov.Set(x, y);
        mov = mov.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + mov);
    }

    void Rotate()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }

    public void TakeMineral(int ammount)
    {
        this.mineralAmmount += ammount;
        mineralText.text = mineralAmmount.ToString() + " / 3";
    }
}
