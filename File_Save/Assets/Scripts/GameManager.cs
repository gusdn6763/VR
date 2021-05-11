using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    string filePath;
    string files;
    string imgfiles;
    string imgsize;
    [SerializeField] UnityEngine.UI.Image loadImage;
    [SerializeField] UnityEngine.UI.Image newimage;

    private void Start()
    {
        filePath = Application.persistentDataPath + @"\saves";
        files = @"\save.json";
        imgfiles = @"\i.png";
        imgsize = @"\img.json";
    }

    public void SaveFile(string fileName)
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        SaveFormatTest test = new SaveFormatTest("abcd", 11, fileName);
        var t = JsonUtility.ToJson(test);
        var t2 = JsonConvert.SerializeObject(test);
        File.WriteAllText(filePath + files, t);
    }

    public void LoadData()
    {
        var stringData = File.ReadAllText(filePath + files);
        var data = JsonConvert.DeserializeObject<SaveFormatTest>(stringData);
        print(data.name);
        print(data.age);

        loadImage.sprite = Resources.Load<Sprite>(data.fileName);

    }

    public void SaveImage()
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        SaveImageFormatTest test = new SaveImageFormatTest();
        SaveImageSizeFormatTest size = new SaveImageSizeFormatTest(loadImage.sprite.texture.width, loadImage.sprite.texture.height);

        test.images = loadImage.sprite.texture;
        var bytes = test.images.EncodeToPNG();
        File.WriteAllBytes(filePath + imgfiles, bytes);

        var t = JsonUtility.ToJson(size);
        var t2 = JsonConvert.SerializeObject(size);
        File.WriteAllText(filePath + imgsize, t);

        print(size.width);
    }

    public void LoadImage()
    {
        if(File.Exists(filePath + imgfiles))
        {
            var stringData = File.ReadAllText(filePath + imgsize);
            var data = JsonConvert.DeserializeObject<SaveImageSizeFormatTest>(stringData);

            var tt = File.ReadAllBytes(filePath + imgfiles);

            Texture2D texture = new Texture2D(data.width, data.height);
            texture.LoadImage(tt);
            Sprite sp = Sprite.Create(texture, new Rect(0, 0, data.width, data.height), new Vector2(0.5f, 0), 1);

            newimage.sprite = sp;
        }
    }
}