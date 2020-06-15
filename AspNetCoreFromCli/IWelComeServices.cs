namespace AspNetCoreFromCli
{
    public interface IWelComeServices
    {
        string GetMessage();
    }

    public class WelComeServices:IWelComeServices
    {
        public string GetMessage()
        {
            return "from WelComeServices";
        }
    }

}