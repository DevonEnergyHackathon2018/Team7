namespace Griedy.Lib.DataAccess.External
{
    public interface IOnPremisesGatewayDataAccess
    {
        T Get<T>(string url);
    }
}
