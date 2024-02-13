# XML Validator project for BoostDraft

Given a XML string and write a function to return true if the string is a valid XML string; otherwise return false. A string is a valid XML string if it satisfies the following two rules:

- Each starting element must have a corresponding ending element
- Nesting of elements within each other must be well nested, which means start first must end last. For example, <tutorial><topic>XML</topic></tutorial> is a correct way of nesting but <tutorial><topic>XML</tutorial></topic> is not

To simplify the question, we treat a pair of a opening tag and a closing tag as matched only if the strings in both tags are identical. So we don’t need to parse extra components like attributes in the XML tag. For example, we treat`<tutorial date="01/01/2000">XML</tutorial>` as not correctly closed since the string **tutorial date=”01/01/2000”** in the opening tag is different from the string **tutorial** in the closing tag

Please write a function to determine whether or not a string is a valid XML string.

Note that any class in `System.XML` and `Regular Expression` are **prohibited** in this question.

Your code should include the entrypoint like `static bool DetermineXml(string xml)` or `bool DetermineXml(string xml)`
