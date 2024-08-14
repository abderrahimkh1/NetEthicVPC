using UnityEngine;
using TMPro;

public class DisplayUserName : MonoBehaviour
{
    public TextMeshProUGUI userNameText;

    private void Start()
    {
        if (PersistentDataManager.Instance != null)
        {
            userNameText.text = "Welcome, " + PersistentDataManager.Instance.UserName;
        }
    }
}
