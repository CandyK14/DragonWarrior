using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private RectTransform arrow;
    private int currentPosition;

    private UIManager uiManager;

    private void Awake()
    {
        arrow = GetComponent<RectTransform>();
        uiManager = FindAnyObjectByType<UIManager>();
    }
    private void OnEnable()
    {
        currentPosition = 0;
        ChangePosition(0);
    }
    

    private void Update()
    {
        // Change the position of the selection arrow
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            ChangePosition(1);

        // Interact with current option
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E) )
            Interact();
        if (uiManager != null && uiManager.IsPauseScreenActive()) // Chỉ khi màn hình PauseGame mở
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                AdjustVolume(-10); // Decrease volume by 10
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                AdjustVolume(10); // Increase volume by 10
        }
    }

private void AdjustVolume(int change)
    {
        if (currentPosition == 1) // Adjust sound volume
        {
            uiManager.AdjustSoundVolume(change);
            Interact();
        }
        else if (currentPosition == 2) // Adjust music volume
        {
            uiManager.AdjustMusicVolume(change);
        }
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (_change != 0)
            SoundManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition > buttons.Length - 1)
            currentPosition = 0;
            
        AssignPosition();
    }
    private void AssignPosition()
    {
        //Assign the Y position of the current option to the arrow (basically moving it up and down)
        arrow.position = new Vector3(arrow.position.x, buttons[currentPosition].position.y);
    }
    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        //Access the button component on each option and call its function
        buttons[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}