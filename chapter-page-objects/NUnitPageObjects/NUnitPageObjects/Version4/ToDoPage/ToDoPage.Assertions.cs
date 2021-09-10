namespace NUnitPageObjects.Version4
{
    public partial class ToDoPage : WebPage
    {
        public ToDoPage AssertLeftItems(int expectedCount)
        {
            if (expectedCount <= 0)
            {
                ValidateInnerTextIs(ResultSpan, $"{expectedCount} item left");
            }
            else
            {
                ValidateInnerTextIs(ResultSpan, $"{expectedCount} items left");
            }

            return this;
        }      
    }
}
