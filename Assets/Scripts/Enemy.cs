using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool stuck = false; // for when trapped by tape
    private float nextCheck = 0f;
    [SerializeField]
    private float checkInterval = 0.2f;
    private Rigidbody2D rb;
    [SerializeField]
    private float movementForce = 700f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stuck && !GameManager.Instance.lost) // maybe enemy can break out with chance or time? up to gameplay
        {
            if (Time.time > nextCheck) // recheck for player
            {
                nextCheck = Time.time + checkInterval;
                Debug.DrawRay(transform.position, (Player.Instance.transform.position - transform.position).normalized * 5, Color.white, 0);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, (Player.Instance.transform.position - transform.position).normalized,
                    5, LayerMask.GetMask("Player", "Obstacle"));
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Found player!");
                    rb.AddForce((Player.Instance.transform.position - transform.position).normalized
                    * movementForce);
                }
            }
        }
    }
    public void KillEnemy()
    {
        Destroy(gameObject);
    }
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0)
            && MetaControls.Instance.activeTool == MetaControls.Tools.Knife)
        {
            if (MetaControls.Instance.UseTool(MetaControls.Tools.Knife))
                KillEnemy();
        }
        if (Input.GetMouseButton(0)
            && MetaControls.Instance.activeTool == MetaControls.Tools.Tape)
        {
            if (MetaControls.Instance.UseTool(MetaControls.Tools.Tape))
            {
                // place some tape sprite, change animation, etc
                stuck = true;
            }
        }
    }
}
