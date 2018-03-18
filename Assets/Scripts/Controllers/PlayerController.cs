using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 2.2f;
    public float runSpeed = 4f;

    private int COLLISION_LAYER_MASK = 1536;
    private int CLIPPING_LAYER_MASK = 2048;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;
    private SpriteRenderer[] childSpriteRenderers;
    public RoomManager roomManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update () {
        Move();
        CheckUnderTile();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            int posX = Mathf.FloorToInt(cameraRay.origin.x);
            int posY = Mathf.FloorToInt(cameraRay.origin.y);
            TileObject to = roomManager.currentRoom.GetTileAt(posX, posY);
            if (to != null)
            {
                to.Destroy();
            }
        }
	}


    private void CheckUnderTile()
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position + Utils.SwapVectorDimension(collider.offset), transform.position + Utils.SwapVectorDimension(collider.offset), CLIPPING_LAYER_MASK);

        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                //hit.collider.GetComponentInParent<TileObject>().PlayerInClippingZone();
            }
        }
    }

    private void updateSpriteOrder()
    {
        int order = 1000 - Mathf.CeilToInt(transform.position.y);
        spriteRenderer.sortingOrder = order;

        foreach (SpriteRenderer renderer in childSpriteRenderers)
        {
            renderer.sortingOrder = order;
        }
    }


    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        bool isMoving = Mathf.Abs(inputX) + Mathf.Abs(inputY) > 0;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            bool isRunning = !Input.GetKey(KeyCode.LeftShift);
            float playerSpeed = isRunning ? runSpeed : walkSpeed;

            animator.SetBool("isRunning", isRunning);
            animator.SetFloat("X", inputX);
            animator.SetFloat("Y", inputY);

            transform.Translate(CalculateMoveVector(inputX, inputY, playerSpeed));
            updateSpriteOrder();
        }
    }

    private Vector3 CalculateMoveVector(float x, float y, float speed)
    {
        Vector2 direction = new Vector2(x, y).normalized * Time.deltaTime * speed;

        bool didHit;

        if (y != 0f)
        {
            Vector2 leftPoint = new Vector2(
                collider.bounds.center.x - collider.bounds.extents.x, 
                collider.bounds.center.y + (collider.bounds.extents.y * Mathf.Sign(y))
                );

            Vector2 rightPoint = new Vector2(
                collider.bounds.center.x + collider.bounds.extents.x, 
                collider.bounds.center.y + (collider.bounds.extents.y * Mathf.Sign(y))
                );

            didHit = CheckHitFromDirection(new Vector2(0, direction.y), leftPoint);
            didHit = didHit || CheckHitFromDirection(new Vector2(0, direction.y), rightPoint);
            
            if (didHit)
            {
                direction.y = 0f;
            }
        }

        if (x != 0f)
        {
            Vector2 bottomPoint = new Vector2(
                collider.bounds.center.x + (collider.bounds.extents.x * Mathf.Sign(x)), 
                collider.bounds.center.y - collider.bounds.extents.y
                );

            Vector2 topPoint = new Vector2(
                collider.bounds.center.x + (collider.bounds.extents.x * Mathf.Sign(x)), 
                collider.bounds.center.y + collider.bounds.extents.y
                );

            didHit = CheckHitFromDirection(new Vector2(direction.x, 0), bottomPoint);
            didHit = didHit || CheckHitFromDirection(new Vector2(direction.x, 0), topPoint);
            
            if (didHit)
            {
                direction.x = 0f;
            }
        }

        if (direction.x != 0 && direction.y != 0)
        {
            Vector2 cornerPoint = new Vector2(
                collider.bounds.center.x + (collider.bounds.extents.x * Mathf.Sign(x)),
                collider.bounds.center.y + (collider.bounds.extents.y * Mathf.Sign(y))
                );

            didHit = CheckHitFromDirection(direction, cornerPoint);
            
            if (didHit)
            {
                direction = new Vector3();
            }
        }

        return direction; 
    }


    private bool CheckHitFromDirection(Vector2 direction, Vector2 point)
    {
        RaycastHit2D hit = Physics2D.Raycast(point, direction, Mathf.Abs(direction.magnitude), COLLISION_LAYER_MASK);
        Debug.DrawRay(point, direction * 2f);
        return hit.collider != null;
    }
}
