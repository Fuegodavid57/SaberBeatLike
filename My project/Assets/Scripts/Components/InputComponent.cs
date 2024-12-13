using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    [SerializeField] IAA_Player inputs;
    [SerializeField] InputAction firstLine;
    [SerializeField] InputAction secondLine;
    [SerializeField] InputAction thirdLine;

    public InputAction FirstLine => firstLine;
    public InputAction SecondLine => secondLine;
    public InputAction ThirdLine => thirdLine;

    private void Awake()
    {
        inputs = new IAA_Player();
        firstLine = inputs.Player.FirstLine;
        secondLine = inputs.Player.SecondLine;
        thirdLine = inputs.Player.ThirdLine;
    }

    private void OnEnable()
    {
        firstLine.Enable();
        secondLine.Enable();
        thirdLine.Enable();
    }
}