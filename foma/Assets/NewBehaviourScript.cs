using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 20f;
     Rigidbody2D _rb;
    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;
    private float distance = 2f;
    
    public LayerMask layerMask;
    private bool isleft = false;
    public LayerMask enemy;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent <Rigidbody2D> () ; 
    }
    bool isRight = true;
    // Update is called once per frame
    void Update()
    {
        float move = GetAxis ("Horizontal");
    
        _rb.MovePosition  (_rb.position + Time.deltaTime * move * speed * Vector2.right);
        Debug.LogError(Time.deltaTime * move * speed * Vector2.right);
        if (move == 1f)
        {
            if (!isRight)
            {
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                isRight = true;
            }
        }
        
        if (move == -1f)
        {
            if (isRight)
            {
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                
                isRight = false;
            }
        }


            if (Input.GetKeyDown(KeyCode.Space))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, layerMask);

            if (hit.collider != null)
            {
                _rb.AddForce(Vector3.up * 8000);
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, enemy);

            if (hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
            }
        }
 
            
    }

    public float GetAxis(string param)
    {
        if (param == "Horizontal")
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                return 1f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return -1f;
            }
            return 0f;
        }
        
        if (param == "Vertical")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                return 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                return -1f;
            }
            return 0f;
        }
        
        return 0f;
    }
    
}
