using Newtonsoft.Json.Linq;

namespace MorozovSoftware.GameSystem
{
    public interface IData
    {
        object GetData();
        void SetData(JObject data);
    }
}
