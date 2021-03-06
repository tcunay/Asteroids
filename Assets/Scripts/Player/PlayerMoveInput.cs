using UnityEngine;
using UI;

namespace Players
{
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerMoveInput : MonoBehaviour
    {
        [SerializeField] private LongPressButton _engineButton;
        [SerializeField] private LongPressButton _leftAxisButton;
        [SerializeField] private LongPressButton _rightAxisButton;

        private PlayerMover _playerMover;
        private float _rightAxisValue = -1;
        private float _leftAxisValue = 1;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            TryPressedEngine();
            TryPressedRotateAxis();
        }

        private void TryPressedEngine()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || _engineButton.IsPressed)
                PressedEngine(true);
            else
                PressedEngine(false);
        }

        private void TryPressedRotateAxis()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || _leftAxisButton.IsPressed)
                PressedRotateAxis(_leftAxisValue);
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || _rightAxisButton.IsPressed)
                PressedRotateAxis(_rightAxisValue);
            else
                PressedRotateAxis(0);

        }

        private void PressedEngine(bool isEngine)
        {
            _playerMover.SetEngine(isEngine);
        }

        private void PressedRotateAxis(float axis)
        {
            _playerMover.SetTourqe(axis);
        }
    }
}
