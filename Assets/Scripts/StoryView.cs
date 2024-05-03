using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DG.Tweening;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SearchService;
using UnityEngine.UI;


public class StoryView : MonoBehaviour
{
   public static event Action<Story> OnCreateStory;
   private Story story;
   
   [SerializeField] private TextMeshProUGUI storyText;

   [SerializeField] private Button buttonPrefab;

   [SerializeField] private RectTransform choiceHolder;
   
   [SerializeField] private TextMeshProUGUI speakerName;

   [SerializeField] private Image speakerImage;
   
   [SerializeField] private QuestsConfig questConfig;
   
   [SerializeField] private List<SpeakerConfig> speakerConfigs;
   
   [Serializable]
   public class SpeakerConfig
   {
      public string name;
      public Sprite sprite;
   }
   
   private void Awake()
   {
      DestroyOldChoices();
      gameObject.SetActive(false);
   }
   
   public void StartStory(TextAsset textAsset)
   {
      FindObjectOfType<PlayerInput>().enabled = false;
      gameObject.SetActive(true);
      story = new Story(textAsset.text);
      
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      
      ShowStory();
   }

   private void CloseStory()
   {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
      FindObjectOfType<PlayerInput>().enabled = true;
      gameObject.SetActive(false);
   }

   private void ShowStory()
   {
      DestroyOldChoices();

      while (story.canContinue)
      {
         string text = story.Continue();
         text = text.Trim();
         CreateContentView(text);
         HandleTags();
      }

      if (story.currentChoices.Count > 0)
      {
         for (int i = 0; i < story.currentChoices.Count; i++)
         {
            Choice choice = story.currentChoices[i];
            Button button = CreateChoiceView(choice.text.Trim(), i);
            button.onClick.AddListener(() => OnClickChoiceButton(choice));

         }
      }
      else
      {
         Button choice = CreateChoiceView("Continue", 0);
         choice.onClick.AddListener(CloseStory);
      }
   }

   private void OnClickChoiceButton(Choice choice)
      {
         story.ChooseChoiceIndex(choice.index);
         ShowStory();
      }

      

   private void DestroyOldChoices()
      {
         foreach (Transform child in choiceHolder)
         {
            Destroy(child.gameObject);
         }
      }

   private void CreateContentView(string text)
   {
      var speaker = story.globalTags.FirstOrDefault(t => t.Contains("speaker"))?.Split(' ')[1];
      speakerName.text = speaker;
      speakerImage.sprite = GetSpeakerImage(speaker);
      StartCoroutine(ShowTextLetterByLetter(text));
   }

   private Sprite GetSpeakerImage(string speaker)
   {
      return speakerConfigs.FirstOrDefault(s => s.name == speaker)?.sprite;
   }

   IEnumerator ShowTextLetterByLetter(string text)
   {
      storyText.text = text;
      storyText.maxVisibleCharacters = 0;
      for (int i = 0; i <= text.Length; i++)
      {
         storyText.maxVisibleCharacters = i;
         if (Keyboard.current.spaceKey.wasPressedThisFrame)
         {
            storyText.maxVisibleCharacters = text.Length;
            yield break;
         }

         yield return new WaitForSeconds(0.025f);
      }
   }
   
   private Button CreateChoiceView(string text, int index)
   {
      var choice = Instantiate(buttonPrefab, choiceHolder.transform, false);
      if (index == 0)
      {
         choice.Select();
      }

      choice.transform
         .DOScale(1f, 0.5f)
         .SetEase(Ease.OutBack)
         .From(0f)
         .SetDelay(index * 0.2f);
       
      var choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
      choiceText.text = text;
       
      return choice;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Locked;
         FindObjectOfType<PlayerInput>().enabled = true;
         gameObject.SetActive(false);
      }
   }

   private void HandleTags()
   {
      if (story.currentTags.Count <= 0)
      {
         return;
      }

      foreach (var currentTag in story.currentTags)
      {
         if (currentTag.Contains("addQuest"))
         {
            var questName = currentTag.Split(' ')[1];
            var quest = questConfig.quests.First(q => q.GetId() == questName);
            GameState.StartQuest(quest);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
         }

         if (currentTag.Contains("removeQuest"))
         {
            var questName = currentTag.Split(' ')[1];
            GameState.RemoveQuest(questName);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
         }
      }
   }
}
