namespace Phonebook
{
    public interface IPrinter
    {
        void Print(string text);

        void Accept(IPrinterVisitor visitor);
    }
}
