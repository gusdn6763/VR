//������ ������ ���� �����͸� ���� Ŭ����
public class SaveFormatTest
{
    public string fileName;
    public string name;
    public int age;
    public UnityEngine.Sprite sprite;

    public SaveFormatTest(string name, int age, string fileName)
    {
        this.name = name;
        this.age = age;
        this.fileName = fileName;
    }
}

[System.Serializable]
public class SaveImageSizeFormatTest
{
    public int width;
    public int height;
    public SaveImageSizeFormatTest(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
}
[System.Serializable]
public class SaveImageFormatTest
{
    public UnityEngine.Texture2D images;
}