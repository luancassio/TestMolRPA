using Boots.BasePage;
using Exceptions;
using OpenQA.Selenium;

namespace Boots.BootMol
{
    public class Boot : Base
    {
        private By btnAdd = By.Id("add_btn");
        private By inputRow = By.XPath("//*[@id=\"row2\"]/input");
        private By btnSave = By.Name("Save");
        private By inputRowDisabled = By.XPath("//*[@id=\"row1\"]/input");
        private By btnEdit = By.XPath("//*[@id=\"edit_btn\"]");

        public Boot(string url)
        {
            PageUrl(url);
        }
        public async void TestCase1()
        {
            try
            {
                AddRow();
                //driver.Quit();
            }
            catch (NoSuchElementException ex)
            {
                throw new ExceptionCustom("Elemento não encontrado.", ex);
            }
        }
        public async void TestCase2()
        {
            var text = "Novo Texto";
            AddRow();
            try
            {
                var element = ElementIsVisible(inputRow);
                element.SendKeys(text);
                FindFirstElementEnable(btnSave).Click();
                var textSave = element.GetAttribute("value");
                //driver.Quit();
            }
            catch (ElementNotInteractableException ex)
            {
                throw new ExceptionCustom("Não Foi possivel interagir com Elemento.", ex);
            }
        }
        public async void TestCase3()
        {
            var text = "Novo Texto";
            try
            {
                CleanAndCheckAddedText(text, "value");
                //driver.Quit();
            }
            catch (InvalidElementStateException ex)
            {
                throw new ExceptionCustom("Elemento está iválido ou desabilitado.", ex);
            }
        }
        private void CleanAndCheckAddedText(string text, string attribute)
        {
            ClickBy(btnEdit);
            var element = FindByElement(inputRowDisabled);
            element.Click();
            element.Clear();
            element.SendKeys(text);
            var textSave = element.GetAttribute(attribute);
        }

        private void AddRow()
        {
            ClickBy(btnAdd);
            var element = AwaitElementAfterClick(inputRow);
            element.Click();
        }

    }
}
