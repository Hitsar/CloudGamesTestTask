using UnityEngine;
using UnityEngine.InputSystem;

namespace Gun
{
    public class WeaponChanger : MonoBehaviour
    {
        [SerializeField] private Gun[] _weapons;
        private InputSystem _input;
        private int _currentWeapon;

        private void Start()
        {
            _input = new InputSystem();
            _input.Gun.ChageWeapon.performed += Change;
            _input.Enable();
        }

        private void Change(InputAction.CallbackContext callback)
        {
            _weapons[_currentWeapon].gameObject.SetActive(false);
            
            _currentWeapon += callback.ReadValue<float>() > 0 ? 1 : -1;
            if (_currentWeapon == _weapons.Length) _currentWeapon = 0;
            else if (_currentWeapon == -1) _currentWeapon = _weapons.Length - 1;

            _weapons[_currentWeapon].gameObject.SetActive(true);
        }
    }
}