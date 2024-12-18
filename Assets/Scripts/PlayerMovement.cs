using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpd = 1f;

    GridManager gridManager;
    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool hasHit = Physics.Raycast(ray, out hit);

            if(hasHit)
            {
                if (hit.transform.tag == "Unit")
                {

                }
                if(hit.transform.tag == "Tile")
                {
                    Vector2Int targetCords = hit.transform.GetComponent<Labeler>().cords;
                    Vector2Int startCords = new Vector2Int((int)transform.position.x, (int)transform.position.y) / gridManager.UnityGridSize;
                    transform.position = new Vector3(targetCords.x, transform.position.y, targetCords.y);
                }
            }
        }
    }
}
