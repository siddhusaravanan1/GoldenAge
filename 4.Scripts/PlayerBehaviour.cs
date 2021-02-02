using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject Spear;
    public GameObject SpawnPoint;
    public GameObject GameOverPanel;


    public float moveSpeed = 5f;
    float dirX;

    Rigidbody2D rb;
    Animator anim;

    public bool canJump = false;
    bool facingRight = true;

    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void DoJump()
    {
        if (canJump=true)
        {
            rb.AddForce(new Vector2(0, 350), ForceMode2D.Force);
            canJump = false;
        }
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (!facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        if (dirX != 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            DoJump();
        }
        Attack();

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.gameObject.tag == "Enemy")
        {
            StartCoroutine(Dead());
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if(cd.gameObject.tag=="EndScene")
        {
            SceneManager.LoadScene("Level2");
        }
        if(cd.gameObject.tag=="EndScene1")
        {
            SceneManager.LoadScene("Level3");
        }
        if (cd.gameObject.tag == "EndScene2")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.X))
        {  
            anim.SetBool("isAttack",true);
        }
        if(Input.GetKeyUp(KeyCode.X))
        {
            anim.SetBool("isAttack",false);
            Instantiate(Spear, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }

}

