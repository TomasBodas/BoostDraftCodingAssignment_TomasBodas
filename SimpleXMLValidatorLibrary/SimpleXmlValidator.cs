namespace SimpleXMLValidatorLibrary
{
    public class SimpleXmlValidator
    {
        public static bool DetermineXml(string xml)
        {
            Stack<string> tagStack = new Stack<string>();

            int index = 0;
            while (index < xml.Length)
            {
                //Find the next opening tag
                int startTagStartIndex = xml.IndexOf('<', index);
                if (startTagStartIndex == -1)
                {
                    break; //No more opening tags found, exit loop
                }

                int startTagEndIndex = xml.IndexOf('>', startTagStartIndex);
                if (startTagEndIndex == -1)
                {
                    return false; //Opening tag not properly formed
                }

                string startTag = xml.Substring(startTagStartIndex + 1, startTagEndIndex - startTagStartIndex - 1);
                index = startTagEndIndex + 1;

                //Check if it's a closing tag
                if (startTag.StartsWith("/"))
                {
                    if (tagStack.Count == 0 || startTag.Substring(1) != tagStack.Pop())
                    {
                        return false; //Closing tag does not match last opening tag
                    }
                }
                else
                {
                    //It's an opening tag, push it onto the stack
                    tagStack.Push(startTag);

                    //Find the corresponding closing tag
                    string endTag = $"</{startTag}>";
                    int endTagIndex = xml.IndexOf(endTag, index);
                    if (endTagIndex == -1)
                    {
                        return false; //No corresponding closing tag found
                    }
                    index = endTagIndex + endTag.Length;
                }
            }

            //If all checks out return true
            return true;
        }
    }
}
