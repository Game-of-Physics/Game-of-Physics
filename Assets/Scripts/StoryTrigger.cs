using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject Role;
    public GameObject NPC1;
    public Rigidbody NPC;
    public Rigidbody role;
    public GameObject GuardRail;
    public Vector3 dist;
    private int flag2;
    private int flag1;

    public void StartDialogue () {
        if ((Role.transform.position - NPC1.transform.position).magnitude < 3) {
            Dialogue.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKey) {
                dist = NPC1.transform.position - Role.transform.position;
                Dialogue.SetActive(false);
                Time.timeScale = 1;
                flag2 = 1;
            }
        }
    }

    // void OnCollisionExit (Collision collision) {
    //     flag1 = 1;
    //     Debug.Log("flag1 = " + flag1);
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        Dialogue.SetActive(false);
        flag2 = 0;
        flag1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Role.transform.position - GuardRail.transform.position).magnitude > 20) {
            flag1 = 1;
        }
        if (flag2 == 0) {
            StartDialogue();
        }
        if (flag2 == 1 && flag1 == 0) {
            NPC1.transform.position = Role.transform.position + dist;
            NPC.velocity = role.velocity;
        }
    }
}
