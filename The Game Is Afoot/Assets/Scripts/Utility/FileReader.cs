using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader
{
    private List<string[]> mStringData;

    public FileReader()
    {
        mStringData = new List<string[]>();
    }

    /// <summary>
    /// ファイルを読み込む（全資料）
    /// </summary>
    public void ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("File not exist : " + path);
            return;
        }

        File.OpenRead(path);
        mStringData.Clear();
        using (var sr = new System.IO.StreamReader(path))
        {
            //一行目は説明ので、読み込まない
            sr.ReadLine();

            string line;
            string[] values;

            //ストリームの末尾まで繰り返す
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                values = line.Split(' ');
                mStringData.Add(values);
            }
            Debug.Log("Reading File success");
        }
    }

    /// <summary>
    /// 指定indexのデータを取得
    /// </summary>
    public string[] GetRow(int index)
    {
        //1行目はテスト資料
        for (int i = 1; i < mStringData.Count; ++i)
        {
            if (int.Parse(mStringData[i][0]) == index)
            {
                return mStringData[i];
            }
        }
        Debug.LogError("GetRow fail at index " + index);
        return mStringData[1];
    }

    /// <summary>
    /// 指定のデータを取得
    /// </summary>
    public string GetData(int index, int column)
    {
        //1行目はテスト資料
        for (int i = 1; i < mStringData.Count; ++i)
        {
            if (int.Parse(mStringData[i][0]) == index)
            {
                return mStringData[i][column];
            }
        }
        Debug.LogError("GetData fail at index " + index);
        return mStringData[1][column];
    }
}