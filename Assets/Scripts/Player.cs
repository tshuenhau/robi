using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 19f;
    [SerializeField] GameObject livesIndicator;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip dieSFX;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip shieldHitSFX;
    AudioSource audioSource;
    PolygonCollider2D myCollider;
    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;
    Animator animator;
    ColorController colorController;
    bool dead;
    bool start = false;
    bool invincible = false;

    int lives;
    Color endColor = new Color(0, 0, 0);

    //Color[] colorList = {new Color(0.6078432f,0.9647059f,1f), new Color(0.7921569f,1,0.7490196f)};
    //int colorListIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GameObject.Find("Skin").GetComponent<SpriteRenderer>();
        myCollider = GetComponentInChildren<PolygonCollider2D>();
        colorController = FindObjectOfType<ColorController>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.bodyType = RigidbodyType2D.Static;
        //mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = transform.parent.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (Save.current.itemsEquipped[0] == 1 && Save.current.items[0] > 0)
        {
            lives = 1;
            livesIndicator.SetActive(true);
        }
        else
        {
            lives = 0;
            livesIndicator.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !dead)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (!start)
                {
                    myRigidBody.bodyType = RigidbodyType2D.Dynamic;
                    start = true;
                }
                Jump();
            }
        }
        mySpriteRenderer.color = colorController.getCurrentColor();
        //Debug.Log("lives: s" + lives);
    }

    public void Jump()
    {
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        animator.SetTrigger("Jump");
        myRigidBody.velocity = Vector2.up * jumpSpeed;
        audioSource.PlayOneShot(jumpSFX);
    }
    public void Win()
    {
        if (FindObjectOfType<LevelController>().GetCurrentLevel() + 1 > Save.current.level)
        {
            Save.current.level += 1;
            SaveLoad.SaveGame();
        }
        StartCoroutine(WaitAndWin());
        GameObject.Find("BodyParts").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; // this is to make it fall through all obstacles and out of the screen.
        audioSource.PlayOneShot(winSFX);
        if (lives < 0) { lives = 0; }
        Save.current.items[0] = lives;
        Destroy(this);

    }
    private IEnumerator WaitAndWin()
    {
        yield return new WaitForSeconds(1.5f);
    }
    public void Die()
    {
        if (invincible) { return; }
        GameObject.Find("Body").GetComponent<PolygonCollider2D>().isTrigger = true; // this is to make it fall through all obstacles and out of the screen.
        audioSource.PlayOneShot(dieSFX);

        if (myRigidBody.velocity.y < -10f)
        {
            animator.SetTrigger("Die");
            Destroy(this);
        }
        else
        {
            StartCoroutine(WaitAndDie());
        }
        dead = true;
        colorController.setDead(true);
        //// StartCoroutine(DeathColorChange());

    }
    private IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(0.65f);
        animator.SetTrigger("Die");
        Destroy(this);

    }
    // private IEnumerator DeathColorChange()
    // {
    //     float tick = 0f;
    //     float speed = 1f;
    //     while (mySpriteRenderer.color != endColor)
    //     {
    //         tick += Time.deltaTime * speed;
    //         mySpriteRenderer.color = Color.Lerp(mySpriteRenderer.color, endColor, tick);
    //         FindObjectOfType<CurrentColor>().ChangeColor(endColor, tick);
    //         FindObjectOfType<NextColor>().ChangeColor(endColor, tick);

    //         yield return null;
    //     }
    // }
    public bool isDead()
    {
        return dead;
    }

    public int getLives()
    {
        return lives;
    }

    public void decreaseLives()
    {
        if (invincible) { return; }
        audioSource.PlayOneShot(shieldHitSFX);
        lives--;
        Save.current.items[0]--;
        SaveLoad.SaveGame();
        if (lives <= 0)
        {
            livesIndicator.SetActive(false);
        }
        StartCoroutine(invincibilityTime());
    }

    private IEnumerator invincibilityTime()
    {
        invincible = true;
        yield return new WaitForSeconds(1.0f);
        invincible = false;
    }


}
