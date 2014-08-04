namespace Phonebook
{
    using System;

    public class ConsolePrinterVisitorWithNewLine : IPrinterVisitor
    {
        public void Visit(string currentText)
        {
            Console.WriteLine(currentText);
        }
    }
}
