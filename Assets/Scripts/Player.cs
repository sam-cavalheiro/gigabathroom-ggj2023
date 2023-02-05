using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    AudioSource deathAudioSource;

    private PlayerInput playerImput;
    private Collider _collider;
    private Vector3 _respawnPoint;
    PlayerLife playerLife;
    public AudioSource footstepsSound;



    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 5.0f;
    [SerializeField]
    private float gravityValue = -20f;
    [SerializeField]
    private bool _active = true;



    private void Awake()
    {
        playerImput = new PlayerInput();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _collider = GetComponent<Collider>();
        playerLife = GetComponent<PlayerLife>();
        SetRespawnPoint((Vector3)transform.position);

    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (!_active)
        {
            return;
        }

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direcao = new Vector3(horizontal, 0f, vertical);
        if (direcao.magnitude > 0 && groundedPlayer)
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }


        Vector2 movementInput = playerImput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;


        }

        // Changes the height position of the player..
        if (playerImput.Player.Jump.triggered && groundedPlayer)
        {
            //playerVelocity.y = 0f;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }

    private void OnEnable()
    {
        playerImput.Enable();
    }

    private void OnDisable()
    {
        playerImput.Disable();
    }

    public void SetRespawnPoint(Vector3 position)
    {
        _respawnPoint = (Vector3)position;
    }

    public void Die()
    {
        _active = false;
        _collider.enabled = false;
        playerVelocity.y = 0f;
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue / 2);
        StartCoroutine(routine: Respawn());
        transform.position = new Vector3(0, 0, 0);
        if (deathAudioSource != null)
            deathAudioSource.Play();

        playerLife.ChangeOneLife(false);

    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        transform.position = (Vector3)_respawnPoint;
        _active = true;
        _collider.enabled = true;
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue / 2);
    }



































    /*
    IMPORTANTE: Colocar Character Controller e Tag Player
    */
    /*
    //Header[Atributes]
    public int health;
    public float speed;
    public float damage;

    //Header[Components]
    private CharacterController controller;
    
    //Header[Objects]
    private Transform cam;

    //Header[Others]
    public float smoothRotTime;
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Reconhece as teclas que o player ta apertando e a direcao
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Armazena os eixos x y e z atuais do player
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 0)
        {
            //calculo para rotacionar o personagem dependendo da direcao + angl y da camera
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //calculo para a rotacao ficar suave
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, smoothRotTime);
            //rotacao
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            //transforma a direcao em q o player virar em "lado da frente"
            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            //movimentacao do personagem
            controller.Move(moveDirection * speed * Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {
         
    }
    */
}
