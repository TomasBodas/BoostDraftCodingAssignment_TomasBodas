using SimpleXMLValidatorLibrary;

class Program
{
    //you can use here to test, feel free to modify/add the test cases here.
    //you can also use other ways to test if you want
    static void Main(string[] args)
    {
        List<(string testCase, bool expectedResult)> testCases = new()
        {
            ("<Design><Code>hello world</Code></Design>",  true),//normal case
            ("<Design><Code>hello world</Code></Design><People>", false),//no closing tag for "People" 
            ("<People><Design><Code>hello world</People></Code></Design>", false),// "/Code" should come before "/People" 
            ("<People age=”1”>hello world</People>", false),//there is no closing tag for "People age=”1”" and no opening tag for "/People"
        };
        for (int i = 0; i < testCases.Count; i++)
        {
            (string testCase, bool expectedResult) = testCases[i];
            bool isValid = SimpleXmlValidator.DetermineXml(testCase);
            Console.WriteLine($"Is a valid XML string? {isValid}, Expected result = {expectedResult}");
        }
    }
}