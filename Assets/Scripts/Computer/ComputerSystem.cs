using UnityEngine;
using UnityEngine.UI;

public class ComputerSystem : MonoBehaviour
{
    [SerializeField] private float _buttonInteractDistance = 5f;

    [SerializeField] private ComputerButton[] _computerButtons;
    [SerializeField] private Image[] _buttonSigns;

    private void Awake()
    {
        if (_computerButtons == null) _computerButtons = new ComputerButton[0];
        if (_buttonSigns == null) _buttonSigns = new Image[0];

        for (int i = 0; i < _computerButtons.Length; i++)
        {
            if (i < _buttonSigns.Length && _computerButtons[i] != null && _buttonSigns[i] != null)
            {
                _computerButtons[i].Init(_buttonSigns[i], _buttonInteractDistance);
            }
        }
    }

}
