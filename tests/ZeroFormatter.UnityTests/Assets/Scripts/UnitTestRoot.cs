﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitTestRoot : MonoBehaviour
{
    static Dictionary<string, List<KeyValuePair<string, Action>>> tests = new Dictionary<string, List<KeyValuePair<string, Action>>>();

    public Button clearButton;
    public RectTransform list;
    public Scrollbar listScrollBar;

    public Text logText;
    public Scrollbar logScrollBar;

    void Start()
    {
        // register unexpected log
        Application.logMessageReceived += (string condition, string stackTrace, LogType type) =>
        {
            if (type == LogType.Error || type == LogType.Exception)
            {
                logText.text += "<color=red>" + condition + "\n" + stackTrace + "</color>\n";
            }
            else
            {
                logText.text += condition + "\n";
            }
        };

        clearButton.onClick.AddListener(() =>
        {
            logText.text = "";
        });

        var executeAll = new List<UnityAction>();
        foreach (var ___item in tests)
        {
            var actionList = ___item; // be careful, capture in lambda

            UnityAction groupAction = () =>
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                foreach (var btn in list.GetComponentsInChildren<Button>()) btn.interactable = false;

                logText.text += "<color=yellow>" + actionList.Key + "</color>\n";
                foreach (var item2 in actionList.Value)
                {
                    logText.text += "<color=teal>" + item2.Key + "</color>\n";
                    try
                    {
                        item2.Value();
                        logText.text += "OK" + "\n";
                    }
                    catch (Exception ex)
                    {
                        // found match line...
                        var line = string.Join("\n", ex.StackTrace.Split('\n').Where(x => x.Contains(actionList.Key) || x.Contains(item2.Key)).ToArray());
                        logText.text += "<color=red>" + ex.Message + "\n" + line + "</color>\n";
                    }
                }

                sw.Stop();
                logText.text += "[" + actionList.Key + " Complete]" + sw.Elapsed.TotalMilliseconds + "ms\n\n";
                foreach (var btn in list.GetComponentsInChildren<Button>()) btn.interactable = true;
                StartCoroutine(ScrollLogToEndNextFrame());
            };

            executeAll.Add(groupAction);
            Add(actionList.Key, groupAction);
        }

        var executeAllButton = Add("Run All Tests", () =>
        {
            foreach (var item in executeAll)
            {
                item();
            }
        });

        clearButton.gameObject.GetComponent<Image>().color = new Color(170 / 255f, 170 / 255f, 170 / 255f, 1);
        executeAllButton.gameObject.GetComponent<Image>().color = new Color(250 / 255f, 150 / 255f, 150 / 255f, 1);
        executeAllButton.transform.SetSiblingIndex(1);

        listScrollBar.value = 1;
        logScrollBar.value = 1;
    }

    Button Add(string title, UnityAction test)
    {
        var newButton = GameObject.Instantiate(clearButton);
        newButton.name = title;
        newButton.onClick.RemoveAllListeners();
        newButton.GetComponentInChildren<Text>().text = title;
        newButton.onClick.AddListener(test);

        newButton.transform.SetParent(list);
        return newButton;
    }

    public static void AddTest(string group, string title, Action test)
    {
        List<KeyValuePair<string, Action>> list;
        if (!tests.TryGetValue(group, out list))
        {
            list = new List<KeyValuePair<string, Action>>();
            tests[group] = list;
        }

        list.Add(new KeyValuePair<string, Action>(title, test));
    }

    System.Collections.IEnumerator ScrollLogToEndNextFrame()
    {
        yield return null;
        yield return null;
        logScrollBar.value = 0;
    }
}