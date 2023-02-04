using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerInput playerImput;



    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;



    private void Awake()
    {
        playerImput = new PlayerInput();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    void Update()
    {
    
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
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
