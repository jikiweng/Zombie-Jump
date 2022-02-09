using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidBody;
    private bool jump = false;
    private AudioSource audioSource;

    void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver&&GameManager.instance.GameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.instance.PlayerStartGame();
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;
            }
        }
    }

    void FixedUpdate() 
    {
        if (jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            audioSource.PlayOneShot(sfxDeath);
            rigidBody.AddForce(new Vector2(50, 20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;

            GameManager.instance.PlayerCollided();
        }

        else if (collision.gameObject.tag=="coin")
        {
            collision.gameObject.SetActive(false);
            //collision.rigidBody.detectCollisions = false;
            GameManager.instance.CollectCoin();
        }
    }

    public void ResetPosition()
    {
        rigidBody.isKinematic = true;

        transform.position =new Vector3(15, 8, -4.5f);
        transform.rotation = Quaternion.AngleAxis(-50,Vector3.up);
        rigidBody.useGravity = false;
        rigidBody.velocity=new Vector3(0, 0, 0);

        rigidBody.isKinematic = false;
        rigidBody.detectCollisions = true;        
    }
}
