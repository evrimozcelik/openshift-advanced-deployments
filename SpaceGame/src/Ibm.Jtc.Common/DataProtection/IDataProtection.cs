namespace Ibm.Jtc.Common
{
    public interface IDataProtection
    {
        string Protect(string input);

        string Unprotect(string input);
    }
}
