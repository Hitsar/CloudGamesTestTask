using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class AnswerButton : MonoBehaviour
    {
        [SerializeField] private AnswerSettings[] _answerSettings;
        private DialogueStory _dialogueStory;
        private string _currentReposeTag;

        private Button _button;
        private TMP_Text _buttonText;

        [System.Serializable]
        private struct AnswerSettings
        {
            [field: SerializeField] public string Tag { get; private set; }
            [field: SerializeField] public string ResponseTag { get; private set; }
            [field: SerializeField] public string ButtonText { get; private set; }
        }

        private void Awake()
        {
            _dialogueStory = GetComponentInParent<DialogueStory>();
            _buttonText = GetComponentInChildren<TMP_Text>();
            _button = GetComponent<Button>();

            _dialogueStory.ChangedStory += ChangeAnswer;
            _button.onClick.AddListener(() => Reply());

            _currentReposeTag = _answerSettings[0].ResponseTag;
        }

        private void ChangeAnswer(string newTag)
        {
            foreach (AnswerSettings answerSetting in _answerSettings)
            {
                if (answerSetting.Tag != newTag) continue;
                
                _currentReposeTag = answerSetting.ResponseTag;
                _buttonText.text = answerSetting.ButtonText;
                _button.interactable = true;
                return;
            }

            _buttonText.text = null;
            _button.interactable = false;
        }

        private void Reply() => _dialogueStory.ChangeStory(_currentReposeTag);
    }
}