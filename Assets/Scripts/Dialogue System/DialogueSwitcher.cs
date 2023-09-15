using UnityEngine;

namespace DialogueSystem
{
    public class DialogueSwitcher : MonoBehaviour
    {
        [SerializeField] private string[] _disableTags;
        private DialogueStory _dialogueStory;

        private void Start()
        {
            _dialogueStory = FindObjectOfType<DialogueStory>(true);
            _dialogueStory.ChangedStory += Disable;
            _dialogueStory.gameObject.SetActive(false);
        }

        private void Disable(string tag) 
        {
            foreach (string disableTag in _disableTags)
            {
                if (tag != disableTag) continue;
                _dialogueStory.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _dialogueStory.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}