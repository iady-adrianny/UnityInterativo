using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    public float velocidade = 0;
    Vector3 direção;
    Vector3 direção2;
    //float tempo = 0;
    //float tempoCor = 2;
    public float força;
    Renderer renderizador;
    Rigidbody rb;

    //0 = cor dele
    //public Material[] cores;


    // Start is called before the first frame update
    void Start()
    {
        renderizador = this.gameObject.GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        direção2 = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
       // tempo += Time.deltaTime;
        direção = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(direção * velocidade * Time.deltaTime);

        /*if (tempo > tempoCor)
        {
            renderizador.material = cores[0];

        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(direção2 * força);

        }

        /* public void OnTriggerEnter(Collider other)
         {
             //se colidir com laranja
             if (other.GetComponent<Laranja>() != null)
             {
                 renderizador.material = cores[1];
                 tempo = 0;
                 Destroy(other.gameObject);

             }


             //se colidir com verde
             else if (other.GetComponent<Verde>() != null)
             {
                 Destroy(this.gameObject);

             }
         }*/


    }
}
