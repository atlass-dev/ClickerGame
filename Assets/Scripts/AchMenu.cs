using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchMenu : MonoBehaviour
{
    public int money;
    public int total_money;
    [SerializeField] bool isFirst;

    public string[] arrayTitles;
    public Sprite[] arraySprites;
    public GameObject small;
    public GameObject content;
    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;

        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        _group = GetComponent<VerticalLayoutGroup>();
        setSmall();
    }

    private void RemovedList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }


    void setSmall()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        RemovedList();
        if (arrayTitles.Length > 0)
        {
            var pr1 = Instantiate(small, transform);
            var h = pr1.GetComponent<RectTransform>().rect.height;
            var tr = GetComponent<RectTransform>();
            tr.sizeDelta = new Vector2(tr.rect.width, h * arrayTitles.Length);
            Destroy(pr1);
            for (var i = 0; i < arrayTitles.Length; i++)
            {
                var pr = Instantiate(small, transform);
                pr.GetComponentInChildren<Text>().text = arrayTitles[i];
                pr.GetComponentsInChildren<Image>()[1].sprite = arraySprites[i];
                var i1 = i;
                pr.GetComponent<Button>().onClick.AddListener(() => GetAchievement(i1));
                list.Add(pr);
            }
        }
    }

    void GetAchievement(int id)
    {
        switch (id)
        {
            case 0:
                Debug.Log(id);
                if (!isFirst)
                {
                    isFirst = true;
                    PlayerPrefs.SetInt("isFirst", isFirst ? 1 : 0);
                    Debug.Log("получено");
                }
                break;
            case 1:
                Debug.Log(id);
                money += 10;
                PlayerPrefs.SetInt("money", money);
                break;
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        
    }
}
