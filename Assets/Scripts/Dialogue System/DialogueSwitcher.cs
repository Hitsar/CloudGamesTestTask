using System.Linq;
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

        private void Disable(DialogueStory.Story story)
        {
            if (_disableTags.Any(disableTag => story.Tag == disableTag))
            {
                _dialogueStory.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                return;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _dialogueStory.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}