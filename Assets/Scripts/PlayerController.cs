using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public  bool GameStart = true;
    public float MaxX;
    public float MinX;
    float horizontal=0;
    public float Speed;
    int Score = 0;
    public Text Point;
    Vector3 vec;
    
    void Start()
    {
        



    }

    
    void FixedUpdate()
    {
       
        if (GameStart)
        {

            //transform.Translate(Vector3.forward * Time.deltaTime * 3f);

            horizontal = Input.GetAxis("Mouse X");

            vec = new Vector3(horizontal, 0);

            transform.Translate(Vector3.forward * Time.deltaTime * 3f);

            transform.Translate(horizontal * Speed * Time.deltaTime, 0, 0);

            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), 0, 0);









            //Move.position = new Vector3(Mathf.Clamp(Move.position.x, MinX, MaxX), 0, 0);
        }






    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow) /*&& transform.position.x < minx*/)
        //{
        //    transform.position += Vector3.left;
        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow) /*&& transform.position.x < maxx*/)
        //{
        //    transform.position += Vector3.right;
        //}






        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);



    }


    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 3f);
    }



    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Point"))
        {
            Score++;
            Point.text = "Score:" + Score;
            Destroy(col.gameObject);
        }
    }

   






}
