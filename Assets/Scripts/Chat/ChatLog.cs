using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatLog : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> chat = new List<TMP_Text>();
    [SerializeField] private bool IsGhettoChat;
    private List<string> messages = new List<string>();
    private ChatActions chatActions = new ChatActions();
    private ChatEvents chatEvents = new ChatEvents();

    private void Awake()
    {
        chatActions.GeneratePlayerList();
        ClearChat();
        if(!IsGhettoChat)
        {
            StartCoroutine(ChatActive());
            StartCoroutine(ChatEvents(chatEvents.GetEvent(chatActions.GetNamesList())));
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator ChatEvents(List<string> msg)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(18.1f, 30.9f));
            for (int i = 0; i < msg.Count; i++)
            {
                yield return new WaitForSeconds(Random.Range(1.1f, 2.1f));
                AddMesage(msg[i]);
            }
            msg = chatEvents.GetEvent(chatActions.GetNamesList());
        }
    }
    private IEnumerator ChatActive()
    {
        while (true)
        {
            AddMesage(chatActions.GetMsg());
            yield return new WaitForSeconds(Random.Range(2.1f,3.9f));
        }
    }
    public List<string> GetLog()
    {
        return messages;
    }
    
    public void ClearChat()
    {
        messages.Clear();
        for (int i = 0; i < chat.Count; i++)
        {
            chat[i].text = string.Empty;
        }
    }
    public void AddMesage(string text)
    {
        messages.Insert(0, text);
        UpdateChat();
    }
    private void UpdateChat()
    {
        for (int i = 0; i < chat.Count; i++)
        {
            if (messages[i] != null)
                messages.Add(string.Empty);
            chat[i].text = messages[i];
        }
        if (messages[chat.Count]  != null)
        {
            messages.RemoveAt(chat.Count);
        }
    }
}
