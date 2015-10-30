namespace Procent.dotnetconf2015.MyApp
{
    public interface ICommunicateWithExternalService
    {
        string GetData();
    }

    public class ExternalServiceCommunication : ICommunicateWithExternalService
    {
        public string GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}