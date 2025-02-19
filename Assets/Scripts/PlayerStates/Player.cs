using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public float Speed;
    [Header("Jumps")]
    [SerializeField] int JumpCount;
    public float JumpHeight;
    public float gravityScale=1;
    public float gravityFall=2;
    public AudioSource audioSteps;
    public AudioSource audioJump;
    public GameObject escMenu;
    [NonSerialized] public Animator animator;
    [NonSerialized] public bool isOnFloor = false;
    [NonSerialized] public bool isOnWall = false;
    [NonSerialized] public bool facingRight = true;
    [NonSerialized] public float movX;
    [NonSerialized] public int CurrentJumpCount;
    public KeyManager km;

    PlayerFiniteState stateMachine;
    State initialState;
    ataquesidescroller _ataquesidescroller;
    Health health;

    private void Awake()
    {
        CurrentJumpCount = JumpCount;
        animator = GetComponent<Animator>();
        initialState = new PlayerIdleState(this);
        stateMachine = new PlayerFiniteState(this, initialState);
        health=GetComponent<Health>();
        
    }

    private void Start()
    {
        _ataquesidescroller = GetComponent<ataquesidescroller>();
        GetComponent<Rigidbody2D>().gravityScale = gravityFall;
        escMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        if (movX > 0 && !facingRight) Flip();
        if (movX < 0 && facingRight) Flip();
        

        stateMachine.FrameUpdate();
        if (Input.GetButtonDown("Jump") && (isOnFloor || isOnWall))
        {
            isOnFloor = false;
            isOnWall = false;
        }
        if (Input.GetButtonDown("Fire1")) _ataquesidescroller.Ataca();

        if (Input.GetButtonDown("Cancel")) 
        {
            Time.timeScale = 0.0f;
            escMenu.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo") { CurrentJumpCount = JumpCount; isOnFloor = true; }    
        if (collision.gameObject.tag == "Pared") { CurrentJumpCount = JumpCount; isOnWall = true; }    
        if (collision.gameObject.tag == "Enemigo") { health.GotHit(); }

    }

    void Flip()
    {
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Destroy(other.gameObject);
            km.keyCount++;
            if (km.keyCount >= 2) 
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

}
