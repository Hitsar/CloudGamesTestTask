using System;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueStory : MonoBehaviour
    {
        [SerializeField] private Story[] _stories;
        private Story _currentStory;
        
        public event Action<Story> ChangedStory;

        [Serializable]
        public struct Story
        {
            [field: SerializeField] public string Tag {get; private set;}
            [field: SerializeField] public string Text {get; private set;}
            [field: SerializeField] public Answer[] Answers {get; private set;}
        }
        
        [Serializable]
        public struct Answer
        {
            [field: SerializeField] public string Text {get; private set;}
            [field: SerializeField] public string ReposeText {get; private set;}
        }

        private void Awake() => ChangeStory(_stories[0].Tag);

        public void ChangeStory(string tag)
        {
            foreach(Story story in _stories)
            {
                if (story.Tag != tag) continue;
                _currentStory = story;
                ChangedStory?. Invoke(_currentStory);
                return;
            }
            Debug.LogError($"Stories do not contain the tag ({tag})");
        }
    }
}