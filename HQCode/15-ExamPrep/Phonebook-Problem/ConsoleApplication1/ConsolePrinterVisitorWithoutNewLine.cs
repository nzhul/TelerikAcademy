namespace Phonebook
{
    using System;

    public class ConsolePrinterVisitorWithoutNewLine : IPrinterVisitor
    {
        public void Visit(string currentText)
        {
            Console.Write(currentText);
        }
    }
}
