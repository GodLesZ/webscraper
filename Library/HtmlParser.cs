using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Library {

    internal class HtmlParser {
        public struct XPathNode {
            public HtmlElement Element;
            public string TagName;
            public int Index;
            public string ClassName;
        }

        private struct SimpleHtmlElement {
            public string TagName;
            public int Index;
            public string ClassName;
        }

        private class HeadRequestWebClient : WebClient {
            public bool HeadOnly { get; set; }

            protected override WebRequest GetWebRequest(Uri address) {
                var webRequest = base.GetWebRequest(address);
                if (webRequest != null && (HeadOnly && webRequest.Method == "GET")) {
                    webRequest.Method = "HEAD";
                }
                return webRequest;
            }
        }

        private static HtmlElement _rootBaseElement;
        private static ArrayList _rootPathList;

        public static void ResetState() {
            _rootBaseElement = null;
            _rootPathList = null;
        }

        private static int GetIndex(HtmlElement element) {
            return element.Parent != null ? GetIndex(element, element.Parent) : 0;
        }

        private static HtmlElement GetSiblingElement(HtmlElement element) {
            HtmlElement htmlElement = null;
            var index = GetIndex(element);
            if (element.Parent != null && element.Parent.Children.Count > index + 1) {
                htmlElement = element.Parent.Children[index + 1];
            }
            return htmlElement;
        }

        private static int GetIndex(HtmlElement element, HtmlElement parent) {
            var index = -1;
            var i = 0;
            try {
                if (element != null && parent != null) {
                    // Search children and compare object
                    var children = parent.Children;
                    foreach (HtmlElement htmlElement in children) {
                        if (htmlElement.Equals(element)) {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    if (index == -1) {
                        // Search children and compare class/tag/id
                        i = 0;
                        foreach (HtmlElement element1 in children) {
                            if (element1.TagName == element.TagName && element1.Id == element.Id && (GetElementClassName(element1) == GetElementClassName(element) && element1.InnerHtml == element.InnerHtml)) {
                                index = i;
                                break;
                            }

                            i++;
                        }
                    }

                    if (index == -1) {
                        // Search children siblings and compare class/tag/id
                        i = 0;
                        var element1 = parent.FirstChild;
                        while (element1 != null) {
                            if (element1.TagName == element.TagName && element1.Id == element.Id && (GetElementClassName(element1) == GetElementClassName(element) && element1.InnerHtml == element.InnerHtml)) {
                                index = i;
                                break;
                            }

                            element1 = element1.NextSibling;
                            i++;
                        }
                    }
                }
            } catch {
            }

            return index;
        }

        public static string GetXPath(HtmlElement element) {
            var arrayList = new ArrayList();
            string str1 = "";
            for (; element != (HtmlElement)null; element = element.Parent) {
                var xnode1 = new XPathNode();
                string str2 = GetElementClassName(element);
                if (string.IsNullOrEmpty(str2))
                    str2 = " ";
                int index = GetIndex(element);
                if (-1 == index) {
                    while (arrayList.Count != 0) {
                        xnode1 = (XPathNode)arrayList[arrayList.Count - 1];
                        arrayList.Remove(xnode1);
                        xnode1.Index = -1;
                        if (-1 != GetIndex(xnode1.Element, element.Parent)) {
                            xnode1.Index = GetIndex(xnode1.Element, element.Parent);
                            break;
                        }
                    }
                }
                if (-1 != index) {
                    XPathNode xnode2;
                    xnode2.Element = element;
                    xnode2.ClassName = str2;
                    xnode2.TagName = element.TagName;
                    xnode2.Index = index;
                    arrayList.Add(xnode2);
                } else if (-1 != xnode1.Index) {
                    arrayList.Add(xnode1);
                } else {
                    arrayList.Clear();
                    break;
                }
            }
            foreach (XPathNode xnode in arrayList)
                str1 = xnode.TagName + "[" + xnode.Index + "][" + xnode.ClassName + "]\\" + str1;
            return str1;
        }

        public static string GetUrlFromElement(string currentUrl, HtmlElement element) {
            var urlFromElement = "";
            string html = null;
            if (element.TagName == "A" || element.TagName == "INPUT") {
                html = element.OuterHtml;
            } else if (element.Parent != null && element.Parent.TagName != null && element.Parent.TagName == "A") {
                html = element.Parent.OuterHtml;
            }

            if (html == null) {
                return urlFromElement;
            }

            var htmlLower = html.ToLower();
            var startIndex = htmlLower.IndexOf("href", StringComparison.Ordinal);
            if (startIndex == -1) {
                return urlFromElement;
            }

            var strArray = htmlLower.Substring(startIndex).Split('"');
            if (strArray.Length <= 1) {
                return urlFromElement;
            }

            urlFromElement = strArray[1];
            if (urlFromElement.Contains("http")) {
                return urlFromElement;
            }

            if (urlFromElement.StartsWith("/")) {
                var num1 = currentUrl.IndexOf('/');
                var num2 = currentUrl.IndexOf('/', num1 + 1);
                var num3 = currentUrl.IndexOf('/', num2 + 1);
                currentUrl = currentUrl.Substring(0, num3 + 1);
                return currentUrl + urlFromElement;
            }

            currentUrl = currentUrl.Substring(0, currentUrl.LastIndexOf('/') + 1);
            return currentUrl + urlFromElement;
        }

        public static string RefineElementText(string text, string regex) {
            var str = text;
            if (text != null && text != "" && regex != null) {
                var match = Regex.Match(text, regex, RegexOptions.Multiline);
                if (match.Success) {
                    str = match.Groups[0].Value;
                    if (match.Groups[1].Success) {
                        str = match.Groups[1].Value;
                        for (var index = 2; index < match.Groups.Count; ++index) {
                            if (match.Groups[index].Success)
                                str = str + match.Groups[index].Value;
                        }
                    }
                } else
                    str = " ";
            }
            return str;
        }

        public static string GetElementText(HtmlElement element, bool delLineBreaks = true) {
            string text = null;
            if (element != null) {
                text = element.InnerText;
                if (delLineBreaks && text != null) {
                    text = text.Replace('\n', ' ');
                }
            }
            if (string.IsNullOrEmpty(text)) {
                text = " ";
            }
            return text;
        }

        private static string GetTextFollowingElementCore(HtmlElement headingElement, string headingText) {
            var text = string.Empty;
            try {
                if (headingElement.Parent != null) {
                    var innerText = headingElement.Parent.InnerText;
                    var siblingElement = GetSiblingElement(headingElement);
                    if (siblingElement == null || string.IsNullOrEmpty(siblingElement.InnerText)) {
                        for (var parent = headingElement.Parent; innerText.Trim() == headingText.Trim() && !(parent.Parent == null); innerText = parent.InnerText) {
                            parent = parent.Parent;
                        }
                        text = innerText.Substring(innerText.IndexOf(headingText, StringComparison.Ordinal) + headingText.Length);
                    } else {
                        var innerText2 = siblingElement.InnerText;
                        var startIndex = innerText.IndexOf(headingText, StringComparison.Ordinal) + headingText.Length;
                        var length = innerText.IndexOf(innerText2, startIndex, StringComparison.Ordinal) - startIndex;
                        text = length < 0 || innerText.Substring(startIndex, length).Trim() == string.Empty ? innerText2 : innerText.Substring(startIndex, length);
                    }
                }
            } catch {
                text = "";
            }
            return text;
        }

        public static string GetTextNearHeading(HtmlElement element, string heading) {
            string text = null;
            if (element != null) {
                for (var index = 0; index < element.Children.Count; ++index) {
                    var htmlElement = element.Children[index];
                    var elementText = GetElementText(htmlElement);
                    if (elementText == null || !elementText.StartsWith(heading)) {
                        continue;
                    }

                    text = GetTextFollowingElementCore(htmlElement, heading);
                    break;
                }
            }
            if (string.IsNullOrEmpty(text)) {
                text = " ";
            }
            return text;
        }

        public static string GetTextNearHeadingBruteForce(HtmlDocument htmlDoc, string heading) {
            string text = null;
            var i = 0;
            do {
                foreach (HtmlElement headingElement in htmlDoc.All) {
                    if (headingElement.InnerText == null || heading == null || headingElement.InnerText.Trim().Equals(heading.Trim()) == false) {
                        continue;
                    }

                    text = GetTextFollowingElementCore(headingElement, heading);
                    break;
                }
                i++;
                if (heading != null && (text == null && heading.Trim().EndsWith(":"))) {
                    heading = heading.Trim();
                    heading = heading.Remove(heading.Length - 1);
                } else {
                    break;
                }
            }
            while (i < 2);

            if (string.IsNullOrEmpty(text)) {
                text = " ";
            }
            return text;
        }

        public static string GetElementHtml(HtmlElement element) {
            string html = null;
            if (element != null && element.InnerHtml != null) {
                html = element.OuterHtml;
            }
            return html;
        }

        public static string GetElementUrl(HtmlElement element) {
            string url = null;
            if (element != null) {
                if (element.TagName != "A" && element.Parent != null && element.Parent.TagName == "A") {
                    element = element.Parent;
                }
                url = element.GetAttribute("href");
            }
            if (url == null) {
                url = " ";
            }
            if (url.ToLower().StartsWith("mailto:")) {
                url = url.Substring("mailto:".Length);
            }
            return url;
        }

        public static string GetElementImageUrl(HtmlElement element) {
            string url = " ";
            if (element == null) {
                return url;
            }
            if (element.TagName == "IMG") {
                return element.GetAttribute("href");
            }

            foreach (HtmlElement htmlElement in element.Children) {
                if (htmlElement.TagName != "IMG") {
                    continue;
                }

                url = htmlElement.GetAttribute("href");
                break;
            }

            return url;
        }

        private static string GetElementClassName(HtmlElement element) {
            string className = null;
            try {
                if (element != null) {
                    className = element.GetAttribute("className");
                    if (className == "" || className == " ") {
                        className = element.GetAttribute("itemprop");
                    }
                    className = className.Replace('[', ' ').Replace(']', ' ').Replace('\\', ' ');
                    if (className == "") {
                        className = " ";
                    }
                }
            } catch {
                className = " ";
            }

            return className;
        }

        public static HtmlElement GetElement(HtmlDocument htmlDoc, string xpath) {
            HtmlElement htmlElement = null;
            var num1 = 10;
            if (htmlDoc == null || xpath == null || xpath.Trim().Length == 0) {
                return null;
            }

            var parentElement = htmlDoc.Body;
            if (parentElement == null) {
                return null;
            }

            var strArray1 = xpath.Split(new[]
            {
                '[',
                ']',
                '\\'
            });
            while (num1 < strArray1.Length - 1) {
                var strArray2 = strArray1;
                var index1 = num1;
                var num2 = 1;
                var num3 = index1 + num2;
                var str1 = strArray2[index1];
                var strArray3 = strArray1;
                var index2 = num3;
                var num4 = 1;
                var num5 = index2 + num4;
                var index3 = int.Parse(strArray3[index2]);
                var num6 = num5 + 1;
                var strArray4 = strArray1;
                var index4 = num6;
                var num7 = 1;
                var num8 = index4 + num7;
                var className = strArray4[index4];
                num1 = num8 + 1;

                SimpleHtmlElement simpleHtmlElement;
                simpleHtmlElement.ClassName = className;
                simpleHtmlElement.Index = index3;
                simpleHtmlElement.TagName = str1;
                HtmlElement element;
                if (index3 >= parentElement.Children.Count) {
                    element = FindMatchingElement(parentElement, simpleHtmlElement);
                    if (null == element)
                        break;
                } else {
                    element = parentElement.Children[index3];
                    if (element.TagName != str1) {
                        element = FindMatchingElement(parentElement, simpleHtmlElement);
                        if (null == element)
                            break;
                    } else if (className != " " && className != GetElementClassName(element)) {
                        var matchingElement = FindMatchingElement(parentElement, simpleHtmlElement);
                        if (matchingElement != null)
                            element = matchingElement;
                    }
                }
                parentElement = element;
            }
            if (num1 == strArray1.Length - 1)
                htmlElement = parentElement;
            return htmlElement;
        }

        public static int ValidChildCount(HtmlElement element) {
            var childCount = 0;
            if (element == null) {
                return childCount;
            }
            foreach (HtmlElement htmlElement in element.Children) {
                if (htmlElement.OuterHtml != null && !htmlElement.OuterHtml.StartsWith("<!--") && (htmlElement.TagName != null && htmlElement.TagName != "BR"))
                    childCount++;
            }
            return childCount;
        }

        private static HtmlElement FindMatchingElement(HtmlElement parentElement, SimpleHtmlElement simpleHtmlElement) {
            HtmlElement element = null;
            try {
                var child = parentElement.FirstChild;
                int i;
                for (i = 0; child != (HtmlElement)null && i < simpleHtmlElement.Index; ++i) {
                    child = child.NextSibling;
                }
                if (i == simpleHtmlElement.Index && null != child && (child.TagName == simpleHtmlElement.TagName && GetElementClassName(child) == simpleHtmlElement.ClassName)) {
                    element = child;
                }
                for (var index = 0; index < 10 && (HtmlElement)null == element; ++index) {
                    if (simpleHtmlElement.Index + index >= 0 && simpleHtmlElement.Index + index < parentElement.Children.Count && (parentElement.Children[simpleHtmlElement.Index + index].TagName == simpleHtmlElement.TagName && GetElementClassName(parentElement.Children[simpleHtmlElement.Index + index]) == simpleHtmlElement.ClassName)) {
                        element = parentElement.Children[simpleHtmlElement.Index + index];
                        break;
                    }
                    if (simpleHtmlElement.Index - index < 0 || simpleHtmlElement.Index - index >= parentElement.Children.Count || (parentElement.Children[simpleHtmlElement.Index - index].TagName != simpleHtmlElement.TagName || GetElementClassName(parentElement.Children[simpleHtmlElement.Index - index]) != simpleHtmlElement.ClassName)) {
                        continue;
                    }

                    element = parentElement.Children[simpleHtmlElement.Index - index];
                    break;
                }
                if (element == null) {
                    if (parentElement.Children.Count > simpleHtmlElement.Index) {
                        var htmlElement2 = parentElement.Children[simpleHtmlElement.Index];
                        if (htmlElement2.Children.Count > 0) {
                            var element2 = htmlElement2.Children[0];
                            if (element2.TagName == simpleHtmlElement.TagName) {
                                if (GetElementClassName(element2) == simpleHtmlElement.ClassName)
                                    element = element2;
                            }
                        }
                    }
                }
            } catch {
            }

            return element;
        }

        private static bool IsChild(HtmlElement baseElement, HtmlElement parentElement, HtmlElement childElement) {
            var flag = false;
            for (var htmlElement = childElement; htmlElement != (HtmlElement)null && htmlElement != baseElement; htmlElement = htmlElement.Parent) {
                if (htmlElement == parentElement) {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static HtmlElement GetNextElement(HtmlElement element) {
            var nextElement = GetNextElement(element, 10);
            if (nextElement == null) {
                nextElement = GetNextElement(element, 5);
                if (nextElement == null) {
                    nextElement = GetNextElement(element, 3);
                    if (nextElement == null) {
                        nextElement = GetNextElement(element, 2);
                        if (nextElement == null)
                            nextElement = GetNextElement(element, 1, 8);
                    }
                }
            }
            return nextElement;
        }

        public static HtmlElement GetNextElement(HtmlElement element, int minChildCount) {
            var minLevelsUp = Settings.Default.MinLevelsUp;
            return GetNextElement(element, minLevelsUp, minChildCount);
        }

        public static HtmlElement GetNextElement(HtmlElement element, int levelsUp, int minChildCount) {
            HtmlElement htmlElement1 = null;
            var arrayList = new ArrayList();
            var i = 0;
            var flag1 = true;
            var htmlElement2 = element;
            if (minChildCount > Settings.Default.MinChildCount) {
                return null;
            }

            SimpleHtmlElement simpleHtmlElement;
            for (; htmlElement2 != null && (i < levelsUp || ValidChildCount(htmlElement2) < minChildCount); ++i) {
                simpleHtmlElement.TagName = htmlElement2.TagName;
                simpleHtmlElement.Index = GetIndex(htmlElement2);
                simpleHtmlElement.ClassName = GetElementClassName(htmlElement2);
                arrayList.Insert(0, simpleHtmlElement);
                htmlElement2 = htmlElement2.Parent;
            }

            for (; htmlElement2 != null; htmlElement2 = htmlElement2.Parent) {
                var num2 = 1;
                HtmlElement htmlElement3;
                bool flag2;
                do {
                    htmlElement3 = htmlElement2;
                    flag2 = false;
                    for (var index = 0; index < arrayList.Count; ++index) {
                        simpleHtmlElement = (SimpleHtmlElement)arrayList[index];
                        if (index == 0)
                            simpleHtmlElement.Index += num2;
                        if (simpleHtmlElement.Index < 0 || simpleHtmlElement.Index >= htmlElement3.Children.Count) {
                            if (index == 0) {
                                flag2 = true;
                                break;
                            }
                            var matchingElement = FindMatchingElement(htmlElement3, simpleHtmlElement);
                            if (matchingElement != null && !IsChild(htmlElement2, matchingElement, element)) {
                                htmlElement3 = matchingElement;
                            } else {
                                flag2 = true;
                                break;
                            }
                        } else {
                            var parentElement = htmlElement3;
                            htmlElement3 = htmlElement3.Children[simpleHtmlElement.Index];
                            if (htmlElement3.Children.Count == 0 && simpleHtmlElement.ClassName == null) {
                                continue;
                            }

                            if (htmlElement3.TagName != simpleHtmlElement.TagName) {
                                if (index == 0) {
                                    flag2 = true;
                                    break;
                                }
                                if (simpleHtmlElement.ClassName == null) {
                                    continue;
                                }
                                
                                htmlElement3 = FindMatchingElement(parentElement, simpleHtmlElement);
                                if (null == htmlElement3) {
                                    flag2 = true;
                                    break;
                                }
                                if (!IsChild(htmlElement2, htmlElement3, element)) {
                                    continue;
                                }
                                
                                flag2 = true;
                                break;
                            }

                            if (simpleHtmlElement.ClassName == null || index == 0 || simpleHtmlElement.ClassName == GetElementClassName(htmlElement3)) {
                                continue;
                            }
                            
                            var matchingElement = FindMatchingElement(parentElement, simpleHtmlElement);
                            if (matchingElement != null && !IsChild(htmlElement2, matchingElement, element)) {
                                htmlElement3 = matchingElement;
                            }
                        }
                    }
                    if (flag2)
                        ++num2;
                }
                while (flag2 && num2 <= 100);

                if (!flag2) {
                    htmlElement1 = htmlElement3;
                    if (_rootBaseElement == null && flag1) {
                        _rootBaseElement = htmlElement2;
                        _rootPathList = new ArrayList(arrayList);
                    }

                    break;
                }

                if (htmlElement2 == _rootBaseElement) {
                    _rootBaseElement = null;
                    flag1 = false;
                    arrayList = new ArrayList(_rootPathList);
                }
                simpleHtmlElement.TagName = htmlElement2.TagName;
                simpleHtmlElement.Index = GetIndex(htmlElement2);
                simpleHtmlElement.ClassName = GetElementClassName(htmlElement2);
                arrayList.Insert(0, simpleHtmlElement);
            }

            return htmlElement1;
        }

        private static string RemoveStyleAttribute(string html) {
            var newHtml = html;
            if (string.IsNullOrEmpty(newHtml)) {
                return newHtml;
            }

            newHtml = newHtml.ToLower().Replace(" ", "");
            var startIndex = newHtml.IndexOf("style", StringComparison.Ordinal);
            if (startIndex == -1) {
                return newHtml;
            }

            var i = newHtml.IndexOf("\"", startIndex, StringComparison.Ordinal);
            if (i == -1) {
                return newHtml;
            }

            var j = newHtml.IndexOf("\"", i + 1, StringComparison.Ordinal);
            if (j != -1) {
                newHtml = newHtml.Remove(startIndex, j - startIndex + 1);
            }

            return newHtml;
        }

        public static bool IsElementClickable(HtmlElement element) {
            return element != null && (element.TagName == "A" || element.TagName == "INPUT" || element.Parent != null && element.Parent.TagName != null && element.Parent.TagName == "A");
        }

        public static bool IsElementLink(HtmlElement element) {
            if (element == null) {
                return false;
            }

            if (element.TagName != "A" && element.Parent != null && element.Parent.TagName == "A") {
                element = element.Parent;
            }
            var attribute = element.GetAttribute("href");
            return attribute.Trim() != "";
        }

        public static bool IsElementEmailAddr(HtmlElement element) {
            if (element == null) {
                return false;
            }

            var attribute = element.GetAttribute("href");
            return (attribute.Trim() != "" && attribute.StartsWith("mailto"));
        }

        public static bool IsElementImage(HtmlElement element) {
            if (element == null) {
                return false;
            }

            return element.TagName == "IMG" || element.Children.Cast<HtmlElement>().Any(htmlElement => htmlElement.TagName == "IMG");
        }

        private static bool IsListPager(HtmlElement element, int pageNumber) {
            if (element.NextSibling != null && element.NextSibling.InnerText != null && element.NextSibling.InnerText.Trim().Contains((pageNumber + 1).ToString(CultureInfo.InvariantCulture))) {
                return true;
            }
            var parent = element.Parent;
            if (parent == null || parent.Children.Count <= 0) {
                return false;
            }

            for (var index1 = 0; index1 < parent.Children.Count; ++index1) {
                if (parent.Children[index1] != element) {
                    continue;
                }

                for (var index2 = 0; index2 < index1; ++index2) {
                    if (parent.Children[index2].InnerText == null || parent.Children[index2].InnerText.Trim() != (pageNumber - 1).ToString(CultureInfo.InvariantCulture)) {
                        continue;
                    } 

                    return true;
                }
                
                for (var index2 = index1 + 1; index2 < parent.Children.Count; ++index2) {
                    if (parent.Children[index2].InnerText == null || parent.Children[index2].InnerText.Trim() != (pageNumber + 1).ToString(CultureInfo.InvariantCulture)) {
                        continue;
                    }
                        
                    return true;
                }
            }

            return false;
        }

        private static bool IsNextPageElement(string html, string nextString) {
            var flag = false;
            var input = RemoveStyleAttribute(html);
            try {
                if (html != null) {
                    if (input == nextString)
                        flag = true;
                    else if (input.Length - nextString.Length <= 2) {
                        if (Regex.Replace(input, "\\d", "") == Regex.Replace(nextString, "\\d", ""))
                            flag = true;
                    }
                }
            } catch (Exception) {
            }
            return flag;
        }

        public static HtmlElement GetNextPageElement(HtmlDocument htmlDoc, string nextString, int pageIndex) {
            HtmlElement htmlElement1 = null;
            var flag1 = true;
            var flag2 = false;
            var pageNumber = 0;
            if (htmlDoc == null || nextString == null) {
                return null;
            }

            if (nextString.StartsWith("<"))
                flag2 = true;
            if (flag2) {
                nextString = RemoveStyleAttribute(nextString);
            } else {
                int result;
                if (int.TryParse(nextString, out result)) {
                    pageNumber = result + (pageIndex - 2);
                    nextString = pageNumber.ToString(CultureInfo.InvariantCulture);
                    flag1 = false;
                }
            }
            foreach (HtmlElement element in htmlDoc.All) {
                if (flag2) {
                    if (!IsNextPageElement(element.OuterHtml, nextString)) {
                        continue;
                    }
                    htmlElement1 = element;
                    break;
                }
                if (element.InnerText != nextString && (flag1 || element.InnerText == null || element.InnerText.Trim() != nextString)) {
                    continue;
                }

                if (flag1) {
                    htmlElement1 = element;
                } else if (IsListPager(element, pageNumber)) {
                    htmlElement1 = element;
                }
                if (htmlElement1 == null) {
                    continue;
                }

                while (htmlElement1.FirstChild != null && htmlElement1.FirstChild.InnerText != null && htmlElement1.FirstChild.InnerText.Trim() == nextString) {
                    htmlElement1 = htmlElement1.FirstChild;
                }
                var flag3 = true;
                while (flag3) {
                    flag3 = false;
                    foreach (HtmlElement htmlElement2 in htmlElement1.Children) {
                        if (htmlElement2.InnerText == null || htmlElement2.InnerText.Trim() != nextString) {
                            continue;
                        }

                        htmlElement1 = htmlElement2;
                        flag3 = true;
                        break;
                    }
                }
                break;
            }
            return htmlElement1;
        }

        public static int Compare(string xpath1, string xpath2) {
            var num1 = 0;
            var index1 = 0;
            var strArray1 = xpath1.Split(new[]
            {
                '[',
                ']',
                '\\'
            });
            var strArray2 = xpath2.Split(new[]
            {
                '[',
                ']',
                '\\'
            });
            var num2 = strArray1.Length < strArray2.Length ? strArray1.Length : strArray2.Length;
            while (index1 < num2 - 1) {
                var index2 = index1;
                var num3 = 1;
                var index3 = index2 + num3;
                var num4 = int.Parse(strArray1[index3]);
                var strArray4 = strArray2;
                var index4 = index3;
                var num5 = 1;
                var num6 = index4 + num5;
                var num7 = int.Parse(strArray4[index4]);
                index1 = num6 + 1 + 1 + 1;
                if (num4 < num7) {
                    num1 = -1;
                    break;
                }
                if (num4 <= num7) {
                    continue;
                }

                num1 = 1;
                break;
            }

            return num1;
        }

        public static string AdjustXPath(string refXPath, string xpath) {
            string str1 = null;
            var index1 = -1;
            var num1 = refXPath.Length < xpath.Length ? refXPath.Length : xpath.Length;
            for (var index2 = 0; index2 < num1; ++index2) {
                if (refXPath[index2] != xpath[index2]) {
                    index1 = index2;
                    break;
                }
            }
            if (index1 == -1 || !char.IsDigit(xpath[index1])) {
                return null;
            }

            if (char.IsDigit(xpath[index1 - 1]))
                --index1;
            var num2 = refXPath.IndexOf(']', index1);
            if (num2 == -1) {
                return null;
            }

            var str2 = refXPath.Substring(index1, num2 - index1);
            var startIndex = xpath.IndexOf(']', index1);
            if (startIndex != -1)
                str1 = xpath.Substring(0, index1) + str2 + xpath.Substring(startIndex);
            return str1;
        }

        public static void PerformClicks(HtmlElement element, bool isPattern) {
            if (isPattern)
                ResetState();
            while (!(element == null)) {
                var htmlElement = element;
                if (isPattern)
                    element = GetNextElement(element);
                htmlElement.InvokeMember("click");
                if (isPattern) {
                    var now = DateTime.Now;
                    while ((DateTime.Now - now).Milliseconds < 200)
                        Application.DoEvents();
                }
                if (!isPattern)
                    break;
            }
        }

        private static bool IsUrlValid(string url) {
            var flag = true;
            using (var myClient = new HeadRequestWebClient()) {
                myClient.HeadOnly = true;
                try {
                    myClient.DownloadString(url);
                } catch (Exception) {
                    flag = false;
                }
            }
            return flag;
        }

        public static string GetAbsoluteUrl(Uri uri, string url) {
            var str = url;
            try {
                if (!url.ToLower().StartsWith("http")) {
                    var url1 = url.Insert(0, "http://");
                    if (!IsUrlValid(url1)) {
                        if (!url.StartsWith("/"))
                            url = url.Insert(0, "/");
                        str = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, url);
                    } else
                        str = url1;
                }
            } catch (Exception) {
                str = url;
            }
            return str;
        }

        public static bool IsFileImage(string fileName) {
            var flag = false;
            if (fileName.EndsWith(".jpg") || fileName.EndsWith(".png") || (fileName.EndsWith(".gif") || fileName.EndsWith(".tif")) || (fileName.EndsWith(".tiff") || fileName.EndsWith(".bmp") || fileName.EndsWith(".jpeg")))
                flag = true;
            else if (GetImageExtension(fileName) != "")
                flag = true;
            return flag;
        }

        public static string GetImageExtension(string imageUrl) {
            var extension = "";
            try {
                using (var response = WebRequest.Create(imageUrl).GetResponse()) {
                    using (response.GetResponseStream()) {
                        switch (response.ContentType.ToLower()) {
                            case "image/jpeg":
                            case "image/jpg":
                                extension = ".jpg";
                                break;
                            case "image/png":
                                extension = ".png";
                                break;
                            case "image/bmp":
                                extension = ".bmp";
                                break;
                            case "image/tiff":
                            case "image/tif":
                                extension = ".tif";
                                break;
                            case "image/gif":
                                extension = ".gif";
                                break;
                        }
                    }
                }
            } catch (Exception) {
                extension = "";
            }

            return extension;
        }

    }
}
