using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 0;
    Vector3 direção2;
    public float força;
    Rigidbody rb;
    private int cont;
    public CharacterController controle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direção2 = new Vector3(0, 1, 0);
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direção = new Vector3(horizontal, 0f, vertical).normalized;

        if (direção.magnitude >= 0.1f)
        {
            float alvo = Mathf.Atan2(direção.x, direção.y);
            controle.Move(direção * velocidade * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(direção2 * força);
        }

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
