using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;

public class SecondFormat
{
    public string num;
    public string name;
    public string call;
    public int width;
    public int height;

    public SecondFormat(string num, string name, string call, int width, int height)
    {
        this.num = num;
        this.name = name;
        this.call = call;
        this.width = width;
        this.height = height;
    }
}

public class Second : MonoBehaviour
{
    public delegate int getButton();

    [SerializeField] Text loadingText;
    [SerializeField] Text numText;
    [SerializeField] Text nameText;
    [SerializeField] Text callText;

    [SerializeField] Image loadImage;

    string filePath;
    string files;
    string imgfiles;

    string names;
    string num;
    string call;

    private void Start()
    {
        filePath = Application.persistentDataPath + @"\saves";
        files = @"\save.json";
        imgfiles = @"\i.png";
    }

    public void SaveFile(Image img)
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        StartCoroutine(loadingDelete("저장중"));

        SecondFormat test = new SecondFormat(num, names, call, img.sprite.texture.width, img.sprite.texture.height);
        var t = JsonUtility.ToJson(test);
        var t2 = JsonConvert.SerializeObject(test);
        File.WriteAllText(filePath + files, t);

        SaveImageFormatTest test1 = new SaveImageFormatTest();
        print(img);
        test1.images = img.sprite.texture;
        var bytes = test1.images.EncodeToPNG();
        File.WriteAllBytes(filePath + imgfiles, bytes);
    }

    public void LoadData()
    {
        StartCoroutine(loadingDelete("로딩중"));

        var stringText = File.ReadAllText(filePath + files);
        var textData = JsonConvert.DeserializeObject<SecondFormat>(stringText);

        var tt = File.ReadAllBytes(filePath + imgfiles);
        Texture2D texture = new Texture2D(textData.width, textData.height);
        texture.LoadImage(tt);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, textData.width, textData.height), new Vector2(0.5f, 0), 1);

        loadImage.sprite = sp;

        numText.text = textData.num;
        nameText.text = textData.name;
        callText.text = textData.call;
    }

    public void GetName(string text)
    {
        names = text;
    }

    public void GetCall(string text)
    {
        call = text;
    }

    public void GetNum(string text)
    {
        num = text;
    }
    IEnumerator loadingDelete(string txt)
    {
        loadingText.text = txt;
        yield return new WaitForSeconds(1f);
        loadingText.text = "";
    }

}
