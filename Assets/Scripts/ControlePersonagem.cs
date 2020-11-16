using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 0;
    private int cont;
    public CharacterController controle;
    private float gravity = -15f;
    Vector3 velocity;
    public Transform cam;
    private float jumpHeight = 50;
    bool isGrounded;
    public Transform groundCheck;
    private float groundDistance = 0f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //pular
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
         if (isGrounded && velocity.y < 0)
         {
             velocity.y = -2f;
         }

         if (Input.GetKeyDown(KeyCode.Space))// && isGrounded)
         {
             velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
         }

        //andar
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direção = new Vector3(horizontal, 0f, vertical).normalized;

        if (direção.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direção.x, direção.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controle.Move(moveDir.normalized * velocidade * Time.deltaTime);
        }

        //gravidade
        velocity.y += gravity * Time.deltaTime;
        controle.Move(velocity / 10 * Time.deltaTime);

        if (cont == 35)
        {
            SceneManager.LoadScene("Vitória");
            //vitória, ganhou!!
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //se colidir com laranja
        if (other.GetComponent<Laranja>() != null)
        {
            Destroy(other.gameObject, 0.3f);
            cont++;
        }

        //se colidir com verde
        else if (other.GetComponent<Verde>() != null)
        {
            Destroy(this.gameObject, 0.4f);
        }
    }
}
