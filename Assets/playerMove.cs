using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMove : MonoBehaviour
{
    public CharacterController Cc;
    public Transform cameraTransform;
    public float Gravity;
    public float WalkSpeed;
    private float yspeed;
    public string enemy = "Enemy";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }


    public void ResetCurrentScene()
    {
        // Get the name of the currently active scene
        string currentSceneName = SceneManager.GetActiveScene().name;


        // Load the scene by its name
        SceneManager.LoadScene(currentSceneName);
    }
     void OnTriggerEnter(Collider Col) {
          if (Col.tag == "Enemy")
               ResetCurrentScene();
     }


     private void HandleRaycasting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast
            if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit))
            {
                if (hit.collider.CompareTag(enemy)) {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawLine(cameraTransform.position + new Vector3(0, -0.1f, 0), hit.point, Color.red, 1f);
                //Collect Parts?
                Destroy(hit.collider.gameObject);
                    Debug.Log("Destroyed: " + hit.collider.gameObject.name);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) );
        cameraTransform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
        Vector3 move = Vector3.zero;
        //Apply walk vector
        move += Input.GetAxis("Vertical") * transform.forward;
        move += Input.GetAxis("Horizontal") * transform.right;
        move = move.normalized * WalkSpeed;
        //Apply gravity
        move += new Vector3(0, yspeed, 0);


        Cc.Move(move * Time.deltaTime);
        HandleRaycasting();
        if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to reset
        {
            ResetCurrentScene();
        }
    }
}
