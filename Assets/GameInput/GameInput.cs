using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions _inputActions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _inputActions = new PlayerInputActions();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _inputActions?.Enable();
    }

    private void OnDisable()
    {
        _inputActions?.Disable();
    }

    public Vector2 GetMoveDirection()
    {
        return _inputActions.Player.Move.ReadValue<Vector2>();
    }

    public float GetJumpPressed()
    {
        return _inputActions.Player.Jump.ReadValue<float>();
    }
}
