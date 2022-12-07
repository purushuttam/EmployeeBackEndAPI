namespace EmployeeBackendAPI.Model.Comman
{
    public class KeyGen
    {
        public static string GetKey()
        {
            return DateTime.UtcNow.ToString("yyMMddHHmmssfffffff");
        }
    }
}
