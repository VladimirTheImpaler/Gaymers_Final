using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ReturnToPoint : MonoBehaviour
{
    // NOTE: Take out all the irrelevant platformer stuff so it's just a return to point script
    // Implement distance calculator that returns to original spot once it's too far away

    public Transform Joystick;
    public float joyMove = 0.1f;

    public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
    public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");

    public JoeJeff character;

    public Renderer jumpHighlight;

    private Vector3 movement;
    private bool jump;
    private float glow;
    private SteamVR_Input_Sources hand;
    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable.attachedToHand)
        {
            hand = interactable.attachedToHand.handType;
            Vector2 m = moveAction[hand].axis;
            movement = new Vector3(m.x, 0, m.y);

            jump = jumpAction[hand].stateDown;
            glow = Mathf.Lerp(glow, jumpAction[hand].state ? 1.5f : 1.0f, Time.deltaTime * 20);
        }
        else
        {
            movement = Vector2.zero;
            jump = false;
            glow = 0;
        }

        Joystick.localPosition = movement * joyMove;

        float rot = transform.eulerAngles.y;

        movement = Quaternion.AngleAxis(rot, Vector3.up) * movement;

        jumpHighlight.sharedMaterial.SetColor("_EmissionColor", Color.white * glow);

        character.Move(movement * 2, jump);
    }
}