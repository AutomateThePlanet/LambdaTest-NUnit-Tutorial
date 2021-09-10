namespace NUnitPageObjects.Version3
{
    public partial class ToDoPage : WebPage
    {
        public void AssertLeftItems(int expectedCount)
        {
            if (expectedCount <= 0)
            {
                ValidateInnerTextIs(ResultSpan, $"{expectedCount} item left");
            }
            else
            {
                ValidateInnerTextIs(ResultSpan, $"{expectedCount} items left");
            }
        }      
    }
}
