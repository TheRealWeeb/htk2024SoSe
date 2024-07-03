using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DG.Tweening;
using Ink.Runtime;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SearchService;
using UnityEngine.UI;


public class StoryView : MonoBehaviour
{
   public static event Action<Story> OnCreateStory;
   private Story story;

   private PlayerInputActions playerInputActions;

   private ThirdPersonController playerController;

   private List<IQuest> _quests;

   [SerializeField] private GameObject thePlayer;
   
   [SerializeField] private TextMeshProUGUI storyText;

   [SerializeField] private Button buttonPrefab;

   [SerializeField] private RectTransform choiceHolder;
   
   [SerializeField] private TextMeshProUGUI speakerName;
   
   [SerializeField] private List<SpeakerConfig> speakerConfigs;
   
   [Serializable]
   public class SpeakerConfig
   {
      public string name;
   }
   
   private void Awake()
   {
      DestroyOldChoices();
      gameObject.SetActive(false);
      playerController = thePlayer.GetComponent<ThirdPersonController>();

      CollectionQuest[] collectionQuests = Resources.LoadAll<CollectionQuest>("Quests");
      _quests = new List<IQuest>();
      foreach (var collectionQuest in collectionQuests)
      {
         _quests.Add(collectionQuest);
      }

   }

   public void StartStory(TextAsset textAsset)
   {
      gameObject.SetActive(true);
      story = new Story(textAsset.text);

      FindObjectOfType<PlayerInput>().enabled = false;
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      
      foreach(var quest in GameState.GetCompletableQuests())
      {
         story.variablesState["completable_" + quest.Quest.GetId().ToLower()] = true;
      }
      
      ShowStory();
   }

   private void CloseStory()
   {
      FindObjectOfType<PlayerInput>().enabled = true;
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
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
      StartCoroutine(ShowTextLetterByLetter(text));
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
            var quest = _quests.First(q => q.GetId().ToLower() == questName.ToLower());
            GameState.StartQuest(quest);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
         }

         if (currentTag.Contains("removeQuest"))
         {
            var questName = currentTag.Split(' ')[1];
            GameState.RemoveQuest(questName);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
         }

         if (currentTag.Contains("completeQuest"))
         {
            var questName = currentTag.Split(' ')[1];
            GameState.CompleteQuest(questName);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
         }
      }
   }
}
