using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raytracing : MonoBehaviour
{
    public Material lineMat;
    public GameObject player;
    //List<Vector3> point = new List<Vector3>();
    //public LayerMask mask;
    //public float speed;
    public float rotation = 0;
    public float maxVisiblityDistance;
    Vector2 mousePos;
    Vector2 movement;
    public float theta;

    void drawRays()
    {
            for (float i = 0; i < theta; i += .1f)
            {
                GL.Begin(GL.LINES);
                lineMat.SetPass(0);
                GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
                RaycastHit2D hit = Physics2D.Raycast(player.transform.position, new Vector2(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad)), maxVisiblityDistance);
                if (hit)
                {
                    GL.Vertex3(player.transform.position.x, player.transform.position.y, 0);
                    /* GL.Vertex3(player.transform.position.x+maxVisiblityDistance, player.transform.position.y+ maxVisiblityDistance , 0);*/
                    GL.Vertex3(hit.point.x, hit.point.y, 0);
                }

                else
                {
                    GL.Vertex3(player.transform.position.x, player.transform.position.y, 0);
                    /* GL.Vertex3(player.transform.position.x+maxVisiblityDistance, player.transform.position.y+ maxVisiblityDistance , 0);*/
                    GL.Vertex3(player.transform.position.x+ Mathf.Cos(i * Mathf.Deg2Rad)* maxVisiblityDistance, player.transform.position.y + Mathf.Sin(i * Mathf.Deg2Rad)* maxVisiblityDistance, 0);
                }
                GL.End();
            }
        
    }

    /*private void Update()
    {
        mousePos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().MovePosition(player.GetComponent<Rigidbody2D>().position + movement * speed * Time.deltaTime);

        Vector2 vectorToTarget = mousePos - new Vector2(player.transform.position.x, player.transform.position.y);
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 30;
        rotation = angle;
    }*/

    void OnPostRender()
    {
        drawRays();
    }
}
