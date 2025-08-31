using UnityEngine;
using UnityEngine.UI;

public class ComputerButton : MonoBehaviour
{
    private Camera _camera;
    private Image _buttonSign;

    private float _interactDistance;
    private bool _enabled = false;
    public bool IsEnabled => _enabled;

    public void Init(Image buttonSign, float interactDistance)
    {
        _buttonSign = buttonSign;
        _interactDistance = interactDistance;
        _camera = Camera.main;

        if (_buttonSign != null)
            _buttonSign.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckInteraction();
    }

    private void CheckInteraction()
    {
        if (_camera == null) return;

        Ray ray = new(_camera.transform.position, _camera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance))
        {
            if (hit.transform == transform)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _enabled = !_enabled;

                    if (_buttonSign != null)
                        _buttonSign.gameObject.SetActive(_enabled);

                    Debug.Log($"Кнопка {gameObject.name} состояние: {_enabled}");
                }
                return;
            }
        }
    }
}
