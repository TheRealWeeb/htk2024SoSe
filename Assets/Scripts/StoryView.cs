using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class StoryView : MonoBehaviour
{
   public static event Action<Story> OnCreateStory;
   private Story story;
   
   [SerializeField] 
   private TextMeshProUGUI storyText;

   [SerializeField]
   private Button buttonPrefab;

   [SerializeField] 
   private RectTransform choiceHolder;
   
   [SerializeField] 
   private TextMeshProUGUI speakerName;
   
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
      }

      if (story.currentChoices.Count > 0)
      {
         for (int i = 0; i < story.currentChoices.Count; i++)
         {
            Choice choice = story.currentChoices[i];
            Button button = CreateChoiceView(choice.text.Trim());
            button.onClick.AddListener(() => OnClickChoiceButton(choice));

         }
      }
      else
      {
         Button choice = CreateChoiceView("Continue");
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
         string[] parts = text.Split(':');
         if (parts.Length >= 2)
         {
            speakerName.text = parts[0];
            storyText.text = parts[1];
         }
         else
         {
            speakerName.text = string.Empty;
            storyText.text = text;
         }
      }
   private Button CreateChoiceView(string text)
             {
                var choice = Instantiate(buttonPrefab, choiceHolder.transform, false);
       
                var choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
                choiceText.text = text;
       
                return choice;
             }
   
}
