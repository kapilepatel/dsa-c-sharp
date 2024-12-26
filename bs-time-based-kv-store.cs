/*

Time Based Key-Value Store

Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.

Implement the TimeMap class:

TimeMap() Initializes the object of the data structure.
void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp. If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".
 

Example 1:

Input
["TimeMap", "set", "get", "get", "set", "get", "get"]
[[], ["foo", "bar", 1], ["foo", 1], ["foo", 3], ["foo", "bar2", 4], ["foo", 4], ["foo", 5]]
Output
[null, null, "bar", "bar", null, "bar2", "bar2"]

Explanation
TimeMap timeMap = new TimeMap();
timeMap.set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
timeMap.get("foo", 1);         // return "bar"
timeMap.get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
timeMap.set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
timeMap.get("foo", 4);         // return "bar2"
timeMap.get("foo", 5);         // return "bar2"
 

Constraints:

1 <= key.length, value.length <= 100
key and value consist of lowercase English letters and digits.
1 <= timestamp <= 107
All the timestamps timestamp of set are strictly increasing.
At most 2 * 105 calls will be made to set and get.

 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */

 using System.Diagnostics;

public class TimeBasedKeyValueStore
{

    public static void Run()
    {
        TimeMap timeMap = new TimeMap();
        timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
        
        string result1 = timeMap.Get("foo", 1);         // return "bar"
        Debug.Assert(result1 == "bar", "Test 1 Failed: Expected 'bar', got " + result1);

        string result2 = timeMap.Get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        Debug.Assert(result2 == "bar", "Test 2 Failed: Expected 'bar', got " + result2);

        timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.

        string result3 = timeMap.Get("foo", 4);         // return "bar2"
        Debug.Assert(result3 == "bar2", "Test 3 Failed: Expected 'bar2', got " + result3);

        string result4 = timeMap.Get("foo", 5);         // return "bar2"
        Debug.Assert(result4 == "bar2", "Test 4 Failed: Expected 'bar', got " + result4);
        Console.WriteLine("All tests passed!");

    }
}



public class TimeMap
{
    Dictionary<string, SortedList<int, string>> data;

    public TimeMap()
    {
        data = new Dictionary<string, SortedList<int, string>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        SortedList<int, string>? keyData;
        if (data.TryGetValue(key, out keyData))
        {
            if (keyData.ContainsKey(timestamp))
            {
                keyData[timestamp] = value;
            }
            else
            {
                keyData.Add(timestamp, value);
            }
        }
        else
        {
            keyData = new SortedList<int, string>();
            keyData.Add(timestamp, value);
            data.Add(key, keyData);
        }
    }

    public string Get(string key, int timestamp)
    {
        if (data.TryGetValue(key, out SortedList<int, string>? keyData))
        {
            int left = 0;
            int right = keyData.Keys.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (keyData.Keys[mid] == timestamp)
                {
                    return keyData.Values[mid];
                }
                if (timestamp < keyData.Keys[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (right >= 0)
            {
                return keyData.Values[right];
            }
        }
        return "";
    }
}
