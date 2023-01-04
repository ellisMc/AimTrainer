using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static StartMenu instance;

    List<HashNode> inputs = new List<HashNode>();
    Hashtable myhashtable = new Hashtable();
    HashNode CurrentUser = new HashNode(1, "", "", 1, 1);

    private string username = "";
    private string password = "";
    private bool IsEmpty = true;

    void Awake()
    {
        instance = this;
    }

    public void ReadUsername(string s)
    {
        username = s;
        Debug.Log("New username: " + username);
    }

    public void ReadPassword(string r)
    {
        password = r;
        Debug.Log("New password: " + password);
    }

    public string[] GetDetails()
    {
        string[] details = { username, password };
        return details;
    }

    public bool CheckUsername()
    {
        if (CheckEmpty(username))
        {
            HashNode UserHashNode = new HashNode(1, username, "", 1, 1);
            if (!CheckHash(UserHashNode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool CheckPassword()
    {
        return (CheckEmpty(password));
    }

    bool CheckEmpty(string s)
    {
        if (s.Length < 1)
        {
            IsEmpty = true;
            return false;
        }
        else
        {
            IsEmpty = false;
            return true;
        }
    }

    /*public void TestForHash()
    {
        HashNode TestHash = (HashNode)myhashtable[0];
        Debug.Log(TestHash.GetValue());
        TestHash = (HashNode)myhashtable[1];
        Debug.Log(TestHash.GetValue());

    }*/

    public bool GetEmptyStatus()
    {
        if (IsEmpty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CreateHashNode(string s, string p, int a, int g)
    {
        HashNode node = new HashNode(1, s, p, a, g);
        inputs.Add(node);
        Debug.Log("HashNode Created");
    }

    public bool CheckLoginHashNode(string s)
    {
        HashNode node = new HashNode(1, s, "", 1, 1);
        CurrentUser = node;
        return (CheckHash(CurrentUser));
    }

    public string GetUserPassword()
    {
        return (FindHashNodePass(CurrentUser));
    }

    public HashNode RetrieveHashNode()
    {
        HashNode Hashholder = inputs[0];
        inputs.Remove(inputs[0]);
        Debug.Log("HashNode retrived");
        return Hashholder;
    }

    static int hashing(string s)
    {
        int holder = 0;
        foreach (char c in s)
        {
            holder += (int)c;
        }
        holder = holder % 50;
        return holder;
    }

    public void HashAdd(HashNode s)
    {
        int index = hashing(s.GetValue());
        s.SetKey(index);
        if (CheckKey(index))
        {
            HashNode mem = (HashNode)myhashtable[index];
            s.Traverse(mem, s);
        }
        else
        {
            myhashtable.Add(index, s);
        }
        Debug.Log("HashNode add to table");
    }

    bool CheckKey(int i)
    {
        if (myhashtable.ContainsKey(i))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckHash(HashNode s)
    {
        int index = hashing(s.GetValue());
        if (CheckKey(index))
        {
            HashNode mem = (HashNode)myhashtable[index];
            if (s.CheckInHashTable(mem, s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    string FindHashNodePass(HashNode s)
    {
        int index = hashing(s.GetValue());
        HashNode mem = (HashNode)myhashtable[index];
        return (s.GetHashNodePassword(mem, s));
    }

    public void UpdateCurrentUser(HashNode current)
    {
        CurrentUser = current;
    }
}

public class HashNode
{
    int key;
    string value;
    string pass;
    int age;
    int gender;
    HashNode next;
    public HashNode(int k, string v, string p, int a, int g)
    {
        this.key = k;
        this.value = v;
        this.pass = p;
        this.age = a;
        this.gender = g;
        this.next = null;
    }
    public int GetKey()
    {
        return key;
    }
    public void SetKey(int i)
    {
        this.key = i;
    }
    public string GetValue()
    {
        return value;
    }
    public string GetPass()
    {
        return pass;
    }
    public int GetAge()
    {
        return age;
    }
    public int GetGender()
    {
        return gender;
    }
    public HashNode GetNext()
    {
        if (next == null)
        {
            Debug.Log("no next value");
            return next;
        }
        else
        {
            return next;
        }
    }
    public HashNode GetHashNode(HashNode current)
    {
        return current;
    }
    public void SetNextNode(HashNode current, HashNode link)
    {
        current.next = link;
    }
    public void Traverse(HashNode current, HashNode link)
    {
        if (current.next != null)
        {
            Traverse(current.next, link);
        }
        else
        {
            SetNextNode(current, link);
        }

    }

    public bool CheckInHashTable(HashNode current, HashNode check)
    {
        while (current != null)
        {
            if (current.GetValue() == check.GetValue())
            {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public string GetHashNodePassword(HashNode current, HashNode check)
    {
        while (current != null)
        {
            if (current.GetValue() == check.GetValue())
            {
                return current.GetPass();
            }
            current = current.next;
        }
        return "";
    }
}
