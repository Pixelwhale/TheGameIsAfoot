using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader
{
    private List<string[]> stringData;

    public FileReader()
    {
        stringData = new List<string[]>();
    }

    public void ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("File not exist : " + path);
            return;
        }

        File.OpenRead(path);
        stringData.Clear();
        using (var sr = new System.IO.StreamReader(path))
        {
            //ストリームの末尾まで繰り返す
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                //読み込んだ1行をカンマごとに分けて配列に格納する
                var values = line.Split(' ');

                //Listに登録する
                stringData.Add(values);
            }
            Debug.Log("Reading File success");
        }
    }

    public string GetData(int rowIndex, int columnIndex)
    {
        return stringData[rowIndex][columnIndex];
    }
}