using System;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueStory : MonoBehaviour
    {
        [SerializeField] private Stories[] _stories;
        [SerializeField] private TMP_Text _text;
        
        public event Action<string> ChangedStory; 

        [Serializable]
        private struct Stories
        {
            [field: SerializeField] public string Tag { get; private set; }
            [field: SerializeField] public string Text { get; private set; }
        }

        private void Awake() => ChangeStory(_stories[0].Tag);

        public void ChangeStory(string newTag)
        {
            foreach (Stories storey in _stories)
            {
                if (storey.Tag != newTag) continue;
                
                _text.text = storey.Text;
                ChangedStory?.Invoke(newTag);
                return;
            }
            Debug.LogError($"Story don't contain ({newTag}) tag!");
        }
    }
}